using System.Text.Json.Serialization;

namespace MessagingPOC.Dto
{
    class SyncEventDTO
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("activeDirectoryId")]
        public string ActiveDirectoryId { get; set; }
        [JsonPropertyName("message")]
        public object Message { get; set; }
    }
}
