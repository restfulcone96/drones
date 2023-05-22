public interface ICommand {
    void Execute(Server server, Robot robot);
}

public class CommandC001 : ICommand {
    public void Execute(Server server, Robot robot) {
        server.Respond("S001 HELLO");
    }
}

public class CommandC002 : ICommand {
    private int x;
    private int y;

    public CommandC002(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public void Execute(Server server, Robot robot) {
        robot.PositionX = x;
        robot.PositionY = y;
        // Add further logic
    }
}

// ... Repeat above steps for all command types ...

public class CommandFactory {
    public ICommand CreateCommand(string commandType, string commandDetails) {
        switch(commandType) {
            case "C001":
                return new CommandC001();
            case "C002":
                var coordinates = commandDetails.Split(' ');
                int x = Int32.Parse(coordinates[0]);
                int y = Int32.Parse(coordinates[1]);
                return new CommandC002(x, y);
            // ... Repeat for all command types ...
            default:
                throw new ArgumentException("Invalid command type.");
        }
    }
}

public class Server {
    private CommandFactory commandFactory;
    public Server(CommandFactory factory) {
        this.commandFactory = factory;
    }

    public void ExecuteCommand(string command, Robot robot) {
        var commandParts = command.Split(' ', 2);
        ICommand cmd = this.commandFactory.CreateCommand(commandParts[0], commandParts.Length > 1 ? commandParts[1] : "");
        cmd.Execute(this, robot);
    }

    public void Respond(string response) {
        Console.WriteLine(response);
    }
}

public class Robot {
    public string CurrentCommand { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
}

class Program {
    static void Main(string[] args) {
        CommandFactory commandFactory = new CommandFactory();
        Server server = new Server(commandFactory);
        Robot robot = new Robot();

        string input;
        while ((input = Console.ReadLine()) != null) {
            server.ExecuteCommand(input, robot);
        }
    }
}
