using Bank.Domain.Models;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert; // CORRECCIÓN: Especificar la referencia a NUnit para evitar ambigüedad

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
            
            Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Account not debited correctly");
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
            
            Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Account not credited correctly");
        }

        [Test]
        public void Debit_WithAmountGreaterThanBalance_ThrowsException()
        {
            // CORRECCIÓN: Prueba agregada para validar excepción cuando el débito es mayor que el saldo
            BankAccount account = new BankAccount("Mr. Bryan Walton", 11.99);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(20.00));
        }

        [Test]
        public void Debit_WithNegativeAmount_ThrowsException()
        {
            // CORRECCIÓN: Prueba agregada para validar excepción cuando el débito es negativo
            BankAccount account = new BankAccount("Mr. Bryan Walton", 11.99);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(-5.00));
        }

        [Test]
        public void Credit_WithNegativeAmount_ThrowsException()
        {
            // CORRECCIÓN: Prueba agregada para validar excepción cuando el crédito es negativo
            BankAccount account = new BankAccount("Mr. Bryan Walton", 11.99);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(-5.00));
        }
    }
}