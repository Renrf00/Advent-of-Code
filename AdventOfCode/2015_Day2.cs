public class Day2
{
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