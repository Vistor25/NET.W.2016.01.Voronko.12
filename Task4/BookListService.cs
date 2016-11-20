using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class BookListService
    {
        private List<Book> BookList { get; }

        public BookListService()
        {
            BookList= new List<Book>();
        }

        public BookListService(IEnumerable<Book> list)
        {
            BookList = list.ToList();
        }

        public void AddBook(Book book)
        {
            if(ReferenceEquals(book,null)) throw new ArgumentException();
            if(BookList.Contains(book)) throw new ArgumentException("Такая книга уже есть в списке");
            BookList.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentException();
            if (!BookList.Remove(book)) throw new ArgumentException("Такой книги не существует");
        }

        public void Save(IBookStorage storage)
        {
            storage.Save(BookList);
        }

        public BookListService Load(IBookStorage storage)
        {
            storage.Load();
        }

        public Book FindBookByTag(Predicate<Book> tag) => BookList.Find(tag);
    }
}