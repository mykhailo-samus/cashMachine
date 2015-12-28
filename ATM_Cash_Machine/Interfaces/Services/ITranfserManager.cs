using System;

namespace ATM_Cash_Machine
{
    public interface ITranfserManager
    {
        void TransferFunds(CreditCard currentCard, CreditCard toCard, decimal amount);
    }
}
