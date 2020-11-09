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
            GroupCreateDTO GroupCreate = new GroupCreateDTO();
            GroupCreate.ObjectGuid = "2332323232";
            GroupCreate.SamAccountName = "Group SamAccountName";
            GroupCreate.DisplayName = "Group DisplayName";
            GroupCreate.Name = "Group Name";
            GroupCreate.Description = "Group Description";
            GroupCreate.GroupScope = GroupScopeEnum.DOMAIN.ToString();
            GroupCreate.GroupType = GroupTypeEnum.DISTRIBUITION.ToString();


            Console.WriteLine("ExecuteAsync ... ");

            GroupCreateEvent groupCreateEvent = new GroupCreateEvent(GroupCreate);
            await _notifierService.Notify(groupCreateEvent);

            while(!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000, stoppingToken);
            }

        }
    }
}
