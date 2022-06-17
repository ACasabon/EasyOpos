namespace EasyOposLibrary.Models
{
    public class ProgressModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Dictionary<QuestionModel, int> Questions { get; set; } = new();
        public UserModel Owner { get; set; }
    }
}
