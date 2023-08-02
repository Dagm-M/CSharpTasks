public class Book
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    public int PublicationYear { get; set; }

    public Book(string Title, string Author, string ISBN, int PublicationYear)
    {
        this.Title = Title;
        this.Author = Author;
        this.ISBN = ISBN;
        this.PublicationYear = PublicationYear;
    }
}

