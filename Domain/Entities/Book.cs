namespace Domain.Entities
{
    public class Book
    {
        public static List<Book> books = new List<Book>() { 
            new Book("TitleTest1","AuthorTest1","DespritionTest1"),
            new Book("TitleTest2","AuthorTest2","DespritionTest2"),
            new Book("TitleTest3","AuthorTest3","DespritionTest3"),
            new Book("TitleTest4","AuthorTest4","DespritionTest4"),
            new Book("TitleTest5","AuthorTest5","DespritionTest5"),
        };

        public static int Compteur { get; private set; } = 5;

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }

        public Book()
        {
            Compteur = Compteur + 1;
            Id = Compteur;
        }
        public Book(string? title, string? author, string? description)
        {
            Compteur = Compteur + 1;
            Id = Compteur;
            Title = title;
            Author = author;
            Description = description;
        }
        
    }
}
