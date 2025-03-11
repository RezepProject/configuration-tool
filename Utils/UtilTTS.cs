using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationTool.Utils
{
    public class UtilTTS
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string ApiUrl = "https://if200181.cloud.htl-leonding.ac.at/v1/audio/speech";
        
        public static async Task<byte[]> GenerateTTSAsync( double speed, string lang)
        {
            string voice = lang == "de" ? "thorsten-emotionally-amused" : "alloy";
            string text = voice == "thorsten-emotionally-amused" ? "Hallo, ich bin Thorsten. Ich bin ein Sprachsynthesizer und ich bin sehr erfreut!." : "Hello, I am Alloy. I am a speech synthesizer and I am very amused.";
            
            var jsonContent = $@"
            {{
                ""model"": ""tts-1"",
                ""input"": ""{text}"",
                ""voice"": ""{voice}"",
                ""response_format"": ""mp3"",
                ""speed"": ""{speed}""
            }}";
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(ApiUrl, content);
                
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Fehler bei der Anfrage: {response.ReasonPhrase}");
                
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Abrufen der Audiodaten.", ex);
            }
        }
    }
}