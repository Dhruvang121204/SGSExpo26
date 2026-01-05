using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SGSExpo26.Models
{
    public class OtpEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Mobile { get; set; }
        public string Otp { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsVerified { get; set; } = false;
    }
}
