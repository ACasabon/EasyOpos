namespace EasyOposLibrary.DataAccess
{
    public interface IQuestionData
    {
        Task CreateQuestion(QuestionModel question);
        Task<List<QuestionModel>> GetAllQuestions(bool rewriteCache = false);
        Task<List<QuestionModel>> GetBlockQuestions(string blockId);
        Task<List<QuestionModel>> GetBlockQuestions(BlockModel block);
        Task<QuestionModel> GetQuestion(string id);
        Task UpdateQuestion(QuestionModel question);
    }
}