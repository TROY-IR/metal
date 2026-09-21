using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;


namespace metal.Application.service.Finance.httpRequast
{
    public interface IZarinPalService
    {
        Task<ZarinPalPaymentResponse?> RequestPaymentAsync(int amount, string description, string callbackUrl, string? mobile = null, string? email = null);
        Task<ZarinPalVerifyResponse?> VerifyPaymentAsync(int amount, string authority);
    }

    public class ZarinPalService : IZarinPalService
    {
        private readonly HttpClient _httpClient;
        private readonly string _merchantId;
        private readonly bool _isSandbox;

        // برای تست مرچنت سندباکس یا مرچنت تستی خودتان را قرار دهید
        private const string SandboxMerchantId = "00000000-0000-0000-0000-000000000000";

        public ZarinPalService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _isSandbox = true;
                //configuration.GetValue<bool>("ZarinPal:IsSandbox", true);
            _merchantId = _isSandbox
                ? SandboxMerchantId
                : SandboxMerchantId;
              //  : configuration.GetValue<string>("ZarinPal:MerchantId") ?? SandboxMerchantId;

            // آدرس پایه زرین‌پال v4
            _httpClient.BaseAddress = new Uri(_isSandbox
                ? "https://sandbox.zarinpal.com/pg/v4/payment/"
                : "https://payment.zarinpal.com/pg/v4/payment/");
        }

        public async Task<ZarinPalPaymentResponse?> RequestPaymentAsync(
            int amount,
            string description,
            string callbackUrl,
            string? mobile = null,
            string? email = null)
        {
            var payload = new ZarinPalPaymentRequest
            {
                MerchantId = _merchantId,
                Amount = amount,
                Currency = "IRT", // یا "IRR"
                Description = description,
                CallbackUrl = callbackUrl,
                Metadata = new ZarinPalMetadata
                {
                    Mobile = mobile,
                    Email = email
                }
            };

            var response = await _httpClient.PostAsJsonAsync("request.json", payload);
            if (!response.IsSuccessStatusCode)
            {
                // در صورت نیاز خطا را لاگ کنید
                var errorContent = await response.Content.ReadAsStringAsync();
            }

            return await response.Content.ReadFromJsonAsync<ZarinPalPaymentResponse>();
        }

        public async Task<ZarinPalVerifyResponse?> VerifyPaymentAsync(int amount, string authority)
        {
            var payload = new ZarinPalVerifyRequest
            {
                MerchantId = _merchantId,
                Amount = amount,
                Authority = authority
            };

            var response = await _httpClient.PostAsJsonAsync("verify.json", payload);
            return await response.Content.ReadFromJsonAsync<ZarinPalVerifyResponse>();
        }
    }

    // مدل ارسال درخواست پرداخت
    public class ZarinPalPaymentRequest
    {
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public int Amount { get; set; } // مبلغ به ریال یا تومان (معمولاً ریال یا تومان بر اساس تنظیمات مرچنت، در v4 پیش‌فرض ریال/تومان طبق واحد حساب شماست)

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "IRT"; // "IRT" برای تومان، "IRR" برای ریال

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; } = string.Empty;

        [JsonPropertyName("metadata")]
        public ZarinPalMetadata? Metadata { get; set; }
    }

    public class ZarinPalMetadata
    {
        [JsonPropertyName("mobile")]
        public string? Mobile { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }

    // مدل پاسخ دریافت Authority
    public class ZarinPalPaymentResponse
    {
        [JsonPropertyName("data")]
        public PaymentData? Data { get; set; }

        [JsonPropertyName("errors")]
        public object? Errors { get; set; }
    }

    public class PaymentData
    {
        [JsonPropertyName("code")]
        public int Code { get; set; } // 100 موفق

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("authority")]
        public string Authority { get; set; } = string.Empty;

        [JsonPropertyName("fee_type")]
        public string FeeType { get; set; } = string.Empty;

        [JsonPropertyName("fee")]
        public int Fee { get; set; }
    }

    // مدل ارسال درخواست Verify
    public class ZarinPalVerifyRequest
    {
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("authority")]
        public string Authority { get; set; } = string.Empty;
    }

    // مدل پاسخ Verify
    public class ZarinPalVerifyResponse
    {
        [JsonPropertyName("data")]
        public VerifyData? Data { get; set; }

        [JsonPropertyName("errors")]
        public object? Errors { get; set; }
    }

    public class VerifyData
    {
        [JsonPropertyName("code")]
        public int Code { get; set; } // 100: موفق، 101: تراکنش قبلاً تأیید شده

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("card_hash")]
        public string? CardHash { get; set; }

        [JsonPropertyName("card_pan")]
        public string? CardPan { get; set; }

        [JsonPropertyName("ref_id")]
        public long RefId { get; set; }

        [JsonPropertyName("fee_type")]
        public string? FeeType { get; set; }

        [JsonPropertyName("fee")]
        public int Fee { get; set; }
    }


}
