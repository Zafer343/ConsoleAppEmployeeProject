using System;

// Define the 'Employee' class with three properties: Id, FirstName, and LastName.
public class Employee
{
    // Properties to get/set employee ID, first name, and last name.
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Overload the '==' operator.
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        // Check if the first object is null using ReferenceEquals to avoid infinite recursion.
        if (ReferenceEquals(emp1, null))
        {
            return ReferenceEquals(emp2, null);
        }

        // Call the Equals method which is overridden below.
        return emp1.Equals(emp2);
    }

    // Overload the '!=' operator.
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        return !(emp1 == emp2);
    }

    // Override the 'Equals' method to compare employee ID's for equality.
    public override bool Equals(object obj)
    {
        var employee = obj as Employee;
        return employee != null && this.Id == employee.Id;
    }

    // Override GetHashCode as well when Equals is overridden.
    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        // Instantiate two Employee objects and assign values to their properties.
        Employee emp1 = new Employee { Id = 1, FirstName = "John", LastName = "Doe" };
        Employee emp2 = new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" };

        // Compare the two Employee objects using the overloaded '==' operator.
        bool areEqual = emp1 == emp2;

        // Display the result of the comparison.
        Console.WriteLine($"Are employees equal? {areEqual}");

        // Wait for the user to press a key before closing the console window.
        Console.ReadKey();
    }
}
