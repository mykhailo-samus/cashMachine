using System;
using System.Collections.Generic;

namespace ATM_Cash_Machine
{
    public class CashDispenser
    {
        public CashDispenser()
        {
            this.Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MoneyAmount { get; set; }
        public int PercentRate { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
