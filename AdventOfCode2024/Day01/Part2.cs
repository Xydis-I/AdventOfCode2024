namespace AdventOfCode2024.Day01
{
    internal static class Part2
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

                for (int i = 0; i < leftNumbers.Count; i++)
                {
                    total += leftNumbers[i] * rightNumbers.FindAll(n => n == leftNumbers[i]).Count;
                }


                Console.WriteLine("Day01_Part2 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
