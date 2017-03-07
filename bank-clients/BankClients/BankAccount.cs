using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClients
{
    public class BankAccount
    {


        private string _accountNumber;
        private List<AccountEvent> _accountEvents;
        private double _amount;

        public List<AccountEvent> AccountEvents
        {
            get { return _accountEvents; }
            set { _accountEvents = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public BankAccount(string accountNumber)
        {
            _accountNumber = accountNumber;
            _accountEvents = new List<AccountEvent>();
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        // Method adding events
        public void AddNewEvent(double sum, DateTime date)
        {
            AccountEvent accountEvent = new AccountEvent(date, sum);
            _accountEvents.Add(accountEvent);
        }

        public List<AccountEvent> GetAccountEvents()
        {
            return _accountEvents;
        }

        public List<AccountEvent> GetAccountEvents(DateTime startDate, DateTime endDate)
        {

            List<AccountEvent> accountEvent = (from account in _accountEvents
                             where account.TimeStamp >= startDate
                             where account.TimeStamp <= endDate
                             select account).ToList();
            return accountEvent;
        }



        public double GetAccountAmount()
        {
            return _amount;
        }

    }
}
