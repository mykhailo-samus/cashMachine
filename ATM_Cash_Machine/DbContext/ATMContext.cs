using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ATM_Cash_Machine
{
     public class ATMContext : DbContext
    {
        public ATMContext()
            : base("name=DbConnection")
        {
        }

        public virtual IDbSet<CashDispenser> CashDispensers { get; set; }
        public virtual IDbSet<CreditCard> CreditCards { get; set; }
        public virtual IDbSet<Service> Services { get; set; }
        public virtual IDbSet<CardType> Types { get; set; }
        public virtual IDbSet<Cardholder> Сardholders { get; set; }

    }
     public class EntitiesContextInitializer : CreateDatabaseIfNotExists<ATMContext>
     {
         void InitializeCardholders(ATMContext context)
         {
             List<Cardholder> cardholders = new List<Cardholder>
            {
                new Cardholder { FullName = "Petrov Semen Ivanovych", RegistrationDate = DateTime.UtcNow.Date},
                new Cardholder { FullName = "Symonenko Ivan Petrovych", RegistrationDate = new DateTime(2015, 04, 25)},
                new Cardholder { FullName = "Ivanenko Sergiy Pavlovych", RegistrationDate = new DateTime(2015, 03, 11)},
            };
             foreach (Cardholder cHolder in cardholders)
             {
                 context.Сardholders.Add(cHolder);
             }
         }
         
         void InitializeCreditCards(ATMContext context)
         {
             List<CreditCard> creditCards = new List<CreditCard>
             {
                 new CreditCard { CardHolderId = 1, Cash = 12000, PinCode = 4040, TypeId = 1 },
                 new CreditCard { CardHolderId = 2, Cash = 5000, PinCode = 2373, TypeId = 2 },
                 new CreditCard { CardHolderId = 2, Cash = 2000, PinCode = 1111, TypeId = 2 }
             };
             foreach (CreditCard card in creditCards)
             {
                 context.CreditCards.Add(card);
             }
         }

         void InitializeServices(ATMContext context)
         {
             List<Service> services = new List<Service>
             {
                 new Service { Name = "TV payment (1 month)", Price = 150 },
                 new Service { Name = "Internet payment (1 month)", Price = 100 },
                 new Service { Name = "Public utilities service (1 month)", Price = 500 }
             };
             foreach (Service service in services)
             {
                 context.Services.Add(service);
             }
         }
         void InitializeTypes(ATMContext context)
         {
             List<CardType> types = new List<CardType>
             {
                 new CardType {Type = "Basic"},
                 new CardType {Type = "Premium"}
             };
             foreach (CardType type in types)
             {
                 context.Types.Add(type);
             }
         }
         void InitializeCashDispensers(ATMContext context)
         {
             context.CashDispensers.Add(new CashDispenser { MoneyAmount = 5000, Name = "Union Bank", PercentRate = 5, });

         }

         protected override void Seed(ATMContext context)
         {
             InitializeCardholders(context);
             InitializeCreditCards(context);
             InitializeServices(context);
             InitializeTypes(context);
             InitializeCashDispensers(context);
             context.SaveChanges();

         }

     }
 }
