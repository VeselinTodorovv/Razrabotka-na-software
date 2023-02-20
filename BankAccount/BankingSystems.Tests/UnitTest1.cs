using System;
using BankAccount;
using NUnit.Framework;

namespace BankingSystems.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void DepositShouldIncreaseBalance()
        {
            Account acc = new Account(123);
            decimal depositAmount = 100;
            
            acc.Deposit(depositAmount);
            
            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            Account acc = new Account(123, 2000m);
            Assert.AreEqual(2000m, acc.Balance);
        }

        [TestCase(100)]
        [TestCase(3500)]
        [TestCase(2400)]
        [Test]
        public void DepositShouldIncreaseBalanceAll(decimal depositAmount)
        {
            Account acc = new Account(123);
            acc.Deposit(depositAmount);
            
            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionWithMessage()
        {
            Account acc = new Account(123);
            decimal depositAmount = -100;

            var ex = Assert.Throws<InvalidOperationException>(() => acc.Deposit(depositAmount));
            
            Assert.AreEqual(ex!.Message, "Negative amount");
        }
    }
}