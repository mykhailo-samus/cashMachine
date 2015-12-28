using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM_Cash_Machine;
using Moq;
using System.Data.Entity;

namespace Test_Atm_Cash_Machine
{
    [TestClass]
    public class TestDbManager
    {
        [TestMethod]
        public void GetCard_InMockContext_IdIsEqual()
        {
            //arrange
            const int expectedId = 1;
            var expected = new CreditCard { Id = expectedId };
            var data = new List<CreditCard> 
            { 
                expected,
                new CreditCard { Id = 2 },
                new CreditCard { Id = 3 },
                new CreditCard { Id = 4 }
            }.AsQueryable();

            var dbSetMock = new Mock<IDbSet<CreditCard>>();
            dbSetMock.Setup(m => m.Provider).Returns(data.Provider);
            dbSetMock.Setup(m => m.Expression).Returns(data.Expression);
            dbSetMock.Setup(m => m.ElementType).Returns(data.ElementType);
            dbSetMock.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var customDbContextMock = new Mock<ATMContext>();
            customDbContextMock
                .Setup(x => x.CreditCards)
                .Returns(dbSetMock.Object);

            var dbManager = new DbManager(customDbContextMock.Object);

            //act
            var actual = dbManager.GetCard(expectedId);

            //assert
            Assert.AreEqual(expected.Id, actual.Id);
        }
    }
}
