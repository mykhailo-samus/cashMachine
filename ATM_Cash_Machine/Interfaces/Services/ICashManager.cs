using System;

namespace ATM_Cash_Machine
{
    public interface ICashManager
    {
        decimal Balance(CreditCard currentCard);
        void Deposit(CreditCard currentCard, decimal amount);
        void Widthraw(CreditCard currentCard, decimal amount);
    }
}
