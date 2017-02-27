using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace create_many_refnumbers
{
    class Program
    {
        static void Main(string[] args)

        {
            //Array declarations
            string refNum = String.Empty;
            string body = string.Empty;
            bool right = false;
            int x;
            string helpNum;
            int y = 1;
            decimal multiplyNum = 0;
            int checkDigit = 0;
            //int check = 0;
            string howMany = string.Empty;
            int numAmount = 0;


            do
            {
                do
                {
                    Console.WriteLine("How many referencenumbers do You need? ");
                    howMany = Console.ReadLine();
                    howMany.Trim();
                    if (int.TryParse(howMany, out x) == true)
                    {
                        numAmount = int.Parse(howMany);
                        if (numAmount == 0)
                        {
                            howMany = string.Empty;
                            Console.WriteLine("Your input was incorrect. Try again. ");
                        }
                    }
                    else
                    {
                        howMany = string.Empty;
                        Console.WriteLine("Your input was incorrect. Try again. ");
                    }

                }
                while (howMany == string.Empty);

                //Get a number
                Console.WriteLine("Give at least 3 numbers long body of referencenumber: ");
                refNum = Console.ReadLine();
                //Delete leading spaces
                refNum.Trim();

                helpNum = refNum;
                body = refNum;
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
                if ((refNum.Length + howMany.Length) < 4 || (refNum.Length + howMany.Length) > 20)
                {
                    Console.WriteLine("Wrong form of reference number. Give a new one. ");
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


            for (y = 1; y <= numAmount; y++)
            {


                do
                {
                    //Add index number to 
                    helpNum = body + y.ToString();
                    //Multiply numbers in string from right to left in order 7-3-1... and add to variable
                    int j = 7;
                    multiplyNum = 0;
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
                    //refNum += checkDigit.ToString();
                    refNum = body + y.ToString() + checkDigit.ToString();
                    right = true;
                    Console.Write(y.ToString() + ". reference number with chek number is " + refNum);
                    Console.WriteLine();
                    if (y == numAmount)
                    {
                        Console.ReadKey();
                    }
                }

                while (right == false);

            }
        }
    }
}
