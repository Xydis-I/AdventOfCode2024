namespace AdventOfCode2024.Day02
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

                    var isSafe = true;
                    bool? isIncreasing = null;
                    int lastNum = numbers[0];

                    for (int i = 1; i < numbers.Count && isSafe; i++)
                    {
                        if (lastNum == numbers[i])
                            isSafe = false;

                        var change = lastNum - numbers[i];

                        // The Null-Coalescing Operator, new to me, neat.
                        isIncreasing ??= change < 0;

                        if (isIncreasing != change < 0)
                            isSafe = false;

                        change = (int)MathF.Abs(change);

                        if (change > 3)
                            isSafe = false;


                        lastNum = numbers[i];
                    }

                    if (isSafe)
                        total++;

                    else
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            var newNumbers = new List<int>(numbers);
                            newNumbers.RemoveAt(i);

                            isSafe = true;
                            isIncreasing = null;
                            lastNum = newNumbers[0];

                            for (int j = 1; j < newNumbers.Count && isSafe; j++)
                            {
                                if (lastNum == newNumbers[j])
                                    isSafe = false;

                                var change = lastNum - newNumbers[j];

                                // The Null-Coalescing Operator, new to me, neat.
                                isIncreasing ??= change < 0;

                                if (isIncreasing != change < 0)
                                    isSafe = false;

                                change = (int)MathF.Abs(change);

                                if (change > 3)
                                    isSafe = false;


                                lastNum = newNumbers[j];
                            }

                            if (isSafe)
                            {
                                total++;
                                break;
                            }
                        }

                    }
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
