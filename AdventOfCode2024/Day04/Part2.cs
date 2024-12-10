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

                for (int i = 0; i < lines.Length - 2; i++)
                    for (int j = 0; j < lines.Length - 2; j++)
                        if (lines[i + 1][j + 1] == 'A')
                        {
                            if (lines[i][j] == 'M' && lines[i + 2][j + 2] == 'S' && lines[i + 2][j] == 'M' && lines[i][j + 2] == 'S')
                                total++;

                            if (lines[i][j] == 'M' && lines[i + 2][j + 2] == 'S' && lines[i + 2][j] == 'S' && lines[i][j + 2] == 'M')
                                total++;

                            if (lines[i][j] == 'S' && lines[i + 2][j + 2] == 'M' && lines[i + 2][j] == 'S' && lines[i][j + 2] == 'M')
                                total++;

                            if (lines[i][j] == 'S' && lines[i + 2][j + 2] == 'M' && lines[i + 2][j] == 'M' && lines[i][j + 2] == 'S')
                                total++;
                        }


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
