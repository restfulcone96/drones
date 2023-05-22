public class CommandC003 : ICommand {
    public void Execute(Server server, Robot robot) {
        // The robot has successfully registered the previous command.
        // It's safe to issue the next command.
        server.NavigateRobot(robot);
    }
}

public class CommandC004 : ICommand {
    private string message;

    public CommandC004(string message) {
        this.message = message;
    }

    public void Execute(Server server, Robot robot) {
        // The robot has successfully picked up the package.
        // Navigate the robot to its original position.
        server.NavigateRobot(robot, robot.OriginalPositionX, robot.OriginalPositionY);
        Console.WriteLine($"SERVER: {message}");
    }
}

public class Server {
    // ...

    public void NavigateRobot(Robot robot, int targetX = 0, int targetY = 0) {
        if (robot.PositionX == targetX && robot.PositionY == targetY) {
            // If the robot has reached the target position, issue the pick command
            this.Respond("S004 PICK");
        } else {
            // Calculate the direction for the next step.
            string direction = CalculateDirection(robot.PositionX, robot.PositionY, targetX, targetY);
            this.Respond($"S003 {direction}");
        }
    }

    private string CalculateDirection(int currentX, int currentY, int targetX, int targetY) {
        // Here we're implementing a simple strategy where the robot first moves along the X axis, then the Y axis.
        if (currentX != targetX) {
            return currentX < targetX ? "RIGHT" : "LEFT";
        } else if (currentY != targetY) {
            return currentY < targetY ? "UP" : "DOWN";
        } else {
            throw new ArgumentException("The current position is already the target position.");
        }
    }
}

public class Robot {
    // Remember the original position so that the robot can return to it later.
    public int OriginalPositionX { get; set; }
    public int OriginalPositionY { get; set; }

    // ...
}

