namespace AdventOfCode2024.Day07
{
    internal static class Part2
    {
        private const string FileLocation = @"..\..\..\Inputs\Day07_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n").ToList();

                var total = 0;

                Console.WriteLine("Day07_Part2 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
