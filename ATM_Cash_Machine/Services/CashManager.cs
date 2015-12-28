using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Cash_Machine
{
    public class CashManager : ICashManager
    {
        ILogManager logManager;
        IDbManager dbManager;
        public CashManager(ILogManager logManager, IDbManager dbManager)
        {
            this.logManager = logManager;
            this.dbManager = dbManager;
        }
        public void Widthraw(CreditCard currentCard, decimal amount)
        {
            currentCard.Cash -= amount;

            logManager.WriteLog("- Widthraw " + amount + " from card id: " + currentCard.Id + ", owner: " + currentCard.Cardholder.FullName);
            dbManager.ApproveChanges<CreditCard>(currentCard);
        }

        public void Deposit(CreditCard currentCard, decimal amount)
        {
            currentCard.Cash += amount;

            logManager.WriteLog("+ Deposit " + amount + " to card id: " + currentCard.Id + ", owner: " + currentCard.Cardholder.FullName);
            dbManager.ApproveChanges<CreditCard>(currentCard);
        }
        public decimal Balance(CreditCard currentCard)
        {
            return currentCard.Cash;
        }
    }
}
