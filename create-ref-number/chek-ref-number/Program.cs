using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chek_ref_number
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array declarations
            string refNum = String.Empty;
            bool right = false;
            int x;
            string helpNum;
            // int y;
            decimal multiplyNum = 0;
            int checkDigit = 0;
            int check = 0;

            do
            {
                //Get a number
                Console.WriteLine("Give 3-19 digits long reference number with 1 digit long check number: ");
                refNum = Console.ReadLine();
                //Delete leading spaces
                refNum.Trim();
                helpNum = refNum;
                refNum = "";

                //Testing input string 
                for (int i = 0; i < (helpNum.Length); i++)
                {
                    //Only numbers are allowed 
                    if (int.TryParse(helpNum.Substring(i, 1), out x) == true)
                    {

                        refNum = refNum + x;
                    }
                    else
                    {
                        refNum = "0";
                    }

                }
                //Deleting leading zeros
                decimal refN = Decimal.Parse(refNum);
                refNum = refN.ToString();

                //Check if legth is wright
                if (refNum.Length < 4 || refNum.Length > 20)
                {
                    Console.WriteLine("Wrong type reference number. Give a new one. ");
                }
                else
                {
                    //Jump out of while loop

                    right = true;
                }
            }
            while (right == false);
            //Console.Write("Reference number is now " + refNum);
            //Console.ReadKey();
            //Take off the last digit
            //Multiply numbers in string from right to left in order 7-3-1... and add to variable

            do
            {
                int j = 7;

                for (int i = helpNum.Length - 1; i >= 0; i--)
                {
                    if (int.TryParse(helpNum.Substring(i, 1), out x) == true)
                    {

                        multiplyNum += (x * j);
                        if (i == helpNum.Length - 1)
                        {
                            check = x;
                            //i = i - 1;
                            multiplyNum = 0;
                        }
                        else if (j == 7)
                        {
                            j = 3;
                        }
                        else if (j == 3)
                        {
                            j = 1;
                        }
                        else
                        {
                            j = 7;
                        }
                    }

                }

                helpNum = multiplyNum.ToString();

                //Find the last digit of the number
                while (multiplyNum > 9)
                {
                    multiplyNum -= 10;
                }
                //Add the check number
                checkDigit = (int)multiplyNum;



                if (check == checkDigit)
                {
                    right = true;
                    Console.Write("Your referencenumber with chekcnumber is correct " + refNum);
                }
                else
                {
                   
                    refNum = refNum.Substring(0,refNum.Length-1)+checkDigit.ToString();
                    Console.Write("Your checknumber was incorrect. The right form is " + refNum);
                }
                Console.WriteLine();
                Console.ReadKey();
            }
            while (right == false);

        }
    }
}
