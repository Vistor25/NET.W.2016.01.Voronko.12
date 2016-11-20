using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class BookListService:IEnumerable<Book>
    {
        private List<Book> BookList { get;  set; }

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

        public void Load(IBookStorage storage)
        {
            foreach (var book in storage.Load())
            {
               AddBook(book);
            }
        }

        public Book FindBookByTag(Predicate<Book> tag) => BookList.Find(tag);
        public void SortBooksByTag(Func<Book, object> tag) => BookList.OrderBy(tag);

        public IEnumerator<Book> GetEnumerator()
        {
            return BookList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}