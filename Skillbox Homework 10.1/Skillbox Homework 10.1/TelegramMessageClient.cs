using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Skillbox_Homework_10._1
{
    class TelegramMessageClient
    {
        public ObservableCollection<MessageLog> BotMessage;
        private MainWindow privateWindow;
        private TelegramBotClient bot;

        public TelegramMessageClient(MainWindow window, string token)
        {
            BotMessage = new ObservableCollection<MessageLog>();
            privateWindow = window;
            bot = new TelegramBotClient(token);
            var cansellationToken = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            bot.StartReceiving(updateHandler: HandleUpdateAsync, errorHandler: HandleErrorsAsync, receiverOptions: receiverOptions, cansellationToken.Token);
        }

        public void SendMessage(string text, string id)
        {
                bot.SendTextMessageAsync(id, text);
        }

        async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
            {
                return;
            }

            if (update.Message!.Type != MessageType.Text)
            {
                return;
            }

            Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} : {Convert.ToString(update.Message.From.Id)} {update.Message.Text} {update.Message.From.FirstName}");

            privateWindow.Dispatcher.Invoke(() =>
            {
                BotMessage.Add(new MessageLog(DateTime.Now.ToLongTimeString(), Convert.ToString(update.Message.From.Id), update.Message.Text, update.Message.From.FirstName));
            });
        }

        async Task HandleErrorsAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
