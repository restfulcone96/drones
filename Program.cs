// Read the number of drones
int n = int.Parse(Console.ReadLine());

// Read the drone data
List<Tuple<float, float, float>> drones = new List<Tuple<float, float, float>>();
for (int i = 0; i < n; i++)
{
  string[] input = Console.ReadLine().Split();
  float x = float.Parse(input[0]);
  float y = float.Parse(input[1]);
  float r = float.Parse(input[2]);
  drones.Add(Tuple.Create(x, y, r));
}

// Read the number of objects
int m = int.Parse(Console.ReadLine());

// Read the object data
List<Tuple<float, float, int>> objects = new List<Tuple<float, float, int>>();
for (int i = 0; i < m; i++)
{
  string[] input = Console.ReadLine().Split();
  float x = float.Parse(input[0]);
  float y = float.Parse(input[1]);
  int a = int.Parse(input[2]);
  objects.Add(Tuple.Create(x, y, a));
}

// Iterate over the drones
for (int i = 0; i < n; i++)
{
  // Initialize counters for organic-type and other-type objects
  int a = 0;
  int b = 0;
  // Get the current drone's data
  float x_drone = drones[i].Item1;
  float y_drone = drones[i].Item2;
  float r = drones[i].Item3;
  // Iterate over the objects
  foreach (var obj in objects)
  {
    // Calculate the distance between the object and the drone's ladle
    float x = obj.Item1;
    float y = obj.Item2;
    float distance = (float)Math.Sqrt((x - x_drone) * (x - x_drone) + (y - y_drone) * (y - y_drone));
    // If the distance is less than or equal to the size of the ladle, the object can be picked up
    if (distance <= r)
    {
      // Increment the counter based on object type - If its prime number, then its non-organic and can be picked for removal
      int a_obj = obj.Item3;
      if (a_obj % 2 == 0)
      {
        a++;
      }
      else
      {
        b++;
      }
    }
  }
  // Output the results for the drone
  Console.WriteLine("DRON {0}: {1} - {2}", i, b, a);
}