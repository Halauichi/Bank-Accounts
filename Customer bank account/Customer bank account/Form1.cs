using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_bank_account
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        BankAccount mybankaccount;

        CheckingAccount mycheckingAccount = new CheckingAccount();
        Saving mysaving = new Saving();
       // BankAccount mybankAccount= new BankAccount()


        public void ClearUI()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAccount.Text = "--Select an Account Type--";
            txtAccountNumber.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            btnDeposit.Enabled = false;
            btnPrintStatement.Enabled = false;
            btnShowBallance.Enabled = false;
            btnWithdrawal.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            groupBox2.Enabled = true;
        }

        // Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearUI();
        }

        // Welcome button
        private void btnWelcome_Click(object sender, EventArgs e)
        {


            if (txtAccount.Text == "--Select an Account Type--")
            {
                MessageBox.Show($"No account selected. Please select an account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccount.Focus();
              
            }
            else if (txtAccountNumber.Text == string.Empty)
            {
                MessageBox.Show($"Customer Account Number is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountNumber.Focus();
            }
            else if (txtFirstName.Text == string.Empty)
            {
                MessageBox.Show($"Customer First Name is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
            }
            else if (txtLastName.Text == string.Empty)
            {
                MessageBox.Show($"Customer Last Name is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
            }
            else if (txtAccount.SelectedIndex == 3 || txtAccount.SelectedIndex == 4)
            {
                MessageBox.Show($" Customer {txtFirstName.Text} {txtLastName.Text} does not have a(an) {txtAccount.Text}  account");
            }

            else if (txtLastName.Text != string.Empty && txtFirstName.Text != string.Empty
                && txtAccountNumber.Text != string.Empty && txtAccount.Text != "--Select an Account Type--")
            {
                btnDeposit.Enabled = true;
                btnPrintStatement.Enabled = true;
                btnShowBallance.Enabled = true;
                btnWithdrawal.Enabled = true;
                groupBox2.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Focus();
            }
          

              
               
                if (txtAccount.SelectedIndex == 1)
                {
                    mybankaccount = new CheckingAccount(txtAccountNumber.Text, txtFirstName.Text, txtLastName.Text);
                }
                else
                {
                    mybankaccount = new Saving(txtAccountNumber.Text, txtFirstName.Text, txtLastName.Text);
                }
            
        }


        //Deposit button
        private void btnDeposit_Click(object sender, EventArgs e)
        {   
            textBox4.Focus();
            try
            {

                if (textBox4.Text == string.Empty)
                {
                    //MessageBox.Show($"Please Enter A Deposit Amount",
                    //"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //textBox4.Focus();
                    //return;
                }
                var amount = Decimal.Parse(textBox4.Text);
                mybankaccount.DepositAmount(amount);
                MessageBox.Show("Was Deposited Successfully", 
               "Money Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Text = "";
            }
            catch (Exception ArgumentException)
            {
                
                MessageBox.Show(ArgumentException.Message, "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Withdrawal butto
        private void btnWithdrawal_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.textBox5.Text == string.Empty)
                {
                    MessageBox.Show($"Please Enter a Withdraw Amount",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox5.Focus();
                    return;
                }
                else
                {
                    var amount = Decimal.Parse(textBox5.Text);
                    mybankaccount.WithdrawAmount(amount, CheckingAccount.CheckingAccountType.Premier);
                    MessageBox.Show($"Was Wathdrawn Successfully",
                    "Money Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox5.Text = "";

                }
              
            }
            catch (Exception ArgumentException)
            {
                MessageBox.Show(ArgumentException.Message, "Implementation is Pending",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,
            //    "Money Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }
        // Print statement button
        private void btnPrintStatement_Click(object sender, EventArgs e)
        {

          mybankaccount.FirstName = txtFirstName.Text;
          mybankaccount.LastName = txtLastName.Text;
          mybankaccount.AccountNumber = txtAccountNumber.Text;
           // MessageBox.Show(BankAccount.PrintStatement());
            try
            {
                MessageBox.Show(mybankaccount.PrintStatement(), "Banking System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (NotImplementedException notImp)
            {
                MessageBox.Show(notImp.Message, "Implementation is Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        static void ImplementationisPending()
        {

            throw new NotImplementedException();
        }

        //public virtual string ShowBalance()  
        //{

        //    return string.Format($"Customer {txtAccountNumber.Text}  {txtFirstName.Text }{txtLastName.Text }has ${textBox4.Text} in Checking Account.");

        //}

        //Show ballance button
        private  void  btnShowBallance_Click(object sender, EventArgs e)
        {

            try
            {

                // BankAccount.Balance = Convert.ToInt32(textBox4.Text);
             mybankaccount.FirstName = txtFirstName.Text;
             mybankaccount.LastName = txtLastName.Text;
             mybankaccount.AccountNumber = txtAccountNumber.Text;

                // MessageBox.Show($"{txtFirstName.Text}  {txtLastName.Text} has ${myBankAccount.Balance} in the {txtAccount.Text} Account.", "Customer Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(mybankaccount.ShowBalance());
            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.Message);
            }
           
            
            
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            PopulateCombo(); 
        }
        public void PopulateCombo()
        {
            this.txtAccount.Items.AddRange(new object[]
             {
                "--Select an Account Type--",
                "Checking",
                "Savings",
                "Money Market",
                "Cerftificate of Deposit"
             });
            txtAccount.SelectedIndex = 0;
            btnDeposit.Enabled = false;
            btnPrintStatement.Enabled = false;
            btnShowBallance.Enabled = false;
            btnWithdrawal.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
