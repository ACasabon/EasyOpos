namespace EasyOposLibrary.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ObjectIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string EmailAdress { get; set; }
        public DateTime EndSubscription { get; set; } = DateTime.MinValue;
        public List<QuestionModel> FavoriteQuestions { get; set; } = new();
    }
}
