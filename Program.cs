using System.IO;
using System.Linq;
class Writer
{
    static void Main(string[] args)
    {
        using (StreamReader sr = new StreamReader(args[0]))
        {
            String Line = sr.ReadToEnd();
            Console.WriteLine(Line);
            List<string> colors = new List<string>();
            List<string> Results = new List<string>();
            Dictionary<string, int> colorCounts = new Dictionary<string, int>();
            Dictionary<string, int> resultCounts = new Dictionary<string, int>();

            foreach (string line in Line.Split())
            {
                if (line.Contains("win") || line.Contains("lose"))
                {
                    if (resultCounts.ContainsKey(line))
                    {
                        resultCounts[line]++;
                    }
                    else
                    {
                        resultCounts[line] = 1;
                    }
                }
                else if (line.Contains("red") || line.Contains("green") || line.Contains("yellow") || line.Contains("blue"))
                {
                    string cleanedLine = line.Replace("was", "").Replace("Was", "");


                    if (colorCounts.ContainsKey(cleanedLine))
                    {
                        colorCounts[cleanedLine]++;
                    }
                    else
                    {
                        colorCounts[cleanedLine] = 1;
                    }
                }

            }
            foreach (string result in Results)
            {
                Console.WriteLine(result);

            }
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }
            foreach (var kvp in colorCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine("\nResult Counts:");
            foreach (var kvp in resultCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
    }
}