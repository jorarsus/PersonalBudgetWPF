using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalBudgetWPF.EF;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace PersonalBudgetWPF.Tests
{
    [TestClass()]
    public class AddTransactionWindowTests
    {
        [TestMethod()]
        public void AddTransaction_NormalTransaction_Added()
        {
            // Create in-memory data list (empty list)
            var AccountData = new List<Account>{}.AsQueryable();

            // Create Mocks
            var mockContext = new Mock<PersonalBudgetContext>();
            var mockTransactions = new Mock<DbSet<Transaction>>();
            var mockAccounts = new Mock<DbSet<Account>>();

            // Wire up the IQueryable implementation to the DbSet Mock
            mockAccounts.As<IQueryable<Account>>().Setup(m => m.Provider).Returns(AccountData.Provider);
            mockAccounts.As<IQueryable<Account>>().Setup(m => m.Expression).Returns(AccountData.Expression);
            mockAccounts.As<IQueryable<Account>>().Setup(m => m.ElementType).Returns(AccountData.ElementType);
            mockAccounts.As<IQueryable<Account>>().Setup(m => m.GetEnumerator()).Returns(AccountData.GetEnumerator());

            // Setup mocks
            mockContext.Setup(m => m.Accounts).Returns(mockAccounts.Object);
            mockContext.Setup(m => m.Transactions).Returns(mockTransactions.Object);
            var window = new AddTransactionWindow(mockContext.Object);

            // Act
            Transaction transaction = new Transaction { Date = DateTime.Now, Value = 120, Account = new Account { Concept = "Food" }, Concept = "Market" };
            window.AddTransaction(transaction);

            // Assert
            mockTransactions.Verify(m => m.Add(It.IsAny<Transaction>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}