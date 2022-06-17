namespace EasyOposLibrary.DataAccess
{
    public interface IUnitData
    {
        Task CreateUnit(UnitModel unit);
        Task<List<UnitModel>> GetAllUnits(bool rewriteCache = false);
        Task<UnitModel> GetUnit(string id);
        Task UpdateUnit(UnitModel unit);
    }
}