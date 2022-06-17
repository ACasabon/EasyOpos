using Microsoft.Extensions.Caching.Memory;

namespace EasyOposLibrary.DataAccess
{
    public class MongoProgressData
    {
        private readonly IMongoCollection<ProgressModel> _progress;
        private readonly IMemoryCache _cache;
        private const string CacheName = "ProgressData";

        public MongoProgressData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _progress = db.ProgressCollection;
        }

        public async Task<ProgressModel> GetProgress(string id)
        {
            var results = await _progress.FindAsync(u => u.Id == id);
            return results.FirstOrDefault();
        }

        public async Task<ProgressModel> GetUserProgress(UserModel owner)
        {
            var results = await _progress.FindAsync(u => u.Owner == owner);
            return results.FirstOrDefault();
        }

        public async Task<ProgressModel> GetUserProgress(string ownerId)
        {
            var results = await _progress.FindAsync(u => u.Owner.Id == ownerId);
            return results.FirstOrDefault();
        }

        public Task CreateProgress(ProgressModel progress)
        {
            return _progress.InsertOneAsync(progress);
        }

        public async Task UpdateProgress(ProgressModel progress)
        {
            await _progress.ReplaceOneAsync(p => p.Id == progress.Id, progress);
            _cache.Remove(CacheName);   //Destroy the cache because you just changed the Suggestions List
        }
    }
}
