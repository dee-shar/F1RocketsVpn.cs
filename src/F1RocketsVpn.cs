using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace F1RocketsVpnApi
{
    public class F1RocketsVpn
    {
        private readonly string deviceCode;
        private readonly HttpClient httpClient;
        private readonly string requestRole = "user";
        private readonly string timeZone = "Asia/Tokyo";
        private readonly string clientVersion = "1.1.119";
        private readonly string applicationCode = "f1rocket-googleplay-1";
        private readonly string apiUrl = "https://api.f1rockets.com/app";
        public F1RocketsVpn()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Dart/2.19 (dart:io)");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            deviceCode = GenerateDeviceCode(16);
            httpClient.DefaultRequestHeaders.Add("device-code", deviceCode);
            httpClient.DefaultRequestHeaders.Add("timezone", timeZone);
            httpClient.DefaultRequestHeaders.Add("client-version", clientVersion);
            httpClient.DefaultRequestHeaders.Add("app-code", applicationCode);
            httpClient.DefaultRequestHeaders.Add("req-role", requestRole);
        }

        private static string GenerateDeviceCode(int length)
        {
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            using var randomNumbers = RandomNumberGenerator.Create();
            var bytes = new byte[length];
            randomNumbers.GetBytes(bytes);
            return new string(bytes.Select(b => characters[b % characters.Length]).ToArray());
        }

        public async Task<string> CheckAppVersion()
        {
            var response = await httpClient.PostAsync($"{apiUrl}/version_check", null);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetBaseInfo()
        {
            var response = await httpClient.PostAsync($"{apiUrl}/base/get", null);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetServers()
        {
            var response = await httpClient.PostAsync($"{apiUrl}/node/list", null);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
