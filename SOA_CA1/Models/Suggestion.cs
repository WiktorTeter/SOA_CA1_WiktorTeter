namespace SOA_CA1.Models;

public enum DayType
{
    PublicHoliday = 0,
    Weekend = 1,
    Weekday = 2
}

public class Suggestion : IComparable<Suggestion>
{
    public string Message { get; set; } = "";
    public DayType Type { get; set; }
    public int Priority { get; set; }

    public int CompareTo(Suggestion? other)
        => other is null ? -1 : Priority.CompareTo(other.Priority);
}