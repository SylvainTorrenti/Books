using BLL.Interfaces;
using Domain.Entities;

namespace BLL.Implementation;

internal class LibrairiService : ILibrairiService
{
    public static List<Book> books = new List<Book>() {
            new Book("TitleTest1","AuthorTest1","DespritionTest1"),
            new Book("TitleTest2","AuthorTest2","DespritionTest2"),
            new Book("TitleTest3","AuthorTest3","DespritionTest3"),
            new Book("TitleTest4","AuthorTest4","DespritionTest4"),
            new Book("TitleTest5","AuthorTest5","DespritionTest5"),
        };


    public Book CreateBook(Book book)
    {

        //id

        //ajoute à la liste 

        return book;
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }

    public Book GetBookById(Guid? id)
    {
        return new Book("", "", "");
    }

    public bool DeleteBook(Guid id)
    {
        return true;
    }

    public Book UpdateBook(Guid id)
    {
        return new Book(id,"", "", "");
    }
}
