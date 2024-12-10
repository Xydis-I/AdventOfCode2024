namespace AdventOfCode2024.Day04
{
    internal static class Part2
    {
        private const string FileLocation = @"..\..\..\Inputs\Day04_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var total = 0;



                Console.WriteLine("Day04_Part2 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
