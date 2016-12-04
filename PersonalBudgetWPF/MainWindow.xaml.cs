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
using System.Data.Entity;

namespace PersonalBudgetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonalBudgetContext ctx = new PersonalBudgetContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource transactionViewSource = (CollectionViewSource)(this.FindResource("transactionViewSource"));

            ctx.Transactions.Load();

            // Load data by setting the CollectionViewSource.Source property:
            transactionViewSource.Source = ctx.Transactions.Local;
        }

        private void AddTransactionButtonClick(object sender, RoutedEventArgs e)
        {
            AddTransactionWindow newTransaction = new AddTransactionWindow(ctx);
            newTransaction.ShowDialog();
            ctx.Transactions.Load(); // Update DbSet Local with the added (or not) Transaction
        }

        private void buttonSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateException)
            {

            }
        }
    }
}
