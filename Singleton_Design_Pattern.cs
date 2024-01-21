 using System;

namespace SDPattern
{
    public sealed class Singleton
    {
        private static Singleton instance; //1. You want the Singleton instance to be accessible wherever it's                                    needed in your application, hence the `public` keyword.
                                         //2. You want to enforce the rule that there's only one instance of the class, and sealing it with `sealed` prevents any kind of inheritance that could potentially create more instances.
        // Initialize the lock object
        private static readonly object obj = new object();

        private Singleton() { }

        public static Singleton GetInstance()
        {
            // Use lock to ensure thread safety
            lock (obj)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }
            // Return the instance outside of the lock
            return instance;
        }
    }

    class Program
    {
        public static void Main()
        {
            Singleton s1 = Singleton.GetInstance();
            // Optionally, you can print the instance to check if it works
            Console.WriteLine(s1);
        }
    }
}