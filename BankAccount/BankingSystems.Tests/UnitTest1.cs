using System;
using BankAccount;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace BankingSystems.Tests {
    [TestFixture]
    public class Tests {
        [Test]
        public void AccountInitializeWithPositiveValue() {
            Account acc = new Account(123, 2000m);
            Assert.AreEqual(2000m, acc.Balance);
        }

        [TestCase(100)]
        [TestCase(3500)]
        [TestCase(2400)]
        [Test]
        public void DepositShouldIncreaseBalanceAll(decimal depositAmount) {
            Account acc = new Account(123);
            acc.Deposit(depositAmount);
            
            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [Test]
        public void MethodsShouldThrowInvalidOperationExceptionWithMessage() {
            Account acc = new Account(123);
            const decimal depositAmount = -100;
            const double percent = -5;

            //Deposit()
            var deposit = Assert.Throws<InvalidOperationException>(() => acc.Deposit(depositAmount));
            //Bonus()
            var bonus = Assert.Throws<InvalidOperationException>(() => acc.Bonus());
            //Increase()
            var increase = Assert.Throws<InvalidOperationException>(() => acc.Increase(percent));
            
            Assert.AreEqual(deposit.Message, "Negative amount");
            Assert.AreEqual(bonus.Message, "Less than 1000");
            Assert.AreEqual(increase.Message, "Negative percentage");
        }
        [Test]
        public void IncreaseMethodShouldIncreaseBalanceByPercentage() {
            Account acc = new(123, 100);
            const double percent = 67;
            acc.Increase(percent);
            Assert.IsTrue(acc.Balance == 167);
        }

        [TestCase(1500)]
        [TestCase(2000)]
        [TestCase(3000)]
        [TestCase(3100)]
        [Test]
        public void BonusIncreasesBalanceWithCorrectAmount(decimal balance) {
            decimal value = balance switch {
                > 1000 and < 2000 => 100,
                >= 2000 and <= 3000 => 200,
                > 3000 => 300,
                _ => 0
            };

            Account acc = new Account(123, balance);
            acc.Bonus();
            Assert.AreEqual(balance + value, acc.Balance);
        }

        
        [Test]
        public void PaymentForCreditShouldThrowErrors() {
            Account acc = new Account(123, 100);
            var payment = Assert.Throws<ArgumentException>(() => acc.PaymentForCredit(0));
            var payment2 = Assert.Throws<ArgumentException>(() => acc.PaymentForCredit(101));
            var payment3 = Assert.Throws<ArgumentException>(() => acc.PaymentForCredit(-5));
            
            Assert.AreEqual(payment.Message, "Payment cannot be zero or negative!");
            Assert.AreEqual(payment2.Message, "Not enough money!");
            Assert.AreEqual(payment3.Message, "Payment cannot be zero or negative!");
        }
        
        [TestCase(39)]
        [TestCase(100)]
        [TestCase(68)]
        [Test]
        public void PaymentForCreditShouldDecreaseBalance(decimal payment) {
            Account acc = new Account(123, 100);
            acc.PaymentForCredit(payment);
            Assert.AreEqual(100 - payment, acc.Balance);
        }
    }
}