using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SGSExpo26.Models;
using SGSExpo26.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SGSExpo26.Controllers
{
    public class BookingController : Controller
    {
        private readonly IMongoCollection<Slot> _slots;
        private readonly IMongoCollection<Booking> _bookings;
        private readonly DatabaseSeeder _seeder;

        private readonly Fast2SmsService _sms;
        private readonly WhatsAppService _whatsapp;

        public BookingController(
            MongoDbContext context,
            DatabaseSeeder seeder,
            Fast2SmsService sms,
            WhatsAppService whatsapp
        )
        {
            _slots = context.GetCollection<Slot>("slots");
            _bookings = context.GetCollection<Booking>("bookings");
            _seeder = seeder;
            _sms = sms;
            _whatsapp = whatsapp;
        }

        // 🔁 Sync slots with bookings
        private void RecalculateSlotCapacities()
        {
            var allSlots = _slots.Find(_ => true).ToList();
            var allBookings = _bookings.Find(_ => true).ToList();

            foreach (var slot in allSlots)
            {
                int used = allBookings
                    .Where(b => b.SlotId == slot.Id)
                    .Sum(b => b.Persons);

                if (slot.CurrentCapacity != used)
                {
                    slot.CurrentCapacity = used;
                    _slots.ReplaceOne(s => s.Id == slot.Id, slot);
                }
            }
        }

        // 🔹 GET
        public IActionResult Index()
        {
            // ✅ Ensure slots exist
            _seeder.SeedSlots();

            // ✅ Sync capacity
            RecalculateSlotCapacities();

            var vm = new BookingViewModel
            {
                Booking = new Booking(),
                Slots = _slots
                    .Find(s => s.IsActive)
                    .SortBy(s => s.StartHour)
                    .ToList()
            };

            return View(vm);
        }

        // 🔹 POST
        [HttpPost]
        public async Task<IActionResult> Index(BookingViewModel vm)
        {
            if (vm?.Booking == null)
                return RedirectToAction("Index");

            RecalculateSlotCapacities();

            var slot = _slots.Find(s => s.Id == vm.Booking.SlotId).FirstOrDefault();
            if (slot == null)
            {
                ModelState.AddModelError("", "Invalid slot selected.");
                vm.Slots = _slots.Find(_ => true).ToList();
                return View(vm);
            }

            int remaining = slot.MaxCapacity - slot.CurrentCapacity;
            if (vm.Booking.Persons > remaining)
            {
                ModelState.AddModelError("", $"Only {remaining} seats available.");
                vm.Slots = _slots.Find(_ => true).ToList();
                return View(vm);
            }

            vm.Booking.SlotText = slot.SlotText;
            vm.Booking.CreatedAt = DateTime.UtcNow;

            _bookings.InsertOne(vm.Booking);

            slot.CurrentCapacity += vm.Booking.Persons;
            _slots.ReplaceOne(s => s.Id == slot.Id, slot);

            await _sms.SendConfirmationAsync(
                vm.Booking.Mobile,
                vm.Booking.Name,
                vm.Booking.SlotText,
                vm.Booking.Persons
            );

            await _whatsapp.SendConfirmationAsync(
                vm.Booking.Mobile,
                vm.Booking.Name,
                vm.Booking.SlotText,
                vm.Booking.Persons
            );

            return View("Success", vm.Booking);
        }
    }
}
