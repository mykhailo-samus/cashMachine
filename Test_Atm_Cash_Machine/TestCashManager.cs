using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM_Cash_Machine;
using Moq;

namespace Test_Atm_Cash_Machine
{
    [TestClass]
    public class TestCashManager
    {
        private CashManager cashManager;
        private CreditCard card;
        [TestInitialize]
         public void Initialize()
        {
            cashManager = new CashManager((new Mock<ILogManager>()).Object, (new Mock<IDbManager>()).Object);
            card = new CreditCard { Id = 110, Cash = 10000, Cardholder = new Cardholder { FullName = "Semonenko Semen Semenovych" } };
        }
        [TestMethod]
        public void Deposit_ToCard_BalanceIsEqual()
        {
            //arrange
            const decimal depositAmount = 1000;
            //act
            cashManager.Deposit(card, depositAmount);
            decimal expectedBalance = 11000;
            decimal actualBalance = cashManager.Balance(card);
            //assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        public void Widthraw_FromCard_BalanceIsEqual()
        {
            //arrange
            const decimal widthrawAmount = 5000;
            //act
            cashManager.Widthraw(card, widthrawAmount);
            decimal expectedBalance = 5000;
            decimal actualBalance = cashManager.Balance(card);
            //assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }
    }
}
