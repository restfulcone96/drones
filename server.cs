using System;

class Server
{
    static void Main()
    {
        Console.WriteLine("SERVER: Starting up...");

        // Send initial hello message
        Console.WriteLine("SERVER: Sending hello message...");
        Console.WriteLine("S001 HELLO");

        // Wait for first client message
        string input = Console.ReadLine();

        // Initialize robot position
        int robotX = 0;
        int robotY = 0;

        // Main loop
        while (true)
        {
            // Parse the input message
            if (input.StartsWith("C"))
            {
                string[] parts = input.Split(' ');

                if (parts.Length == 1 && parts[0] == "C001")
                {
                    // Client sends hello message
                    Console.WriteLine("SERVER: Client connected");
                    Console.WriteLine("S001 HELLO");
                }
                else if (parts.Length == 3 && parts[0] == "C002")
                {
                    // Client sends position message
                    if (int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
                    {
                        robotX = x;
                        robotY = y;

                        // Check if robot is at position 0 0
                        if (robotX == 0 && robotY == 0)
                        {
                            Console.WriteLine("SERVER: Robot at position 0 0");
                            Console.WriteLine("S002 POSITION");
                        }
                        else
                        {
                            Console.WriteLine("SERVER: Navigating robot to position 0 0...");
                            // Here you would add code to navigate the robot to position 0 0
                            // and then send a S002 POSITION command when it gets there
                        }
                    }
                    else
                    {
                        Console.WriteLine("SERVER: Error: Invalid position message");
                        break;
                    }
                }
                else if (parts.Length == 1 && parts[0] == "C003")
                {
                    // Client sends OK message
                    Console.WriteLine("SERVER: Robot registered command");
                    Console.WriteLine("S003 OK");
                }
                else if (parts.Length >= 2 && parts[0] == "C004")
                {
                    // Client sends message with package contents
                    string message = string.Join(" ", parts, 1, parts.Length - 1);
                    Console.WriteLine("SERVER: Robot picked up package with contents: " + message);
                    Console.WriteLine("SERVER: Navigating robot back to position " + robotX + " " + robotY + "...");
                    // Here you would add code to navigate the robot back to its original position
                    Console.WriteLine("S003 OK");
                }
                else
                {
                    Console.WriteLine("SERVER: Error: Invalid command");
                    break;
                }
            }
            else
            {
                Console.WriteLine("SERVER: Error: Invalid input");
                break;
            }

            // Wait for next client message
            input = Console.ReadLine();
        }

        // Shutdown
        Console.WriteLine("SERVER: Error: Shutting down");
        Console.WriteLine("SERVER: STOP");
    }
}
