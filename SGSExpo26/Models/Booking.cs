using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SGSExpo26.Models
{
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[0-9]{10}$")]
        [BsonElement("mobile")]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        [BsonElement("persons")]
        public int Persons { get; set; }

        // 🔗 Relation
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("slotId")]
        public string SlotId { get; set; } = string.Empty;

        // 👇 NEW (for display & history safety)
        [BsonElement("slotText")]
        public string SlotText { get; set; } = string.Empty;

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
