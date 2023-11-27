namespace Domain.Entities;

public class Book
{

    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }

    public Book()
    {
    }
    public Book(string? title, string? author, string? description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        Description = description;
    }

    public Book(Guid id, string? title, string? author, string? description)
    {
        Id = id;
        Title = title;
        Author = author;
        Description = description;
    }
}
