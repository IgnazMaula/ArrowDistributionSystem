namespace ArrowDistributionSystem
{
    public class Program
    {
        public static void Main()
        {
            int maxCapacity = 10;

            Console.WriteLine("=========================================");
            Console.WriteLine("Gin's Elemental Arrow Distribution System");
            Console.WriteLine("=========================================");
            Console.WriteLine("\n");

            //Collect user inputs for each arrow type
            Console.Write("Input fire arrows: ");
            int fire = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Input water arrows: ");
            int water = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Input wind arrows: ");
            int wind = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Input earth arrows: ");
            int earth = int.Parse(Console.ReadLine() ?? "0");

            //Count how many quivers are needed
            int totalArrows = fire + water + wind + earth;
            int quivers = (int)Math.Ceiling(totalArrows / (double)maxCapacity);

            //Arrays to store per quiver distributions
            int[] fireDistribution = new int[quivers];
            int[] waterDistribution = new int[quivers];
            int[] windDistribution = new int[quivers];
            int[] earthDistribution = new int[quivers];

            //Distribute each arrow type evenly across all quivers
            void Distribute(int total, int[] distribution)
            {
                int baseAmount = total / quivers;
                int remainder = total % quivers;

                for (int i = 0; i < quivers; i++)
                {
                    distribution[i] = baseAmount;

                    if (i < remainder)
                    {
                        distribution[i]++;
                    }
                }
            }

            Distribute(fire, fireDistribution);
            Distribute(water, waterDistribution);
            Distribute(wind, windDistribution);
            Distribute(earth, earthDistribution);

            /// Ensure each quiver contains all elements and doesn't exceed the max capacity
            for (int i = 0; i < quivers; i++)
            {
                // Ensure each quiver has at least one of every element (if stock available)
                if (fireDistribution[i] == 0 && fire > 0) { fireDistribution[i]++; fire--; }
                if (waterDistribution[i] == 0 && water > 0) { waterDistribution[i]++; water--; }
                if (windDistribution[i] == 0 && wind > 0) { windDistribution[i]++; wind--; }
                if (earthDistribution[i] == 0 && earth > 0) { earthDistribution[i]++; earth--; }
            }

            // Display result
            Console.WriteLine("\n");
            Console.WriteLine("Quiver Distribution:");
            for (int i = 0; i < quivers; i++)
            {
                Console.WriteLine($"Quiver {i + 1}: {fireDistribution[i]} fire, {waterDistribution[i]} water, {windDistribution[i]} wind, {earthDistribution[i]} earth");
            }
        }
    }
}

