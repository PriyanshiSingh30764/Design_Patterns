// First, we define an interface for our repository to abstract the operations.
public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

// Then, we create a concrete implementation of that repository for a specific entity type, like 'Book'.
public class BookRepository : IRepository<Book>
{
    private readonly List<Book> _books = new List<Book>();

    public IEnumerable<Book> GetAll()
    {
        // Return all books
        return _books;
    }

    public Book GetById(int id)
    {
        // Find a book by its ID
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public void Add(Book book)
    {
        // Add a new book to the collection
        _books.Add(book);
    }

    public void Update(Book book)
    {
        // Update an existing book
        var index = _books.FindIndex(b => b.Id == book.Id);
        if (index != -1)
        {
            _books[index] = book;
        }
    }

    public void Delete(Book book)
    {
        // Remove a book from the collection
        _books.Remove(book);
    }
}

// A simple Book class
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    // Other properties...
}

class Program
{
    static void Main(string[] args)
    {
        // Create a new instance of BookRepository
        IRepository<Book> bookRepository = new BookRepository();
        
        // Add a new book
        bookRepository.Add(new Book { Id = 1, Title = "The Catcher in the Rye", Author = "J.D. Salinger" });
        
        // Get all books and print their details
        foreach (var book in bookRepository.GetAll())
        {
            Console.WriteLine($"Book: {book.Title} by {book.Author}");
        }
    }
}