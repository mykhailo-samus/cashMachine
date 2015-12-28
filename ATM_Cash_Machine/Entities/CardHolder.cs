using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Cash_Machine
{
    public class Cardholder
    {
        public Cardholder()
        {
            this.CreditCards = new HashSet<CreditCard>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public System.DateTime RegistrationDate { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }
    }
}
