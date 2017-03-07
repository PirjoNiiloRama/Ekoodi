using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClients
{
    public class Client
    {

        private string _firstName;
        private string _surName;
        private readonly string _bankAccount;

        public Client(string firstName, string surName,string bankAccount)
        {
            _firstName = firstName;
            _surName = surName;
            _bankAccount = bankAccount;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string SurName
        {
            get { return _surName; }
            set { _surName = value; }
        }

        public string BankAccount
        {
            get { return _bankAccount; }
        }

        public override string ToString()
        {
            return Print();

        }
        private string Print()
        {
            return "Name: " + _firstName + " " + _surName + "\t Accountnumber: " + _bankAccount;

        }

       

       

    }
}
