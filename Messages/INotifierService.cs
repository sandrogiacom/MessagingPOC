using System.Threading.Tasks;
using Tnf.Application.Services;

namespace MessagingPOC.Messages
{
    public interface INotifierService : IApplicationService 
    {
        Task Notify(object message);
    }
}