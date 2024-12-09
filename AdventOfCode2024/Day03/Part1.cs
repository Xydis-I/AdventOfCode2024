using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day03
{
    internal static class Part1
    {
        private const string FileLocation = @"..\..\..\Inputs\Day03_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var total = 0;

                var instructions = new List<string>();

                foreach (var line in lines)
                {
                    instructions.AddRange(Regex.Matches(line, "(mul\\()([0-9]{1,3})(,)([0-9]{1,3})(\\))").Select(m => m.Value).ToList());
                }

                foreach (var instruction in instructions)
                {
                    var mul = Regex.Match(instruction, "([0-9]{1,3})(,)([0-9]{1,3})").Value.Split(",");
                    total += int.Parse(mul[0]) * int.Parse(mul[1]);
                }

                Console.WriteLine("Day02_Part1 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
