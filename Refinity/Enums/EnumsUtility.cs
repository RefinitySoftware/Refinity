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
    /// <summary>
    /// Represents the month of January.
    /// </summary>
    [Description("January")]
    January,
    /// <summary>
    /// Represents the month of February.
    /// </summary>
    [Description("February")]
    February,
    /// <summary>
    /// Represents the month of March.
    /// </summary>
    [Description("March")]
    March,
    /// <summary>
    /// Represents the month of April.
    /// </summary>
    [Description("April")]
    April,
    /// <summary>
    /// Represents the month of May.
    /// </summary>
    [Description("May")]
    May,
    /// <summary>
    /// Represents the month of June.
    /// </summary>
    [Description("June")]
    June,
    /// <summary>
    /// Represents the month of July.
    /// </summary>
    [Description("July")]
    July,
    /// <summary>
    /// Represents the month of August.
    /// </summary>
    [Description("August")]
    August,
    /// <summary>
    /// Represents the month of September.
    /// </summary>
    [Description("September")]
    September,
    /// <summary>
    /// Represents the month of October.
    /// </summary>
    [Description("October")]
    October,
    /// <summary>
    /// Represents the month of November.
    /// </summary>
    [Description("November")]
    November,
    /// <summary>
    /// Represents the month of December.
    /// </summary>
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
    /// <summary>
    /// Represents the TXT file format.
    /// </summary>
    [Description(".txt")]
    TXT,
    /// <summary>
    /// Represents the console application type.
    /// </summary>
    [Description(".exe")]
    CONSOLE,
    /// <summary>
    /// Represents the log file format.
    /// </summary>
    [Description(".log")]
    LOG,
    /// <summary>
    /// Represents the XML file format.
    /// </summary>
    [Description(".xml")]
    XML,
    /// <summary>
    /// Represents the JSON file format.
    /// </summary>
    [Description(".json")]
    JSON,
    /// <summary>
    /// Represents the CSV file format.
    /// </summary>
    [Description(".csv")]
    CSV,
    /// <summary>
    /// Represents the XLS file format.
    /// </summary>
    [Description(".xls")]
    XLS,
    /// <summary>
    /// Represents the XLSX file format.
    /// </summary>
    [Description(".xlsx")]
    XLSX,
    /// <summary>
    /// Represents the DOC file format.
    /// </summary>
    [Description(".doc")]
    DOC,
    /// <summary>
    /// Represents the DOCX file format.
    /// </summary>
    [Description(".docx")]
    DOCX,
    /// <summary>
    /// Represents the PDF file format.
    /// </summary>
    [Description(".pdf")]
    PDF,
    /// <summary>
    /// Represents the ZIP file format.
    /// </summary>
    [Description(".zip")]
    ZIP,
    /// <summary>
    /// Represents the RAR file format.
    /// </summary>
    [Description(".rar")]
    RAR,
    /// <summary>
    /// Represents the 7z file format.
    /// </summary>
    [Description(".7z")]
    _7Z,
    /// <summary>
    /// Represents the TAR file format.
    /// </summary>
    [Description(".tar")]
    TAR,
    /// <summary>
    /// Represents the GZ file format.
    /// </summary>
    [Description(".gz")]
    GZ,
    /// <summary>
    /// Represents the BZ2 file format.
    /// </summary>
    [Description(".bz2")]
    BZ2,
    /// <summary>
    /// Represents the XZ file format.
    /// </summary>
    [Description(".xz")]
    XZ,
    /// <summary>
    /// Represents the JPG file format.
    /// </summary>
    [Description(".jpg")]
    JPG,
    /// <summary>
    /// Represents the JPEG file format.
    /// </summary>
    [Description(".jpeg")]
    JPEG,
    /// <summary>
    /// Represents the PNG file format.
    /// </summary>
    [Description(".png")]
    PNG,
    /// <summary>
    /// Represents the GIF file format.
    /// </summary>
    [Description(".gif")]
    GIF,
    /// <summary>
    /// Represents the BMP file format.
    /// </summary>
    [Description(".bmp")]
    BMP,
    /// <summary>
    /// Represents the TIFF file format.
    /// </summary>
    [Description(".tiff")]
    TIFF,
    /// <summary>
    /// Represents the TIF file format.
    /// </summary>
    [Description(".tif")]
    TIF
}

/// <summary>
/// Represents the log levels for logging purposes.
/// </summary>
public enum EnumLogLevel
{
    /// <summary>
    /// Represents the TRACE enum value.
    /// </summary>
    [Description("Trace")]
    TRACE,
    /// <summary>
    /// Represents the debug mode.
    /// </summary>
    [Description("Debug")]
    DEBUG,
    /// <summary>
    /// Represents the "Info" value.
    /// </summary>
    [Description("Info")]
    INFO,
    /// <summary>
    /// Represents a warning.
    /// </summary>
    [Description("Warning")]
    WARNING,
    /// <summary>
    /// Represents an error.
    /// </summary>
    [Description("Error")]
    ERROR,
    /// <summary>
    /// Represents a fatal error.
    /// </summary>
    [Description("Fatal")]
    FATAL
}

/// <summary>
/// Represents colors as hex values in description attribute.
/// </summary>
public enum EnumColor
{
    /// <summary>
    /// Represents the color red.
    /// </summary>
    [Description("#FF0000")]
    Red,
    /// <summary>
    /// Represents the color green.
    /// </summary>
    [Description("#00FF00")]
    Green,
    /// <summary>
    /// Represents the color blue.
    /// </summary>
    [Description("#0000FF")]
    Blue,
    /// <summary>
    /// Represents the color yellow.
    /// </summary>
    [Description("#FFFF00")]
    Yellow,
    /// <summary>
    /// Represents the Magenta color.
    /// </summary>
    [Description("#FF00FF")]
    Magenta,
    /// <summary>
    /// Represents the color cyan.
    /// </summary>
    [Description("#00FFFF")]
    Cyan,
    /// <summary>
    /// Represents the color white.
    /// </summary>
    [Description("#FFFFFF")]
    White,
    /// <summary>
    /// Represents the color black.
    /// </summary>
    [Description("#000000")]
    Black,
    /// <summary>
    /// Represents the color gray.
    /// </summary>
    [Description("#808080")]
    Gray,
    /// <summary>
    /// Represents the color Maroon.
    /// </summary>
    [Description("#800000")]
    Maroon,
    /// <summary>
    /// Represents the color olive.
    /// </summary>
    [Description("#808000")]
    Olive,
    /// <summary>
    /// Represents the color Green2.
    /// </summary>
    [Description("#008000")]
    Green2,
    /// <summary>
    /// Represents the color purple.
    /// </summary>
    [Description("#800080")]
    Purple,
    /// <summary>
    /// Represents the Teal color.
    /// </summary>
    [Description("#008080")]
    Teal,
    /// <summary>
    /// Represents the color Navy with.
    /// </summary>
    [Description("#000080")]
    Navy,
    /// <summary>
    /// Represents the color orange.
    /// </summary>
    [Description("#FFA500")]
    Orange,
    /// <summary>
    /// Represents the color brown.
    /// </summary>
    [Description("#A52A2A")]
    Brown,
    /// <summary>
    /// Represents the color pink.
    /// </summary>
    [Description("#FFC0CB")]
    Pink,
    /// <summary>
    /// Represents the color LightPink.
    /// </summary>
    [Description("#FFB6C1")]
    LightPink,
    /// <summary>
    /// Represents the color HotPink.
    /// </summary>
    [Description("#FF69B4")]
    HotPink,
    /// <summary>
    /// Represents the color DeepPink.
    /// </summary>
    [Description("#FF1493")]
    DeepPink,
    /// <summary>
    /// Represents the color MediumVioletRed.
    /// </summary>
    [Description("#C71585")]
    MediumVioletRed,
    /// <summary>
    /// Represents the color PaleVioletRed.
    /// </summary>
    [Description("#DB7093")]
    PaleVioletRed
}

/// <summary>
/// Represents the days of the week.
/// </summary>
public enum EnumWeekDays
{
    /// <summary>
    /// Represents Monday.
    /// </summary>
    [Description("Monday")]
    Monday,
    /// <summary>
    /// Represents Tuesday.
    /// </summary>
    [Description("Tuesday")]
    Tuesday,
    /// <summary>
    /// Represents Wednesday.
    /// </summary>
    [Description("Wednesday")]
    Wednesday,
    /// <summary>
    /// Represents Thursday.
    /// </summary>
    [Description("Thursday")]
    Thursday,
    /// <summary>
    /// Represents the day of the week as Friday.
    /// </summary>
    [Description("Friday")]
    Friday,
    /// <summary>
    /// Represents the day of the week as Saturday.
    /// </summary>
    [Description("Saturday")]
    Saturday,
    /// <summary>
    /// Represents the day of the week as Sunday.
    /// </summary>
    [Description("Sunday")]
    Sunday
}

/// <summary>
/// Represents the short names of the week days.
/// </summary>
public enum EnumWeekDaysShort
{
    /// <summary>
    /// Represents Monday.
    /// </summary>
    [Description("Mon")]
    Mon,
    /// <summary>
    /// Represents Tuesday.
    /// </summary>
    [Description("Tue")]
    Tue,
    /// <summary>
    /// Represents Wednesday.
    /// </summary>
    [Description("Wed")]
    Wed,
    /// <summary>
    /// Represents Thursday.
    /// </summary>
    [Description("Thu")]
    Thu,
    /// <summary>
    /// Represents the day of the week as Friday.
    /// </summary>
    [Description("Fri")]
    Fri,
    /// <summary>
    /// Represents the day of the week as Saturday.
    /// </summary>
    [Description("Sat")]
    Sat,
    /// <summary>
    /// Represents the Sun enum value.
    /// </summary>
    [Description("Sun")]
    Sun
}

/// <summary>
/// Represents different currency types with their symbols as description attribute.
/// </summary>
public enum EnumCurrency
{
    /// <summary>
    /// Represents the US Dollar currency.
    /// </summary>
    [Description("USD")]
    US_Dollar,
    /// <summary>
    /// Represents the Euro currency.
    /// </summary>
    [Description("EUR")]
    Euro,
    /// <summary>
    /// Represents the British Pound currency.
    /// </summary>
    [Description("GBP")]
    British_Pound,
    /// <summary>
    /// Represents the Japanese Yen currency.
    /// </summary>
    [Description("JPY")]
    Japanese_Yen,
    /// <summary>
    /// Represents the Canadian Dollar currency.
    /// </summary>
    [Description("CAD")]
    Canadian_Dollar,
    /// <summary>
    /// Represents the Australian Dollar currency.
    /// </summary>
    [Description("AUD")]
    Australian_Dollar,
    /// <summary>
    /// Represents the Swiss Franc currency.
    /// </summary>
    [Description("CHF")]
    Swiss_Franc,
    /// <summary>
    /// Represents the Chinese Yuan currency.
    /// </summary>
    [Description("CNY")]
    Chinese_Yuan,
    /// <summary>
    /// Represents the Swedish Krona currency.
    /// </summary>
    [Description("SEK")]
    Swedish_Krona,
    /// <summary>
    /// Represents the New Zealand Dollar currency.
    /// </summary>
    [Description("NZD")]
    New_Zealand_Dollar,
    /// <summary>
    /// Represents the Mexican Peso currency.
    /// </summary>
    [Description("MXN")]
    Mexican_Peso,
    /// <summary>
    /// Represents the Singapore Dollar currency.
    /// </summary>
    [Description("SGD")]
    Singapore_Dollar,
    /// <summary>
    /// Represents the Hong Kong Dollar currency.
    /// </summary>
    [Description("HKD")]
    Hong_Kong_Dollar,
    /// <summary>
    /// Represents the Norwegian Krone currency.
    /// </summary>
    [Description("NOK")]
    Norwegian_Krone,
    /// <summary>
    /// Represents the South Korean Won currency.
    /// </summary>
    [Description("KRW")]
    South_Korean_Won,
    /// <summary>
    /// Represents the Turkish Lira currency.
    /// </summary>
    [Description("TRY")]
    Turkish_Lira,
    /// <summary>
    /// Represents the Russian Ruble currency.
    /// </summary>
    [Description("RUB")]
    Russian_Ruble,
    /// <summary>
    /// Represents the Indian Rupee currency.
    /// </summary>
    [Description("INR")]
    Indian_Rupee,
    /// <summary>
    /// Represents the Brazilian Real currency.
    /// </summary>
    [Description("BRL")]
    Brazilian_Real,
    /// <summary>
    /// Represents the South African Rand currency.
    /// </summary>
    [Description("ZAR")]
    South_African_Rand,
    /// <summary>
    /// Represents the Saudi Riyal currency.
    /// </summary>
    [Description("SAR")]
    Saudi_Riyal,
    /// <summary>
    /// Represents the UAE Dirham currency.
    /// </summary>
    [Description("AED")]
    UAE_Dirham,
    /// <summary>
    /// Represents the Danish Krone currency.
    /// </summary>
    [Description("DKK")]
    Danish_Krone,
    /// <summary>
    /// Represents the Polish Zloty currency.
    /// </summary>
    [Description("PLN")]
    Polish_Zloty,
    /// <summary>
    /// Represents the Israeli Shekel currency.
    /// </summary>
    [Description("ILS")]
    Israeli_Shekel,
    /// <summary>
    /// Represents the Philippine Peso currency.
    /// </summary>
    [Description("PHP")]
    Philippine_Peso,
    /// <summary>
    /// Represents the Czech Koruna currency.
    /// </summary>
    [Description("CZK")]
    Czech_Koruna,
    /// <summary>
    /// Represents the Indonesian Rupiah currency.
    /// </summary>
    [Description("IDR")]
    Indonesian_Rupiah,
    /// <summary>
    /// Represents the Thai Baht currency.
    /// </summary>
    [Description("THB")]
    Thai_Baht,
    /// <summary>
    /// Represents the Malaysian Ringgit currency.
    /// </summary>
    [Description("MYR")]
    Malaysian_Ringgit,
    /// <summary>
    /// Represents the Hungarian Forint currency.
    /// </summary>
    [Description("HUF")]
    Hungarian_Forint,
    /// <summary>
    /// Represents the Romanian Leu currency.
    /// </summary>
    [Description("RON")]
    Romanian_Leu
}

/// <summary>
/// Represents different unit systems with their descriptions.
/// </summary>
public enum EnumUnitSystem
{
    /// <summary>
    /// Represents a metric.
    /// </summary>
    [Description("Metric")]
    Metric,
    /// <summary>
    /// Represents the Imperial unit of measurement.
    /// </summary>
    [Description("Imperial")]
    Imperial
}

/// <summary>
/// Represents the units of temperature.
/// </summary>
public enum EnumTemperatureUnits
{
    /// <summary>
    /// Represents the Celsius unit of temperature.
    /// </summary>
    [Description("Celsius")]
    Celsius,

    /// <summary>
    /// Represents the Fahrenheit unit of temperature.
    /// </summary>
    [Description("Fahrenheit")]
    Fahrenheit,

    /// <summary>
    /// Represents the Kelvin unit of temperature.
    /// </summary>
    [Description("Kelvin")]
    Kelvin
}

/// <summary>
/// Represents the units of pressure.
/// </summary>
public enum EnumPressureUnits
{
    /// <summary>
    /// Represents the Pascal enumeration value.
    /// </summary>
    [Description("Pascal")]
    Pascal,

    /// <summary>
    /// Represents the Bar enum value.
    /// </summary>
    [Description("Bar")]
    Bar,

    /// <summary>
    /// Represents the atmosphere enum value.
    /// </summary>
    [Description("Atmosphere")]
    Atmosphere,

    /// <summary>
    /// Represents the unit of pressure called Torr.
    /// </summary>
    [Description("Torr")]
    Torr,

    /// <summary>
    /// Represents the unit of pressure called Psi.
    /// </summary>
    [Description("Psi")]
    Psi
}

/// <summary>
/// Represents the result of a benchmark operation.
/// </summary>
public enum EnumBenchmarkResult
{
    /// <summary>
    /// Represents a successful operation.
    /// </summary>
    [Description("Success")]
    Success,
    /// <summary>
    /// Represents a failure.
    /// </summary>
    [Description("Failure")]
    Failure
}

/// <summary>
/// Represents the language codes for different languages with their descriptions.
/// </summary>
public enum EnumLanguageCodes
{
    /// <summary>
    /// Represents the English language.
    /// </summary>
    [Description("English")]
    EN,
    /// <summary>
    /// Represents the Spanish language.
    /// </summary>
    [Description("Spanish")]
    ES,
    /// <summary>
    /// Represents the French language.
    /// </summary>
    [Description("French")]
    FR,
    /// <summary>
    /// Represents the German language.
    /// </summary>
    [Description("German")]
    DE,
    /// <summary>
    /// Represents the Italian language.
    /// </summary>
    [Description("Italian")]
    IT,
    /// <summary>
    /// Represents the Japanese language.
    /// </summary>
    [Description("Japanese")]
    JA,
    /// <summary>
    /// Represents the Korean language.
    /// </summary>
    [Description("Korean")]
    KO,
    /// <summary>
    /// Represents the Chinese language.
    /// </summary>
    [Description("Chinese")]
    ZH,
    /// <summary>
    /// Represents the Arabic language.
    /// </summary>
    [Description("Arabic")]
    AR,
    /// <summary>
    /// Represents the Bulgarian language.
    /// </summary>
    [Description("Bulgarian")]
    BG,
    /// <summary>
    /// Represents the Catalan language.
    /// </summary>
    [Description("Catalan")]
    CA,
    /// <summary>
    /// Represents the Czech language.
    /// </summary>
    [Description("Czech")]
    CS,
    /// <summary>
    /// Represents the Danish language.
    /// </summary>
    [Description("Danish")]
    DA,
    /// <summary>
    /// Represents the Dutch language.
    /// </summary>
    [Description("Dutch")]
    NL,
    /// <summary>
    /// Represents the Estonian language.
    /// </summary>
    [Description("Estonian")]
    ET,
    /// <summary>
    /// Represents the Finnish language.
    /// </summary>
    [Description("Finnish")]
    FI,
    /// <summary>
    /// Represents the Greek language.
    /// </summary>
    [Description("Greek")]
    EL,
    /// <summary>
    /// Represents the Hebrew language.
    /// </summary>
    [Description("Hebrew")]
    HE,
    /// <summary>
    /// Represents the Hindi language.
    /// </summary>
    [Description("Hindi")]
    HI,
    /// <summary>
    /// Represents the Hungarian language.
    /// </summary>
    [Description("Hungarian")]
    HU,
    /// <summary>
    /// Represents the Portuguese language.
    /// </summary>
    [Description("Portuguese")]
    PT,
    /// <summary>
    /// Represents the Romanian language.
    /// </summary>
    [Description("Romanian")]
    RO,
    /// <summary>
    /// Represents the Russian language.
    /// </summary>
    [Description("Russian")]
    RU,
    /// <summary>
    /// Represents the Slovak language.
    /// </summary>
    [Description("Slovak")]
    SK,
    /// <summary>
    /// Represents the Slovenian language.
    /// </summary>
    [Description("Slovenian")]
    SL,
    /// <summary>
    /// Represents the Swedish language.
    /// </summary>
    [Description("Swedish")]
    SV,
    /// <summary>
    /// Represents the Turkish language.
    /// </summary>
    [Description("Turkish")]
    TR,
    /// <summary>
    /// Represents the Ukrainian language.
    /// </summary>
    [Description("Ukrainian")]
    UK,
    /// <summary>
    /// Represents the Vietnamese language.
    /// </summary>
    [Description("Vietnamese")]
    VI,
    /// <summary>
    /// Represents the Albanian language.
    /// </summary>
    [Description("Albanian")]
    SQ,
    /// <summary>
    /// Represents the Belarusian language.
    /// </summary>
    [Description("Belarusian")]
    BE,
    /// <summary>
    /// Represents the Bosnian language.
    /// </summary>
    [Description("Bosnian")]
    BS,
    /// <summary>
    /// Represents the Croatian language.
    /// </summary>
    [Description("Croatian")]
    HR,
    /// <summary>
    /// Represents the Icelandic language.
    /// </summary>
    [Description("Icelandic")]
    IS,
    /// <summary>
    /// Represents the country code for Ireland.
    /// </summary>
    [Description("Irish")]
    GA,
    /// <summary>
    /// Represents the Latvian language.
    /// </summary>
    [Description("Latvian")]
    LV,
    /// <summary>
    /// Represents the Lithuanian language.
    /// </summary>
    [Description("Lithuanian")]
    LT,
    /// <summary>
    /// Represents the Macedonian language.
    /// </summary>
    [Description("Macedonian")]
    MK,
    /// <summary>
    /// Represents the country code for Maltese.
    /// </summary>
    [Description("Maltese")]
    MT,
    /// <summary>
    /// Represents the Norwegian language.
    /// </summary>
    [Description("Norwegian")]
    NO,
    /// <summary>
    /// Represents the Polish language.
    /// </summary>
    [Description("Polish")]
    PL,
    /// <summary>
    /// Represents the Serbian language.
    /// </summary>
    [Description("Serbian")]
    SR,
    /// <summary>
    /// Represents the Welsh language.
    /// </summary>
    [Description("Welsh")]
    CY
}

/// <summary>
/// Represents a set of scale units in meters.
/// </summary>
public enum EnumScaleMeters
{
    /// <summary>
    /// Represents a unit of length in gigameters.
    /// </summary>
    [Description("Gigameters")]
    Gigameters,

    /// <summary>
    /// Represents a unit of measurement in megameters.
    /// </summary>
    [Description("Megameters")]
    Megameters,

    /// <summary>
    /// Represents a unit of measurement in kilometers.
    /// </summary>
    [Description("Kilometers")]
    Kilometers,

    /// <summary>
    /// Represents a unit of measurement in hectometers.
    /// </summary>
    [Description("Hectometers")]
    Hectometers,

    /// <summary>
    /// Represents a unit of measurement equal to ten meters.
    /// </summary>
    [Description("Decameters")]
    Decameters,

    /// <summary>
    /// Represents a unit of measurement in meters.
    /// </summary>
    [Description("Meters")]
    Meters,

    /// <summary>
    /// Represents a unit of measurement in decimeters.
    /// </summary>
    [Description("Decimeters")]
    Decimeters,

    /// <summary>
    /// Represents the unit of measurement in centimeters.
    /// </summary>
    [Description("Centimeters")]
    Centimeters,

    /// <summary>
    /// Represents a unit of measurement in millimeters.
    /// </summary>
    [Description("Millimeters")]
    Millimeters,

    /// <summary>
    /// Represents a unit of measurement in micrometers.
    /// </summary>
    [Description("Micrometers")]
    Micrometers,

    /// <summary>
    /// Represents a unit of measurement in nanometers.
    /// </summary>
    [Description("Nanometers")]
    Nanometers,

    /// <summary>
    /// Represents a unit of measurement in picometers.
    /// </summary>
    [Description("Picometers")]
    Picometers,

    /// <summary>
    /// Represents a unit of length in femtometers.
    /// </summary>
    [Description("Femtometers")]
    Femtometers,

    /// <summary>
    /// Represents a unit of measurement in attometers.
    /// </summary>
    [Description("Attometers")]
    Attometers
}

/// <summary>
/// Represents the scale of weight in grams.
/// </summary>
public enum EnumScaleGrams
{
    /// <summary>
    /// Represents a unit of measurement in gigagrams.
    /// </summary>
    [Description("Gigagrams")]
    Gigagrams,

    /// <summary>
    /// Represents the unit of measurement "Megagrams".
    /// </summary>
    [Description("Megagrams")]
    Megagrams,

    /// <summary>
    /// Represents the unit of measurement for kilograms.
    /// </summary>
    [Description("Kilograms")]
    Kilograms,

    /// <summary>
    /// Represents a unit of measurement in hectograms.
    /// </summary>
    [Description("Hectograms")]
    Hectograms,

    /// <summary>
    /// Represents a unit of measurement equal to ten grams.
    /// </summary>
    [Description("Decagrams")]
    Decagrams,

    /// <summary>
    /// Represents a unit of measurement in grams.
    /// </summary>
    [Description("Grams")]
    Grams,

    /// <summary>
    /// Represents a unit of measurement equal to one-tenth of a gram.
    /// </summary>
    [Description("Decigrams")]
    Decigrams,

    /// <summary>
    /// Represents the unit of measurement "Centigrams".
    /// </summary>
    [Description("Centigrams")]
    Centigrams,

    /// <summary>
    /// Represents the unit of measurement in milligrams.
    /// </summary>
    [Description("Milligrams")]
    Milligrams,

    /// <summary>
    /// Represents the unit of measurement in micrograms.
    /// </summary>
    [Description("Micrograms")]
    Micrograms,

    /// <summary>
    /// Represents a unit of measurement in nanograms.
    /// </summary>
    [Description("Nanograms")]
    Nanograms,

    /// <summary>
    /// Represents a unit of measurement in picograms.
    /// </summary>
    [Description("Picograms")]
    Picograms,

    /// <summary>
    /// Represents a unit of measurement for femtograms.
    /// </summary>
    [Description("Femtograms")]
    Femtograms,

    /// <summary>
    /// Represents a unit of measurement called Attograms.
    /// </summary>
    [Description("Attograms")]
    Attograms
}

/// <summary>
/// Represents the scale of time for a measurement.
/// </summary>
public enum EnumScaleTime
{
    /// <summary>
    /// Represents a unit of time equal to one hundred years.
    /// </summary>
    [Description("Centuries")]
    Centuries,

    /// <summary>
    /// Represents the enumeration value for decades.
    /// </summary>
    [Description("Decades")]
    Decades,

    /// <summary>
    /// Represents the enumeration value for years.
    /// </summary>
    [Description("Years")]
    Years,

    /// <summary>
    /// Represents the months.
    /// </summary>
    [Description("Months")]
    Months,

    /// <summary>
    /// Represents a unit of time measured in weeks.
    /// </summary>
    [Description("Weeks")]
    Weeks,

    /// <summary>
    /// Represents the enumeration value for days.
    /// </summary>
    [Description("Days")]
    Days,

    /// <summary>
    /// Represents the unit of time in hours.
    /// </summary>
    [Description("Hours")]
    Hours,

    /// <summary>
    /// Represents a unit of time in minutes.
    /// </summary>
    [Description("Minutes")]
    Minutes,

    /// <summary>
    /// Represents a unit of time in seconds.
    /// </summary>
    [Description("Seconds")]
    Seconds,

    /// <summary>
    /// Represents a unit of time in milliseconds.
    /// </summary>
    [Description("Milliseconds")]
    Milliseconds,

    /// <summary>
    /// Represents a unit of time in microseconds.
    /// </summary>
    [Description("Microseconds")]
    Microseconds,

    /// <summary>
    /// Represents a unit of time equal to one billionth of a second.
    /// </summary>
    [Description("Nanoseconds")]
    Nanoseconds,

    /// <summary>
    /// Represents the unit of measurement in picoseconds.
    /// </summary>
    [Description("Picoseconds")]
    Picoseconds,

    /// <summary>
    /// Represents a unit of time equal to one quadrillionth of a second.
    /// </summary>
    [Description("Femtoseconds")]
    Femtoseconds,

    /// <summary>
    /// Represents a unit of time equal to one quintillionth of a second.
    /// </summary>
    [Description("Attoseconds")]
    Attoseconds
}

/// <summary>
/// Represents the scale of energy in joules.
/// </summary>
public enum EnumScaleJoules
{
    /// <summary>
    /// Represents the unit of measurement "Gigajoules".
    /// </summary>
    [Description("Gigajoules")]
    Gigajoules,

    /// <summary>
    /// Represents the unit of measurement in megajoules.
    /// </summary>
    [Description("Megajoules")]
    Megajoules,

    /// <summary>
    /// Represents the unit of measurement "Kilojoules".
    /// </summary>
    [Description("Kilojoules")]
    Kilojoules,

    /// <summary>
    /// Represents the unit of measurement for energy in joules.
    /// </summary>
    [Description("Joules")]
    Joules,

    /// <summary>
    /// Represents the unit of measurement in millijoules.
    /// </summary>
    [Description("Millijoules")]
    Millijoules,

    /// <summary>
    /// Represents the unit of measurement for energy in microjoules.
    /// </summary>
    [Description("Microjoules")]
    Microjoules,

    /// <summary>
    /// Represents the unit of measurement in nanojoules.
    /// </summary>
    [Description("Nanojoules")]
    Nanojoules,

    /// <summary>
    /// Represents the unit of measurement in picojoules.
    /// </summary>
    [Description("Picojoules")]
    Picojoules,

    /// <summary>
    /// Represents the unit of measurement "Femtojoules".
    /// </summary>
    [Description("Femtojoules")]
    Femtojoules,

    /// <summary>
    /// Represents the unit of energy in attojoules.
    /// </summary>
    [Description("Attojoules")]
    Attojoules
}

/// <summary>
/// Represents the scale of pressure in pascals.
/// </summary>
public enum EnumScalePascal
{
    /// <summary>
    /// Represents the unit of pressure called Gigapascals.
    /// </summary>
    [Description("Gigapascals")]
    Gigapascals,

    /// <summary>
    /// Represents the unit of pressure in megapascals.
    /// </summary>
    [Description("Megapascals")]
    Megapascals,

    /// <summary>
    /// Represents the unit of pressure in kilopascals.
    /// </summary>
    [Description("Kilopascals")]
    Kilopascals,

    /// <summary>
    /// Represents the unit of measurement in hectopascals.
    /// </summary>
    [Description("Hectopascals")]
    Hectopascals,

    /// <summary>
    /// Represents a unit of measurement called Decapascals.
    /// </summary>
    [Description("Decapascals")]
    Decapascals,

    /// <summary>
    /// Represents the unit of pressure in Pascals.
    /// </summary>
    [Description("Pascals")]
    Pascals,

    /// <summary>
    /// Represents a unit of pressure in millipascals.
    /// </summary>
    [Description("Millipascals")]
    Millipascals,

    /// <summary>
    /// Represents a unit of pressure measurement in micropascals.
    /// </summary>
    [Description("Micropascals")]
    Micropascals,

    /// <summary>
    /// Represents a unit of measurement for pressure in nanopascals.
    /// </summary>
    [Description("Nanopascals")]
    Nanopascals,

    /// <summary>
    /// Represents a unit of pressure called Picopascals.
    /// </summary>
    [Description("Picopascals")]
    Picopascals,

    /// <summary>
    /// Represents a unit of measurement equal to one quadrillionth of a pascal.
    /// </summary>
    [Description("Femtopascals")]
    Femtopascals,

    /// <summary>
    /// Represents a unit of pressure measurement in Attopascals.
    /// </summary>
    [Description("Attopascals")]
    Attopascals
}

/// <summary>
/// Represents the scale of miles.
/// </summary>
public enum EnumScaleMiles
{
    /// <summary>
    /// Represents the unit of measurement "Megamiles".
    /// </summary>
    [Description("Megamiles")]
    Megamiles,

    /// <summary>
    /// Represents the unit of measurement "Kilomiles".
    /// </summary>
    [Description("Kilomiles")]
    Kilomiles,

    /// <summary>
    /// Represents a unit of measurement for distance in miles.
    /// </summary>
    [Description("Miles")]
    Miles,

    /// <summary>
    /// Represents the unit of measurement in yards.
    /// </summary>
    [Description("Yards")]
    Yards,

    /// <summary>
    /// Represents the unit of measurement in feet.
    /// </summary>
    [Description("Feet")]
    Feet,

    /// <summary>
    /// Represents a unit of measurement in inches.
    /// </summary>
    [Description("Inches")]
    Inches
}

/// <summary>
/// Represents the scale units for weight measurement.
/// </summary>
public enum EnumScaleOnces
{
    /// <summary>
    /// Represents a unit of measurement for weight called "Kiloounces".
    /// </summary>
    [Description("Kiloounces")]
    Kiloounces,

    /// <summary>
    /// Represents the unit of measurement in ounces.
    /// </summary>
    [Description("Ounces")]
    Ounces,

    /// <summary>
    /// Represents a unit of measurement in milliounces.
    /// </summary>
    [Description("Milliounces")]
    Milliounces,

    /// <summary>
    /// Represents a unit of measurement in microounces.
    /// </summary>
    [Description("Microounces")]
    Microounces
}

/// <summary>
/// Represents the scale of power in watts.
/// </summary>
public enum EnumScaleWatts
{
    /// <summary>
    /// Represents the unit of power measurement in terawatts.
    /// </summary>
    [Description("Terawatts")]
    Terawatts,

    /// <summary>
    /// Represents the unit of measurement for gigawatts.
    /// </summary>
    [Description("Gigawatts")]
    Gigawatts,

    /// <summary>
    /// Represents the unit of measurement for power in megawatts.
    /// </summary>
    [Description("Megawatts")]
    Megawatts,

    /// <summary>
    /// Represents the unit of measurement for power in kilowatts.
    /// </summary>
    [Description("Kilowatts")]
    Kilowatts,

    /// <summary>
    /// Represents the unit of measurement for power in watts.
    /// </summary>
    [Description("Watts")]
    Watts,

    /// <summary>
    /// Represents the unit of power in milliwatts.
    /// </summary>
    [Description("Milliwatts")]
    Milliwatts,

    /// <summary>
    /// Represents a unit of measurement for microwatts.
    /// </summary>
    [Description("Microwatts")]
    Microwatts,

    /// <summary>
    /// Represents the unit of measurement for power in nanowatts.
    /// </summary>
    [Description("Nanowatts")]
    Nanowatts,

    /// <summary>
    /// Represents the unit of measurement in picowatts.
    /// </summary>
    [Description("Picowatts")]
    Picowatts,

    /// <summary>
    /// Represents the unit of power measurement in femtowatts.
    /// </summary>
    [Description("Femtowatts")]
    Femtowatts,

    /// <summary>
    /// Represents a unit of power equal to one attowatt.
    /// </summary>
    [Description("Attowatts")]
    Attowatts
}

/// <summary>
/// Represents the scale of voltage in different units.
/// </summary>
public enum EnumScaleVolts
{
    /// <summary>
    /// Represents the unit of measurement "Kilovolts".
    /// </summary>
    [Description("Kilovolts")]
    Kilovolts,

    /// <summary>
    /// Represents the unit of measurement for volts.
    /// </summary>
    [Description("Volts")]
    Volts,

    /// <summary>
    /// Represents the unit of measurement in millivolts.
    /// </summary>
    [Description("Millivolts")]
    Millivolts,

    /// <summary>
    /// Represents the unit of measurement in microvolts.
    /// </summary>
    [Description("Microvolts")]
    Microvolts,

    /// <summary>
    /// Represents the unit of measurement in nanovolts.
    /// </summary>
    [Description("Nanovolts")]
    Nanovolts,

    /// <summary>
    /// Represents the unit of measurement in picovolts.
    /// </summary>
    [Description("Picovolts")]
    Picovolts,

    /// <summary>
    /// Represents the unit of measurement "Femtovolts".
    /// </summary>
    [Description("Femtovolts")]
    Femtovolts,

    /// <summary>
    /// Represents a unit of measurement in attovolts.
    /// </summary>
    [Description("Attovolts")]
    Attovolts
}

/// <summary>
/// Represents the scale of measurement in liters.
/// </summary>
public enum EnumScaleLiters
{
    /// <summary>
    /// Represents the unit of measurement "Kiloliters".
    /// </summary>
    [Description("Kiloliters")]
    Kiloliters,

    /// <summary>
    /// Represents the unit of measurement in liters.
    /// </summary>
    [Description("Liters")]
    Liters,

    /// <summary>
    /// Represents the unit of measurement "Deciliters".
    /// </summary>
    [Description("Deciliters")]
    Deciliters,

    /// <summary>
    /// Represents a unit of measurement in centiliters.
    /// </summary>
    [Description("Centiliters")]
    Centiliters,

    /// <summary>
    /// Represents a unit of measurement in milliliters.
    /// </summary>
    [Description("Milliliters")]
    Milliliters,

    /// <summary>
    /// Represents a unit of measurement for microliters.
    /// </summary>
    [Description("Microliters")]
    Microliters,

    /// <summary>
    /// Represents the unit of measurement "Nanoliters".
    /// </summary>
    [Description("Nanoliters")]
    Nanoliters,

    /// <summary>
    /// Represents a unit of measurement called "Picoliters".
    /// </summary>
    [Description("Picoliters")]
    Picoliters,

    /// <summary>
    /// Represents a unit of volume measurement in femtoliters.
    /// </summary>
    [Description("Femtoliters")]
    Femtoliters,

    /// <summary>
    /// Represents a volume measurement in attoliters.
    /// </summary>
    [Description("Attoliters")]
    Attoliters
}

/// <summary>
/// Represents the SQL operators used in query conditions.
/// </summary>
public enum SQLOperators
{
    /// <summary>
    /// Represents the equal operator.
    /// </summary>
    [Description("=")]
    Equal,
    /// <summary>
    /// Represents the not equal operator.
    /// </summary>
    [Description("<>")]
    NotEqual,
    /// <summary>
    /// Represents the greater than operator.
    /// </summary>
    [Description(">")]
    GreaterThan,
    /// <summary>
    /// Represents the less than operator.
    /// </summary>
    [Description("<")]
    LessThan,
    /// <summary>
    /// Represents the greater than or equal operator.
    /// </summary>
    [Description(">=")]
    GreaterThanOrEqual,
    /// <summary>
    /// Represents the less than or equal operator.
    /// </summary>
    [Description("<=")]
    LessThanOrEqual,
}