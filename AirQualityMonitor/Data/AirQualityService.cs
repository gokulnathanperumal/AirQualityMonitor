using System.Net.Http.Json;

namespace AirQualityMonitor.Data;

public class AirQualityService
{
    public async Task<Identity> SignIn()
    {
        Identity identity = new Identity();

        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyCE1aKSHkbvk63XMJN50-xZPayybwlFXGs");
            request.Content = new StringContent("{'email':'rfwhik@wfp.hok', 'password':'reader@aqm','returnSecureToken': true}", null, "application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            identity = response.Content.ReadFromJsonAsync<Identity>().Result;
        }
        catch { }

        return identity;
    }

    public async Task<AirQualityCollection> GetAirQualityDataAsync(int pageSize)
    {
        AirQualityCollection airQualityCollection = new AirQualityCollection { Documents = new List<AirQualityDocument>() };

        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://firestore.googleapis.com/v1beta1/projects/air-quality-monitor-mettur/databases/(default)/documents/sensor-data?orderBy=CreatedDate desc&pageSize={pageSize}");
            request.Headers.Add("Authorization", $"Bearer {(await SignIn())?.IdToken}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            airQualityCollection = response.Content.ReadFromJsonAsync<AirQualityCollection>().Result;
        }
        catch { }

        return airQualityCollection;
    }
}
