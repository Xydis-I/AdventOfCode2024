namespace AdventOfCode2024.Day06
{
    internal static class Part2
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
                var guardStartingPosition = (0, 0);
                var pathPositions = new List<(int, int)>();

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

                guardStartingPosition = guardPosition;

                try
                {
                    while (true)
                    {
                        var lastPosition = guardPosition;

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
                    }
                }
                catch (Exception e)
                {
                    map[guardPosition.Item1, guardPosition.Item2] = 'X';

                    for (int i = 0; i < mapSize; i++)
                        for (int j = 0; j < mapSize; j++)
                            if (map[i, j] == 'X')
                            {
                                pathPositions.Add((i, j));
                            }
                }

                pathPositions.Remove(guardStartingPosition);

                foreach (var pathPosition in pathPositions)
                {
                    var guardDistance = 0;
                    guardPosition = guardStartingPosition;
                    map[guardPosition.Item1, guardPosition.Item2] = '^';

                    try
                    {
                        map[pathPosition.Item1, pathPosition.Item2] = 'O';

                        while (guardDistance < 250000)
                        {
                            if (map[guardPosition.Item1, guardPosition.Item2] == '^')
                            {
                                if (map[guardPosition.Item1 - 1, guardPosition.Item2] != '#' && map[guardPosition.Item1 - 1, guardPosition.Item2] != 'O')
                                {
                                    map[guardPosition.Item1 - 1, guardPosition.Item2] = '^';
                                    map[guardPosition.Item1, guardPosition.Item2] = 'X';
                                    guardPosition.Item1--;
                                    guardDistance++;
                                }
                                else
                                    map[guardPosition.Item1, guardPosition.Item2] = '>';
                            }

                            if (map[guardPosition.Item1, guardPosition.Item2] == '>')
                            {
                                if (map[guardPosition.Item1, guardPosition.Item2 + 1] != '#' && map[guardPosition.Item1, guardPosition.Item2 + 1] != 'O')
                                {
                                    map[guardPosition.Item1, guardPosition.Item2 + 1] = '>';
                                    map[guardPosition.Item1, guardPosition.Item2] = 'X';
                                    guardPosition.Item2++;
                                    guardDistance++;
                                }
                                else
                                    map[guardPosition.Item1, guardPosition.Item2] = 'v';
                            }

                            if (map[guardPosition.Item1, guardPosition.Item2] == 'v')
                            {
                                if (map[guardPosition.Item1 + 1, guardPosition.Item2] != '#' && map[guardPosition.Item1 + 1, guardPosition.Item2] != 'O')
                                {
                                    map[guardPosition.Item1 + 1, guardPosition.Item2] = 'v';
                                    map[guardPosition.Item1, guardPosition.Item2] = 'X';
                                    guardPosition.Item1++;
                                    guardDistance++;
                                }
                                else
                                    map[guardPosition.Item1, guardPosition.Item2] = '<';
                            }

                            if (map[guardPosition.Item1, guardPosition.Item2] == '<')
                            {
                                if (map[guardPosition.Item1, guardPosition.Item2 - 1] != '#' && map[guardPosition.Item1, guardPosition.Item2 - 1] != 'O')
                                {
                                    map[guardPosition.Item1, guardPosition.Item2 - 1] = '<';
                                    map[guardPosition.Item1, guardPosition.Item2] = 'X';
                                    guardPosition.Item2--;
                                    guardDistance++;
                                }
                                else
                                    map[guardPosition.Item1, guardPosition.Item2] = '^';
                            }
                        }

                        map[pathPosition.Item1, pathPosition.Item2] = 'X';
                        total++;
                    }
                    catch (Exception e)
                    {
                        map[guardPosition.Item1, guardPosition.Item2] = 'X';
                        map[pathPosition.Item1, pathPosition.Item2] = 'X';
                    }
                }

                Console.WriteLine("Day05_Part2 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
