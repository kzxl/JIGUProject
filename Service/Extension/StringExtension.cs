using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared.Services.Extension
{
    public static class StringExtension
    {
        public static bool IsNumber(this string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public static bool checkCOMExits(this string PortName)
        {
            try
            {
                if (SerialPort.GetPortNames().Any(x => x == PortName))
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
        }
        public static async Task<string> PostAsync(this string url, HttpClient httpClient, object content)
        {
            try
            {
                var json = JsonSerializer.Serialize(content);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode(); // throw nếu status code là lỗi

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public static async Task<string> GetAsync(this string url, HttpClient httpClient)
        {
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
