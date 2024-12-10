namespace AdventOfCode2024.Day04
{
    internal static class Part1
    {
        private const string FileLocation = @"..\..\..\Inputs\Day04_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var total = 0;

                for (int i = 0; i < lines.Length; i++)
                    for (int j = 0; j < lines.Length; j++)
                        if (lines[i][j] == 'X')
                            for (int mx = -1; mx < 2; mx++)
                                for (int my = -1; my < 2; my++)
                                    try
                                    {
                                        if (lines[i + mx][j + my] == 'M')
                                            try
                                            {
                                                if (lines[i + mx + mx][j + my + my] == 'A')
                                                    try
                                                    {
                                                        if (lines[i + mx + mx + mx][j + my + my + my] == 'S')
                                                            total += 1;
                                                    }
                                                    catch (Exception e) { }
                                            }
                                            catch (Exception e) { }
                                    }
                                    catch (Exception e) { }


                Console.WriteLine("Day04_Part1 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
