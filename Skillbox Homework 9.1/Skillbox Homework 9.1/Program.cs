using System;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using Aspose.Html.DataScraping.MultimediaScraping;
using Aspose.Html.DataScraping.MultimediaScraping.YouTube;

namespace Skillbox_Homework_9._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "";
            string directory = @"c:\store\";

            HttpClient httpClient = new HttpClient();
            Dictionary<string, bool> clients = new Dictionary<string, bool>();
            string baseAdress = $@"https://api.telegram.org/bot{token}/";
            int updateID = 0;
            bool foo;

            while (true)
            {             
                string updateRequest = $"{baseAdress}getUpdates?offset={updateID}";
                string response = Request(updateRequest, httpClient).Result;

                var messages = JObject.Parse(response)["result"].ToArray();

                foreach (dynamic message in messages)
                {
                    updateID = Convert.ToInt32(message.update_id) + 1;

                    string userText = message.message.text;
                    string userID = message.message.from.id;
                    string userFirstName = message.message.from.first_name;
                    Console.WriteLine(message);

                    if (clients.TryGetValue(userFirstName, out foo))
                    {
                        Download(updateRequest, baseAdress, userID, httpClient, message, token, directory, userText);
                        clients.Remove(userFirstName);
                    }
                    else
                    {
                        switch (userText)
                        {
                            case "/start":
                                Start(baseAdress, userID, userFirstName, httpClient);
                                break;

                            case "/show":
                                Show();
                                break;

                            case "/crypto":
                                Crypto(baseAdress, userID, userFirstName, httpClient);
                                break;

                            case "/download":
                                clients.Add(userFirstName, true);
                                string text = $"Теперь загрузите в чат ваш документ, видео, фото либо ссылку на ютуб видео";
                                string send = $"{baseAdress}sendMessage?chat_id={userID}&text={text}";
                                Request(send, httpClient);
                                break;

                            default:
                                UnrecognisedCommand(baseAdress, userID, userFirstName, httpClient);
                                break;
                        }
                    }                    
                }

                Thread.Sleep(200);
            }
        }

        static void Start(string baseAdress, string userID, string userFirstName, HttpClient httpClient)
        {
            string text = $"Здравствуйте {userFirstName}, я обладаю следующим функционалом:\n\n" +
                          $"/show - чтобы вывести список всех скачанных файлов\n\n" +
                          $"/crypto - чтобы увидеть текущий курс криптовалюты\n\n" +
                          $"/download - после этой команды вы можете скинуть в чат ссылку на YouTube видео или просто любой документ, " +
                          $"после чего он будет загружен на сервер\n\n" +
                          $"Приятного пользования с:";

            string send = $"{baseAdress}sendMessage?chat_id={userID}&text={text}";
            Request(send, httpClient);
        }

        static void Show()
        {

        }

        static void Crypto(string baseAdress, string userID, string userFirstName, HttpClient httpClient)
        {
            string response = RequestString(httpClient).Result;
            var htmlCode = new HtmlDocument();
            htmlCode.LoadHtml(response);

            var currencyName = htmlCode.DocumentNode.SelectNodes("//*[@id='crypto_currency']/table/tbody/tr[1]/td[1]").Last();
            var currencyValue = htmlCode.DocumentNode.SelectNodes("//*[@id='crypto_currency']/table/tbody/tr[1]/td[2]").Last();

            string text = $"{currencyName.InnerText} = {currencyValue.InnerText.Split()[0]}";
            string send = $"{baseAdress}sendMessage?chat_id={userID}&text={text}";
            Request(send, httpClient);
        }

        static void Download(string uri, string baseAdress, string userID, HttpClient httpClient, dynamic message, string token, string directory, string userText)
        {
            try // загрузка документа
            {   
                string fileId = message.message.document.file_id;
                string fileName = message.message.document.file_name;
                string send = $@"https://api.telegram.org/bot{token}/getFile?file_id={fileId}";
                var response = Request(send, httpClient).Result;

                var jResponse = JObject.Parse(response)["result"];
                dynamic result = jResponse;

                string filePath = result.file_path;
                send = $@"https://api.telegram.org/file/bot{token}/{filePath}";
                response = Request(send, httpClient).Result;

                string downloadPath = Path.Combine(directory + fileName + ".txt");

                using (var writer = new StreamWriter(downloadPath))
                {
                    writer.WriteLine(response);
                }

                string text = $"Документ загружен!";
                send = $"{baseAdress}sendMessage?chat_id={userID}&text={text}";
                Request(send, httpClient);
            }
            catch (Exception)
            {

            }

            try // загрузка видео
            {
                string fileId = message.message.video.file_id;
                string fileName = message.message.video.file_name;
                string send = $@"https://api.telegram.org/bot{token}/getFile?file_id={fileId}";
                var response = Request(send, httpClient).Result;

                var jResponse = JObject.Parse(response)["result"];
                dynamic result = jResponse;

                string filePath = result.file_path;
                send = $@"https://api.telegram.org/file/bot{token}/{filePath}";
                response = Request(send, httpClient).Result;

                string downloadPath = Path.Combine(directory + fileName + ".mp4");

                using (var writer = new StreamWriter(downloadPath))
                {
                    writer.WriteLine(response);
                }

                string text = $"Видео загружено!";
                send = $"{baseAdress}sendMessage?chat_id={userID}&text={text}";
                Request(send, httpClient);
            }
            catch (Exception)
            {

            }

            try // загрузка фото
            {
                string fileId = message.message.photo[3].file_id;
                string fileName = fileId;
                string send = $@"https://api.telegram.org/bot{token}/getFile?file_id={fileId}";
                var response = Request(send, httpClient).Result;

                var jResponse = JObject.Parse(response)["result"];
                dynamic result = jResponse;

                string filePath = result.file_path;
                send = $@"https://api.telegram.org/file/bot{token}/{filePath}";
                response = Request(send, httpClient).Result;

                string downloadPath = Path.Combine(directory + fileName);

                using (var writer = new StreamWriter(downloadPath))
                {
                    writer.WriteLine(response);
                }

                string text = $"Фото загружено!";
                send = $"{baseAdress}sendMessage?chat_id={userID}&text={text}";
                Request(send, httpClient);
            }
            catch (Exception)
            {

            }

            try // загрузка аудиосообщений
            {
                string fileId = message.message.voice.file_id;
                string fileName = message.message.voice.file_name;
                string send = $@"https://api.telegram.org/bot{token}/getFile?file_id={fileId}";
                var response = Request(send, httpClient).Result;

                var jResponse = JObject.Parse(response)["result"];
                dynamic result = jResponse;

                string filePath = result.file_path;
                send = $@"https://api.telegram.org/file/bot{token}/{filePath}";
                response = Request(send, httpClient).Result;

                string downloadPath = Path.Combine(directory + fileName);

                using (var writer = new StreamWriter(downloadPath))
                {
                    writer.WriteLine(response);
                }

                string text = $"Аудио загружено!";
                send = $"{baseAdress}sendMessage?chat_id={userID}&text={text}";
                Request(send, httpClient);
            }
            catch (Exception)
            {

            }

            try // загрузка ютуб видео
            {
                string link = $"{userText}";

                var multimediaScraper = new MultimediaScraper();
                var multimedia = multimediaScraper.GetMultimedia(link);
                var videoInfo = multimedia.CollectVideoInfo();
                var youTubeVideoInfo = videoInfo as YouTubeVideoInfo;

                string fileName = videoInfo.Title;

                if (youTubeVideoInfo != null)
                {
                    var format = youTubeVideoInfo.Formats.OrderBy(f => f.Bitrate).First(f => f.AudioCodec != null && f.VideoCodec != null);
                    var extension = string.IsNullOrEmpty(format.Extension) ? "mp4" : format.Extension;
                    var filePath = Path.Combine(directory + fileName + "." + extension);
                    multimedia.Download(format, filePath);

                    string text = $"Ютуб видео загружено!";
                    string send = $"{baseAdress}sendMessage?chat_id={userID}&text={text}";
                    Request(send, httpClient);
                }
            }
            catch (Exception)
            {

            }

            Console.WriteLine("Файл записан");
        }

        static void UnrecognisedCommand(string baseAdress, string userID, string userFirstName, HttpClient httpClient)
        {
            string text = $"Здравствуйте {userFirstName}, для вывода списка команд введите /start";
            string answer = $"{baseAdress}sendMessage?chat_id={userID}&text={text}";
            Request(answer, httpClient);
        }

        static async Task<string> Request(string uri, HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseText = await response.Content.ReadAsStringAsync();
            return responseText;
        }

        static async Task<string> RequestString(HttpClient httpClient)
        {
                var response = await httpClient.GetStringAsync("https://myfin.by/crypto-rates");
                return response;
        }
    }
}
