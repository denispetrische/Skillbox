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
using System.Media;
using System.Text.Json;
using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Skillbox_Homework_10._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramMessageClient client;

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeyPressedDown);
            client = new TelegramMessageClient(this, "");

            listView.ItemsSource = client.BotMessage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBlock.Text != "")
            {
                client.SendMessage(textBox.Text, textBlock.Text);
                textBox.Text = "";
            }
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            var json = JsonConvert.SerializeObject(client.BotMessage);

            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText($@"{dialog.FileName}", json);
            }           
        }

        private void ButtonLoad(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                string foo = File.ReadAllText(dialog.FileName);
                client.BotMessage.Clear();

                var json = JsonConvert.DeserializeObject<List<MessageLog>>(foo);

                foreach (dynamic item in json)
                {
                    client.BotMessage.Add(new MessageLog(item.time, item.id, item.message, item.firstName));
                }
            }
        }

        private void KeyPressedDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (textBlock.Text != "")
                {
                    client.SendMessage(textBox.Text, textBlock.Text);
                    textBox.Text = "";
                }
            }
        }
    }
}
