using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace ATM_Cash_Machine
{
    public class  GlobalNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICashManager>().To<CashManager>();
            Bind<IServiceManager>().To<ServiceManager>();
            Bind<ILogManager>().To<LogManager>();
            Bind<ITranfserManager>().To<TransferManager>();
            Bind<IDbManager>().To<DbManager>();
            Bind<ATMContext>().ToSelf().InSingletonScope();
        }
    }
}
