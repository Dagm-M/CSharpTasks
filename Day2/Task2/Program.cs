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

        bool quit = false;
        while (!quit)
        {
            displayMenu();
            int input = Int32.Parse(Console.ReadLine());
            Console.Clear();

            if (input == 1)
            {
                Console.Write("Eneter the number of books that you want to Enter:   ");
                int num = Int32.Parse(Console.ReadLine());
                for (int i = 0; i < num; i++)
                {
                    Console.Write("Enter the book's Name:   ");
                    var BookName = Console.ReadLine();
                    Console.Write("Enter the book's Author:   ");
                    var BookAuthor = Console.ReadLine();
                    Console.Write("Enter the book's ISBN:   ");
                    var BookISBN = Console.ReadLine();
                    Console.Write("Enter the book's Publication year:   ");
                    int BookPublicationYear = Int32.Parse(Console.ReadLine());
                    Book book1 = new Book(BookName, BookAuthor, BookISBN, BookPublicationYear);
                    myLibrary.AddBook(book1);
                }
            }
            else if (input == 2)
            {
                Console.Write("Enter Book's ISBN:   ");
                string Isbn = Console.ReadLine();
                foreach (Book bookItem in myLibrary.Books)
                {
                    if (bookItem.ISBN == Isbn)
                    {
                        myLibrary.RemoveBook(bookItem);
                    }
                }
            }

            else if (input == 3)
            {
                Console.Write("Eneter the number of Media Item that you want to Enter:   ");
                int num = Int32.Parse(Console.ReadLine());
                for (int i = 0; i < num; i++)
                {
                    Console.Write("Enter the Media Title:   ");
                    var MediaTitle = Console.ReadLine();
                    Console.Write("Enter the Media Type:   ");
                    var MediaType = Console.ReadLine();
                    Console.Write("Enter the Duration:   ");
                    int MediaDuration = Int32.Parse(Console.ReadLine());
                    Book media1 = new MediaItem(MediaTitle, MediaType, MediaDuration);
                    myLibrary.AddMediaItem(media1);
                }
            }
            else if (input == 4)
            {
                Console.Write("Enter Book's ISBN:   ");
                string Isbn = Console.ReadLine();
                foreach (Book bookItem in myLibrary.Books)
                {
                    if (bookItem.ISBN == Isbn)
                    {
                        myLibrary.RemoveBook(bookItem);
                    }
                }
            }


        }


        MediaItem dvd = new MediaItem("dvditem", "dvd", 30);

        myLibrary.AddMediaItem(dvd);

        MediaItem cd = new MediaItem("cdItem", "CD", 90);

        myLibrary.AddMediaItem(cd);

        myLibrary.PrintCatalog();
    }
}