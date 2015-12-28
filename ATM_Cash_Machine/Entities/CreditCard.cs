using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Cash_Machine
{
    public class CreditCard
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int PinCode { get; set; }
        public decimal Cash { get; set; }
        public int CardHolderId { get; set; }

        public virtual Cardholder Cardholder { get; set; }
        public virtual CardType CardType { get; set; }
    }
}
