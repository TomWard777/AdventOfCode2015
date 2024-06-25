namespace AdventOfCode2023;

public class Day2
{
    public void Run()
    {
        ///var input = FileParser.ReadInputFromFile("Test2.txt");
        var input = FileParser.ReadInputFromFile("Day2.txt");

        var sum = 0;

        foreach (var line in input)
        {
            var arr = line
            .Split('x')
            .Select(y => int.Parse(y))
            .Order()
            .ToArray();

            var area = 3*arr[0]*arr[1] + 2*arr[1]*arr[2] + 2*arr[0]*arr[2];
            var length = 2*(arr[0] + arr[1]) + arr[0]*arr[1]*arr[2];
            sum += length;

            Console.WriteLine(line);
            Console.WriteLine(area);
            Console.WriteLine(length);
        } 

        Console.WriteLine("\nTOTAL:");
        Console.WriteLine(sum);
    }
}