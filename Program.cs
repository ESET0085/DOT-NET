
using System;

namespace PrinterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            EpsonPrinter epson = new EpsonPrinter();
            Console.WriteLine("--- Epson Printer ---");
            epson.PerformPrint(); 
            epson.Print();        

            Console.WriteLine(); 

            
            OtherPrinter other = new OtherPrinter();
            Console.WriteLine("--- Other Printer ---");
            other.PerformPrint(); 
            other.Print();        
        }
    }
}
