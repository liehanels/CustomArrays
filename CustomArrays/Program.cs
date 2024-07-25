namespace CustomArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TravelList<TravelEvent> holidays = new TravelList<TravelEvent>(10);
            bool stop = false;
            while(!stop)
            {
                Console.Clear();
                Console.WriteLine("Travel Planner and Co");
                Console.WriteLine("1. Add a holiday");
                Console.WriteLine("2. Remove a holiday");
                Console.WriteLine("3. Search for a holiday");
                Console.WriteLine("4. View All holidays");
                Console.WriteLine("5. Exit");
                Console.WriteLine("\nChoose an option...");
                var choice = Console.ReadLine();
                int index;

                switch (choice)
                {
                    case "1":
                    Console.WriteLine("Client Name?");
                    var clientName = Console.ReadLine();
                    Console.WriteLine("Destination?");
                    var location = Console.ReadLine();
                    bool add = true;
                    List<string> todo = new List<string>();
                    while (add)
                    {
                        Console.WriteLine("To do item?");
                        todo.Add(Console.ReadLine());
                        Console.WriteLine("Add another item? y/n");
                        if (Console.ReadLine().Equals("n")) { add = false; }
                    }
                    try
                    {
                        holidays.AddResize(new TravelEvent(clientName, location, todo.ToArray()));
                        Console.WriteLine($"Added {clientName}'s holiday to {location}");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                    }
                    catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
                    break;

                case "2":
                    holidays.Print();
                    Console.WriteLine("Delete which holiday.");
                    index = int.Parse(Console.ReadLine()) - 1;
                    holidays.RemoveAt(index);
                    Console.WriteLine("Removed successfully");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("Search which holiday by client name.");
                    var searchName = Console.ReadLine();
                    index = -1;
                    for (int i = 0; i < holidays.C; i++)
                    {
                        if (holidays.Get(i).clientName.Equals(searchName))
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index != -1)
                    {
                        Console.WriteLine($"Holiday at index {index}.\n{holidays.Get(index)}");
                    }
                    else
                    {
                        Console.WriteLine("Holiday not found.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.WriteLine("Holidays");
                    holidays.Print();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;

                case "5":
                    Console.WriteLine("Have a great holiday!");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadLine();
                    stop = true;
                    break;
                }
            }
        }
    }
}