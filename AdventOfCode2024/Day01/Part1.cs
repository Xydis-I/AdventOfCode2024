namespace AdventOfCode2024.Day01
{
    internal static class Part1
    {
        private const string FileLocation = @"..\..\..\Inputs\Day01_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\n");

                var leftNumbers = new List<int>();
                var rightNumbers = new List<int>();
                var total = 0;
                foreach (var line in lines)
                {
                    var numbers = line.Split("   ");
                    leftNumbers.Add(int.Parse(numbers[0]));
                    rightNumbers.Add(int.Parse(numbers[1]));
                }

                leftNumbers.Sort();
                rightNumbers.Sort();

                for (int i = 0; i < leftNumbers.Count; i++)
                {
                    total += (int)MathF.Abs(leftNumbers[i] - rightNumbers[i]);
                }


                Console.WriteLine("Day01_Part1 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
