using BLL.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    internal class LibrairiService : ILibrairiService
    {
        public Book CreateBook(Book book)
        {
            return book;
        }

        public List<Book> GetAllBooks()
        {
            return new List<Book>();
        }

        public Book GetBookById(int id)
        {
            return new Book("", "", "");
        }
    }
}
