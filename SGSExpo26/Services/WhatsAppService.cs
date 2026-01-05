using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SGSExpo26.Services
{
    public class WhatsAppService
    {
        private readonly HttpClient _http;
        private readonly string _token;
        private readonly string _phoneNumberId;

        public WhatsAppService(IConfiguration config)
        {
            _http = new HttpClient();
            _token = config["WhatsApp:AccessToken"];
            _phoneNumberId = config["WhatsApp:PhoneNumberId"];
        }

        // 🔹 SEND OTP
        public async Task SendOtpAsync(string mobile, string otp)
        {
            var payload = new
            {
                messaging_product = "whatsapp",
                to = "91" + mobile,
                type = "text",
                text = new
                {
                    body = $"Your OTP for SGS Jainism Park Expo is {otp}. It is valid for 5 minutes."
                }
            };

            await SendAsync(payload);
        }

        // 🔹 SEND CONFIRMATION
        public async Task SendConfirmationAsync(string mobile, string name, string slot, int persons)
        {
            var payload = new
            {
                messaging_product = "whatsapp",
                to = "91" + mobile,
                type = "text",
                text = new
                {
                    body = $"🙏 Jai Jinendra {name}\n\nYour booking is CONFIRMED.\n\n🕒 Slot: {slot}\n👥 Persons: {persons}\n\nThank you for visiting SGS Jainism Park Expo 26."
                }
            };

            await SendAsync(payload);
        }

        private async Task SendAsync(object payload)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Post,
                $"https://graph.facebook.com/v18.0/{_phoneNumberId}/messages"
            );

            request.Headers.Add("Authorization", $"Bearer {_token}");
            request.Content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            await _http.SendAsync(request);
        }
    }
}
