namespace AdventOfCode2024.Day07
{
    internal static class Part1
    {
        private const string FileLocation = @"..\..\..\Inputs\Day07_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n").ToList();

                ulong total = 0;

                foreach (var line in lines)
                {
                    ulong result = ulong.Parse(line.Split(": ")[0]);
                    var variables = line.Split(": ")[1].Split(" ").Select(ulong.Parse).ToList();

                    var outcomes = new List<ulong>
                    {
                        variables[0]
                    };

                    for (int i = 1; i < variables.Count; i++)
                    {
                        var outcomeCount = outcomes.Count;
                        for (int j = 0; j < outcomeCount; j++)
                        {
                            outcomes.Add(outcomes[j] + variables[i]);
                            outcomes.Add(outcomes[j] * variables[i]);
                        }
                    }

                    foreach (var outcome in outcomes)
                    {
                        if (outcome == result)
                        {
                            total += result;
                            break;
                        }
                    }
                }

                Console.WriteLine("Day07_Part1 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
