namespace EasyOposLibrary.Models
{
    public class QuestionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Question { get; set; }
        public List<OptionModel> Options { get; set; } = new();
        public BlockModel Block { get; set; }
    }
}
