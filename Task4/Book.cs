using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Book:IComparable<Book>, IEquatable<Book>
    {
        public string Title;
        public string Author;
        public int NumberOfPages;
        public int YearOfPublishing;
        public decimal Price;

        public Book(string title, string author, int numberOfPages, int yearOfPublishing, decimal price)
        {
            Title = title;
            Author = author;
            NumberOfPages = numberOfPages;
            YearOfPublishing = yearOfPublishing;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Book) obj);
        }

        public override string ToString()
            =>
            $"Title: {Title},\nAuthor: {Author}\nNumberOfPages: {NumberOfPages}\nYearOfPublishing: {YearOfPublishing}\nPrice: {Price.ToString("C", new CultureInfo("be-BY"))}.";

        public override int GetHashCode()
        {
            int HashCode = 0;
            HashCode = Title.GetHashCode()*2 + Author.GetHashCode()*3 + NumberOfPages.GetHashCode()*4 +
                       YearOfPublishing.GetHashCode()*5 + Price.GetHashCode()*6;

            return HashCode;
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null)) return 1;
            return NumberOfPages.CompareTo(other.NumberOfPages);
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Title.Equals(other.Title) && Author.Equals(other.Author) && NumberOfPages == other.NumberOfPages &&
                YearOfPublishing == other.YearOfPublishing && Price == other.Price;

        }
    }
}
