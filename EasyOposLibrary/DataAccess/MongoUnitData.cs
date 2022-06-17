using Microsoft.Extensions.Caching.Memory;

namespace EasyOposLibrary.DataAccess
{
    public class MongoUnitData : IUnitData
    {
        private readonly IMongoCollection<UnitModel> _units;
        private readonly IMemoryCache _cache;
        private const string CacheName = "UnitData";

        public MongoUnitData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _units = db.UnitCollection;
        }

        public async Task<List<UnitModel>> GetAllUnits(bool rewriteCache = false)
        {
            var output = rewriteCache ? null : _cache.Get<List<UnitModel>>(CacheName);
            if (output is null)
            {
                var results = await _units.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }

        public async Task<UnitModel> GetUnit(string id)
        {
            var results = await _units.FindAsync(u => u.Id == id);
            return results.FirstOrDefault();
        }

        public Task CreateUnit(UnitModel unit)
        {
            return _units.InsertOneAsync(unit);
        }

        public async Task UpdateUnit(UnitModel unit)
        {
            await _units.ReplaceOneAsync(u => u.Id == unit.Id, unit);
            _cache.Remove(CacheName);   //Destroy the cache because you just changed the Suggestions List
        }
    }
}
