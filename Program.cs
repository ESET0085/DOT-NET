using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<string> bookTitles = new List<string>();
    static List<string> bookAuthors = new List<string>();
    static List<decimal> bookPrices = new List<decimal>();
    static List<int> bookQuantities = new List<int>();

    static List<string> saleCustomerNames = new List<string>();
    static List<string> saleBookTitles = new List<string>();
    static List<int> saleQuantities = new List<int>();
    static List<decimal> saleAmounts = new List<decimal>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n====== BOOK SHOP MENU ======");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Sell Book");
            Console.WriteLine("3. View Books");
            Console.WriteLine("4. View Sales Report");
            Console.WriteLine("5. Exit");
            Console.WriteLine("============================");
            Console.Write("Choice: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    SellBook();
                    break;
                case 3:
                    ViewBooks();
                    break;
                case 4:
                    ViewSalesReport();
                    break;
                case 5:
                    Console.WriteLine("Thanks for using Book Shop Management!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author: ");
        string author = Console.ReadLine();

        decimal price;
        while (true)
        {
            Console.Write("Enter price: ");
            if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0) break;
            Console.WriteLine("Invalid price, please enter a positive number.");
        }

        int quantity;
        while (true)
        {
            Console.Write("Enter quantity: ");
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0) break;
            Console.WriteLine("Invalid quantity, please enter a positive integer.");
        }

        int index = bookTitles.FindIndex(t => t.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (index != -1)
        {
            bookQuantities[index] += quantity;
            bookPrices[index] = price;
            bookAuthors[index] = author;
        }
        else
        {
            bookTitles.Add(title);
            bookAuthors.Add(author);
            bookPrices.Add(price);
            bookQuantities.Add(quantity);
        }

        Console.WriteLine("Book added successfully.");
    }

    static void SellBook()
    {
        if (bookTitles.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        Console.Write("Enter book title to sell: ");
        string titleToSell = Console.ReadLine();

        int index = bookTitles.FindIndex(t => t.Equals(titleToSell, StringComparison.OrdinalIgnoreCase));

        if (index == -1)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        int quantityToSell;
        while (true)
        {
            Console.Write("Enter quantity to sell: ");
            if (int.TryParse(Console.ReadLine(), out quantityToSell) && quantityToSell > 0) break;
            Console.WriteLine("Invalid quantity, please enter a positive integer.");
        }

        if (quantityToSell > bookQuantities[index])
        {
            Console.WriteLine($"Not enough stock. Available: {bookQuantities[index]}");
            return;
        }

        Console.Write("Enter customer name: ");
        string customer = Console.ReadLine();

        bookQuantities[index] -= quantityToSell;
        saleCustomerNames.Add(customer);
        saleBookTitles.Add(titleToSell);
        saleQuantities.Add(quantityToSell);
        saleAmounts.Add(quantityToSell * bookPrices[index]);

        Console.WriteLine($"Sold {quantityToSell} copies of '{titleToSell}' to {customer}.");
    }

    static void ViewBooks()
    {
        if (bookTitles.Count == 0)
        {
            Console.WriteLine("No books in inventory.");
            return;
        }

        Console.WriteLine("\n--- Book Inventory ---");
        Console.WriteLine("Title\t\tAuthor\t\tPrice\tQuantity");
        for (int i = 0; i < bookTitles.Count; i++)
        {
            Console.WriteLine($"{bookTitles[i]}\t{bookAuthors[i]}\t${bookPrices[i]:F2}\t{bookQuantities[i]}");
        }
    }

    static void ViewSalesReport()
    {
        if (saleCustomerNames.Count == 0)
        {
            Console.WriteLine("No sales to report.");
            return;
        }

        Console.WriteLine("\n--- Sales Report ---");
        Console.WriteLine("Customer\tBook\t\tQuantity\tAmount");
        decimal totalAmount = 0;
        for (int i = 0; i < saleCustomerNames.Count; i++)
        {
            Console.WriteLine($"{saleCustomerNames[i]}\t{saleBookTitles[i]}\t{saleQuantities[i]}\t${saleAmounts[i]:F2}");
            totalAmount += saleAmounts[i];
        }
        Console.WriteLine($"\nTotal Amount Spent: ${totalAmount:F2}");
    }
}
