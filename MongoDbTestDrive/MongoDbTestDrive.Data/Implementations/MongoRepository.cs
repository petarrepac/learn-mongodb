using MongoDB.Driver;

namespace MongoDbTestDrive.Data.Implementations
{
    public abstract class MongoRepository
    {
        protected MongoClient Client { get; private set; }
        protected MongoServer Server { get; private set; }
        protected MongoDatabase Database { get; private set; }

        protected MongoRepository()
        {
            Client = new MongoClient();
            Server = Client.GetServer();
            Database = Server.GetDatabase("MongoDbTestDrive");
        }

    }
}
