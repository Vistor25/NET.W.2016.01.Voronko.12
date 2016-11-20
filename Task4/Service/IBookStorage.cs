using System.Collections.Generic;

namespace Task4
{
    public interface IBookStorage
    {
        List<Book> Load();
        void Save(List<Book> bookList);
    }
}