using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;



namespace Skillbox_Homework_11._1
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Data> database = new ObservableCollection<Data>();
        ObservableCollection<Data> visibleDatabase = new ObservableCollection<Data>();

        User user = new Undefined();
        AddDialog addEditDialog = new AddDialog();

        bool isButtonAddPressed = false;

        public MainWindow()
        {
            InitializeComponent();
            Data.GetPermissions(ref user);
            listView.ItemsSource = visibleDatabase;
            textBlock.Text = "Вход не выполнен";
            addEditDialog.buttonAccept.Click += new RoutedEventHandler(ButtonAccept);
            this.Closed += new EventHandler(Shutdown);
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

                    Data.OverridePetrmissions(true);

                    var json = JsonConvert.DeserializeObject<ObservableCollection<Data>>(foo);

                    foreach (dynamic item in json)
                    {
                        database.Add(new Data(item.SecondName, item.FirstName, item.Patronymic, item.PhoneNumber, item.Passport));
                    }

                    Data.OverridePetrmissions(false);

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
            Application.Current.Shutdown();
        }

        private void ButtonHelp(object sender, RoutedEventArgs e)
        {
            statusBar.Text = "Функция не реализована, помощи не будет ))";
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        { 
            if (user.GetType() == typeof(Manager))
            {
                isButtonAddPressed = true;
                addEditDialog = new AddDialog();
                addEditDialog.buttonAccept.Click += new RoutedEventHandler(ButtonAccept);

                addEditDialog.textboxSecondName.Text = "";
                addEditDialog.textboxFirstName.Text = "";
                addEditDialog.textboxPatronymic.Text = "";
                addEditDialog.textboxPhoneNumber.Text = "";
                addEditDialog.textboxPassport.Text = "";

                addEditDialog.Show();
            }
            else
            {
                statusBar.Text = "У вас нет доступа к этой функции";
            }
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            if (user.GetType() == typeof(Manager))
            {
                if (listView.SelectedItem != null)
                {
                    database.Remove(database[listView.SelectedIndex]);
                    statusBar.Text = "Запись удалена";

                    VisibleInformation();
                }
                else
                {
                    statusBar.Text = "Выберите пункт для удаления";
                }
            }
            else
            {
                statusBar.Text = "У вас нет доступа к этой функции";
            }
        }

        private void ButtonEdit(object sender, RoutedEventArgs e)
        {           
            if (listView.SelectedItem != null && user.GetType() != typeof(Undefined))
            {
                addEditDialog = new AddDialog();
                addEditDialog.buttonAccept.Click += new RoutedEventHandler(ButtonAccept);

                Data selected = (Data)listView.SelectedItem;                

                addEditDialog.textboxSecondName.Text = selected.SecondName;
                addEditDialog.textboxFirstName.Text = selected.FirstName;
                addEditDialog.textboxPatronymic.Text = selected.Patronymic;
                addEditDialog.textboxPhoneNumber.Text = selected.PhoneNumber;
                addEditDialog.textboxPassport.Text = selected.Passport;

                if (user.IsSecondNamePermittedWrite == false)
                {
                    addEditDialog.textboxSecondName.IsEnabled = false;
                }

                if (user.IsFirstNamePermittedWrite == false)
                {
                    addEditDialog.textboxFirstName.IsEnabled = false;
                }

                if (user.IsPatronymicPermittedWrite == false)
                {
                    addEditDialog.textboxPatronymic.IsEnabled = false;
                }

                if (user.IsPhoneNumberPermittedWrite == false)
                {
                    addEditDialog.textboxPhoneNumber.IsEnabled = false;
                }

                if (user.IsPassportPermittedWrite == false)
                {
                    addEditDialog.textboxPassport.IsEnabled = false;
                }

                addEditDialog.Show();
            }
            else
            {
                if (user.GetType() == typeof(Undefined))
                {
                    statusBar.Text = "Авторизуйтесь для доступа к этой фукции";
                }
                else
                {
                    statusBar.Text = "Выберите элемент, кликнув по нему левой кнопкой мыши";
                }
            }
        }

        private void ButtonLogIn(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(radioButtonManager.IsChecked))
            {
                textBlock.Text = "Менеджер";
                user = new Manager();
                Data.GetPermissions(ref user);
                statusBar.Text = "Вход выполнен как <Менеджер>";
            }

            if (Convert.ToBoolean(radioButtonAdviser.IsChecked))
            {
                textBlock.Text = "Консультант";
                user = new Advisor();
                Data.GetPermissions(ref user);
                statusBar.Text = "Вход выполнен как <Консультант>";
            }

            if (Convert.ToBoolean(radioButtonLogOut.IsChecked))
            {
                textBlock.Text = "Вход не выполнен";
                user = new Undefined();
                Data.GetPermissions(ref user);
                statusBar.Text = "Выполнен выход";
                database.Clear();
            }

            VisibleInformation();
        }

        private void VisibleInformation()
        {
            visibleDatabase.Clear();

            foreach (var item in database)
            {
                visibleDatabase.Add(new Data(item.SecondName, item.FirstName, item.Patronymic, item.PhoneNumber, item.Passport, item.Time, item.WhatChanged, item.ChangeType, item.WhoChanged));
            }
        }

        private void ButtonAccept(object sender, RoutedEventArgs e)
        {
            string text;            

            if (isButtonAddPressed)
            {
                if (addEditDialog.textboxSecondName.Text == ""
                   || addEditDialog.textboxFirstName.Text == ""
                   || addEditDialog.textboxPatronymic.Text == ""
                   || addEditDialog.textboxPhoneNumber.Text == ""
                   || addEditDialog.textboxPassport.Text == "")
                {
                    text = "Элемент не добавлен, одно или несколько полей пустые";
                }
                else
                {
                    database.Add(new Data(addEditDialog.textboxSecondName.Text,
                                          addEditDialog.textboxFirstName.Text,
                                          addEditDialog.textboxPatronymic.Text,
                                          addEditDialog.textboxPhoneNumber.Text,
                                          addEditDialog.textboxPassport.Text));

                    text = "Элемент добавлен";
                }

                isButtonAddPressed = false;
            }
            else
            {
                if (addEditDialog.textboxSecondName.Text == ""
                   || addEditDialog.textboxFirstName.Text == ""
                   || addEditDialog.textboxPatronymic.Text == ""
                   || addEditDialog.textboxPhoneNumber.Text == ""
                   || addEditDialog.textboxPassport.Text == "")
                {
                    Data.OverridePetrmissions(true);
                    addEditDialog.textboxSecondName.Text = database[listView.SelectedIndex].SecondName;
                    addEditDialog.textboxFirstName.Text = database[listView.SelectedIndex].FirstName;
                    addEditDialog.textboxPatronymic.Text = database[listView.SelectedIndex].Patronymic;
                    addEditDialog.textboxPhoneNumber.Text = database[listView.SelectedIndex].PhoneNumber;
                    addEditDialog.textboxPassport.Text = database[listView.SelectedIndex].Passport;
                    Data.OverridePetrmissions(false);

                    text = "Некоторые поля пусты, изменения не приняты";
                }
                else
                {
                    text = "Элемент отредактирован";
                }

                database[listView.SelectedIndex].Edit(addEditDialog.textboxSecondName.Text,
                                                      addEditDialog.textboxFirstName.Text,
                                                      addEditDialog.textboxPatronymic.Text,
                                                      addEditDialog.textboxPhoneNumber.Text,
                                                      addEditDialog.textboxPassport.Text, ref user);
            }

            VisibleInformation();
            addEditDialog.Hide();
            statusBar.Text = text;
        }

        private void Shutdown(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
