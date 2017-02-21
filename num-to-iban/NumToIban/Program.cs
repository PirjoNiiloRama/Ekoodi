using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumToIban
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = string.Empty;
            string bban = string.Empty;
            string iban = string.Empty;
            string teststr = string.Empty;
            bool right = false;
            //string numerot = "1234567890";
            int x;

            do
            {
                Console.WriteLine("Anna vanhanmuotoinen tilinumero: " + bban);
                bban = Console.ReadLine();
                //Delete leading spaces
                bban.Trim();

                if (bban.Length < 9)
                {
                    message = "Liian lyhyt tilinumero. Syötä vähintään 9 merkkiä. ";
                    Console.WriteLine(message);
                    Console.ReadKey();
                }

                else
                {
                    //System.Text.StringBuilder ib = new System.Text.StringBuilder(bban);
                    for (int i = 0; i < (bban.Length); i++)
                    {
                        if (int.TryParse(bban.Substring(i, 1), out x) == true)
                        //string x = numerot.Substring(ib[i], 1);
                        //if (x != null) 
                        {
                            //iban.Append(c);
                            iban = iban + x;
                        }
                    }

                    Console.WriteLine(iban);
                    Console.ReadKey();
                }
                if (iban.Length >= 9)
                {
                    string middleIban = "";
                    for (int j = 0; j < (14 - iban.Length); j++)
                    { middleIban += "0"; }
                    right = false;
                    if (iban.Substring(0, 1) == "4" || iban.Substring(0, 1) == "5")
                    {
                        string startIban = iban.Substring(0, 7);
                        string endIban = iban.Substring(7, iban.Length - 7);
                        iban = startIban + middleIban + endIban;
                        Console.WriteLine(iban);
                        Console.ReadKey();
                    }
                    else
                    {
                        string startIban = iban.Substring(0, 6);
                        string endIban = iban.Substring(6, iban.Length - 6);
                        iban = startIban + middleIban + endIban;
                        Console.WriteLine(iban);
                        Console.ReadKey();
                    }
                }
            } while (right == true);
            //Add Finnish bankcode in numbers and two zeros
            string testIban = iban + "151800";
            decimal check = 98 - (decimal.Parse(testIban) % 97);
            if (check < 10)
            {
                iban = "FI0" + check.ToString() + iban;
            }
            else
            {
                iban = "FI" + check.ToString() + iban;
            }

            Console.WriteLine(iban);
            Console.ReadKey();
        }

    }
}
}
