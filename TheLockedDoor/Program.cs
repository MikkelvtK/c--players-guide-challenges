
Console.Write("Please enter a passcode: ");
ushort answer = Convert.ToUInt16(Console.ReadLine());

Door newDoor = new(answer);

bool running = true;

do
{
    Console.Write("What do you want to do? (open, close, lock, unlock, change passcode, quit) ");
    string? command = Console.ReadLine();
    if (command == null)
        continue;

    switch (command)
    {
        case "open":
            newDoor.Open();
            break;
        case "close":
            newDoor.Close();
            break;
        case "lock":
            newDoor.Lock();
            break;
        case "unlock":
            Console.Write("Please enter your passcode: ");
            ushort yourPasscode = Convert.ToUInt16(Console.ReadLine());
            newDoor.Unlock(yourPasscode);
            break;
        case "change passcode":
            Console.Write("Please enter your passcode: ");
            yourPasscode = Convert.ToUInt16(Console.ReadLine());
            Console.Write("Please enter a new passcode: ");
            ushort newPasscode = Convert.ToUInt16(Console.ReadLine());
            newDoor.ChangePasscode(yourPasscode, newPasscode);
            break;
        case "quit":
            running = false;
            break;
        default:
            Console.WriteLine("That is not a valid command.");
            break;
    }
}
while (running);


class Door
{
    private DoorState State { get; set; }
    private ushort Passcode { get; set; }

    public Door(ushort passcode)
    {
        State = DoorState.Locked;
        Passcode = passcode;
    }

    public void Open()
    {
        string feedback = State switch
        {
            DoorState.Locked => "The door is locked.",
            DoorState.Open => "The door is already open.",
            DoorState.Closed => "The door is now open.",
        };

        if (State == DoorState.Closed) State = DoorState.Open;

        Console.WriteLine(feedback);
    }

    public void Close()
    {
        string feedback = State switch
        {
            DoorState.Locked => "The door is locked.",
            DoorState.Open => "The door is now closed.",
            DoorState.Closed => "The door is already closed.",
        };

        if (State == DoorState.Open) State = DoorState.Closed;

        Console.WriteLine(feedback);
    }

    public void Lock()
    {
        string feedback = State switch
        {
            DoorState.Locked => "The door is already locked.",
            DoorState.Open => "The door is not closed.",
            DoorState.Closed => "The door is now locked.",
        };

        if (State == DoorState.Closed) State = DoorState.Locked;

        Console.WriteLine(feedback);
    }

    public void Unlock(ushort passcode)
    {
        string feedback = State switch
        {
            DoorState.Locked => "The door is now unlocked.",
            DoorState.Open => "The door is open.",
            DoorState.Closed => "The door is already un.",
        };

        if (State == DoorState.Locked && passcode == Passcode) State = DoorState.Closed;

        Console.WriteLine(feedback);
    }

    public void ChangePasscode(ushort currentPasscode, ushort newPasscode)
    {
        if (currentPasscode == Passcode)
            Passcode = newPasscode;
        else
            Console.WriteLine("Your gave an incorrect current passcode.");
    }
}

enum DoorState { Open, Closed, Locked }
