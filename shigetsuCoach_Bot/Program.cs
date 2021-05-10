﻿using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Contollers;
using shigetsuCoach_Bot.Models;
using shigetsuCoach_Bot.Models.Commands;
using shigetsuCoach_Bot.Models.Contollers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot
{
    class Program
    {
        public static bool isMainMenu = true;
        public static  bool botWorks = true;


        private static List<Command> commandsList;
        public static IReadOnlyList<Command> commands { get => commandsList.AsReadOnly(); }

        private static TelegramBotClient client;

           // public static async Task Main()
            public static void Main()
        {
            client = new TelegramBotClient(ConfigSettings.Token);

            commandsList = new List<Command>();
            // adding new commands
            commandsList.Add(new HelloCommand());
            commandsList.Add(new HelpCommand());
            commandsList.Add(new StartCommand());
            commandsList.Add(new AboutCommand());
            commandsList.Add(new CoachingCommand());
            commandsList.Add(new AboutCoachingCommand());
            commandsList.Add(new MainMenuCommand());
            commandsList.Add(new OrderTrainingCommand());


            client.StartReceiving();
            client.OnMessage += BotOnMessageReceived;
            client.OnCallbackQuery += BotOnCallBackQueryAsync;

            //  Console.ReadLine();
            while (botWorks)  { }
            client.StopReceiving();
        }

        private static  void BotOnCallBackQueryAsync(object sender, CallbackQueryEventArgs e)
        {
            var callback = e.CallbackQuery.Data;
            var msg = e.CallbackQuery.Message;

            Console.WriteLine($"message recieved: {callback}");

            foreach (var command in commands)
            {
                if (command.Name ==(callback))
                {
                    command.ExecuteAsync(msg, client);
                    break;
                }
            }
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {

           
            var msg = e.Message;

            if (msg.Type == Telegram.Bot.Types.Enums.MessageType.Contact)
            {
                await client.SendContactAsync(747969117, msg.Contact.PhoneNumber,msg.Contact.FirstName,msg.Contact.LastName);
                await client.SendTextMessageAsync(msg.Chat.Id, "Контакт добавлен в список", replyMarkup:new ReplyKeyboardRemove());
                MakeOrderController makeOrderController = new MakeOrderController(msg, client);
                makeOrderController.SetPayment();
            }
            else if(msg.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
            {
                var test = await client.GetFileAsync(msg.Photo[msg.Photo.Count() - 1].FileId);
                ConfirmPaymentContoller confirmPaymentContoller = new ConfirmPaymentContoller(msg, client);
                confirmPaymentContoller.SendShigetsuScreen(test);
                // await client.SendPhotoAsync(msg.Chat.Id, test.FileId);
                //     await client.SendPhotoAsync(443521128, test.FileId);
            }

            if (msg.Text != null)
            {
                Console.WriteLine($"message recieved: {msg.Text}");

                foreach (var command in commands)
                {
                    if (command.Contains(msg.Text))
                    {
                        command.ExecuteAsync(msg, client);
                        break;
                    }
                }
              
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}
