using System;

class Person
{
    private string name;
    private int age;

    // Property for Name with validation
    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length >= 3)
                name = value;
            else
                throw new ArgumentException("Name must be at least 3 characters long and not empty.");
        }
    }

    // Property for Age with validation
    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0)
                age = value;
            else
                throw new ArgumentException("Age cannot be negative.");
        }
    }

    // Constructor to initialize the Person object
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Method to display information
    public void DisplayInfo()
    {
        Console.WriteLine($"My name is {Name} and I am {Age} years old.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        string nameInput;
        int ageInput;

        // Get valid name input
        while (true)
        {
            Console.Write("Enter the person's name: ");
            nameInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nameInput) && nameInput.Length >= 3)
                break;
            else
                Console.WriteLine("Invalid input. Name must be at least 3 characters long.");
        }

        // Get valid age input
        while (true)
        {
            Console.Write("Enter the person's age: ");
            if (int.TryParse(Console.ReadLine(), out ageInput) && ageInput >= 0)
                break;
            else
                Console.WriteLine("Invalid input. Age must be a non-negative number.");
        }

        // Create the Person object with valid input
        Person person = new Person(nameInput, ageInput);

        // Display the validated information
        person.DisplayInfo();
    }
}
