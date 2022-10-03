//1.Ask for the name
//2.Show at which time he clocked in
//3.Keep asking for the name again
//4a.When a different name is input-> 2
//4b.When clocked in name is given-> 5
//4c.When no name is supplied-> 6
//5.Show date clocked out
//6.Show message that name has to be given-> 1
//7.After clocking in or out, show who's still clocked in
//8. (Bonus) show the clock duration when clocking out

using ClockInOut.Bll;

var clockMachine = new ClockMachine();

while (true)
{
    Console.WriteLine("Enter your name:");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name)) continue;

    if (clockMachine.IsClockedIn(name))
    {
        var entry = clockMachine.ClockOut(name);
        Console.WriteLine($"Clocked out at {entry.OutAt}!");
        Console.WriteLine($"Worked {entry.WorkedSeconds} seconds");
    }
    else
    {
        var entry = clockMachine.ClockIn(name);
        Console.WriteLine($"Clocked in at {entry.InAt}!");
    }

    Console.WriteLine();

    Console.WriteLine(clockMachine.GetStatus());

    Console.WriteLine();
}

