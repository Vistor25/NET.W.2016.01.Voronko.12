using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
        //    Book book1 = new Book("Гордость и предубеждение", "Джейн Остин", 700, 1985, (decimal)23.44);
        //    Book book2=new Book("Тёмные начала", "Филип Пулман", 453, 1998, (decimal)12.45);
           BookListService booklist = new BookListService();
        //    booklist.AddBook(book1);
        //    booklist.AddBook(book2);
        //    booklist.SortBooksByTag(Book=>Book.Price);
        //    foreach (var VARIABLE in booklist)
        //    {
        //        Console.WriteLine(VARIABLE.ToString());
        //    }
        //    booklist.Save(new BookStorage("a"));
            booklist.Load(new BookStorage("a"));
            foreach (var VARIABLE in booklist)
            {
                Console.WriteLine(VARIABLE.ToString());
            }
            Console.ReadKey();
        }
    }
}
