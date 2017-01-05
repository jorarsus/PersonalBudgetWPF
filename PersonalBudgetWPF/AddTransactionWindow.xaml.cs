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
using PersonalBudgetWPF.Repos;
using System.Collections.ObjectModel;

namespace PersonalBudgetWPF
{
    /// <summary>
    /// Interaction logic for NewTransaction.xaml
    /// </summary>
    public partial class AddTransactionWindow : Window
    {

        public AddTransactionWindow()
        {
            InitializeComponent();

            using (var repo = new AccountRepo())
            {
                AccountComboBox.ItemsSource = repo.GetAllConcepts();
            }
            // Creates new Transaction for Binding and validation
            this.DataContext = new EF.Transaction() { Date = DateTime.Now };
        }

        /// <summary>
        /// Event handler for the 'Add transaction' button
        /// </summary>
        /// <remarks>
        /// Fills a transaction and inserts it in the database </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            if(!Utils.IsValid(TransactionGrid))
            {
                MessageBox.Show("Transaction is not valid");
                return;
            }

            // Get selected account
            Account selectedAccount;
            using (var repo = new AccountRepo())
            {
                selectedAccount = repo.GetAccountByConcept((String)AccountComboBox.SelectedItem);
            }

            // Creates transaction
            // TODO: this should use the Transaction created in the constructor
            Transaction transaction = new EF.Transaction() { Date = DatePicker.DisplayDate, Value = Convert.ToDecimal(textValue.Text), Concept = textConcept.Text, Account = selectedAccount };

            using(var repo = new TransactionRepo())
            {
                repo.Add(transaction);
            }

            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
