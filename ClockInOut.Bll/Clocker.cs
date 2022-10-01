namespace ClockInOut.Bll;

public class Clocker
{
    private readonly List<string> namesClockedIn;
    private ILogger logger;

    public Clocker(ILogger logger)
    {
        namesClockedIn = new List<string>();
        this.logger = logger;
    }

    public void ClockInOut(string? name)
    {
        var dateClocked = DateTime.Now;

        if (string.IsNullOrWhiteSpace(name))
        {
            logger.Write("Hey, vul je naam in!");
        }

        if (namesClockedIn.Contains(name))
        {
            namesClockedIn.Remove(name);
            logger.Write(name + " is uitgeklokt op " + dateClocked);
            Thread.Sleep(1000);
        }
        else
        {
            namesClockedIn.Add(name);
            logger.Write(name + " is ingeklokt op " + dateClocked);
            Thread.Sleep(1000);
        }
    }

    public string GetClockStatus()
    {
        string clockedInStatus = "";
        foreach (var nameClockedIn in namesClockedIn)
        {
            clockedInStatus += nameClockedIn;

            if (namesClockedIn.Last() != nameClockedIn) clockedInStatus += ", "; // font liguratures
        }

        return clockedInStatus;
    }

}
