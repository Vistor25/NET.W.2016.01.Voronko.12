using System;
using System.Collections.Generic;
using System.IO;

namespace Task4.ConsoleUI
{
    public class BookStorage : IBookStorage
    {
        private string FilePath { get; }

        public BookStorage(string path)
        {
            FilePath = path;
        }

        public List<Book> Load()
        {
            List<Book> list = new List<Book>();
            try
            {
                using (BinaryReader binaryReader = new BinaryReader(File.Open(FilePath, FileMode.Open)))
                {
                    while (binaryReader.PeekChar() > -1)
                    {
                        string Title = binaryReader.ReadString();
                        string Author = binaryReader.ReadString();
                        int NumberOfPages = binaryReader.ReadInt32();
                        int YearOfPublishing = binaryReader.ReadInt32();
                        decimal Price = binaryReader.ReadDecimal();
                        list.Add(new Book(Title, Author, NumberOfPages, YearOfPublishing, Price));
                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return list;
        }

        public void Save(List<Book> bookList)
        {
            try
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(FilePath, FileMode.OpenOrCreate)))
                {
                    foreach (var book in bookList)
                    {
                        binaryWriter.Write(book.Title);
                        binaryWriter.Write(book.Author);
                        binaryWriter.Write(book.NumberOfPages);
                        binaryWriter.Write(book.YearOfPublishing);
                        binaryWriter.Write(book.Price);
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}