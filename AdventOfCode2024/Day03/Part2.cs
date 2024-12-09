using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day03
{
    internal static class Part2
    {
        private const string FileLocation = @"..\..\..\Inputs\Day03_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var total = 0;

                var instructions = new List<Match>();

                foreach (var line in lines)
                {
                    instructions.AddRange(Regex.Matches(line, "(mul\\()([0-9]{1,3})(,)([0-9]{1,3})(\\))|(don't\\(\\))|(do\\(\\))"));
                }

                var isDisabled = false;

                foreach (var instruction in instructions)
                {
                    var isMul = true;

                    if (instruction.Value == "do()")
                    {
                        isDisabled = false;
                        isMul = false;
                    }

                    if (instruction.Value == "don't()")
                    {
                        isDisabled = true;
                        isMul = false;
                    }


                    if (!isDisabled && isMul)
                    {
                        total += int.Parse(instruction.Groups[2].Value) * int.Parse(instruction.Groups[4].Value);
                    }
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
