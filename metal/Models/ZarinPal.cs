    using System.Text.Json.Serialization;

namespace metal.Models
{
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
