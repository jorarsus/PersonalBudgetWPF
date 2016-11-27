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

            //using (var ctx = new PersonalBudgetContext())
            //{
            //    Transaction trans = new Transaction { Value = 100, Date=DateTime.Now};

            //    ctx.Transactions.Add(trans);

            //    try
            //    {
            //        ctx.SaveChanges();
            //    }
            //    catch (DbUpdateException e)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            using (var ctx = new PersonalBudgetContext())
            {
                var Transactions = ctx.Transactions;

                var query = from transaction in Transactions
                            select new { transaction.Date, transaction.Value , AccountType = transaction.Account.Concept, transaction.Concept, transaction.Type.Description};

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
