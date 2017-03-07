using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankClients
{
    public class AccountEvent
    {
               
        private DateTime _timeStamp;
        private double _amount;
        //private Random _rnd;
        //private int _value;
    
        //Constructor
        public AccountEvent(DateTime timeStamp, double amount)
        {
            _timeStamp = timeStamp;
            _amount = amount;
        }

        public string AddNewEvent(double money, DateTime date)
        {
            _timeStamp=date;
            _amount = money;
            return (_timeStamp +" : " + _amount);

        }
        public DateTime TimeStamp => _timeStamp;

        public double Money => _amount;

        public override string ToString()
        {
            return _timeStamp + " : " + _amount;
        }

    }


}

