namespace EasyOposLibrary.Models
{
    public class UnitModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public int BlockCount { get; set; }
    }
}
