namespace AdventOfCode2024.Day03
{
    internal static class Part2
    {
        private const string FileLocation = @"..\..\..\Inputs\Day02_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var total = 0;
                foreach (var line in lines)
                {
                    var numbers = line.Split(" ").Select(int.Parse).ToList();



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
