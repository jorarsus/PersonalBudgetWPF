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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PersonalBudgetWPF.EF;
using System.Data.Entity.Infrastructure;

namespace PersonalBudgetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            using (var ctx = new PersonalBudgetContext())
            {
                var Transactions = ctx.Transactions;

                var query = from transaction in Transactions
                            select new { transaction.Date, transaction.Value , Account = transaction.Account.Concept, transaction.Concept};

                TransactionsDataGrid.ItemsSource = query.ToList();
            }
        }

        private void AddTransactionButtonClick(object sender, RoutedEventArgs e)
        {
            AddTransaction newTransaction = new AddTransaction();
            newTransaction.ShowDialog();
        }
    }
}
