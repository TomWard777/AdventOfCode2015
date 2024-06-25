namespace AdventOfCode2023;

public class Day3
{
    public void Run()
    {
        var input = FileParser.ReadInputFromFile("Day3.txt");
        var directions = input.First().ToCharArray();

        var list1 = new List<char>();
        var list2 = new List<char>();

        for (var k = 0; k < directions.Length / 2; k++)
        {
            list1.Add(directions[2*k]);
            list2.Add(directions[2*k + 1]);
        }

        var h1 = GetVisitedHouses((0, 0), list1.ToArray());
        var h2 = GetVisitedHouses((0, 0), list2.ToArray());
        
        var ct = h1.Union(h2).Distinct().Count();

        Console.WriteLine($"Visited {ct} places.");
    }

    public List<(int, int)> GetVisitedHouses((int, int) startingPosition, char[]? directions)
    {
        var position = startingPosition;

        var visited = new List<(int, int)>();
        visited.Add(position);

        foreach (var step in directions)
        {
            position = Move(position, step);
            visited.Add(position);
        }

        return visited.Distinct().ToList();
    }

    public (int, int) Move((int, int) position, char step)
    {
        var x = position.Item1;
        var y = position.Item2;

        switch (step)
        {
            case '>':
                return (x + 1, y);
            case '<':
                return (x - 1, y);
            case 'v':
                return (x, y - 1);
            case '^':
                return (x, y + 1);
        }
        throw new Exception($"Invalid direction: {step}");
    }
}