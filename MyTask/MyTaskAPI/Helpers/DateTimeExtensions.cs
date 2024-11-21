namespace MyTaskAPI.Helpers;

public static class DateTimeExtensions
{
    public static string? ToFriendlyFormat(this DateTime? dateTime)
    {
        return dateTime?.ToString("dd-MM-yyyy HH:mm") ?? null;
    }

    public static string ToFriendlyFormat(this DateTime dateTime)
    {
        return dateTime.ToString("dd-MM-yyyy HH:mm");
    }
}