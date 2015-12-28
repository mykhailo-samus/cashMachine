using System;

namespace ATM_Cash_Machine
{
    public interface ILogManager
    {
        string ReadLog();
        void WriteLog(string text);
    }
}
