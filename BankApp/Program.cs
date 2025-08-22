using System;

namespace BankApp
{
    // Base class
    public abstract class BankAccount
    {
        public decimal Balance { get; protected set; }

        public BankAccount(decimal balance)
        {
            Balance = balance;
        }

        public abstract void CheckBalance();

        public virtual void Transfer(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Your transferred {amount} đ, Your balance: {Balance} đ");
            }
            else
            {
                Console.WriteLine("Not enough balance to transfer!");
            }
        }
    }

    // Normal Account
    public class NormalAccount : BankAccount
    {
        public NormalAccount(decimal balance) : base(balance) { }

        public override void CheckBalance()
        {
            Console.WriteLine($"Your balance: {Balance} đ");
        }
    }

    // Exchange Account (USD → VND)
    public class ExchangeAccount : BankAccount
    {
        private decimal exchangeRate;

        public ExchangeAccount(decimal usdAmount, decimal exchangeRate)
            : base(usdAmount)
        {
            this.exchangeRate = exchangeRate;
        }

        public override void CheckBalance()
        {
            decimal vndBalance = Balance * exchangeRate;
            Console.WriteLine($"Your balance: {vndBalance} đ (Rate: {exchangeRate})");
        }

        public override void Transfer(decimal amount)
        {
            decimal vndBalance = Balance * exchangeRate;

            if (vndBalance >= amount)
            {
                vndBalance -= amount;
                Console.WriteLine($"Your transferred {amount} đ, Your balance: {vndBalance} đ");
            }
            else
            {
                Console.WriteLine("Not enough balance to transfer!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Normal Account
            BankAccount acc1 = new NormalAccount(25000000);
            acc1.CheckBalance();
            acc1.Transfer(1000000);

            Console.WriteLine("---------------------");

            // Exchange Account
            BankAccount acc2 = new ExchangeAccount(1000, 25000);
            acc2.CheckBalance();
            acc2.Transfer(1000000);

            Console.ReadLine();
        }
    }
}
