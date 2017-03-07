using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankClients
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("OmaPankki");
            double amount;
            Random rnd = new Random();

            List<Client> clients = new List<Client>();

            // Creating some new clients and accounts  
            clients.Add(new Client("Ville", "Vallaton", bank.CreateNewAccount()));
            clients.Add(new Client("Maija", "Meikäläinen", bank.CreateNewAccount()));
            clients.Add(new Client("Liisa", "Luttinen", bank.CreateNewAccount()));


            int year = 0;
            int month = 0;
            int day = 0;
            int hour = 0;
            int minute = 0;
            int second = 0;

            for (int i = 0; i < clients.Count; i++)
            {
                // Adding money and timestamps to bankaccounts
                amount = (i + 2) * 1000.0;
                //Random rnd = new Random();
                //Add 3 new events to each client
                for (int j = 0; j < 3; j++)
                {
                    year = rnd.Next(2016,2017); //The bank was opened at 2016
                    month = rnd.Next(1, 12);
                    day = rnd.Next(1, 28);
                    hour = rnd.Next(1, 24);
                    minute = rnd.Next(1, 59);
                    second = rnd.Next(1, 59);

                    if (j == 0)
                    {
                        amount = (i + 2) * 1000.0;
                    }
                    if (i == 0 && j == 1)
                    {
                        amount = -1000.0;
                    }
                    if (i == 0 && j == 2)
                    {
                        amount = -800.0;
                    }
                    if (i == 1 && j == 1)
                    {
                        amount = 700.0;
                    }
                    if (i == 1 && j == 2)
                    {
                        amount = -80.0;
                    }
                    if (i == 2 && j == 1)
                    {
                        amount = -70.0;
                    }
                    if (i == 2 && j == 2)
                    {
                        amount = -20.0;
                    }

                    bank.AddEvent(amount, new DateTime(year, month, day, hour, minute, second), clients[i].BankAccount);
                }
                
            }
            
            // Listing accountevents of each client
            for (int i = 0; i < clients.Count; i++)
            {
                double sum = 0.0;
               
                List<AccountEvent> accountEvents = bank.FindAccountEventsOfClient(clients[i].BankAccount);
                sum = bank.GetBankAccountAmount(clients[i].BankAccount);

                for (int j = 0; j < accountEvents.Count; j++)
                {
                    if (j == 0 && accountEvents.Count > 0)
                    {
                        Console.WriteLine();
                        Console.Write(clients[i]);
                        Console.WriteLine();
                    }
                    //sum += accountEvents[j].Money;
                    Console.Write("\t\t" + accountEvents[j].Money + "\t\t" + accountEvents[j].TimeStamp);
                    Console.WriteLine();

                    if (j == accountEvents.Count - 1)
                    {
                        Console.Write("Total amount \t" + sum.ToString() + " ");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();

            //Listing accountevents of each client between timeborders
            DateTime endTime = DateTime.Now;
            year = endTime.Year-1;
            month = endTime.Month;
            day = endTime.Day;
            hour = endTime.Hour;
            minute = endTime.Minute;
            second = endTime.Second;
            DateTime startTime = new DateTime(year, month, day, hour, minute, second);
            Console.Write("Press Enter to get only bankevents that has happened during last year.");
            Console.WriteLine();
            Console.ReadKey();
            for (int i = 0; i < clients.Count; i++)
            {
                double sum = 0.0;

                List<AccountEvent> accountEvents = bank.FindAccountEventsBetweenBorders(clients[i].BankAccount, startTime, endTime);
                sum = bank.GetBankAccountAmount(clients[i].BankAccount);

                for (int j = 0; j < accountEvents.Count; j++)
                {
                    if (j == 0 && accountEvents.Count > 0)
                    {
                        Console.WriteLine();
                        Console.Write(clients[i]);
                        Console.WriteLine();
                    }
                    //sum += accountEvents[j].Money;
                    Console.Write("\t\t" + accountEvents[j].Money + "\t\t" + accountEvents[j].TimeStamp);
                    Console.WriteLine();

                    if (j == accountEvents.Count - 1)
                    {
                        Console.Write("Total amount \t" + sum.ToString() + " ");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();

 
        }
    }
}
