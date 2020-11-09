using MessagingPOC.Dto;
using Tnf.Bus.Client;

namespace MessagingPOC.Messages
{
    class GroupCreateEvent : Message
    {
        public GroupCreateDTO GroupCreate { get; set; }

        public GroupCreateEvent()
        {
        }
        public GroupCreateEvent(GroupCreateDTO groupCreate)
        {
            GroupCreate = groupCreate;
        }
    }
}
