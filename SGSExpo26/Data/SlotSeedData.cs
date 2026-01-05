using System.Collections.Generic;
using SGSExpo26.Models;

namespace SGSExpo26.Data
{
    public static class SlotSeedData
    {
        public static List<Slot> DefaultSlots => new()
        {
            new Slot { SlotText = "10:00 AM - 11:00 AM", StartHour = 10, EndHour = 11, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "11:00 AM - 12:00 PM", StartHour = 11, EndHour = 12, MaxCapacity = 100,  CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "12:00 PM - 01:00 PM", StartHour = 12, EndHour = 13, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "01:00 PM - 02:00 PM", StartHour = 13, EndHour = 14, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "02:00 PM - 03:00 PM", StartHour = 14, EndHour = 15, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "03:00 PM - 04:00 PM", StartHour = 15, EndHour = 16, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "04:00 PM - 05:00 PM", StartHour = 16, EndHour = 17, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "05:00 PM - 06:00 PM", StartHour = 17, EndHour = 18, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "06:00 PM - 07:00 PM", StartHour = 18, EndHour = 19, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "07:00 PM - 08:00 PM", StartHour = 19, EndHour = 20, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },
            new Slot { SlotText = "08:00 PM - 09:00 PM", StartHour = 20, EndHour = 21, MaxCapacity = 100, CurrentCapacity = 0, IsActive = true },

        };
    }
}
