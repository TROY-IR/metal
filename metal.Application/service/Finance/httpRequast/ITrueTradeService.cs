using metal.Application.service.AiSearch.n8n;
using metal.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

namespace metal.Application.service.Finance.httpRequast
{
    public interface ITrueTradeService
    {
        Task<ResultDto<List<TTTDto>>> GetAssetsAsync(
            CancellationToken cancellationToken = default
        );
    }

    public class TrueTradeService : ITrueTradeService
    {
        private readonly HttpClient _httpClient;

        public TrueTradeService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultDto<List<TTTDto>>> GetAssetsAsync(
            CancellationToken cancellationToken = default)
        {
  //          TrueTradeOptions t = new TrueTradeOptions();
            // 1. Generate timestamp
            string timestamp = DateTimeOffset.UtcNow
                .ToUnixTimeMilliseconds()
                .ToString();

            // 2. API endpoint
            const string method = "GET";
            const string path = "/accounting/assets";

            // 3. Generate signature
            string signature = GenerateSignature(
                timestamp,
                method,
                path
            );

            // 4. Create request
            using var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://apiv2.thetruetrade.io/accounting/assets"
            );

            request.Headers.Add("X-API-Key", "SYAYNR_4YL0tH2SaccfeDnShtHbE-90cVRhdvtoT");
            request.Headers.Add("X-Timestamp", timestamp);
            request.Headers.Add("X-Signature", signature);

            // 5. Send request
            using var response = await _httpClient.SendAsync(
                request,
                cancellationToken
            );

            // 6. Read response
            string responseContent = await response.Content
                .ReadAsStringAsync(cancellationToken);

            var resbody = await response.Content.ReadFromJsonAsync<List<TTTDto>>(
    cancellationToken: cancellationToken
    );
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"TrueTrade API Error: {(int)response.StatusCode} - {responseContent}",
                    null,
                    response.StatusCode
                );
            }

            return new ResultDto<List<TTTDto>>{
                Data = resbody,
                IsSuccess = true
            }
            ;
        }

        private string GenerateSignature(
            string timestamp,
            string method,
            string path)
        {

            // IMPORTANT:
            // This payload format is an assumption based on your JS code.
            string payload = $"{timestamp}{method}{path}";

            byte[] secretBytes = Encoding.UTF8.GetBytes(
                "5576036b8e4b801093f679eb6d94f34f7264999177ff23b49a662c1ad61ecf4b"
            );

            byte[] payloadBytes = Encoding.UTF8.GetBytes(
                payload
            );

            byte[] hash = HMACSHA256.HashData(
                secretBytes,
                payloadBytes
            );

            return Convert.ToHexString(hash).ToLowerInvariant();
        }
    }

    public class TrueTradeOptions
    {
        public string BaseUrl { get; set; } = "https://apiv2.thetruetrade.io";
        public string ApiKey { get; set; } = "SYAYNR_4YL0tH2SaccfeDnShtHbE-90cVRhdvtoT";
        public string Secret { get; set; } = "5576036b8e4b801093f679eb6d94f34f7264999177ff23b49a662c1ad61ecf4b";
    }
    public class TTTDto
    {
        public string asset { get; set; }
        public string accountType { get; set; }
        public string assetType { get; set; }
        public string balance { get; set; }
        public string lockedBalance { get; set; }
    }
  
}
