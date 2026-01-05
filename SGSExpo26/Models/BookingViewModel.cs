using System.Collections.Generic;

namespace SGSExpo26.Models
{
    public class BookingViewModel
    {
        public Booking Booking { get; set; } = new Booking();
        public List<Slot> Slots { get; set; } = new List<Slot>();
    }
}
