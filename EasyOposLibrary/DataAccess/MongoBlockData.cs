using Microsoft.Extensions.Caching.Memory;

namespace EasyOposLibrary.DataAccess
{
    public class MongoBlockData : IBlockData
    {
        private readonly IMongoCollection<BlockModel> _blocks;
        private readonly IMemoryCache _cache;
        private const string CacheName = "BlockData";

        public MongoBlockData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _blocks = db.BlockCollection;
        }

        public async Task<List<BlockModel>> GetAllBlocks(bool rewriteCache = false)
        {
            var output = rewriteCache ? null : _cache.Get<List<BlockModel>>(CacheName);
            if (output is null)
            {
                var results = await _blocks.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }

        public async Task<List<BlockModel>> GetUnitBlocks(UnitModel unit)
        {
            var results = await _blocks.FindAsync(b => b.Unit.Id == unit.Id);
            return results.ToList();
        }

        public async Task<List<BlockModel>> GetUnitBlocks(string unitId)
        {
            var results = await _blocks.FindAsync(b => b.Unit.Id == unitId);
            return results.ToList();
        }

        public async Task<BlockModel> GetBlock(string id)
        {
            var results = await _blocks.FindAsync(b => b.Id == id);
            return results.FirstOrDefault();
        }

        public Task CreateBlock(BlockModel block)
        {
            return _blocks.InsertOneAsync(block);
        }

        public async Task UpdateBlock(BlockModel block)
        {
            await _blocks.ReplaceOneAsync(b => b.Id == block.Id, block);
            _cache.Remove(CacheName);   //Destroy the cache because you just changed the Suggestions List
        }
    }
}
