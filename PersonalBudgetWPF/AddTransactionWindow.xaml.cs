using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PersonalBudgetWPF.EF;
using System.Data.Entity;

namespace PersonalBudgetWPF
{
    /// <summary>
    /// Interaction logic for NewTransaction.xaml
    /// </summary>
    public partial class AddTransactionWindow : Window
    {
        private PersonalBudgetContext ctx;
        public PersonalBudgetContext Context { get; set; }

        public AddTransactionWindow(PersonalBudgetContext context)
        {
            InitializeComponent();

            ctx = context;

            var query = from account in ctx.Accounts
                        select account.Concept;

            AccountComboBox.ItemsSource = query.ToList();
        }


        public void AddTransactionEvent(object sender, RoutedEventArgs e)
        {
            // Get Account
            var query = from account in ctx.Accounts
                        where account.Concept == (String)AccountComboBox.SelectedItem
                        select account;

            Transaction transaction = new EF.Transaction() { Date = DatePicker.DisplayDate, Value=Convert.ToDecimal(textValue.Text), Concept = textConcept.Text, Account = query.First()};
            AddTransaction(transaction);
            this.Close();
        }

        public void AddTransaction(Transaction transaction)
        {
            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
