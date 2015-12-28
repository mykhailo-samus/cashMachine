using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM_Cash_Machine
{
    public class LogManager : ILogManager
    {
        string path;
        public LogManager()
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles\\log.txt");
        }
        public void WriteLog(string text)
        {
            using (StreamWriter sWriter = new StreamWriter(path,true))
            {
                sWriter.WriteLine(text);
            }
        }

        public string ReadLog()
       {
           return File.ReadAllText(path);
       }
    }
}
