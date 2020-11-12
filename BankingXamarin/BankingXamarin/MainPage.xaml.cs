using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Banking;

namespace BankingXamarin
{
    public partial class MainPage : ContentPage
    {
        private BankAccount _account;


        public MainPage()
        {
            InitializeComponent();

            Bank fnb = new Bank("First National Bank", 4324, "Kenilworth");
            Customer myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
            fnb.AddCustomer(myNewCustomer);

            _account = myNewCustomer.ApplyForBankAccount();
        }

        private void DepositButton_Clicked(object sender, EventArgs e)
        {
            //thix comment

            decimal depositAmount = 0;

            var valid = decimal.TryParse(DepositAmountEntry.Text, out depositAmount);
            var reason = DepositEntry.Text;
            if (valid)
            {
                _account.DepositMoney(depositAmount, DateTime.Now, "Stipend");

            }

            else
            {
                DisplayAlert("Validation Error", "Please Enter a Number", "Cancel");
            }

        }
    }
}
