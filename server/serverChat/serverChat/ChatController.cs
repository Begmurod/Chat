﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverChat
{
    public static class ChatController
    {
        private const int _maxMessage = 100;
        public static List<message> Chat = new List<message>();
        public struct message
        {
            public string userName;
            public string data;
            public message(string name, string msg)
            {
                userName = name;
                data = msg;
            }
        }
        public static void AddMessage(string userName,string msg)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(msg)) return;
            int countMessages = Chat.Count;
            if (countMessages > _maxMessage) ClearChat();
            message newMessage = new message(userName, msg);
            Chat.Add(newMessage);
            Console.WriteLine("Новое сообщение от {0}.",userName);
            Server.UpdateAllChats();
        }
        public static void ClearChat()
        {
            Chat.Clear();
        }
        public static string GetChat()
        {
            string data = "#updatechat&";
            int countMessages = Chat.Count;
            if (countMessages <= 0) return string.Empty;
            for (int i = 0; i < countMessages; i++)
            {
                data += String.Format("{0}~{1}|", Chat[i].userName, Chat[i].data);
            }
            return data;
        }
    }
}
