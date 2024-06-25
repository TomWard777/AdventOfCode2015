namespace AdventOfCode2023;

public class Day4
{
    public void Run()
    {
        ///var key = "abcdef";
        var key = "ckczppom";
        var n = 1;

        while (true)
        {
            var input = key + n.ToString();
            var hash = CreateMD5(input);

            if (hash.Substring(0, 5) == "000000")
            {
                Console.WriteLine($"\n\nInput: {n}");
                Console.WriteLine($"Hash: {hash}");
                break;
            }

            n++;

            if (n % 10000000 == 0)
            {
                Console.WriteLine($"\n\nInput: {n}");
                Console.WriteLine($"Hash: {hash}");
            }
        }
    }

    //// https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
    public static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes); // .NET 5 +

            // Convert the byte array to hexadecimal string prior to .NET 5
            // StringBuilder sb = new System.Text.StringBuilder();
            // for (int i = 0; i < hashBytes.Length; i++)
            // {
            //     sb.Append(hashBytes[i].ToString("X2"));
            // }
            // return sb.ToString();
        }
    }
}