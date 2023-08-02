public class Program
{

    public static void displayMenu()
    {
        Console.WriteLine("Choose one of the opetions");
        Console.WriteLine("");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Input 1 to Add a book");
        Console.WriteLine("Input 2 to Remove a book");
        Console.WriteLine("Input 3 to Add a Media Item");
        Console.WriteLine("Input 4 to Remove a Media Item");
        Console.WriteLine("Input 0 to Quit");
        Console.WriteLine("-----------------------------------");
    }
    public static void Main()
    {

        string LibraryName;
        string LibraryAddress;
        do
        {
            Console.Write("Input the name of the Library: ");
            LibraryName = Console.ReadLine();
        } while (LibraryName == null);

        do
        {
            Console.Write("Input the address of the Library: ");
            LibraryAddress = Console.ReadLine();
        } while (LibraryAddress == null);




        Library myLibrary = new Library(LibraryName, LibraryAddress);

        // bool quit = false;
        // while (!quit)
        // {
        //     displayMenu();
        //     int input = Int32.Parse(Console.ReadLine());

        //     if (input == 1)
        //     {
        //         Console.Write("Enter the book's Name:   ");
        //         var BookName = Console.ReadLine();
        //         var BookTitle = Title;
        // var BookAuthor = Author;
        // var BookISBN = ISBN;
        // var BookPublicationYear = PublicationYear;
        //         Book book1 = new Book(BookName, "abebe", "1000012213", 2015);
        //         myLibrary.AddBook(book1);
        //     }


        // }
        // Console.Write("");


        Book book2 = new Book("chi", "kebede", "23453265", 2003);

        myLibrary.AddBook(book2);

        MediaItem dvd = new MediaItem("dvditem", "dvd", 30);

        myLibrary.AddMediaItem(dvd);

        MediaItem cd = new MediaItem("cdItem", "CD", 90);

        myLibrary.AddMediaItem(cd);

        myLibrary.PrintCatalog();
    }
}