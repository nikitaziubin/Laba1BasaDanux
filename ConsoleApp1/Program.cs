using ConsoleApp1;
using System.Text.Json;
using System.IO;


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
    public static void FindMatch(int id, Matches matches, Stadium[] stadiums )
    {
        string josnFile = File.ReadAllText(Mpath);
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
    public static void Get_s(int id)
    {
        
    }

    private static void Main(string[] args)
    {
        var jsonConect = File.ReadAllText(Spath);
        var stadiums = JsonSerializer.Deserialize<Stadium[]>(jsonConect, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
        Matches matches = new Matches();
        //Console.WriteLine(stadiums[0]);
        while (true)
        {
            Console.WriteLine($"(0) Exit \n(1) Add match");
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

        }
    }
}