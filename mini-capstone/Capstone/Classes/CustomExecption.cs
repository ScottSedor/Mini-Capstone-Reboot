using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CustomExecption : Exception
    {
        public void InvalidEntryMainMenu()
        {
            Console.WriteLine("\nOops.  Please select a valid option.  ");
        }
    }

    public class MakeSaleMenuException : Exception
    {
        public void InvalidEntryMakeSaleMenu()
        {
            Console.WriteLine("\nOops.  Please select a valid option.  ");
        }
    }
}
