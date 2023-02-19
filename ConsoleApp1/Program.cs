using ConsoleApp1;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

internal class Program
{

    const string Mpath = "C:\\Users\\nikit\\source\\repos\\Laba1BasaDanux\\ConsoleApp1\\Matches.json";
    const string Spath = "C:\\Users\\nikit\\source\\repos\\Laba1BasaDanux\\ConsoleApp1\\Stadium.json";
    public static void addMatch(Matches matches)
    {
        
        Console.Write("Write homeTeamGoals: ");
        int homeTeamGoals = Convert.ToInt32(Console.ReadLine());
        Console.Write("Write visitorTeamGoals: ");
        int visitorTeamGoals = Convert.ToInt32(Console.ReadLine());
        Console.Write("Write division: ");
        int division = Convert.ToInt32(Console.ReadLine());
        Console.Write("Write date: ");
        string date = Console.ReadLine();
        Console.Write("Write stadiumID: ");
        int stadiumID = Convert.ToInt32(Console.ReadLine());
        Matche newMatch = new Matche(homeTeamGoals, visitorTeamGoals, division, date, stadiumID);
        
        matches.matchesList.Add(newMatch);

        var json = JsonSerializer.Serialize(matches, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(Mpath, json);
    }
    public static void FindMatch(int id, Matches matches, List<Stadium> stadiums )
    {
        foreach (var matche in matches.matchesList)
        {
            if (id == matche.id)
            {
                Console.WriteLine($"homeTeamGoals: {matche.homeTeamGoals}\n"+
                    $"visitorTeamGoals: {matche.visitorTeamGoals}\n" +
                    $"division: {matche.division}\n" +
                    $"date: {matche.date}\nStadium: ");
                foreach (var stadium in stadiums)
                {
                    if (stadium.id == matche.stadiumID)
                    {
                        Console.WriteLine($"\nadress: {stadium.adress}\n" +
                            $"name: {stadium.name}\n" +
                            $"capacity: {stadium.capacity}\n" +
                            $"max_capacity: {stadium.max_capacity}\n");
                    }
        }
                break;
            }
        }
        
    }
    public static void DelleteMach(int id, Matches matches)
    {
        matches.matchesList.RemoveAt(id);
        var json = JsonSerializer.Serialize(matches, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(Mpath, json);
    }
    public static void UpdateMatches(int id, Matches matches)
    {
        Console.Write($"Write item to change: ");
        string? item = Console.ReadLine();
        foreach (var matche in matches.matchesList)
        {
            if (id == matche.id)
            {
                switch (item)
                {
                    case "h":
                        Console.Write("Enater new homeTeamGoals: ");
                        int newitem = Convert.ToInt32(Console.ReadLine());
                        matche.homeTeamGoals = newitem;
                        break;
                    case "v":
                        Console.Write("Enater new visitorTeamGoals: ");
                        int vitem = Convert.ToInt32(Console.ReadLine());
                        matche.visitorTeamGoals = vitem;
                        break;
                    case "d":
                        Console.Write("Enater new division: ");
                        int ditem = Convert.ToInt32(Console.ReadLine());
                        matche.visitorTeamGoals = ditem;
                        break;
                    case "date":
                        Console.Write("Enater new data: ");
                        string data = Console.ReadLine();
                        matche.date = data;
                        break;
                    case "s":
                        Console.Write("Enater new stadiumID: ");
                        int sitem = Convert.ToInt32(Console.ReadLine());
                        matche.stadiumID = sitem;
                        break;
                    default:
                        Console.Write("Value didn't match earlier.");
                        break;
                }
                break;
            }
        }
        var json = JsonSerializer.Serialize(matches, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(Mpath, json);
    }
    public static void AddStadium(List<Stadium> stadiums)
    {
        Console.Write("Write adress: ");
        string adress = Console.ReadLine();
        Console.Write("Write name: ");
        string name = Console.ReadLine();
        Console.Write("Write capacity: ");
        int capacity = Convert.ToInt32(Console.ReadLine());
        Console.Write("Write max_capacity: ");
        int max_capacity = Convert.ToInt32(Console.ReadLine());
        Stadium stadium = new Stadium(adress, name, capacity, max_capacity);

        stadiums.Add(stadium);

        var json = JsonSerializer.Serialize(stadiums, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(Spath, json);
    }
    public static void FindStadium(int id, List<Stadium> stadiums)
    {
        foreach (var stadium in stadiums)
        {
            if (id == stadium.id)
            {
                Console.WriteLine($"\nadress: {stadium.adress}\n" +
                    $"name: {stadium.name}\n" +
                    $"capacity: {stadium.capacity}\n" +
                    $"max_capacity: {stadium.max_capacity}\n");
                    break;
            }
        }

    }
    public static void DelleteStadium(int id, List<Stadium> stadiums)
    {
        stadiums.RemoveAt(id);
        var json = JsonSerializer.Serialize(stadiums, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(Spath, json);
    }
    public static void UpdateStadium(int id, List<Stadium> stadiums)
    {
        Console.Write($"Write item to change: ");
        string? item = Console.ReadLine();
        foreach (var stadium in stadiums)
        {
            if (id == stadium.id)
            {
                switch (item)
                {
                    case "a":
                        Console.Write("Enater new adress: ");
                        string newitem = Console.ReadLine();
                        stadium.adress = newitem;
                        break;
                    case "n":
                        Console.Write("Enater new name: ");
                        string vitem = Console.ReadLine();
                        stadium.name = vitem;
                        break;
                    case "c":
                        Console.Write("Enater new capacity: ");
                        int ditem = Convert.ToInt32(Console.ReadLine());
                        stadium.capacity = ditem;
                        break;
                    case "m":
                        Console.Write("Enater new data: ");
                        int mitem = Convert.ToInt32(Console.ReadLine());
                        stadium.max_capacity = mitem;
                        break;
                    default:
                        Console.Write("Value didn't match earlier.");
                        break;
                }
                break;
            }
        }
        var json = JsonSerializer.Serialize(stadiums, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(Spath, json);
    }
    private static void Main(string[] args)
    {
        var jsonConect = File.ReadAllText(Spath);
        var stadiums = JsonSerializer.Deserialize<List<Stadium>>(jsonConect, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
        Matches matches = new Matches();
        //Console.WriteLine(stadiums[0]);
        while (true)
        {
            Console.WriteLine($"(0) Exit \n(1) Add Match\n(2) Get match\n(3) Dellete Match" +
                $"\n(4) Update Matches\n(5) Add Stadium\n(6) Get Stadium\n (7) Dellete Stadium\n(8) Update Stadium");
            int cumNum = Convert.ToInt32(Console.ReadLine());
            if (cumNum == 0)
            {
                break;
            }
            else if (cumNum == 1)
            {
                addMatch(matches);
            }
            else if (cumNum == 2)
            {
                Console.Write("Warite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                FindMatch(id, matches, stadiums);
            }
            else if (cumNum == 3)
            {
                Console.Write("Warite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                DelleteMach(id-1, matches);
            }
            else if (cumNum == 4)
            {
                Console.Write("Warite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                UpdateMatches(id, matches);
            }
            else if (cumNum == 5)
            {
                AddStadium(stadiums);
            }
            else if (cumNum == 6)
            {
                Console.Write("Warite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                FindStadium(id, stadiums);
            }
            else if (cumNum == 7)
            {
                Console.Write("Warite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                DelleteStadium(id - 1, stadiums);
            }
            else if (cumNum == 8)
            {
                Console.Write("Warite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                UpdateStadium(id, stadiums);
            }
        }
    }
}