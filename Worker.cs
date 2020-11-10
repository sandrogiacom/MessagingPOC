using MessagingPOC.Dto;
using MessagingPOC.Messages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingPOC
{

    class Worker : BackgroundService
    {
        private readonly INotifierService _notifierService;

        public Worker(INotifierService notifierService)
        {
            _notifierService = notifierService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            GroupCreateDTO groupCreate = new GroupCreateDTO();
            groupCreate.ObjectGuid = Guid.NewGuid().ToString().Replace("-", "");
            groupCreate.SamAccountName = "Group SamAccountName 11111";
            groupCreate.DisplayName = "Group DisplayName 1212121212";
            groupCreate.Name = "Group Name 12121212";
            groupCreate.Description = "Group Description 12121212";
            groupCreate.DistinguishedName = "Group DistinguishedName asakdalk";
            groupCreate.GroupScope = GroupScopeEnum.DOMAIN.ToString();
            groupCreate.GroupType = GroupTypeEnum.DISTRIBUTION.ToString();
            groupCreate.LastAdChangeMillis = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            SyncEventDTO body = new SyncEventDTO();
            body.ActiveDirectoryId = "5c11b84a4e9b467d84356761448a997e";
            body.Type = "GROUP_CREATE";
            body.Message = groupCreate;

            Console.WriteLine("ExecuteAsync ... ");

            BrokerHeader header = new BrokerHeader();
            header.Tenant = "12345";
            header.User = "3333";

            BrokerMessage message = new BrokerMessage(header, body);

            await _notifierService.Notify(message);

        }
    }
}
