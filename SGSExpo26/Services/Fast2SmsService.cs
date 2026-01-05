using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SGSExpo26.Services
{
    public class Fast2SmsService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;
        private readonly string _senderId;
        private readonly string _otpTemplateId;
        private readonly string _confirmTemplateId;

        public Fast2SmsService(IConfiguration config)
        {
            _http = new HttpClient();

            // These will be used ONLY after DLT approval
            _apiKey = config["Fast2SMS:ApiKey"];
            _senderId = config["Fast2SMS:SenderId"];
            _otpTemplateId = config["Fast2SMS:OtpTemplateId"];
            _confirmTemplateId = config["Fast2SMS:ConfirmTemplateId"];
        }

        // =========================================================
        // 🔹 SEND OTP
        // =========================================================
        public async Task SendOtpAsync(string mobile, string otp)
        {
            // =========================
            // ✅ CURRENT TEST MODE
            // =========================
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===== OTP SMS (TEST MODE) =====");
            Console.WriteLine($"Mobile: {mobile}");
            Console.WriteLine($"OTP: {otp}");
            Console.WriteLine("================================");
            Console.ResetColor();

            await Task.CompletedTask;

            /*
            // =========================
            // 🚀 ENABLE AFTER DLT APPROVAL
            // =========================

            var payload = new
            {
                route = "otp",
                sender_id = _senderId,
                template_id = _otpTemplateId,
                variables_values = otp,
                numbers = mobile
            };

            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://www.fast2sms.com/dev/bulkV2");

            request.Headers.Add("authorization", _apiKey);

            request.Content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            await _http.SendAsync(request);
            */
        }

        // =========================================================
        // 🔹 SEND CONFIRMATION SMS
        // =========================================================
        public async Task SendConfirmationAsync(
            string mobile,
            string name,
            string slot,
            int persons)
        {
            // =========================
            // ✅ CURRENT TEST MODE
            // =========================
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===== CONFIRMATION SMS (TEST MODE) =====");
            Console.WriteLine($"Mobile: {mobile}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Slot: {slot}");
            Console.WriteLine($"Persons: {persons}");
            Console.WriteLine("========================================");
            Console.ResetColor();

            await Task.CompletedTask;

            /*
            // =========================
            // 🚀 ENABLE AFTER DLT APPROVAL
            // =========================

            var message = $"Dear {name}, your visit is confirmed for {slot}. " +
                          $"Visitors: {persons}. – SGS Jainism Park Expo 26";

            var payload = new
            {
                route = "q",
                sender_id = _senderId,
                message = message,
                numbers = mobile
            };

            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://www.fast2sms.com/dev/bulkV2");

            request.Headers.Add("authorization", _apiKey);

            request.Content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            await _http.SendAsync(request);
            */
        }
    }
}
