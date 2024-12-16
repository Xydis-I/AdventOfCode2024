namespace AdventOfCode2024.Day08
{
    internal static class Part2
    {
        private const string FileLocation = @"..\..\..\Inputs\Day08_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n").ToList();

                var mapSize = lines.Count;

                var map = new char[mapSize, mapSize];
                var signals = new HashSet<char>();

                var total = 0;

                for (int i = 0; i < mapSize; i++)
                    for (int j = 0; j < mapSize; j++)
                    {
                        map[i, j] = lines[i][j];
                        signals.Add(lines[i][j]);
                    }

                signals.Remove('.');

                foreach (var signal in signals)
                {
                    var locations = new List<(int y, int x)>();

                    for (int y = 0; y < mapSize; y++)
                        for (int x = 0; x < mapSize; x++)
                            if (map[y, x] == signal)
                                locations.Add((y, x));

                    foreach (var sourceLocation in locations)
                    {
                        foreach (var testLocation in locations)
                        {
                            if (sourceLocation == testLocation)
                                continue;

                            var yDif = sourceLocation.y - testLocation.y;
                            var xDif = sourceLocation.x - testLocation.x;

                            var yAmount = Math.Abs(yDif);
                            var xAmount = Math.Abs(xDif);

                            if (yDif <= 0 && xDif >= 0)
                            {
                                try
                                {
                                    var lastPoint = sourceLocation;

                                    while (true)
                                    {
                                        if (map[lastPoint.y - yAmount, lastPoint.x + xAmount] == '.')
                                        {
                                            map[lastPoint.y - yAmount, lastPoint.x + xAmount] = '#';
                                            lastPoint = (lastPoint.y - yAmount, lastPoint.x + xAmount);
                                        }
                                        else
                                            lastPoint = (lastPoint.y - yAmount, lastPoint.x + xAmount);
                                    }
                                }
                                catch (Exception e) { }

                                try
                                {
                                    var lastPoint = testLocation;

                                    while (true)
                                    {
                                        if (map[lastPoint.y + yAmount, lastPoint.x - xAmount] == '.')
                                        {
                                            map[lastPoint.y + yAmount, lastPoint.x - xAmount] = '#';
                                            lastPoint = (lastPoint.y + yAmount, lastPoint.x - xAmount);
                                        }
                                        else
                                            lastPoint = (lastPoint.y + yAmount, lastPoint.x - xAmount);
                                    }
                                }
                                catch (Exception e) { }
                            }

                            if (yDif <= 0 && xDif <= 0)
                            {
                                try
                                {
                                    var lastPoint = sourceLocation;

                                    while (true)
                                    {
                                        if (map[lastPoint.y - yAmount, lastPoint.x - xAmount] == '.')
                                        {
                                            map[lastPoint.y - yAmount, lastPoint.x - xAmount] = '#';
                                            lastPoint = (lastPoint.y - yAmount, lastPoint.x - xAmount);
                                        }
                                        else
                                            lastPoint = (lastPoint.y - yAmount, lastPoint.x - xAmount);
                                    }
                                }
                                catch (Exception e) { }

                                try
                                {
                                    var lastPoint = testLocation;

                                    while (true)
                                    {
                                        if (map[lastPoint.y + yAmount, lastPoint.x + xAmount] == '.')
                                        {
                                            map[lastPoint.y + yAmount, lastPoint.x + xAmount] = '#';
                                            lastPoint = (lastPoint.y + yAmount, lastPoint.x + xAmount);
                                        }
                                        else
                                            lastPoint = (lastPoint.y + yAmount, lastPoint.x + xAmount);
                                    }
                                }
                                catch (Exception e) { }
                            }
                        }
                    }
                }

                for (int y = 0; y < mapSize; y++)
                    for (int x = 0; x < mapSize; x++)
                        if (map[y, x] != '.')
                            total++;

                Console.WriteLine("Day08_Part2 Answer: " + total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
