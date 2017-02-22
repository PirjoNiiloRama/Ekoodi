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
                Console.WriteLine("Give an old type bank account number: ");
                bban = Console.ReadLine();
                //Delete leading spaces
                bban.Trim();

                if (bban.Length < 9)
                {
                    message = "Accountnumber was too short. Give at least 9 digits. ";
                    Console.WriteLine(message);
                    Console.ReadKey();
                    iban = "";
                    right = true;
                               }
                else
                {
                    //Testing input string 
                    for (int i = 0; i < (bban.Length); i++)
                    {
                        //Only numbers are allowed 
                        if (int.TryParse(bban.Substring(i, 1), out x) == true)
                        {
                            //Add the digit to iban
                            iban = iban + x;
                        }
                    }
                    //Console.WriteLine(iban);
                    //Console.ReadKey();
                }
                // At least 9 numbers needed
                if (iban.Length >= 9)
                {
                    //how many zeros needed for string of 14 digits 
                    string middleIban = "";
                    for (int j = 0; j < (14 - iban.Length); j++)
                    { middleIban += "0"; }
                    right = false;
                    // If iban string begins with 4 or 5, zeros need to be added after 7. element, otherwise after 6. element
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
                        //Console.WriteLine(iban);
                        //Console.ReadKey();
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

            Console.WriteLine("IBAN code is " + iban);
            Console.ReadKey();
        }
    }
}

