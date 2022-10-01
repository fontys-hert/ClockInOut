namespace ClockInOut.Bll;

public class ClockEntry
{
    public string Name { get; private set; }
    public DateTime InAt { get; private set; }
    public DateTime? OutAt { get; private set; }
    public int WorkedSeconds => ((OutAt ?? DateTime.Now) - InAt).Seconds;

    public ClockEntry(string name)
    {
        Name = name;
        InAt = DateTime.Now;
    }

    public void SignOff()
    {
        OutAt = DateTime.Now;
    }
}
