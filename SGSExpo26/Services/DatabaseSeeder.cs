using MongoDB.Driver;
using SGSExpo26.Models;
using SGSExpo26.Data;
using System.Linq;

namespace SGSExpo26.Services
{
    public class DatabaseSeeder
    {
        private readonly IMongoCollection<Slot> _slots;

        public DatabaseSeeder(MongoDbContext context)
        {
            _slots = context.GetCollection<Slot>("slots");
        }

        public void SeedSlots()
        {
            var existingSlots = _slots.Find(_ => true).ToList();

            foreach (var defaultSlot in SlotSeedData.DefaultSlots)
            {
                bool exists = existingSlots.Any(s =>
                    s.SlotText == defaultSlot.SlotText
                );

                if (!exists)
                {
                    _slots.InsertOne(defaultSlot);
                }
            }
        }
    }
}
