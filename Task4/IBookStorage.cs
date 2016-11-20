using System.Collections.Generic;

namespace Task4
{
    public interface IBookStorage
    {
        BookListService Load();
        void Save(List<Book> bookList);
    }
}