using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ConfigurationTool.Utils;

public class HttpUtils
{
    //ToDo: Fix before Production?
    private const string BASE_URL = "http://localhost:5260/";

    public static async Task<T?> Get<T>(string url, string jwtToken = "")
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BASE_URL + url);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (typeof(T) == typeof(string))
                    return (T)(object)content;

                return JsonSerializer.Deserialize<T>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
        catch
        {
            // ignored
        }

        return default;
    }

    public static async Task<T?> Post<T>(string url, object obj, string jwtToken = "")
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + url);
            request.Content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (typeof(T) == typeof(string))
                    return (T)(object)content;

                return JsonSerializer.Deserialize<T>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
        catch
        {
            // ignored
        }

        return default;
    }

    public static async Task<T?> Put<T>(string url, object obj, string jwtToken = "")
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Put, BASE_URL + url);
            request.Content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (typeof(T) == typeof(string))
                    return (T)(object)content;

                return JsonSerializer.Deserialize<T>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
        catch
        {
            // ignored
        }

        return default;
    }

    public static async Task<T?> Delete<T>(string url, string jwtToken = "")
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, BASE_URL + url);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (typeof(T) == typeof(string))
                    return (T)(object)content;

                return JsonSerializer.Deserialize<T>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
        catch
        {
            // ignored
        }

        return default;
    }
}