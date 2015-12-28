using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Ninject;
namespace ATM_Cash_Machine
{
    class Program
    {
        static GlobalManager globalManager;
        public static IKernel AppKernel;
        static void Main(string[] args)
        {
            Database.SetInitializer(new EntitiesContextInitializer());
            AppKernel = new StandardKernel(new GlobalNinjectModule());
            globalManager = AppKernel.Get<GlobalManager>();
            ShowIntroduction();
            ShowDepositWidtraw();
            ShowTransfer();
            ShowPayForService();
            ShowingLog();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static void ShowIntroduction()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Welcome! This is the Cash Machine.");
            Console.WriteLine("Main features: deposit/widthraw/show balance,");
            Console.WriteLine("transfer funds, pay for service, behaviour logging to file.");
            CreditCard card = globalManager.DbManager.GetCard(1);
            Console.WriteLine("--------------------------");
            Console.WriteLine("Current user is: " + card.Cardholder.FullName + ", credit card id is: " + card.Id);
            Console.WriteLine("Balance: " + card.Cash);
            Console.WriteLine("--------------------------");
        }

        static void ShowDepositWidtraw()
        {
            CreditCard card = globalManager.DbManager.GetCard(1);
            Console.WriteLine("Processing local features:");
            Console.WriteLine("--------------------------");
            const decimal widthrawAmount = 1000;
            Console.WriteLine("Withdrawing " + widthrawAmount + " from card id : " + card.Id);
            globalManager.CashManager.Widthraw(card, widthrawAmount);
            Console.WriteLine("Balance: " + globalManager.CashManager.Balance(card));
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
            const decimal depositAmount = 2000;
            Console.WriteLine("Depositing " + depositAmount + " to card id : " + card.Id);
            globalManager.CashManager.Deposit(card, depositAmount);
            Console.WriteLine("Balance: " + globalManager.CashManager.Balance(card));
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
        }
       static void ShowTransfer()
        {
            CreditCard card = globalManager.DbManager.GetCard(1);
            CreditCard toCard = globalManager.DbManager.GetCard(3);
            const decimal transferAmount = 1000;
            Console.WriteLine("Transfer funds in amount: " + transferAmount + " from card id: " + card.Id + " to card id : " + toCard.Id);
            Console.WriteLine("Balance before, card id:" + card.Id + " is: " + globalManager.CashManager.Balance(card));
            Console.WriteLine("Balance before, card id:" + toCard.Id + " is: " + globalManager.CashManager.Balance(toCard));
            Console.WriteLine("Transfering......");
            globalManager.TransferManager.TransferFunds(card, toCard, transferAmount);
            Console.WriteLine("Balance after, card id:" + card.Id + " is: " + globalManager.CashManager.Balance(card));
            Console.WriteLine("Balance after, card id:" + toCard.Id + " is: " + globalManager.CashManager.Balance(toCard));
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
        }
        static void ShowPayForService()
       {
           CreditCard card = globalManager.DbManager.GetCard(1);
           Service service = globalManager.DbManager.GetService(1);
           Console.WriteLine("Paying for service " + service.Name + ", price: " + service.Price + " from card id: " + card.Id);
           Console.WriteLine("Balance before, card id: " + card.Id + "is: " + globalManager.CashManager.Balance(card));
           Console.WriteLine("Paying......");
           globalManager.ServiceManager.PayForService(card, service);
           Console.WriteLine("Balance after, card id: " + card.Id + " is: " + globalManager.CashManager.Balance(card));
           Console.WriteLine("--------------------------");
       }
        static void ShowingLog()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Writing log..........");
            Console.WriteLine("--------------------------");
            Console.WriteLine(globalManager.LogManager.ReadLog());
        }
    }
}
