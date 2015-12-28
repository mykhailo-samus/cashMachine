using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM_Cash_Machine;
using Moq;

namespace Test_Atm_Cash_Machine
{
    [TestClass]
    public class TestLogManager
    {
        [TestMethod]
        public void Verify_LogManager_LogWriteIsCalled()
        {
            //arrange
            var mockLogManager = (new Mock<ILogManager>());
            //act
            mockLogManager.Object.WriteLog("Write to log called.");
            //assert
            mockLogManager.Verify(t => t.WriteLog(It.IsAny<string>()));
        }
    }
}
