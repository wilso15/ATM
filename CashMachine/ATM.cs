using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    public class ATM
    {
        List<List<int>> atmMoney = new List<List<int>>();
        List<int> ones = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        List<int> fives = new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
        List<int> tens = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        List<int> twenties = new List<int> { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20 };
        List<int> fifties = new List<int> { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
        List<int> hundreds = new List<int> { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
        public ATM()
        {
            atmMoney.Add(ones);
            atmMoney.Add(fives);
            atmMoney.Add(tens);
            atmMoney.Add(twenties);
            atmMoney.Add(fifties);
            atmMoney.Add(hundreds);
        }

        public string GetUserInput()
        {
            Console.WriteLine("Enter 'R' to restock the cash machine.");
            Console.WriteLine("Enter 'W' to withdraw that amount.");
            Console.WriteLine("Enter 'I' to view the inventory.");
            Console.WriteLine("Enter 'Q' to quit the application.");
            string userInput = Console.ReadLine();
            return userInput;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Machine Balance:");
            Console.WriteLine("$1 - " + ones.Count);
            Console.WriteLine("$5 - " + fives.Count);
            Console.WriteLine("$10 - " + tens.Count);
            Console.WriteLine("$20 - " + twenties.Count);
            Console.WriteLine("$50 - " + fifties.Count);
            Console.WriteLine("$100 - " + hundreds.Count);
        }

        public void RestockCashMachine()
        {
            while (ones.Count < 10)
            {
                ones.Add(1);
            }
            while (fives.Count < 10)
            {
                fives.Add(5);
            }
            while (tens.Count < 10)
            {
                tens.Add(10);
            }
            while (twenties.Count < 10)
            {
                twenties.Add(20);
            }
            while (fifties.Count < 10)
            {
                fifties.Add(50);
            }
            while (hundreds.Count < 10)
            {
                hundreds.Add(100);
            }
        }

        public void WithdrawDollarAmount()
        {
            try
            {
                int amountToWithdraw = 0;
                Console.WriteLine("How much would you like to withdraw?");
                string userDollarAmountToWithdraw = Console.ReadLine();
                amountToWithdraw = Int32.Parse(userDollarAmountToWithdraw);

                if (ones.Count > 0 && fives.Count > 0 && tens.Count > 0 && twenties.Count > 0 && fifties.Count > 0 && hundreds.Count > 0)
                {
                    while (amountToWithdraw > 100)
                    {
                        hundreds.Remove(100);
                        amountToWithdraw -= 100;
                    }
                    while (amountToWithdraw > 50)
                    {
                        fifties.Remove(50);
                        amountToWithdraw -= 50;
                    }
                    while (amountToWithdraw > 20)
                    {
                        twenties.Remove(20);
                        amountToWithdraw -= 20;
                    }
                    while (amountToWithdraw > 10)
                    {
                        tens.Remove(10);
                        amountToWithdraw -= 10;
                    }
                    while (amountToWithdraw > 5)
                    {
                        fives.Remove(5);
                        amountToWithdraw -= 5;
                    }
                    while (amountToWithdraw >= 1)
                    {
                        ones.Remove(1);
                        amountToWithdraw -= 1;
                    }
                }
                else
                {
                    Console.WriteLine("Failure: insufficient funds");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        public void AutomateTeller()
        {
            string userInput = "";
            while (userInput != "Q")
            {
                userInput = GetUserInput();
                switch (userInput)
                {
                    case "R":
                        RestockCashMachine();
                        DisplayInventory();
                        break;
                    case "W":
                        WithdrawDollarAmount();
                        DisplayInventory();
                        break;
                    case "I":
                        DisplayInventory();
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye.");
                        break;
                    default:
                        Console.WriteLine("Failure: Invalid Command");
                        break;
                }
            }
        }
    }
}
