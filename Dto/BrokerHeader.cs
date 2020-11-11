using System.Text.Json.Serialization;

namespace MessagingPOC.Dto
{
    class BrokerHeader
    {
        [JsonPropertyName("tenant")]
        public string Tenant { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
