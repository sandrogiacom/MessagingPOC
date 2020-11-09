using System;
using System.Threading.Tasks;
using Tnf.Bus.Client;
using Tnf.Bus.Queue.Interfaces;

namespace MessagingPOC.Messages
{
    class GroupMessageService : IPublish<GroupCreateEvent>, INotifierService
    {

        public async Task Handle(GroupCreateEvent message) => await message.Publish();

        public Task Notify(object message)
        {
            Console.WriteLine("Notify " + message);
            return Handle((GroupCreateEvent)message);
        }
    }
}
