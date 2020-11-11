using System.Text.Json;
using System.Text.Json.Serialization;
using Tnf.Bus.Client;

namespace MessagingPOC.Dto
{
    class BrokerMessage : Message
    {
        [JsonPropertyName("header")]
        public BrokerHeader Header { get; set; }
        [JsonPropertyName("body")]
        public object Body { get; set; }

        public BrokerMessage(BrokerHeader header, object body)
        {
            Header = header;
            Body = JsonSerializer.Serialize(body);
        }


    }
}
