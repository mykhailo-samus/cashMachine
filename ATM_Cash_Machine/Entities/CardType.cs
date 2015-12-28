using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Cash_Machine
{
    public class CardType
    {
        public CardType()
        {
            this.CreditCards = new HashSet<CreditCard>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }
    }
}
