using MessagingPOC.Dto;
using MessagingPOC.Messages;
using Microsoft.Extensions.Hosting;
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
            groupCreate.ObjectGuid = "2332323232";
            groupCreate.SamAccountName = "Group SamAccountName";
            groupCreate.DisplayName = "Group DisplayName";
            groupCreate.Name = "Group Name";
            groupCreate.Description = "Group Description";
            groupCreate.GroupScope = GroupScopeEnum.DOMAIN.ToString();
            groupCreate.GroupType = GroupTypeEnum.DISTRIBUITION.ToString();

            SyncEventDTO body = new SyncEventDTO();
            body.activeDirectoryId = "5c11b84a4e9b467d84356761448a997e";
            body.type = "GROUP_CREATE";
            body.message = groupCreate;

            Console.WriteLine("ExecuteAsync ... ");

            BrokerHeader header = new BrokerHeader();
            header.Tenant = "12345";
            header.User = "3333";

            BrokerMessage message = new BrokerMessage(header, body);

            await _notifierService.Notify(message);

        }
    }
}
