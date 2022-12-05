using System;


int[] x = new Int32[2];
int[] y = new Int32[2];
int[] d = new Int32[2];

string str = "1 1 10";
String[] strlist = str.Split(" ", 3,
               StringSplitOptions.RemoveEmptyEntries);

int count = 2;
int m = 0;
foreach (String s in strlist)
{
    m = Convert.ToInt32(s);
    Console.WriteLine("X Coordinates", strlist[s]);

    x[0] = m;
    //y[0] = Convert.ToInt32(strlist[s]);
    //d[0] = Convert.ToInt32(strlist[s]);

}


for (int k = 0; k <= count; k++)
{
Console.WriteLine("X Coordinates", x[0]);
    Console.WriteLine("Y Coordinates", y[0]);
    Console.WriteLine("Distance", d[0]);

}

int no_of_drones = Convert.ToInt32(Console.ReadLine());

        string[] drones = new string[no_of_drones];
        int i;
        for (i = 0; i < no_of_drones; i++)
        {
            drones[i] = Console.ReadLine();
}
        Console.WriteLine(no_of_drones);
        for (i = 0; i < no_of_drones; i++)
        {
            Console.WriteLine(drones[i]);
        }

int noOfObjects = Convert.ToInt32(Console.ReadLine());
string[] objects = new string[noOfObjects];
int j;
for (j = 0; j < noOfObjects; j++)
{
    objects[j] = Console.ReadLine();
}
Console.WriteLine(noOfObjects);
for (j = 0; j < noOfObjects; j++)
{
    Console.WriteLine(objects[j]);
}



Console.ReadKey();

        int total_objects = 0;
    

namespace measure_distance
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1, x2, y1, y2;
            x1 = 0;
            x2 = 1;
            y1 = 0;
            y2 = 1;
            var distance = Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
   
            Console.WriteLine(distance);
        }
    }
}
