using System.Globalization;

namespace AdventOfCode2023
{
    internal class DayTwo
    {
        public static void Solution()
        {
            string[] testInput = InputOutputHelper.GetInput(true, "02");
            PartOne(true, testInput);

            string[] input = InputOutputHelper.GetInput(false, "02");
            PartOne(false, input);

            PartTwo(true, testInput);
            PartTwo(false, input);
        }

        public static void PartOne(bool isTest, string[] input)
        {
            int result = 0;
            int twiceCount = 0;
            int threeCount = 0;

            foreach (string line in input)
            {
                int count = GetCountOf(line);

                switch (count)
                {
                    case 1:
                        twiceCount++;
                        break;
                    
                    case 2:
                        threeCount++;
                        break;
                    
                    case 3:
                        twiceCount++;
                        threeCount++;
                        break;
                }
            }

            result = twiceCount * threeCount;
            
            InputOutputHelper.WriteOutput<int>(isTest, result);
        }

        // 0 if none, 1 if only twice, 2 if only three, 3 if both
        public static int GetCountOf(string line)
        {
            int count = 0;
            List<int> chars = new List<int>();

            for (int i = 0; i < 26; i++)
            {
                chars.Add(0);
            }
            
            foreach (char ch in line)
            {
                chars[ch - 'a']++;
            }

            if (chars.Contains(2))
            {
                if (chars.Contains(3))
                {
                    return 3;
                }

                return 1;
            }
            else
            {
                if (chars.Contains(3))
                {
                    return 2;
                }
                
                return 0;
            }
        }

        public static void PartTwo(bool isTest, string[] input)
        {
            string result = "";

            foreach (string line in input)
            {
                foreach (string lineOther in input)
                {
                    if(line != lineOther && GetString(out string box, line, lineOther))
                    {
                        result = box;
                    }
                }
            }
            
            InputOutputHelper.WriteOutput<string>(isTest, result);
        }

        public static bool GetString(out string box, string firstBox, string secondBox)
        {
            box = "";
            
            for (int i = 0; i < firstBox.Length; i++)
            {
                char firstBoxChar = firstBox[i];
                char secondBoxChar = secondBox[i];

                if (firstBoxChar == secondBoxChar)
                {
                    box += firstBoxChar;
                }
            }

            if (firstBox.Length - box.Length <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}