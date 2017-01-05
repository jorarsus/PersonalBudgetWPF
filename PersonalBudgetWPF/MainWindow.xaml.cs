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
using PersonalBudgetWPF.Repos;

namespace PersonalBudgetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // XAML element with the source of the transaction view
        CollectionViewSource transactionViewSource;

        public MainWindow()
        {
            InitializeComponent();

            transactionViewSource = (CollectionViewSource)(this.FindResource("transactionViewSource"));
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            UpdateView();
        }

        private void ButtonAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            AddTransactionWindow newTransaction = new AddTransactionWindow();
            newTransaction.ShowDialog();
            UpdateView();
        }

        /// <summary>
        /// Updates Transaction View
        /// </summary>
        private void UpdateView()
        {
            using (var repo = new TransactionRepo())
            {
                transactionViewSource.Source = repo.GetAll();
            }
        }

        private void ButtonSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            using (var repo = new TransactionRepo())
            {
                repo.SaveChanges();
            }
        }
    }
}
