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
        }

        /// <summary>
        /// Event handler for the 'Add transaction' button
        /// </summary>
        /// <remarks>
        /// Fills a transaction and inserts it in the database </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddTransactionEvent(object sender, RoutedEventArgs e)
        {
            // Get selected account
            Account selectedAccount;
            using (var repo = new AccountRepo())
            {
                selectedAccount = repo.GetAccountByConcept((String)AccountComboBox.SelectedItem);
            }

            // Creates transaction
            Transaction transaction = new EF.Transaction() { Date = DatePicker.DisplayDate, Value = Convert.ToDecimal(textValue.Text), Concept = textConcept.Text, Account = selectedAccount };

            using(var repo = new TransactionRepo())
            {
                repo.Add(transaction);
            }

            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
