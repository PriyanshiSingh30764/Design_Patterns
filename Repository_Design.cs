// Define a class named Person with two properties: Id and Name.
public class Person
{
    public int Id { get; set; }  // Property to store the ID of the person.
    public string Name { get; set; }  // Property to store the name of the person.
}

// Define an interface named IPersonRepository with methods for CRUD operations on Person objects.
public interface IPersonRepository
{
    IEnumerable<Person> GetAll();   // Get all persons.
    Person GetById(int id);         // Get a person by their ID.
    void Add(Person person);        // Add a new person.
    void Update(Person person);     // Update an existing person.
    void Delete(int id);            // Delete a person by their ID.
}

// Implement the IPersonRepository interface in the PersonRepository class.
public class PersonRepository : IPersonRepository
{
    // Private list to store instances of the Person class.
    private readonly List<Person> _people = new List<Person>();

    // Implement the GetAll method from the interface.
    public IEnumerable<Person> GetAll()
    {
        return _people;  // Return all persons in the list.
    }

    // Implement the GetById method from the interface.
    public Person GetById(int id)
    {
        // Use LINQ to find the first person with the specified ID.
        return _people.FirstOrDefault(p => p.Id == id);
    }

    // Implement the Add method from the interface.
    public void Add(Person person)
    {
        // Add the provided person to the list.
        _people.Add(person);
    }

    // Implement the Update method from the interface.
    public void Update(Person personToUpdate)
    {
        // Find the first person in the list with the same ID as personToUpdate.
        var person = _people.FirstOrDefault(p => p.Id == personToUpdate.Id);
        // If found, update the name of the person.
        if (person != null)
        {
            person.Name = personToUpdate.Name;
        }
    }

    // Implement the Delete method from the interface.
    public void Delete(int id)
    {
        // Find the first person in the list with the specified ID.
        var person = _people.FirstOrDefault(p => p.Id == id);
        // If found, remove the person from the list.
        if (person != null)
        {
            _people.Remove(person);
        }
    }
}

// Entry point of the program.
class Program
{
    static void Main(string[] args)
    {
        // Create an instance of our repository implementing IPersonRepository.
        IPersonRepository repository = new PersonRepository();

        // Add two Person objects to the repository.
        repository.Add(new Person { Id = 1, Name = "Alice" });
        repository.Add(new Person { Id = 2, Name = "Bob" });

        // Retrieve and display all persons in the repository.
        var people = repository.GetAll();
        Console.WriteLine("All people:");
        foreach (var person in people)
        {
            Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
        }

        // Update the name of the person with ID 2 to "Robert".
        Console.WriteLine("\nUpdating Bob's name to Robert...");
        repository.Update(new Person { Id = 2, Name = "Robert" });

        // Retrieve and display all persons after the update.
        people = repository.GetAll();
        Console.WriteLine("\nAll people after update:");
        foreach (var person in people)
        {
            Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
        }

        // Delete the person with ID 1 from the repository.
        Console.WriteLine("\nDeleting Alice...");
        repository.Delete(1);

        // Retrieve and display all persons after the deletion.
        people = repository.GetAll();
        Console.WriteLine("\nAll people after deletion:");
        foreach (var person in people)
        {
            Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
        }
    }
}