using System;

namespace ATM_Cash_Machine
{
    public interface IDbManager
    {
        void ApproveChanges<T>(T item) where T : class;
        CreditCard GetCard(int id);
        Service GetService(int id);
    }
}
