using System.Text.Json.Serialization;

namespace BAS.DTO;

public abstract class BaseApiResponse
{
    [JsonPropertyName("requestTime")]
    public string RequestTime { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
}