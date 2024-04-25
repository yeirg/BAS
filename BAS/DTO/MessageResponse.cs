using System.Text.Json.Serialization;

namespace BAS.DTO;

public sealed class MessageResponse : BaseApiResponse
{
    [JsonPropertyName("writeTime")]
    public string WriteTime { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    
    [JsonPropertyName("processingTime")]
    public int ProcessingTime { get; set; } = 0;
}

