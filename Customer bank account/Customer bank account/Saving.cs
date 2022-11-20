using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_bank_account
{
    public class Saving : BankAccount
    {
        public const decimal defaultINTEREST = 0.02m;
        public const decimal defaultBALANCE_CHECK = 100m;
        public const decimal Add_Interest = defaultINTEREST + defaultBALANCE_CHECK;
        public override string Owner => $"Saving- {base.Owner}";

        public Saving()
        {

        }
        public Saving(string accountNumber, string firstName, string lastName) : base(accountNumber, firstName, lastName)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
        }
        public decimal AddInterest()
        {

           
            if (Balance > defaultBALANCE_CHECK)
            {
              Balance += defaultINTEREST;
                return defaultINTEREST;
            }
            else
            {
                return 0;
            }
        }
        public override string PrintStatement()
        {

            // return base.PrintStatement();
            return $@"Statement Date as { DateTime.Now.Date.ToShortDateString()} for { owner }
                      Savings Account Balance is $ { Balance}
                      Interest earned for the month is $ { AddInterest()}
                      Total Savings Account balance including interest earned is $ { Balance + AddInterest()}";

        }

        public override string ShowBalance() 
        {
           // return base.ShowBalance();
            return $"Customer {owner} has ${Balance} in Savings Account.";
        }
    }
}
