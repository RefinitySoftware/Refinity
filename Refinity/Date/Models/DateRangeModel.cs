/// <summary>
/// Represents a date range with start and end dates.
/// </summary>
public class DateRangeModel
{
    /// <summary>
    /// Gets or sets the start date of the date range.
    /// </summary>
    public DateTime dateStart { get; set; }

    /// <summary>
    /// Gets or sets the end date of the date range.
    /// </summary>
    public DateTime dateEnd { get; set; }

    /// <summary>
    /// Gets or sets the list of dates within the date range.
    /// </summary>
    public required List<DateTime> dateRange { get; set; }
}