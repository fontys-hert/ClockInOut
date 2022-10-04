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
using ClockInOut.Presentation;

var logger = new Logger();
var clocker = new Clocker(logger);

while (true)
{
    Console.WriteLine("Wat is je naam:");
    string? name = Console.ReadLine();

    clocker.ClockInOut(name);


    var clockedInStatus = clocker.GetClockStatus();
    Console.WriteLine($"Op dit moment zijn ingeklokt: {clockedInStatus}");
}

Console.WriteLine("Einde van het programa");
