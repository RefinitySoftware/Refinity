using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Refinity.Enums;
public static class EnumsUtility
{
    /// <summary>
    /// Retrieves the description attribute value of an enum value.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="e">The enum value.</param>
    /// <returns>The description attribute value of the enum value, or null if not found.</returns>
    public static string GetDescription<T>(this T e) where T : IConvertible
    {
        if (e is Enum)
        {
            Type type = e.GetType();
            Array values = System.Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val == e.ToInt32(CultureInfo.InvariantCulture))
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Retrieves the enum value by its number.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="number">The number representing the enum value.</param>
    /// <returns>The enum value corresponding to the number, or null if not found.</returns>
    public static T GetEnumByNumber<T>(int number) where T : Enum
    {
        if (Enum.IsDefined(typeof(T), number))
        {
            return (T)Enum.ToObject(typeof(T), number);
        }

        return default;
    }
}


/// <summary>
/// Represents the months of the year.
/// </summary>
public enum EnumMonths
{
    [Description("January")]
    January,
    [Description("February")]
    February,
    [Description("March")]
    March,
    [Description("April")]
    April,
    [Description("May")]
    May,
    [Description("June")]
    June,
    [Description("July")]
    July,
    [Description("August")]
    August,
    [Description("September")]
    September,
    [Description("October")]
    October,
    [Description("November")]
    November,
    [Description("December")]
    December
}

/// <summary>
/// Represents the file types as extensions in description attribute.
/// </summary>
public enum EnumFileTypes
{
    [Description(".rft")]
    RTF,
    [Description(".txt")]
    TXT,
    [Description(".exe")]
    CONSOLE,
    [Description(".log")]
    LOG,
    [Description(".xml")]
    XML,
    [Description(".json")]
    JSON,
    [Description(".csv")]
    CSV,
    [Description(".xls")]
    XLS,
    [Description(".xlsx")]
    XLSX,
    [Description(".doc")]
    DOC,
    [Description(".docx")]
    DOCX,
    [Description(".pdf")]
    PDF,
    [Description(".zip")]
    ZIP,
    [Description(".rar")]
    RAR,
    [Description(".7z")]
    _7Z,
    [Description(".tar")]
    TAR,
    [Description(".gz")]
    GZ,
    [Description(".bz2")]
    BZ2,
    [Description(".xz")]
    XZ,
    [Description(".jpg")]
    JPG,
    [Description(".jpeg")]
    JPEG,
    [Description(".png")]
    PNG,
    [Description(".gif")]
    GIF,
    [Description(".bmp")]
    BMP,
    [Description(".tiff")]
    TIFF,
    [Description(".tif")]
    TIF
}

/// <summary>
/// Represents the log levels for logging purposes.
/// </summary>
public enum EnumLogLevel
{
    [Description("Trace")]
    TRACE,
    [Description("Debug")]
    DEBUG,
    [Description("Info")]
    INFO,
    [Description("Warning")]
    WARNING,
    [Description("Error")]
    ERROR,
    [Description("Fatal")]
    FATAL
}

/// <summary>
/// Represents colors as hex values in description attribute.
/// </summary>
public enum EnumColor
{
    [Description("#FF0000")]
    Red,
    [Description("#00FF00")]
    Green,
    [Description("#0000FF")]
    Blue,
    [Description("#FFFF00")]
    Yellow,
    [Description("#FF00FF")]
    Magenta,
    [Description("#00FFFF")]
    Cyan,
    [Description("#FFFFFF")]
    White,
    [Description("#000000")]
    Black,
    [Description("#808080")]
    Gray,
    [Description("#800000")]
    Maroon,
    [Description("#808000")]
    Olive,
    [Description("#008000")]
    Green2,
    [Description("#800080")]
    Purple,
    [Description("#008080")]
    Teal,
    [Description("#000080")]
    Navy,
    [Description("#FFA500")]
    Orange,
    [Description("#A52A2A")]
    Brown,
    [Description("#FFC0CB")]
    Pink,
    [Description("#FFB6C1")]
    LightPink,
    [Description("#FF69B4")]
    HotPink,
    [Description("#FF1493")]
    DeepPink,
    [Description("#C71585")]
    MediumVioletRed,
    [Description("#DB7093")]
    PaleVioletRed
}

/// <summary>
/// Represents the days of the week.
/// </summary>
public enum EnumWeekDays
{
    [Description("Monday")]
    Monday,
    [Description("Tuesday")]
    Tuesday,
    [Description("Wednesday")]
    Wednesday,
    [Description("Thursday")]
    Thursday,
    [Description("Friday")]
    Friday,
    [Description("Saturday")]
    Saturday,
    [Description("Sunday")]
    Sunday
}

/// <summary>
/// Represents the short names of the week days.
/// </summary>
public enum EnumWeekDaysShort
{
    [Description("Mon")]
    Mon,
    [Description("Tue")]
    Tue,
    [Description("Wed")]
    Wed,
    [Description("Thu")]
    Thu,
    [Description("Fri")]
    Fri,
    [Description("Sat")]
    Sat,
    [Description("Sun")]
    Sun
}

/// <summary>
/// Represents different currency types with their symbols as description attribute.
/// </summary>
public enum EnumCurrency
{
    [Description("USD")]
    US_Dollar,
    [Description("EUR")]
    Euro,
    [Description("GBP")]
    British_Pound,
    [Description("JPY")]
    Japanese_Yen,
    [Description("CAD")]
    Canadian_Dollar,
    [Description("AUD")]
    Australian_Dollar,
    [Description("CHF")]
    Swiss_Franc,
    [Description("CNY")]
    Chinese_Yuan,
    [Description("SEK")]
    Swedish_Krona,
    [Description("NZD")]
    New_Zealand_Dollar,
    [Description("MXN")]
    Mexican_Peso,
    [Description("SGD")]
    Singapore_Dollar,
    [Description("HKD")]
    Hong_Kong_Dollar,
    [Description("NOK")]
    Norwegian_Krone,
    [Description("KRW")]
    South_Korean_Won,
    [Description("TRY")]
    Turkish_Lira,
    [Description("RUB")]
    Russian_Ruble,
    [Description("INR")]
    Indian_Rupee,
    [Description("BRL")]
    Brazilian_Real,
    [Description("ZAR")]
    South_African_Rand,
    [Description("SAR")]
    Saudi_Riyal,
    [Description("AED")]
    UAE_Dirham,
    [Description("DKK")]
    Danish_Krone,
    [Description("PLN")]
    Polish_Zloty,
    [Description("ILS")]
    Israeli_Shekel,
    [Description("PHP")]
    Philippine_Peso,
    [Description("CZK")]
    Czech_Koruna,
    [Description("IDR")]
    Indonesian_Rupiah,
    [Description("THB")]
    Thai_Baht,
    [Description("MYR")]
    Malaysian_Ringgit,
    [Description("HUF")]
    Hungarian_Forint,
    [Description("RON")]
    Romanian_Leu
}

/// <summary>
/// Represents different unit systems with their descriptions.
/// </summary>
public enum EnumUnitSystem
{
    [Description("Metric")]
    Metric,
    [Description("Imperial")]
    Imperial
}

/// <summary>
/// Represents the units of length for measurements.
/// </summary>
public enum EnumLengthUnits
{
    [Description("Meters")]
    Meters,

    [Description("Kilometers")]
    Kilometers,

    [Description("Centimeters")]
    Centimeters,

    [Description("Millimeters")]
    Millimeters,

    [Description("Micrometers")]
    Micrometers,

    [Description("Nanometers")]
    Nanometers,

    [Description("Miles")]
    Miles,

    [Description("Yards")]
    Yards,

    [Description("Feet")]
    Feet,

    [Description("Inches")]
    Inches
}

/// <summary>
/// Represents the units of mass for a measurement.
/// </summary>
public enum EnumMassUnits
{
    [Description("Kilograms")]
    Kilograms,

    [Description("Grams")]
    Grams,

    [Description("Milligrams")]
    Milligrams,

    [Description("Micrograms")]
    Micrograms,

    [Description("Tonnes")]
    Tonnes,

    [Description("Pounds")]
    Pounds,

    [Description("Ounces")]
    Ounces
}

/// <summary>
/// Represents the units of time for enumeration.
/// </summary>
public enum EnumTimeUnits
{
    [Description("Seconds")]
    Seconds,

    [Description("Milliseconds")]
    Milliseconds,

    [Description("Minutes")]
    Minutes,

    [Description("Hours")]
    Hours,

    [Description("Days")]
    Days
}

/// <summary>
/// Represents the units of temperature.
/// </summary>
public enum EnumTemperatureUnits
{
    [Description("Celsius")]
    Celsius,

    [Description("Fahrenheit")]
    Fahrenheit,

    [Description("Kelvin")]
    Kelvin
}

/// <summary>
/// Represents the units of energy for the EnumEnergyUnits enum.
/// </summary>
public enum EnumEnergyUnits
{
    [Description("Joules")]
    Joules,

    [Description("Kilojoules")]
    Kilojoules,

    [Description("Calories")]
    Calories,

    [Description("Kilocalories")]
    Kilocalories,

    [Description("Watt Hours")]
    WattHours,

    [Description("Kilowatt Hours")]
    KilowattHours
}

/// <summary>
/// Represents the units of pressure.
/// </summary>
public enum EnumPressureUnits
{
    [Description("Pascal")]
    Pascal,

    [Description("Bar")]
    Bar,

    [Description("Atmosphere")]
    Atmosphere,

    [Description("Torr")]
    Torr,

    [Description("Psi")]
    Psi
}