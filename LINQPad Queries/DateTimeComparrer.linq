<Query Kind="Program" />

void Main()
{
	DateTime A = new DateTime(1999, 1, 1, 1, 1, 1);
	DateTime B = new DateTime(1999, 1, 1, 2, 2, 2);
	
	var comparer = new DateTimePrecisionComparer(DateTimePrecisionComparer.DateTimePrecision.HourPrecision);
	
	Console.WriteLine(comparer.Compare(A, B));
}

public class DateTimePrecisionComparer : IComparer<DateTime>
{
    public enum DateTimePrecision: long
	{
		HourPrecision = 36000000000 
	}

    private TimeSpan _precision;

    public DateTimePrecisionComparer(DateTimePrecision precision)
    {
        this._precision = new TimeSpan((long)precision);
    }

    public int Compare(DateTime x, DateTime y)
    {
        x = Floor(x, _precision);
        y = Floor(y, _precision);

        return x.CompareTo(y);
    }

    private static DateTime Floor(DateTime dateTime, TimeSpan interval)
    {
        return dateTime.AddTicks(-(dateTime.Ticks % interval.Ticks));
    }
}


