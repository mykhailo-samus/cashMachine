using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ATM_Cash_Machine
{
    public class DbManager : IDbManager
    {
        ATMContext context;
        public DbManager(ATMContext context)
        {
            this.context = context;
        }

        public void ApproveChanges<T>(T item) where T : class
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public CreditCard GetCard(int id)
        {
           return context.CreditCards.Single(x => x.Id == id);
        }

        public Service GetService(int id)
        {
            return context.Services.Single(x => x.Id == id);
        }
    }
}
