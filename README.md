learn-mongodb
=============

Play with MongoDb

* installed MongoDb on Windows 8 64bit (needed to restart to get rid of some socket error)
* reading MongoDb in Action
* introduction chapter
* JavaScript shell - inserts, updates, queries, deletes
* Basic administration, how commands work
* used NUnit tests to check basic operations with MongoDb
* running test requires a running MongoDb server on local instance with default ports
* created domain model with Movies, ActorRoles and UserReviews (inspired by IMDB)
* created test data for The Matrix and Casablanca
* implemented DocumentBase class that forces Id property and implements GetHashCode and Equals logic
* implemented MongoRepository that is base repo and connects to database (maybe bad pattern to connect to db on every new repo creation)
* do we need repos with document dbs ? maybe for implementation of "constraints" and "triggers"
* implemented MovieRepository (FindAll, Insert, FindById, FindByTitle, Remove, RemoveAll)
* confirmed correctness of repository implementation with "unit" tests (they access db, so not really unit):
    * When_EntityInstanceIsCreated_Then_Id_Should_BeEmptyObjectId
    * When_RemoveAll_Then_FindAll_Should_ReturnZeroCount
    * When_Insert2_Then_FindAll_Should_Return2
    * When_Insert2_Then_Database_Should_ContainInsertedData
    * When_Insert3_Then_FindById_Should_ReturnRightDocument
    * When_Insert2_Then_FindWithQuery_Should_ReturnRightDocuments
    * When_RemoveDocument_Then_FindAll_Should_ReturnOneLessDocument
