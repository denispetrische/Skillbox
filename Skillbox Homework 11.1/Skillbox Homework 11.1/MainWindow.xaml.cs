using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Skillbox_Homework_11._1
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Data> database = new ObservableCollection<Data>();
        ObservableCollection<Data> visibleDatabase = new ObservableCollection<Data>();

        User user = new Undefined();
        AddDialog addEditDialog = new AddDialog();

        public MainWindow()
        {
            InitializeComponent();
            Data.GetPermissions(user);
            listView.ItemsSource = visibleDatabase;
            textBlock.Text = "Вход не выполнен";
            addEditDialog.buttonAccept.Click += new RoutedEventHandler(ButtonAccept);
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            if (user.GetType() != typeof(Undefined))
            {
                Data.OverridePetrmissions(true);

                var json = JsonConvert.SerializeObject(database);

                SaveFileDialog dialog = new SaveFileDialog();

                if (dialog.ShowDialog() == true)
                {
                    File.WriteAllText($@"{dialog.FileName}", json);
                }

                Data.OverridePetrmissions(false);
                statusBar.Text = "Сохранено";
            }
            else
            {
                statusBar.Text = "У вас нет прав для сохранения, смените пользователя";
            }
        }

        private void ButtonLoad(object sender, RoutedEventArgs e)
        {
            if (user.GetType() != typeof(Undefined))
            {
                OpenFileDialog dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == true)
                {
                    string foo = File.ReadAllText(dialog.FileName);
                    database.Clear();

                    var json = JsonConvert.DeserializeObject<ObservableCollection<Data>>(foo);

                    foreach (dynamic item in json)
                    {
                        database.Add(new Data(item.SecondName, item.FirstName, item.Patronymic, item.PhoneNumber, item.Passport));
                    }

                    VisibleInformation();
                }

                statusBar.Text = "Загружено";
            }
            else
            {
                statusBar.Text = "У вас нет прав на проведение данной операции, авторизуйтесь";
            }
        }

        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonHelp(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEdit(object sender, RoutedEventArgs e)
        {           
            if (listView.SelectedItem != null)
            {
                addEditDialog = new AddDialog();
                addEditDialog.buttonAccept.Click += new RoutedEventHandler(ButtonAccept);

                Data selected = (Data)listView.SelectedItem;                

                addEditDialog.textboxSecondName.Text = selected.SecondName;
                addEditDialog.textboxFirstName.Text = selected.FirstName;
                addEditDialog.textboxPatronymic.Text = selected.Patronymic;
                addEditDialog.textboxPhoneNumber.Text = selected.PhoneNumber;
                addEditDialog.textboxPassport.Text = selected.Passport;

                addEditDialog.Show();
            }
        }

        private void ButtonLogIn(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(radioButtonAdviser.IsChecked))
            {
                textBlock.Text = "Консультант";
                user = new Advisor();
                Data.GetPermissions(user);
            }
            if (Convert.ToBoolean(radioButtonLogOut.IsChecked))
            {
                textBlock.Text = "Вход не выполнен";
                user = new Undefined();
                Data.GetPermissions(user);
            }

            VisibleInformation();
        }

        private void VisibleInformation()
        {
            visibleDatabase.Clear();

            foreach (var item in database)
            {
                visibleDatabase.Add(new Data(item.SecondName, item.FirstName, item.Patronymic, item.PhoneNumber, item.Passport));
            }
        }

        private void ButtonAccept(object sender, RoutedEventArgs e)
        {
            database[listView.SelectedIndex].Edit(addEditDialog.textboxSecondName.Text,
                                                  addEditDialog.textboxFirstName.Text,
                                                  addEditDialog.textboxPatronymic.Text,
                                                  addEditDialog.textboxPhoneNumber.Text,
                                                  addEditDialog.textboxPassport.Text);

            VisibleInformation();
            addEditDialog.Hide();
        }
    }
}
