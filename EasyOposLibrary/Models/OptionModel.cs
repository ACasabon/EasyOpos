namespace EasyOposLibrary.Models
{
    public class OptionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Content { get; set; }
        public bool Veracity { get; set; } = false;
    }
}
