using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BAS.DTO;

public sealed class MessageRequest
{
    [JsonPropertyName("message")]
    [Required]
    [MaxLength(100, ErrorMessage = "Message is too long")]
    public string? Message { get; set; }
}