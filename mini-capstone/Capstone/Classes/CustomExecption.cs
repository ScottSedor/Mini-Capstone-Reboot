using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CustomException : Exception
    {
        public void InvalidEntryMainMenu()
        {
            Console.WriteLine("\n***ERROR*** \nOops.  Please select a valid option.\n***ERROR***");
        }
    }

    public class MakeSaleMenuException : Exception
    {
        public void InvalidEntryMakeSaleMenu()
        {
            Console.WriteLine("\n***ERROR*** \nOops.  Please select a valid option.\n***ERROR***");
        }
    }
    public class BalanceOver1000Exception : Exception
    {
        public void InvalidEntry()
        {
            Console.WriteLine("\n***ERROR*** \nOops.  Your balance may not exceed $1000.00\n***ERROR***");
        }
    }
    public class InsufficientFundsException : Exception
    {
        public void NotEnoughFunds()
        {
            Console.WriteLine("\n***ERROR*** \nPurchase total exceeds current balance.\n***ERROR*** \n");
        }
    }
}
