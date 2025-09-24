
using System;

namespace PrinterExample
{
    public class OtherPrinter : IPrinter
    {
        
        public void PerformPrint()
        {
            Console.WriteLine("Other printer is performing a print job.");
        }

        public void Print()
        {
            Console.WriteLine("Other printer specific print command.");
        }
    }
}
