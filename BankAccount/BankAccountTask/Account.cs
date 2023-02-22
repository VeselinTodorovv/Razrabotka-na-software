using System;

namespace BankAccount {
    public class Account {
        public int Id { get; }
        public decimal Balance { get; set; }

        public Account(int id, decimal balance = 0) {
            Id = id;
            Balance = balance;
        }

        public void Deposit(decimal amount) {
            if (amount < 0) {
                throw new InvalidOperationException("Negative amount");
            }
            Balance += amount;
        }
        
        public void Increase(double percent) {
            if (percent < 0) {
                throw new InvalidOperationException("Negative percentage");
            }
            Balance += Balance / 100 * (decimal) percent;
        }

        public void Bonus() {
            switch (Balance) {
                case > 1000 and < 2000:
                    Balance += 100;
                    break;
                case >= 2000 and <= 3000:
                    Balance += 200;
                    break;
                case > 3000:
                    Balance += 300;
                    break;
                default:
                    throw new InvalidOperationException("Less than 1000");
            }
        }

        public void PaymentForCredit(decimal payment) {
            if (payment <= 0) {
                throw new ArgumentException("Payment cannot be zero or negative!");
            }

            if (Balance < payment) {
                throw new ArgumentException("Not enough money!");
            }

            Balance -= payment;
        }
    }
}