using Bank.Domain.Models;
using NUnit.Framework;

namespace Bank.Domain.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange EJM2
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
         [Test]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 5.00;
            double expected = 16.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            
            // Act
            account.Credit(creditAmount);
            
            // Assert
            double actual = account.Balance;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }
    }
}
