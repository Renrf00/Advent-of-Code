using System.Numerics;

namespace AdventOfCode
{
    public class Day3
    {
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

            foreach(KeyValuePair<Vector2, int> pair in santaDeliveries)
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
            int housesWPresent;

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
    }
}