using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ConfigurationTool.Utils;

public static class HttpUtils
{
    private const string BASE_URL = "http://localhost:5260/";

    public static async Task<T?> Get<T>(string url, string jwtToken = "")
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BASE_URL + url);
            var client = new HttpClient();

            if(!string.IsNullOrEmpty(jwtToken))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) return HandleStatusCode<T>(response.StatusCode, response, content);

            if (typeof(T) == typeof(string))
                return (T)(object)content;

            return JsonSerializer.Deserialize<T>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    public static async Task<T?> Post<T>(string url, object obj, string jwtToken = "")
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + url);
            request.Content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
            var client = new HttpClient();

            if(!string.IsNullOrEmpty(jwtToken))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) return HandleStatusCode<T>(response.StatusCode, response, content);

            if (typeof(T) == typeof(string))
                return (T)(object)content;

            return Deserialize<T>(content);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    public static async Task<T?> Put<T>(string url, object obj, string jwtToken = "")
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Put, BASE_URL + url);
            request.Content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
            var client = new HttpClient();

            if(!string.IsNullOrEmpty(jwtToken))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) return HandleStatusCode<T>(response.StatusCode, response, content);

            if (typeof(T) == typeof(string))
                return (T)(object)content;

            return Deserialize<T>(content);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    public static async Task<T?> Delete<T>(string url, string jwtToken = "")
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, BASE_URL + url);
            var client = new HttpClient();

            if(!string.IsNullOrEmpty(jwtToken))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) return HandleStatusCode<T>(response.StatusCode, response, content);

            if (typeof(T) == typeof(string))
                return (T)(object)content;

            return Deserialize<T>(content);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    private static T? Deserialize<T>(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        } catch { return default; }
    }

    private static T? HandleStatusCode<T>(HttpStatusCode code, HttpResponseMessage response, string content)
    {
        switch (code)
        {
            case HttpStatusCode.Unauthorized:
                return (T)(object)null;
            case HttpStatusCode.BadRequest:
                return (T)(object)$"{response.StatusCode}: {content}";
            default:
                return default;
        }
    }
}