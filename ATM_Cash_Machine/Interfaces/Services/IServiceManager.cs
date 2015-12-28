using System;

namespace ATM_Cash_Machine
{
    public interface IServiceManager
    {
        void PayForService(CreditCard currentCard, Service service);
    }
}
