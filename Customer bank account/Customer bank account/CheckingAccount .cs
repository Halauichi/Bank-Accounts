using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_bank_account
{
    public class CheckingAccount : BankAccount
    {

        public CheckingAccount()
        {

        }
        public CheckingAccount(string accountNumber, string firstName, string lastName) : base(accountNumber, firstName, lastName)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
        }
        //public enum  CheckingAccountType
        //{
        //    Basic = 0,
        //    Premier = 1
        //}


        // default value = Premier
        public CheckingAccountType AccountType { get; set; } = CheckingAccountType.Premier;


        public override string Owner => $"Checking- {base.Owner}";


        public decimal OverDraftFee { get; set; }
        public int NumberofOverdrafts { get; set; }


        public override bool WithdrawAmount(decimal withdrawalAmount, CheckingAccountType checkingAccountType)
        {
            if (base.WithdrawAmount(withdrawalAmount, checkingAccountType))
            {
                Balance -= 25; 
                OverDraftFee += 25;
                NumberofOverdrafts++;
                return true;
            }
            return false;
        }




        //public bool WithdrawAmount(decimal amount, AccountType? accountType)
        //{
        //    if (amount <= 0 || Convert.ToDecimal( Balance) - amount < 0)
        //        return false;
        //       // this.Balance -= amount;
        //        return true;
        //}

        public override string PrintStatement()
        {

            // return  base.PrintStatement();
            return $@"Statement Date as { DateTime.Now.Date.ToShortDateString()} for { owner}
                      Checking Account Balance is $ { Balance}
                      Amount of OverDraft Fee for the month is $ { OverDraftFee}
                      The number of overdrafts for the month is {NumberofOverdrafts}";

        }

        public override string ShowBalance()
        {
            // return base.ShowBalance();
            return $@"Customer {owner} has ${Balance} in Checking Account.";
        }
       

    }
}
