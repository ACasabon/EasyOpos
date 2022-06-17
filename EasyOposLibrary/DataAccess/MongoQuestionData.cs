using Microsoft.Extensions.Caching.Memory;

namespace EasyOposLibrary.DataAccess
{
    public class MongoQuestionData : IQuestionData
    {
        private readonly IMongoCollection<QuestionModel> _questions;
        private readonly IMemoryCache _cache;
        private const string CacheName = "QuestionData";

        public MongoQuestionData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _questions = db.QuestionCollection;
        }

        public async Task<List<QuestionModel>> GetAllQuestions(bool rewriteCache = false)
        {
            var output = rewriteCache ? null : _cache.Get<List<QuestionModel>>(CacheName);
            if (output is null)
            {
                var results = await _questions.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }

        public async Task<List<QuestionModel>> GetBlockQuestions(BlockModel block)
        {
            var results = await _questions.FindAsync(q => q.Block.Id == block.Id);
            return results.ToList();
        }

        public async Task<List<QuestionModel>> GetBlockQuestions(string blockId)
        {
            var results = await _questions.FindAsync(q => q.Block.Id == blockId);
            return results.ToList();
        }

        public async Task<QuestionModel> GetQuestion(string id)
        {
            var results = await _questions.FindAsync(q => q.Id == id);
            return results.FirstOrDefault();
        }

        public Task CreateQuestion(QuestionModel question)
        {
            return _questions.InsertOneAsync(question);
        }

        public async Task UpdateQuestion(QuestionModel question)
        {
            await _questions.ReplaceOneAsync(q => q.Id == question.Id, question);
            _cache.Remove(CacheName);   //Destroy the cache because you just changed the Suggestions List
        }
    }
}
