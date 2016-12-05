using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Task4.ConsoleUI
{
    public class XMLBookStorage : IBookStorage
    {
        public List<Book> Load()
        {
            List<Book> list = new List<Book>();
            XDocument xmldoc = XDocument.Load("Books.xml");
            foreach (var element in xmldoc.Element("Books").Elements("Book"))
            {
                string title = element.Attribute("Title:").Value;
                string author = element.Attribute("Author:").Value;
                int numberofpages = int.Parse(element.Attribute("NumberOfPages:").Value);
                int yearofpublishing =int.Parse(element.Attribute("YearOfPublishing:").Value);
                decimal price = decimal.Parse(element.Attribute("Price:").Value);
                list.Add(new Book(title,author,numberofpages,yearofpublishing,price));
            }
            return list;
        }

        public void Save(List<Book> bookList)
        {
            XDocument xmldoc = new XDocument(new XElement("Books"));
            foreach (var book in bookList)
            {
                XElement bookElement = new XElement("Book");
                XAttribute title = new XAttribute("Title:", book.Title);
                XAttribute author = new XAttribute("Author:", book.Author);
                XAttribute numberofpages = new XAttribute("NumberOfPages:", book.NumberOfPages);
                XAttribute yearofpublishing = new XAttribute("YearOfPublishing:", book.YearOfPublishing);
                XAttribute price = new XAttribute("Price:", book.Price);
                bookElement.Add(title, author, numberofpages, yearofpublishing, price);
                xmldoc.Add(bookElement);
            }
            xmldoc.Save("Books.xml");
        }
    }
}