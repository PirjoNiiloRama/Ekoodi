using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClients
{
    public class Bank
    {
        private string _bankName;
        private List<BankAccount> _accounts;
        private Random _rnd;


        public Bank(string name)
        {
            _bankName = name;
            _accounts = new List<BankAccount>();
            _rnd = new Random();
        }

        // List<BankAccount> accountnumbers = new List<BankAccount>();
        //List<AccountEvent> accountevents = new List<AccountEvent>();

        //Methods

        //Return created new accountnumber
        public string CreateNewAccount()
        {
            BankAccount account = new BankAccount(AddRandom());
            _accounts.Add(account);
            // AccountEvent event = new AccountEvent(DateTime);
            // Console.Write(account.AccountNumber);
            // Console.ReadKey();
            return account.AccountNumber;
        }

        private string AddRandom()
        {
            //Creating Finnish bankaccount using 16 random numbers 
            string bNumber = "FI";
            int Value = 0;
            for (int i = 0; i < 16; i++)
            {
                Value = _rnd.Next(1, 10);
                bNumber += Value.ToString();
            }
            //Console.WriteLine(bNumber);
            //Console.ReadLine();
            return bNumber;
        }

        //Add event to account
        public void AddEvent(double sum, DateTime date, string accountNumber)
        {
            var bankAccount = (from account in _accounts
                              where account.AccountNumber == accountNumber
                              select account).FirstOrDefault();
            bankAccount.AddNewEvent(sum, date);
            bankAccount.Amount += sum;  //Add sum of event to amount of bankaccount
        }


        //Get all client's accountevents
        public List<AccountEvent> FindAccountEventsOfClient(string accountNumber)
        {
            var bankAccount = (from account in _accounts
                               where account.AccountNumber == accountNumber
                               select account).FirstOrDefault();
            return bankAccount.GetAccountEvents();
            // Console.Write();
        }

        //Get all client's accountevents between two timestamps
        public List<AccountEvent> FindAccountEventsBetweenBorders(string accountNumber,DateTime startTime, DateTime endTime)
        {
            var accountEvent = (from account in _accounts
                               where account.AccountNumber == accountNumber
                               select account).FirstOrDefault();
            List<AccountEvent> accountEvents = accountEvent.GetAccountEvents(startTime, endTime);
            return accountEvents;
            // Console.Write();
        }

        //Get amount of client's bankaccount
        public double GetBankAccountAmount(string accountNumber)
        {
            var bankAccount = (from account in _accounts
                               where account.AccountNumber == accountNumber
                               select account).FirstOrDefault();
            return bankAccount.GetAccountAmount();
        }


    }
}


