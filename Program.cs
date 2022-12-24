using System;
using System.Collections.Generic;

namespace DebrisCollection
{
    class Program
    {
        public static bool IsPrime(int n)
    {
    if (n <= 1) return false;
    if (n <= 3) return true;

    if (n % 2 == 0 || n % 3 == 0) return false;

    int i = 5;
    while (i * i <= n)
    {
        if (n % i == 0 || n % (i + 2) == 0) return false;
        i += 6;
    }

    return true;
    }


        static void Main(string[] args)
        {
            // Read the number of drones
            int n = int.Parse(Console.ReadLine());

            // Read the drone data
            List<Tuple<float, float, float>> drones = new List<Tuple<float, float, float>>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                float x = float.Parse(tokens[0]);
                float y = float.Parse(tokens[1]);
                float r = float.Parse(tokens[2]);
                drones.Add(Tuple.Create(x, y, r));
            }

            // Read the number of objects
            int m = int.Parse(Console.ReadLine());

            // Read the object data
            List<Tuple<float, float, int>> objects = new List<Tuple<float, float, int>>();
            for (int i = 0; i < m; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                float x = float.Parse(tokens[0]);
                float y = float.Parse(tokens[1]);
                int a = int.Parse(tokens[2]);
                objects.Add(Tuple.Create(x, y, a));
            }

            // Iterate over the drones in reverse order
            for (int i = n - 1; i >= 0; i--)
            {
                // Initialize counters for organic-type and other-type objects
                int a = 0;
                int b = 0;
                // Get the current drone's data
                float x_drone = drones[i].Item1;
                float y_drone = drones[i].Item2;
                float r = drones[i].Item3;
                // Iterate over the objects
                for (int j = 0; j < objects.Count; j++)
                {
                    // Calculate the distance between the object and the drone's ladle
                    float x = objects[j].Item1;
                    float y = objects[j].Item2;
                    float distance = (float)Math.Sqrt((x - x_drone) * (x - x_drone) + (y - y_drone) * (y - y_drone));
                    // Check if the object is within the range of the drone's ladle
                   if (distance <= r)
                    {
                        // Check if the object size is a prime number
                        if (IsPrime(objects[j].Item3))
                        {
                            a++;
                        }
                        else
                        {
                            b++;
                        }
                        // Remove the object from the list
                        objects.RemoveAt(j);
                        // Decrement the index to account for the removed object
                        j--;
                    }
                }
                // Print the output for the current drone
                Console.WriteLine($"DRON {i}: {a} - {b}");
            }
        }
    }
}