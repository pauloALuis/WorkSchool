using Objets_Classes;
using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var account = new BankAccount("Carlos", 1500);
            var account1 = new BankAccount("1Carlos", 1500);
            var account2 = new BankAccount("2Carlos");
            Console.WriteLine($"Account {account2.ToString()}");

            Console.WriteLine($"My account name= {account.Owner}, with  {account.Number}");
            Console.WriteLine($"My account name= {account1.Owner}, with  {account1.Number}");
            Console.WriteLine($"Account {account2.Owner}, with  {account2.Number}");
            string note = "With Drawal  necessar";
            Console.WriteLine($"Balance {account2.Balance}");
            account.MakeWithDrawal(750, DateTime.Now, "Attempt to overdraw");
            account.MakeDeposit(890, DateTime.Now, "money carlos");

            string dateInput = "Jan 1, 2009";
            var parsedDate = DateTime.Parse(dateInput);
            account.MakeDeposit(10000, parsedDate, "money carlos");

            Console.WriteLine(account.GetAccountHistory());

            try
            {
                var invalidAccount = new BankAccount("Marta Domingos ", -55);
               // account2.MakeWithDrawal(800, DateTime.Now, note );

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Exception caugth creating account {account.Owner}, with  negative balance");
                Console.WriteLine($" {e}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Erro disconhecido!!");
               // Console.WriteLine($" {e.ToString()}");
            }


            // Test for a negative balance.
            try
            {
                account.MakeWithDrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }


        }
    }
}
