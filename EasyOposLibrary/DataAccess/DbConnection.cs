using Microsoft.Extensions.Configuration;

namespace EasyOposLibrary.DataAccess
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private string _connectionId = "MongoDB";

        public string DbName { get; private set; }
        public string UserCollectionName { get; private set; } = "users";
        public string UnitCollectionName { get; private set; } = "units";
        public string BlockCollectionName { get; private set; } = "blocks";
        public string QuestionCollectionName { get; private set; } = "questions";
        public string OptionCollectionName { get; private set; } = "options";
        public string ProgressCollectionName { get; private set; } = "progress";

        public MongoClient Client { get; private set; }
        public IMongoCollection<UserModel> UserCollection { get; private set; }
        public IMongoCollection<UnitModel> UnitCollection { get; private set; }
        public IMongoCollection<BlockModel> BlockCollection { get; private set; }
        public IMongoCollection<QuestionModel> QuestionCollection { get; private set; }
        public IMongoCollection<OptionModel> OptionCollection { get; private set; }
        public IMongoCollection<ProgressModel> ProgressCollection { get; private set; }

        public DbConnection(IConfiguration config)
        {
            _config = config;
            Client = new MongoClient(_config.GetConnectionString(_connectionId));
            DbName = _config["DatabaseName"];
            _db = Client.GetDatabase(DbName);

            UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
            UnitCollection = _db.GetCollection<UnitModel>(UnitCollectionName);
            BlockCollection = _db.GetCollection<BlockModel>(BlockCollectionName);
            QuestionCollection = _db.GetCollection<QuestionModel>(QuestionCollectionName);
            OptionCollection = _db.GetCollection<OptionModel>(OptionCollectionName);
            ProgressCollection = _db.GetCollection<ProgressModel>(ProgressCollectionName);
        }
    }
}
