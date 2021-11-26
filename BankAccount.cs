using System;
using System.Collections.Generic;
using System.Text;

namespace Objets_Classes
{
    class MakeDeposits
    {
        public DateTime DateDeposit { get; set; }

        public decimal Amount { get; set; }
        public string Note { get; set; }



    }
    /// <summary>
    /// 
    /// </summary>
    class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }

        }

        private static int accountNumberSeed = 1234567890; //{ get; set; }
        string otherName; // field

        private List<Transaction> allTransactions = new List<Transaction>();


        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            decimal balance = 0;
            //create header
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                //create rows
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}- \t{item.Amount} - \t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        public string OtherName   // property
        {
            get { return otherName; }   // get method
            set { otherName = value; }  // set method
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="initialBalace"></param>
        public BankAccount(string name, decimal initialBalance = 500)
        {
            this.Owner = name;//
            //this.Balance = initialBalace;
            this.MakeDeposit(initialBalance,DateTime.Now, "Inicial Deposit");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

        }


        public override string ToString()
        {
            return $"{this.Number}, {this.Owner}, {this.Balance} ";
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            //  Balance += amount;

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }


            Transaction deposit = new Transaction(amount, date, note);
            this.allTransactions.Add(deposit);
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        public void MakeWithDrawal(decimal amount, DateTime date, string note)
        {


            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            //Balance -= amount;
            Transaction withDrawal = new Transaction(-amount, date, note);
            this.allTransactions.Add(withDrawal);


        }





    }
}
