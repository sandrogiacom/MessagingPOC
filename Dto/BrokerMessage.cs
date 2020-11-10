using System.Text.Json;
using Tnf.Bus.Client;

namespace MessagingPOC.Dto
{
    class BrokerMessage : Message
    {
        public BrokerHeader Header { get; set; }
        public object Body { get; set; }

        public BrokerMessage(BrokerHeader header, object body)
        {
            Header = header;
            Body = JsonSerializer.Serialize(body);
        }


    }
}
