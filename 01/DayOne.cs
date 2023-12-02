using System.Collections.Generic;

namespace AdventOfCode2023
{
    internal class DayOne
    {
        public static void Solution()
        {
            string[] testInput = InputOutputHelper.GetInput(true, "01");
            PartOne(true, testInput);

            string[] input = InputOutputHelper.GetInput(false, "01");
            PartOne(false, input);

            PartTwo(true, testInput);
            PartTwo(false, input);
        }

        public static List<int> Reached = new();
        
        public static void PartOne(bool isTest, string[] input)
        {
            int result = 0;

            foreach (string line in input)
            {
                int amount = 0;

                foreach (string valueString in line.Split(", "))
                {
                    amount += int.Parse(valueString);
                }

                result += amount;
            }
            
            InputOutputHelper.WriteOutput<int>(isTest, result);
        }

        public static void PartTwo(bool isTest, string[] input)
        {
            int realResult = 0;
            int result = 0;
            Reached.Add(result);
            bool notFound = true;
            Reached = new List<int>();

            while (notFound)
            {
                foreach (string line in input)
                {
                    int amount = 0;


                    amount += int.Parse(line);

                    result += amount;

                    if (Reached.Contains(result))
                    {
                        realResult = result;
                        notFound = false;
                        break;
                    }

                    Reached.Add(result);
                }
            }

            InputOutputHelper.WriteOutput<int>(isTest, realResult);
        }
    }
}