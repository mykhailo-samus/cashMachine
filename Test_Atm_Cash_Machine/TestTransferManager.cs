using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM_Cash_Machine;
using Moq;

namespace Test_Atm_Cash_Machine
{
    [TestClass]
    public class TestTransferManager
    {
        private TransferManager transferManager;
        private CashManager cashManager;
        private CreditCard fromCard, toCard;
        [TestInitialize]
        public void Initialize()
        {
            var mockLogManager = (new Mock<ILogManager>()).Object;
            var mockDbManager = (new Mock<IDbManager>()).Object;
            cashManager = new CashManager(mockLogManager, mockDbManager);
            transferManager = new TransferManager(mockLogManager, mockDbManager);
            fromCard = new CreditCard { Id = 110, Cash = 10000, Cardholder = new Cardholder { FullName = "Semonenko Semen Semenovych" } };
            toCard = new CreditCard { Id = 111, Cash = 10000, Cardholder = new Cardholder { FullName = "Ivanov Ivan Ivanovych" } };
        }

        [TestMethod]
        public void Transfer_FromCardToCard_BalanceIsEqual()
        {
            //arrange
            const decimal amount = 6000;
            //act
            transferManager.TransferFunds(fromCard, toCard, amount);
            decimal expectedBalance = 4000;
            decimal actualBalance = cashManager.Balance(fromCard);
            //assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }
    }
}
