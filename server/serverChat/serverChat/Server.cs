using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace serverChat
{
    public static class Server
    {
        public static List<Client> Clients = new List<Client>();
        public static void NewClient(Socket handle)
        {
            Client newClient = new Client(handle);
            Clients.Add(newClient);
            Console.WriteLine("Подключен новый клиент: {0}", handle.RemoteEndPoint);
        }
        public static void EndClient(Client client)
        {
            client.End();
            Clients.Remove(client);
            Console.WriteLine("Пользователь {0} отключился.", client.UserName);
        }
        public static void UpdateAllChats()
        {
            int countUsers = Clients.Count;
            for (int i = 0; i < countUsers; i++)
            {
                Clients[i].UpdateChat();
            }
        } 
    }
}
