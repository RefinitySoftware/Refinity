using System.ComponentModel;
using System.Globalization;

namespace Refinity.Enums;

/// <summary>
/// Utility class for working with enums.
/// </summary>
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
                    var member = type.GetEnumName(val);
                    if (member == null)
                    {
                        throw new ArgumentException("Enum name not found.");
                    }
                    var memInfo = type.GetMember(member);
                    var descriptionAttribute = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }
        }

        throw new ArgumentException("Enum value not found.");
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
        throw new ArgumentException("Enum value not found.");
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
    /// <summary>
    /// Represents the Rich Text Format file type.
    /// </summary>
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

/// <summary>
/// Represents the result of a benchmark operation.
/// </summary>
public enum EnumBenchmarkResult
{
    [Description("Success")]
    Success,
    [Description("Failure")]
    Failure
}

/// <summary>
/// Represents the language codes for different languages with their descriptions.
/// </summary>
public enum EnumLanguageCodes
{
    [Description("English")]
    EN,
    [Description("Spanish")]
    ES,
    [Description("French")]
    FR,
    [Description("German")]
    DE,
    [Description("Italian")]
    IT,
    [Description("Japanese")]
    JA,
    [Description("Korean")]
    KO,
    [Description("Chinese")]
    ZH,
    [Description("Arabic")]
    AR,
    [Description("Bulgarian")]
    BG,
    [Description("Catalan")]
    CA,
    [Description("Czech")]
    CS,
    [Description("Danish")]
    DA,
    [Description("Dutch")]
    NL,
    [Description("Estonian")]
    ET,
    [Description("Finnish")]
    FI,
    [Description("Greek")]
    EL,
    [Description("Hebrew")]
    HE,
    [Description("Hindi")]
    HI,
    [Description("Hungarian")]
    HU,
    [Description("Portuguese")]
    PT,
    [Description("Romanian")]
    RO,
    [Description("Russian")]
    RU,
    [Description("Slovak")]
    SK,
    [Description("Slovenian")]
    SL,
    [Description("Swedish")]
    SV,
    [Description("Turkish")]
    TR,
    [Description("Ukrainian")]
    UK,
    [Description("Vietnamese")]
    VI,
    [Description("Albanian")]
    SQ,
    [Description("Belarusian")]
    BE,
    [Description("Bosnian")]
    BS,
    [Description("Croatian")]
    HR,
    [Description("Icelandic")]
    IS,
    [Description("Irish")]
    GA,
    [Description("Latvian")]
    LV,
    [Description("Lithuanian")]
    LT,
    [Description("Macedonian")]
    MK,
    [Description("Maltese")]
    MT,
    [Description("Norwegian")]
    NO,
    [Description("Polish")]
    PL,
    [Description("Serbian")]
    SR,
    [Description("Welsh")]
    CY
}

/// <summary>
/// Represents a set of scale units in meters.
/// </summary>
public enum EnumScaleMeters
{
    [Description("Gigameters")]
    Gigameters,

    [Description("Megameters")]
    Megameters,

    [Description("Kilometers")]
    Kilometers,

    [Description("Hectometers")]
    Hectometers,

    [Description("Decameters")]
    Decameters,

    [Description("Meters")]
    Meters,

    [Description("Decimeters")]
    Decimeters,

    [Description("Centimeters")]
    Centimeters,

    [Description("Millimeters")]
    Millimeters,

    [Description("Micrometers")]
    Micrometers,

    [Description("Nanometers")]
    Nanometers,

    [Description("Picometers")]
    Picometers,

    [Description("Femtometers")]
    Femtometers,

    [Description("Attometers")]
    Attometers
}

/// <summary>
/// Represents the scale of weight in grams.
/// </summary>
public enum EnumScaleGrams
{
    [Description("Gigagrams")]
    Gigagrams,

    [Description("Megagrams")]
    Megagrams,

    [Description("Kilograms")]
    Kilograms,

    [Description("Hectograms")]
    Hectograms,

    [Description("Decagrams")]
    Decagrams,

    [Description("Grams")]
    Grams,

    [Description("Decigrams")]
    Decigrams,

    [Description("Centigrams")]
    Centigrams,

    [Description("Milligrams")]
    Milligrams,

    [Description("Micrograms")]
    Micrograms,

    [Description("Nanograms")]
    Nanograms,

    [Description("Picograms")]
    Picograms,

    [Description("Femtograms")]
    Femtograms,

    [Description("Attograms")]
    Attograms
}

/// <summary>
/// Represents the scale of time for a measurement.
/// </summary>
public enum EnumScaleTime
{
    [Description("Centuries")]
    Centuries,

    [Description("Decades")]
    Decades,

    [Description("Years")]
    Years,

    [Description("Months")]
    Months,

    [Description("Weeks")]
    Weeks,

    [Description("Days")]
    Days,

    [Description("Hours")]
    Hours,

    [Description("Minutes")]
    Minutes,

    [Description("Seconds")]
    Seconds,

    [Description("Milliseconds")]
    Milliseconds,

    [Description("Microseconds")]
    Microseconds,

    [Description("Nanoseconds")]
    Nanoseconds,

    [Description("Picoseconds")]
    Picoseconds,

    [Description("Femtoseconds")]
    Femtoseconds,

    [Description("Attoseconds")]
    Attoseconds
}

/// <summary>
/// Represents the scale of energy in joules.
/// </summary>
public enum EnumScaleJoules
{
    [Description("Gigajoules")]
    Gigajoules,

    [Description("Megajoules")]
    Megajoules,

    [Description("Kilojoules")]
    Kilojoules,

    [Description("Joules")]
    Joules,

    [Description("Millijoules")]
    Millijoules,

    [Description("Microjoules")]
    Microjoules,

    [Description("Nanojoules")]
    Nanojoules,

    [Description("Picojoules")]
    Picojoules,

    [Description("Femtojoules")]
    Femtojoules,

    [Description("Attojoules")]
    Attojoules
}

/// <summary>
/// Represents the scale of pressure in pascals.
/// </summary>
public enum EnumScalePascal
{
    [Description("Gigapascals")]
    Gigapascals,

    [Description("Megapascals")]
    Megapascals,

    [Description("Kilopascals")]
    Kilopascals,

    [Description("Hectopascals")]
    Hectopascals,

    [Description("Decapascals")]
    Decapascals,

    [Description("Pascals")]
    Pascals,

    [Description("Millipascals")]
    Millipascals,

    [Description("Micropascals")]
    Micropascals,

    [Description("Nanopascals")]
    Nanopascals,

    [Description("Picopascals")]
    Picopascals,

    [Description("Femtopascals")]
    Femtopascals,

    [Description("Attopascals")]
    Attopascals
}

/// <summary>
/// Represents the scale of miles.
/// </summary>
public enum EnumScaleMiles
{
    [Description("Megamiles")]
    Megamiles,

    [Description("Kilomiles")]
    Kilomiles,

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
/// Represents the scale units for weight measurement.
/// </summary>
public enum EnumScaleOnces
{
    [Description("Kiloounces")]
    Kiloounces,

    [Description("Ounces")]
    Ounces,

    [Description("Milliounces")]
    Milliounces,

    [Description("Microounces")]
    Microounces
}

/// <summary>
/// Represents the scale of power in watts.
/// </summary>
public enum EnumScaleWatts
{
    [Description("Terawatts")]
    Terawatts,

    [Description("Gigawatts")]
    Gigawatts,

    [Description("Megawatts")]
    Megawatts,

    [Description("Kilowatts")]
    Kilowatts,

    [Description("Watts")]
    Watts,

    [Description("Milliwatts")]
    Milliwatts,

    [Description("Microwatts")]
    Microwatts,

    [Description("Nanowatts")]
    Nanowatts,

    [Description("Picowatts")]
    Picowatts,

    [Description("Femtowatts")]
    Femtowatts,

    [Description("Attowatts")]
    Attowatts
}

/// <summary>
/// Represents the scale of voltage in different units.
/// </summary>
public enum EnumScaleVolts
{
    [Description("Kilovolts")]
    Kilovolts,

    [Description("Volts")]
    Volts,

    [Description("Millivolts")]
    Millivolts,

    [Description("Microvolts")]
    Microvolts,

    [Description("Nanovolts")]
    Nanovolts,

    [Description("Picovolts")]
    Picovolts,

    [Description("Femtovolts")]
    Femtovolts,

    [Description("Attovolts")]
    Attovolts
}

/// <summary>
/// Represents the scale of measurement in liters.
/// </summary>
public enum EnumScaleLiters
{
    [Description("Kiloliters")]
    Kiloliters,

    [Description("Liters")]
    Liters,

    [Description("Deciliters")]
    Deciliters,

    [Description("Centiliters")]
    Centiliters,

    [Description("Milliliters")]
    Milliliters,

    [Description("Microliters")]
    Microliters,

    [Description("Nanoliters")]
    Nanoliters,

    [Description("Picoliters")]
    Picoliters,

    [Description("Femtoliters")]
    Femtoliters,

    /// <summary>
    /// Represents a volume measurement in attoliters.
    /// </summary>
    [Description("Attoliters")]
    Attoliters
}