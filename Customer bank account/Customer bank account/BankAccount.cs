using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_bank_account
{

    public interface  IPrintable
    {
          string PrintStatement();
          string ShowBalance();

    }

    public abstract class BankAccount : IPrintable
    {




        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual string Owner { get; }


        public virtual string owner
        {

            get
            {
                return AccountNumber + "  " + FirstName + " " + LastName;
            }
        }

        public decimal Balance;
            
           


        //public decimal getBalance()
        //{
            
        //    {
        //         return Balance;
        //    }

        //  //  return Balance;
        //}

        // constructor
        public BankAccount()
        {

        }

        // constructor with 3 parameters
        public BankAccount(string accountNumber, string firstName, string lastName)
        {
            this.AccountNumber = accountNumber;
            this.FirstName = firstName;
            this.LastName = lastName;

        }

        public enum CheckingAccountType
        {
            Basic = 0,
            Premier = 1
            
        }

        // private List<Transaction> allTransactions = new List<Transaction>();
        // decimal method 
        public void DepositAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException ("Amount of deposit must be positive");
            }
            Balance += amount;
        }


        public virtual bool WithdrawAmount(decimal amount, CheckingAccountType checkingAccountType )
        {
            bool chargeOverDraft = false;

            if (amount < 0)
            {
                throw new ArgumentException("No negative withdrawal amounts are allowed. Please enter a valid amount.");

            }
            if (checkingAccountType != CheckingAccountType.Premier && amount > Balance)
            {
                throw new ArgumentException($"Insufficient funds. Please enter a smaller amount.");
                
            }

            if (amount > 300)
            {
                throw new ArgumentException($"Your daily maximum withdrawal is $300 dollars or less. Please enter a smaller amount.");
               
            }
            else if (checkingAccountType == CheckingAccountType.Premier && amount > Balance)
            {
                chargeOverDraft = true;
            }


            Balance -= amount;
            return chargeOverDraft;
            throw new Exception ($"Was Wathdrawn Successfully");

        }
        public abstract string PrintStatement();

        public abstract string ShowBalance();

       
    }
}
