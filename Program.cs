using System;

class Program
{
    public string Name { get; set; }
    public int OutbreakLevel { get; set; }
    public List<int> Contacts { get; set; }

    public City()
    {
        Contacts = new List<int>();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of cities: ");
        int numCities = int.Parse(Console.ReadLine());

        List<City> cities = new List<City>();

        for (int i = 0; i < numCities; i++)
        {
            Console.Write("Enter the name of city {0}: ", i);
            string cityName = Console.ReadLine();

            Console.Write("Enter the number of cities in contact with {0}: ", cityName);
            int numContacts = int.Parse(Console.ReadLine());

            City city = new City();
            city.Name = cityName;

            for (int j = 0; j < numContacts; j++)
            {
                int contact;
                do
                {
                    Console.Write("Enter the city number in contact with {0}: ", cityName);
                    contact = int.Parse(Console.ReadLine());

                    if (contact < 0 || contact >= numCities)
                        Console.WriteLine("Invalid ID");
                } while (contact < 0 || contact >= numCities);

                city.Contacts.Add(contact);
            }

            cities.Add(city);
        }

        Console.WriteLine("\nCity number\tCity name\tCOVID-19 Outbreak Level");

        for (int i = 0; i < cities.Count; i++)
        {
            Console.WriteLine("{0}\t\t{1}\t\t{2}", i, cities[i].Name, cities[i].OutbreakLevel);
        }

        while (true)
        {
            Console.WriteLine("\nEnter the event (Outbreak, Vaccinate, Lockdown, Spread) or type 'Exit' to end the program:");
            string eventText = Console.ReadLine();

            if (eventText == "Exit")
                break;

            Console.Write("Enter the city number where the event occurred: ");
            int cityNumber = int.Parse(Console.ReadLine());

            if (eventText == "Outbreak")
            {
                cities[cityNumber].OutbreakLevel += 2;
                foreach (int contact in cities[cityNumber].Contacts)
                {
                    if (cities[contact].OutbreakLevel < 3)
                        cities[contact].OutbreakLevel += 1;
                }
            }
            else if (eventText == "Vaccinate")
            {
                cities[cityNumber].OutbreakLevel = 0;
            }
            else if (eventText == "Lockdown")
            {
                cities[cityNumber].OutbreakLevel = Math.Max(cities[cityNumber].OutbreakLevel - 1, 0);
                foreach (int contact in cities[cityNumber].Contacts)
                {
                    if (cities[contact].OutbreakLevel > 0)
                        cities[contact].OutbreakLevel -= 1;
                }
            }
            else if (eventText == "Spread")
            {
                foreach (City city in cities)
                {
                    if (city.OutbreakLevel > 0)
                    {
                        bool hasHigherOutbreak = false;
                        foreach (int contact in city.Contacts)
                        {
                            if (cities[contact].OutbreakLevel > city.OutbreakLevel)
                            {
                                hasHigherOutbreak = true;
                                break;
                            }
                        }
                        if (hasHigherOutbreak)
                            city.OutbreakLevel += 1;
                    }
                }
            }
            else
            {
        Console.WriteLine("\nCity number\tCity name\tCOVID-19 Outbreak Level");

        for (int i = 0; i < cities.Count; i++)
        {
            Console.WriteLine("{0}\t\t{1}\t\t{2}", i, cities[i].Name, cities[i].OutbreakLevel);
        }
    }
    }
    }
}