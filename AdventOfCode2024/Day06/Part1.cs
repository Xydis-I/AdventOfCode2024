namespace AdventOfCode2024.Day06
{
    internal static class Part1
    {
        private const string FileLocation = @"..\..\..\Inputs\Day06_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n").ToList();

                var mapSize = lines.Count;

                var map = new char[mapSize, mapSize];
                var guardPosition = (0, 0);

                var total = 0;

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        map[i, j] = lines[i][j];
                        if (lines[i][j] == '^')
                            guardPosition = (i, j);
                    }
                }

                try
                {
                    while (true)
                    {
                        if (map[guardPosition.Item1, guardPosition.Item2] == '^')
                        {
                            if (map[guardPosition.Item1 - 1, guardPosition.Item2] != '#')
                            {
                                map[guardPosition.Item1 - 1, guardPosition.Item2] = '^';
                                map[guardPosition.Item1, guardPosition.Item2] = 'X';
                                guardPosition.Item1--;
                            }
                            else
                                map[guardPosition.Item1, guardPosition.Item2] = '>';
                        }

                        if (map[guardPosition.Item1, guardPosition.Item2] == '>')
                        {
                            if (map[guardPosition.Item1, guardPosition.Item2 + 1] != '#')
                            {
                                map[guardPosition.Item1, guardPosition.Item2 + 1] = '>';
                                map[guardPosition.Item1, guardPosition.Item2] = 'X';
                                guardPosition.Item2++;
                            }
                            else
                                map[guardPosition.Item1, guardPosition.Item2] = 'v';
                        }

                        if (map[guardPosition.Item1, guardPosition.Item2] == 'v')
                        {
                            if (map[guardPosition.Item1 + 1, guardPosition.Item2] != '#')
                            {
                                map[guardPosition.Item1 + 1, guardPosition.Item2] = 'v';
                                map[guardPosition.Item1, guardPosition.Item2] = 'X';
                                guardPosition.Item1++;
                            }
                            else
                                map[guardPosition.Item1, guardPosition.Item2] = '<';
                        }

                        if (map[guardPosition.Item1, guardPosition.Item2] == '<')
                        {
                            if (map[guardPosition.Item1, guardPosition.Item2 - 1] != '#')
                            {
                                map[guardPosition.Item1, guardPosition.Item2 - 1] = '<';
                                map[guardPosition.Item1, guardPosition.Item2] = 'X';
                                guardPosition.Item2--;
                            }
                            else
                                map[guardPosition.Item1, guardPosition.Item2] = '^';
                        }

                        //Console.Clear();

                        //for (int i = 0; i < mapSize; i++)
                        //{
                        //    for (int j = 0; j < mapSize; j++)
                        //        Console.Write(map[i, j]);
                        //    Console.Write("\n");
                        //}

                        //Thread.Sleep(100);
                    }
                }
                catch (Exception e)
                {
                    map[guardPosition.Item1, guardPosition.Item2] = 'X';

                    //Console.Clear();

                    //for (int i = 0; i < mapSize; i++)
                    //{
                    //    for (int j = 0; j < mapSize; j++)
                    //        Console.Write(map[i, j]);
                    //    Console.Write("\n");
                    //}

                    for (int i = 0; i < mapSize; i++)
                        for (int j = 0; j < mapSize; j++)
                            if (map[i, j] == 'X')
                                total++;
                }

                Console.WriteLine("Day06_Part1 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
