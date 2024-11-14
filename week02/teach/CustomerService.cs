using System.Runtime.InteropServices;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create a CustomerService queue with a max size of 0, which means the default value is 10.
        // Expected Result: 10
        Console.WriteLine("Test 1");
        CustomerService cs = new CustomerService(0);
        Console.WriteLine(cs.GetMaxSize());

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 2
        // Scenario:  Create a CustomerService queue with a max size of 5, and add one customer to the queue.
        // Expected Result: [size=1 max_size=5 => Charles (1)  : Dunno]
        Console.WriteLine("Test 2");
        CustomerService cs2 = new CustomerService(5);
        cs2.AddNewCustomer();
        Console.WriteLine(cs2.ToString());

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 3
        // Scenario:  Create a CustomerService queue with a max size of 1, and add two customers to the queue.
        // Expected Result: " Maximum Number of Customers in Queue " to return after entering the first customer detail 
        // preventing the second customer from being entered.
        Console.WriteLine("Test 3");
        CustomerService cs3 = new CustomerService(1);
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();



        // Defect(s) Found: More customers added more than the specified max size of queue. Corrected this comparison sign to greater than or equal to.
        // After correction, Only the first customer was entered after which the error message displayed.

        Console.WriteLine("=================");

        // Test 4
        // Scenario:  Create a CustomerService queue with a max size of 5, add two customer to the queue, and then serve the customer.
        // Expected Result:  Charles (2): hi  => that is the first customer added is served
        Console.WriteLine("Test 4");
        CustomerService cs4 = new CustomerService(5);
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.ServeCustomer();


        // Defect(s) Found: The _queue.RemoveAt was called before customer variable was declared. This resulted in a customer at index[0]
        // being removed and the next one called. Corrected the error by moving the _queue.RemoveAt to be called after the customer variable
        // has been declared. This ensured that the first customer is served before being removed.

        Console.WriteLine("=================");

        // Test 5
        // Scenario:  Create a a CustomerService queue of max-size 1 and and 1 new customer. then serve two customer
        // Expected Result: Error message to display on console after serving one customer
        Console.WriteLine("Test 5");
        CustomerService cs5 = new CustomerService(1);
        cs5.AddNewCustomer();
        cs5.ServeCustomer();
        cs5.ServeCustomer();

        // Defect(s) Found: Function does not not check if the queue is empty and an error is thrown before the second ServeCustomer is called. I added a condtion to check if 
        // queue length is les than 1, which triggers a console message and return statement. this fixed the bug.

        Console.WriteLine("=================");

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count < 1)
        {
            Console.WriteLine("No customer on queue");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }


    public int GetMaxSize()
    {
        return _maxSize;
    }
}