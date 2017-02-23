using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateRefNumber
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

            do
            {
                //Get a number
                Console.WriteLine("Give 3-19 digits long reference number: ");
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
                if (refNum.Length < 3 || refNum.Length > 19)
                {
                    Console.WriteLine("Wrong reference number. Give a new one. ");
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

            do
            {


                //Multiply numbers in string from right to left in order 7-3-1... and add to variable
                int j = 7;
                for (int i = helpNum.Length - 1; i >= 0; i--)
                {
                    if (int.TryParse(helpNum.Substring(i, 1), out x) == true)
                    {

                        multiplyNum += (x * j);

                        if (j == 7)
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
                refNum += checkDigit.ToString();

                right = true;
                Console.Write("Reference number with chek number is " + refNum);
                Console.WriteLine();
                Console.ReadKey();
            }
            while (right == false);

        }
    }
}
