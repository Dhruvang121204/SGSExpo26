using System.Collections.Generic;
using SGSExpo26.Models;

namespace SGSExpo26.Data
{
    public static class SlotSeedData
    {
        public static List<Slot> DefaultSlots => new()
        {
            new Slot { SlotText = "10 to 11 AM", StartHour = 10, EndHour = 11, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "11 to 12 PM", StartHour = 11, EndHour = 12, MaxCapacity = 100,  CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "12 to 1 PM", StartHour = 12, EndHour = 13, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "1 to 2 PM", StartHour = 13, EndHour = 14, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "2 to 3 PM", StartHour = 14, EndHour = 15, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "3 to 4 PM", StartHour = 15, EndHour = 16, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "4 to 5 PM", StartHour = 16, EndHour = 17, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "5 to 6 PM", StartHour = 17, EndHour = 18, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "6 to 7 PM", StartHour = 18, EndHour = 19, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "7 to 8 PM", StartHour = 19, EndHour = 20, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "8 to 9 PM", StartHour = 20, EndHour = 21, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },

        };
    }
}
