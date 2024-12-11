namespace AdventOfCode2024.Day05
{
    internal static class Part2
    {
        private const string FileLocation = @"..\..\..\Inputs\Day05_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n").ToList();

                var rules = lines.Slice(0, lines.IndexOf(""));
                var updates = lines.Slice(lines.IndexOf("") + 1, lines.Count - rules.Count - 1);

                var total = 0;

                foreach (var pages in updates)
                {
                    var isSafe = true;
                    var pageList = pages.Split(",").ToList();

                    // Just running through it a few extra times does the trick
                    for (int i = 0; i < 5; i++)
                    {
                        foreach (var page in pageList.ToList())
                        {
                            var relevantRules = rules.FindAll(r => r.Contains(page));

                            foreach (var relevantRule in relevantRules)
                            {
                                var rulePages = relevantRule.Split("|");

                                if (pageList.Contains(rulePages[1]))
                                {
                                    if (pageList.IndexOf(rulePages[0]) > pageList.IndexOf(rulePages[1]))
                                    {
                                        var temp = pageList[pageList.IndexOf(rulePages[0])];
                                        pageList[pageList.IndexOf(rulePages[0])] = pageList[pageList.IndexOf(rulePages[1])];
                                        pageList[pageList.IndexOf(rulePages[1])] = temp;
                                        isSafe = false;
                                    }
                                }
                            }
                        }
                    }

                    if (!isSafe)
                        total += int.Parse(pageList[(int)MathF.Ceiling(pageList.Count / 2)]);
                }

                Console.WriteLine("Day05_Part2 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
