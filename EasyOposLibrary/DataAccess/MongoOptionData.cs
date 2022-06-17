using Microsoft.Extensions.Caching.Memory;

namespace EasyOposLibrary.DataAccess
{
    public class MongoOptionData : IOptionData
    {
        private readonly IMongoCollection<OptionModel> _options;
        private readonly IMemoryCache _cache;
        private const string CacheName = "OptionData";

        public MongoOptionData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _options = db.OptionCollection;
        }

        public async Task<List<OptionModel>> GetAllOptions(bool rewriteCache = false)
        {
            var output = rewriteCache ? null : _cache.Get<List<OptionModel>>(CacheName);
            if (output is null)
            {
                var results = await _options.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }

        public async Task<OptionModel> GetOption(string id)
        {
            var results = await _options.FindAsync(o => o.Id == id);
            return results.FirstOrDefault();
        }

        public Task CreateOption(OptionModel option)
        {
            return _options.InsertOneAsync(option);
        }

        public async Task UpdateOption(OptionModel option)
        {
            await _options.ReplaceOneAsync(o => o.Id == option.Id, option);
            _cache.Remove(CacheName);   //Destroy the cache because you just changed the Suggestions List
        }
    }
}
