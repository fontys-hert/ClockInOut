using System.Text;

namespace ClockInOut.Bll;

public class ClockMachine
{
    private readonly List<ClockEntry> _entries;

    public ClockMachine()
    {
        _entries = new List<ClockEntry>();
    }

    public bool IsClockedIn(string name)
    {
        bool isEmployeeClockedIn = false;
        foreach (var entry in _entries)
        {
            if (entry.Name == name)
            {
                isEmployeeClockedIn = true;
                break;
            }
        }
        return isEmployeeClockedIn;
    }

    public ClockEntry ClockIn(string name)
    {
        if (IsClockedIn(name)) throw new InvalidOperationException("Cannot clock in somebody that is already working");
        var entry = new ClockEntry(name);
        _entries.Add(entry);
        return entry;
    }

    public ClockEntry ClockOut(string name)
    {
        if (!IsClockedIn(name)) throw new InvalidOperationException("Cannot clock out somebody that is not clocked in");

        ClockEntry? entryToRemove = null;
        foreach (var entry in _entries)
        {
            if (entry.Name == name)
            {
                entryToRemove = entry;
                break;
            }
        }

        entryToRemove!.SignOff();

        _entries.Remove(entryToRemove);
        return entryToRemove;
    }

    public string GetStatus()
    {
        if (!_entries.Any())
        {
            return "There is nobody clocked in at the moment";
        }

        StringBuilder statusBuilder = new();
        statusBuilder.AppendLine("The following people are clocked in:");
        foreach (var entry in _entries)
        {
            statusBuilder.AppendLine($"{entry.InAt}: {entry.Name}");
        }

        return statusBuilder.ToString();
    }
}
