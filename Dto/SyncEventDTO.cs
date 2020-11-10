using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingPOC.Dto
{
    class SyncEventDTO
    {
        public string Type { get; set; }
        public string ActiveDirectoryId { get; set; }
        public object Message { get; set; }
    }
}
