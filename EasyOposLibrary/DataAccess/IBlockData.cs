namespace EasyOposLibrary.DataAccess
{
    public interface IBlockData
    {
        Task CreateBlock(BlockModel unit);
        Task<List<BlockModel>> GetAllBlocks(bool rewriteCache = false);
        Task<BlockModel> GetBlock(string id);
        Task<List<BlockModel>> GetUnitBlocks(UnitModel unit);
        Task<List<BlockModel>> GetUnitBlocks(string unitId);
        Task UpdateBlock(BlockModel unit);
    }
}