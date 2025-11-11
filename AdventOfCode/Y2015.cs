using System.Numerics;

public class Y2015
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
    public static void WrapingPaper(string input)
    {
        int squarePaper = 0;
        int ribbonLenght = 0;
        string[] splitInput = input.Split('\n');

        foreach (string box in splitInput)
        {
            string[] splitBox = box.Split('x');

            int lenght = int.Parse(splitBox[0]);
            int width = int.Parse(splitBox[1]);
            int height = int.Parse(splitBox[2]);

            int[] twoMins = TwoMinimum(new int[] { lenght, width, height });

            squarePaper += 2 * lenght * width +
                            2 * width * height +
                            2 * lenght * height;

            squarePaper += Minimum(new int[] { lenght * width, width * height, height * lenght });

            ribbonLenght += 2 * twoMins[0] + 2 * twoMins[1];
            ribbonLenght += lenght * width * height;

        }

        Console.WriteLine("The elfs need: " + squarePaper + " square feet of wraping paper");
        Console.WriteLine("The elfs need: " + ribbonLenght + " feet of ribbon");
    }

public static void SantaDuo(string input)
    {
        bool isRoboSanta = false;
        string santa = "";
        Dictionary<Vector2, int> santaDeliveries;
        string roboSanta = "";
        Dictionary<Vector2, int> allDeliveries;

        foreach (char character in input)
        {
            if (isRoboSanta)
            {
                roboSanta += character;
                isRoboSanta = false;
            }
            else
            {
                santa += character;
                isRoboSanta = true;
            }
        }
        santaDeliveries = DeliverPresents(santa);
        allDeliveries = DeliverPresents(roboSanta);

        foreach (KeyValuePair<Vector2, int> pair in santaDeliveries)
        {
            if (allDeliveries.ContainsKey(pair.Key))
            {
                allDeliveries[pair.Key] += 1;
            }
            else
            {
                allDeliveries.Add(pair.Key, pair.Value);
            }
        }

        Console.WriteLine(allDeliveries.Count + " homes have at least 1 present");
    }
    public static Dictionary<Vector2, int> DeliverPresents(string input)
    {
        Dictionary<Vector2, int> housePresentGrid = new Dictionary<Vector2, int>();
        Vector2 currentLocation = new Vector2(0, 0);

        housePresentGrid.Add(new Vector2(0, 0), 1);

        foreach (char direction in input)
        {
            switch (direction)
            {
                case '^':
                    currentLocation += new Vector2(0, 1);
                    break;
                case '>':
                    currentLocation += new Vector2(1, 0);
                    break;
                case 'v':
                    currentLocation += new Vector2(0, -1);
                    break;
                case '<':
                    currentLocation += new Vector2(-1, 0);
                    break;
            }

            if (housePresentGrid.ContainsKey(currentLocation))
                housePresentGrid[currentLocation] += 1;
            else
                housePresentGrid.Add(currentLocation, 1);
        }

        return housePresentGrid;
        // Console.WriteLine(housePresentGrid.Count + " homes have at least 1 present");
    }

    private static int Minimum(int[] ints)
    {
        int min = ints[0];

        foreach (int i in ints)
        {
            if (i < min)
            {
                min = i;
            }
        }

        return min;
    }

    private static int[] TwoMinimum(int[] ints)
    {
        int[] mins = new int[2];
        List<int> intsNoMin = ints.ToList();

        mins[0] = Minimum(ints);

        intsNoMin.Remove(mins[0]);

        mins[1] = Minimum(intsNoMin.ToArray());

        return mins;
    }
}