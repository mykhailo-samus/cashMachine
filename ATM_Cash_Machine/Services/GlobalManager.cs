using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Cash_Machine
{
    public class GlobalManager
    {
        ICashManager cashManager;
        IServiceManager serviceManager;
        ITranfserManager transferManager;
        IDbManager dbManager;
        ILogManager logManager;
        public GlobalManager(ICashManager cashManager, IServiceManager serviceManager, ITranfserManager transferManager, IDbManager dbManager, ILogManager logManager)
        {
            this.cashManager = cashManager;
            this.serviceManager = serviceManager;
            this.transferManager = transferManager;
            this.dbManager = dbManager;
            this.logManager = logManager;
        }
        public ICashManager CashManager { get { return cashManager; } }
        public IServiceManager ServiceManager { get { return serviceManager; } }
        public ITranfserManager TransferManager { get { return transferManager; } }
        public IDbManager DbManager { get { return dbManager; } }
        public ILogManager LogManager { get { return logManager; } }
    }
}
