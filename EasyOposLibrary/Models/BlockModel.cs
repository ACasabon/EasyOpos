namespace EasyOposLibrary.Models
{
    public class BlockModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public int QuestionCount { get; set; }
        public UnitModel Unit { get; set; }
    }
}
