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
using System.Collections.ObjectModel;

namespace Skillbox_Homework_13._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddClientDialog addClientDialog;
        OpenBillWindow openBillWindow = new OpenBillWindow();

        public MainWindow()
        {
            InitializeComponent();
            listView.ItemsSource = Client.clients;
            this.Closed += new EventHandler(ClosedWindow);
            openBillWindow.buttonNewDeposit.Click += new RoutedEventHandler(NewDeposit);
            openBillWindow.buttonNewNonDeposit.Click += new RoutedEventHandler(NewNonDeposit);
        }

        private void OpenAccount(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                openBillWindow = new OpenBillWindow();
                openBillWindow.Show();
            }
            else
            {
                statusBar.Text = "Выберите клиента для добавления счёта";
            }
        }

        private void CloseAccount(object sender, RoutedEventArgs e)
        {

        }

        private void TransferMoney(object sender, RoutedEventArgs e)
        {

        }

        private void AddMoney(object sender, RoutedEventArgs e)
        {

        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            addClientDialog = new AddClientDialog();
            addClientDialog.Show();
        }

        private void ClosedWindow(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NewDeposit(object sender, RoutedEventArgs e)
        {
            foreach (var item in Client.clients[listView.SelectedIndex].bills)
            {
                if (item.GetType() == typeof(DepositBill))
                {
                    statusBar.Text = "Пользователь уже содержит депозитный счёт";
                }
                else
                {
                    Client.clients[listView.SelectedIndex].bills.Add(new DepositBill());
                }
            }             
        }
         
        private void NewNonDeposit(object sender, RoutedEventArgs e)
        {
            foreach (var item in Client.clients[listView.SelectedIndex].bills)
            {
                if (item.GetType() == typeof(NonDepositBill))
                {
                    statusBar.Text = "Пользователь уже содержит недепозитный счёт";
                }
                else
                {
                    Client.clients[listView.SelectedIndex].bills.Add(new NonDepositBill());
                }
            }
        }
    }
}
