using System.Reflection;
using Tnf.Modules;

namespace MessagingPOC
{
    public class AppModule: TnfModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
