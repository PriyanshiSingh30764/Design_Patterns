// The product interface
public interface IPizza
{
    void Prepare();
    void Bake();
    void Cut();
    void Box();
}

// Concrete product classes
public class CheesePizza : IPizza
{
    public void Prepare()
    {
        Console.WriteLine("Preparing Cheese Pizza");
    }

    public void Bake()
    {
        Console.WriteLine("Baking Cheese Pizza");
    }

    public void Cut()
    {
        Console.WriteLine("Cutting Cheese Pizza");
    }

    public void Box()
    {
        Console.WriteLine("Boxing Cheese Pizza");
    }
}

public class PepperoniPizza : IPizza
{
    public void Prepare()
    {
        Console.WriteLine("Preparing Pepperoni Pizza");
    }

    public void Bake()
    {
        Console.WriteLine("Baking Pepperoni Pizza");
    }

    public void Cut()
    {
        Console.WriteLine("Cutting Pepperoni Pizza");
    }

    public void Box()
    {
        Console.WriteLine("Boxing Pepperoni Pizza");
    }
}

// The factory class
public class PizzaFactory
{
    public IPizza CreatePizza(string type)
    {
        IPizza pizza = null;

        if (type.Equals("cheese"))
        {
            pizza = new CheesePizza();
        }
        else if (type.Equals("pepperoni"))
        {
            pizza = new PepperoniPizza();
        }
        // Add more types as needed

        return pizza;
    }
}

// Client code
public class PizzaStore
{
    private PizzaFactory factory;

    public PizzaStore(PizzaFactory factory)
    {
        this.factory = factory;
    }

    public IPizza OrderPizza(string type)
    {
        IPizza pizza = factory.CreatePizza(type);

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }
}

// Usage
class Program
{
    static void Main(string[] args)
    {
        var factory = new PizzaFactory();
        var store = new PizzaStore(factory);

        IPizza cheesePizza = store.OrderPizza("cheese");
        IPizza pepperoniPizza = store.OrderPizza("pepperoni");

        // Output will be the preparation steps for each pizza type
    }
}