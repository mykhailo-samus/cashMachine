using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Cash_Machine
{
    class ServiceManager : IServiceManager
    {
        ILogManager logManager;
        IDbManager dbManager;
        public ServiceManager(ILogManager logManager, IDbManager dbManager)
        {
            this.logManager = logManager;
            this.dbManager = dbManager;
        }

        public void PayForService(CreditCard currentCard, Service service)
        {
            currentCard.Cash -= service.Price;

            logManager.WriteLog("x Payed " + service.Price + " for service: " + service.Name + ", from card id: " + currentCard.Id);
            dbManager.ApproveChanges<CreditCard>(currentCard);
        }
    }
}
