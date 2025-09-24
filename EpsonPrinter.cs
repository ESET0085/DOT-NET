
using System;

namespace PrinterExample
{
    public class EpsonPrinter : IPrinter
    {
        
        public void PerformPrint()
        {
            Console.WriteLine("Epson printer is performing a print job.");
        }

        
        public void Print()
        {
            Console.WriteLine("Epson specific print command.");
        }
    }
}
