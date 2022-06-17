namespace EasyOposLibrary.DataAccess
{
    public interface IDbConnection
    {
        IMongoCollection<BlockModel> BlockCollection { get; }
        string BlockCollectionName { get; }
        MongoClient Client { get; }
        string DbName { get; }
        IMongoCollection<QuestionModel> QuestionCollection { get; }
        string QuestionCollectionName { get; }
        IMongoCollection<OptionModel> OptionCollection { get; }
        string OptionCollectionName { get; }
        IMongoCollection<UnitModel> UnitCollection { get; }
        string UnitCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionName { get; }
        IMongoCollection<ProgressModel> ProgressCollection { get; }
        string ProgressCollectionName { get; }
    }
}