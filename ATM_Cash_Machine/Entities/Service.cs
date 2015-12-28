using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Cash_Machine
{
    public class Service
    {
        public Service()
        {
            this.CashDispensers = new HashSet<CashDispenser>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CashDispenser> CashDispensers { get; set; }
    }
}
