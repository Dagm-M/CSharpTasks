public class Library
{
    private string Name { get; set; }
    private string Address { get; set; }
    public List<Book> Books { get; }
    public List<MediaItem> MediaItems { get; }

    public Library(string name, string address)
    {
        this.Name = name;
        this.Address = address;
        this.Books = new List<Book>();
        this.MediaItems = new List<MediaItem>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Library: {Name}, Address: {Address}\n");
        Console.WriteLine("------------------------------------------");

        Console.WriteLine("");

        Console.WriteLine("******************************************");
        Console.WriteLine("Books:");
        foreach (var book in Books)
        {
            Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN}, Publication Year: {book.PublicationYear})");
        }
        Console.WriteLine("******************************************");

        Console.WriteLine("");

        Console.WriteLine("******************************************");
        Console.WriteLine("\nMedia Items:");
        foreach (var mediaItem in MediaItems)
        {
            Console.WriteLine($"{mediaItem.Title} ({mediaItem.MediaType}), Duration: {mediaItem.Duration} minutes");
        }
        Console.WriteLine("******************************************");
    }
}