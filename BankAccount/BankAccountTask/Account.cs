using System;

namespace BankAccount
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public Account(int id, decimal balance = 0)
        {
            Id = id;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("Negative amount");
            }

            Balance += amount;
        }
    }
}