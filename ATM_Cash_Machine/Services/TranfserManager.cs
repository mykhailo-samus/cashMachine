using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Cash_Machine
{
    public class TransferManager : ITranfserManager
    {
        ILogManager logManager;
        IDbManager dbManager;
        public TransferManager(ILogManager logManager, IDbManager dbManager)
        {
            this.logManager = logManager;
            this.dbManager = dbManager;
        }
        public void TransferFunds(CreditCard fromCard, CreditCard toCard, decimal amount)
        {
            toCard.Cash += amount;
            fromCard.Cash -= amount;

            logManager.WriteLog("* Transfer " + amount + " from card id: " + fromCard.Id + ", to card id: " + toCard.Id);
            dbManager.ApproveChanges<CreditCard>(fromCard);
            dbManager.ApproveChanges<CreditCard>(toCard);
        }
    }
}
