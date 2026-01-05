using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SGSExpo26.Models
{
    public class Slot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string SlotText { get; set; }

        public int StartHour { get; set; }
        public int EndHour { get; set; }

        public int MaxCapacity { get; set; }

        // ✅ MUST EXIST to avoid errors
        public int CurrentCapacity { get; set; } = 0;

        public bool IsActive { get; set; } = true;
    }
}
