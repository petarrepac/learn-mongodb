using MongoDB.Bson;

namespace MongoDbTestDrive.Domain
{
    public abstract class DocumentBase
    {
        protected DocumentBase()
        {
            Id = ObjectId.Empty;
        }

        public ObjectId Id { get; set; }

        // note: because uniqueness is only on collection there is small possiblity that 
        // 2 different entities have same hash code
        // maybe combine with type into
        public override int GetHashCode()
        {
            if (Equals(Id, ObjectId.Empty))
            {
                return base.GetHashCode();
            }
            return Id.GetHashCode();
        }

        public bool Equals(DocumentBase other)
        {
            // x.Equals(null) must always return false
            if (other == null)
                return false;

            // if two variables reference the same instance, they are equal
            if (ReferenceEquals(this, other))
                return true;

            // note: http://stackoverflow.com/questions/5303869/mongodb-are-mongoids-unique-across-collections
            // The uniqueness constraint for _id is per collection.

            // if types are not equal, the variables are not equal
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            // If it can't be cast, null is passed instead, then false is returned
            return Equals(obj as DocumentBase); 
        }

    }

}
