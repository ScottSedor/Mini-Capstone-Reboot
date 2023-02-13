using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CustomExecption : Exception
    {
        public CustomExecption() { }
        public void InvalidEntry()
        {
            Console.WriteLine("\nOops.  Please select a valid option.  ");
        }
    }
}
