namespace AdventOfCode
{
    public class Day1
    {
        public static void CountFloors(String input)
        {
            int StartOnFloor = 0;
            int Floor;
            int position = 0;
            bool DidNotEnterBasement = true;

            Floor = StartOnFloor;
            foreach (char c in input)
            {
                position++;

                if (c == '(')
                {
                    Floor++;
                }
                else
                {
                    Floor--;
                }

                if (Floor < 0 && DidNotEnterBasement)
                {
                    DidNotEnterBasement = false;
                    Console.WriteLine("Santa first entered the basement at: " + position);
                }
            }
            Console.WriteLine("Santa ends at number: " + Floor);
        }
    }
}