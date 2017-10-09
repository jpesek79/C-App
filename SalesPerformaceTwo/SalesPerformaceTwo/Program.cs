/* Program:     Sales Performance Part Two
 * Programmer:  Joseph Pesek
 * Date:        23 MAR 17
 * Description: Display user inputted 
 *              sales results for 6 salespeople and 3 products
                adding top sales result and any number of salespeople*/

using System;
using static System.Console;

namespace SalesPerformanceTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            double salesEntry = 0;
            int inputSales, inputSalespeople = 0;
            string productName = "";
            

            DisplayInstruction();

            //user enters sales and salesperson numbers
            Clear();
            Write("Please enter the number of sales per item: ");
            inputSales = int.Parse(ReadLine());
            double[,] sales = new double[inputSales, 3];
            Clear();
            Write("Enter the number of salespeople: ");
            inputSalespeople = int.Parse(ReadLine());
            string[,] salesPerson = new string[inputSalespeople, 2];
            double[,] salesTotal = new double[inputSalespeople, 3];
            //End  entering sales and salespeople

            Clear();
            EnterNames(salesPerson, inputSalespeople);

            
            GetSales(sales, salesPerson, salesEntry, productName, salesTotal, 
                inputSalespeople, inputSales);

            double overallSales = 0;
            DisplayOutput(salesPerson, productName, salesTotal, inputSalespeople, overallSales,
                inputSales);

        }
        public static void DisplayInstruction()
        {
            WriteLine("To receive sales analysis, you will need to enter the salesperson name,");
            WriteLine("first and last, as well as the various sales amounts per item.");
            ReadKey();
        }
        public static void EnterNames(string[,] salesPerson, int inputSalespeople)
        {
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < inputSalespeople; y++)
                {
                    string place = "";
                    if (x == 0)
                    { place = "first"; }
                    else
                    { place = "last"; }
                    Write("Enter the " + place + " name of saleperson " + (y + 1) + " : ");
                    salesPerson[y, x] = ReadLine();
                    Clear();
                }
            }
        }

        public static void GetSales(double[,] sales, string[,] salesPerson,
            double salesEntry, string productName, double[,] salesTotal, 
            int inputSalespeople, int inputSales)
        {
            for (int x = 0; x < 3; x++)
            {
                if (x == 0)
                {
                    productName = "Butcher Knife";
                }
                else if (x == 1)
                {
                    productName = "Paring Knife";
                }
                else
                {
                    productName = "Chef Knife";
                }

                for (int y = 0; y < inputSalespeople; y++)
                {
                    salesEntry = 0;
                    for (int z = 0; z < inputSales; z++)
                    {
                        
                        WriteLine("Enter sales for saleperson " + salesPerson[y, 1]);
                        Write("Sales for " + productName + ": ");
                        salesEntry = double.Parse(ReadLine());
                        sales[z, x] = salesEntry;
                        salesTotal[y, x] += salesEntry;
                        Clear();
                    }
                }

            }
        }
        public static void DisplayOutput(string[,] salesPerson,
            string productName, double[,] salesTotal, int inputSalespeople, double overallSales, 
                int inputSales)
        {
            Write("Salesperson:         ");
            for (int x = 0; x < inputSalespeople; x++)
            {
                Write(salesPerson[x, 1] + "  ");
            }
            WriteLine();
            Write("Butcher Knife:     ");
            for (int y = 0; y < inputSalespeople; y++)
            {
                Write("{0,7}", salesTotal[y, 0]);
            }
            WriteLine();

            Write("Paring Knife:      ");
            for (int y = 0; y < inputSalespeople; y++)
            {
                Write("{0,7}", salesTotal[y, 1]);
            }
            WriteLine();

            Write("Chefs Knife:       ");
            for (int y = 0; y < inputSalespeople; y++)
            {
                Write("{0,7}", salesTotal[y, 2]);
            }
            WriteLine();

            Write("Total:             ");
            for (int y = 0; y < inputSalespeople; y++)
            {
                overallSales = 0;
                overallSales += salesTotal[y, 0];
                overallSales += salesTotal[y, 1];
                overallSales += salesTotal[y, 2];
                Write("{0,7}", overallSales);
            }
            WriteLine();
            WriteLine();

            double bestSale = 0;
            string[,] tempSalesPerson = new string[inputSalespeople, 2];
            string bestProduct, tempName = "";
            int bestProdNum = 0;

            for (int y = 0; y < inputSalespeople; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    if (salesTotal[y, z] > bestSale)
                    {
                        bestSale = salesTotal[y, z];
                        tempSalesPerson[y, 1] = salesPerson[y, 1];
                        tempName = tempSalesPerson[y, 1];
                        bestProdNum = z;
                    }

                }
            }

            if (bestProdNum == 0)
            {
                bestProduct = "Butcher Knife";
            }
            else if (bestProdNum == 1)
            {
                bestProduct = "Paring Knife";
            } else
                bestProduct = "Chefs Knife";

            Write("The best sale was the " + bestProduct + " sold by " + tempName +
                " for " + bestSale);
            
            WriteLine();

            ReadKey();
        }
    }
}
