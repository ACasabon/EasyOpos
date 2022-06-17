namespace EasyOposLibrary.DataAccess
{
    public interface IOptionData
    {
        Task CreateOption(OptionModel option);
        Task<List<OptionModel>> GetAllOptions(bool rewriteCache = false);
        Task<OptionModel> GetOption(string id);
        Task UpdateOption(OptionModel option);
    }
}