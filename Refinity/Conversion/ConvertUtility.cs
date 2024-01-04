using System.Data;
using System.Reflection;
using System.Text;
using Refinity.Strings;

namespace Refinity.Conversion;

public class LogEntry
{
    public DateTime Time { get; set; }
    public string? LogLevel { get; set; }
    public string? Message { get; set; }
    public int Severity { get; set; }
}
public static class ConvertUtility
{
    /// <summary>
    /// Converts a file to a Base64 string representation.
    /// </summary>
    /// <param name="path">The path of the file to convert.</param>
    /// <returns>The Base64 string representation of the file.</returns>
    public static string ConvertToBase64(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);
        return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// Converts a CSV file to a list of objects of type T.
    /// </summary>
    /// <typeparam name="T">The type of objects to convert to.</typeparam>
    /// <param name="stream">The stream containing the CSV data.</param>
    /// <param name="delimiter">The delimiter used to separate values in the CSV file. Default is ','.</param>
    /// <param name="ignoreCaseHeader">If true, the header is case insensitive. Default is false.</param>
    /// <returns>A list of objects of type T.</returns>
    public static List<T> ConvertCsvToObject<T>(Stream stream, char delimiter = ',', bool ignoreCaseHeader = false)
    {
        List<PropertyInfo> objectProperties = typeof(T).GetProperties().ToList();
        List<T> objects = new();

        using StreamReader reader = new(stream);
        {
            bool isFirstLine = true;
            string[]? headers = null;
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                if (line == null)
                {
                    continue;
                }
                string[] values = line.Split(delimiter);
                if (isFirstLine)
                {
                    headers = values.Select(v => v.RemoveWhitespace()).ToArray();
                    isFirstLine = false;
                }
                else
                {
                    if (headers == null)
                    {
                        throw new Exception("Headers not found");
                    }
                    if (values.Length != headers.Length)
                    {
                        throw new Exception("The number of values in a row does not match the number of headers.");
                    }
                    T obj = Activator.CreateInstance<T>();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        PropertyInfo? property = objectProperties.FirstOrDefault(p => p.Name == headers[i]);
                        if (ignoreCaseHeader && property == null)
                        {
                            property = objectProperties.FirstOrDefault(p => p.Name.Equals(headers[i], StringComparison.OrdinalIgnoreCase));
                        }

                        if (property == null)
                        {
                            throw new Exception($"Property \"{headers[i]}\" not found, if you want to ignore case set ignoreCaseHeader to true");
                        }

                        object value = Convert.ChangeType(values[i], property.PropertyType);
                        if (value is string)
                        {
                            value = ((string)value).Trim();
                        }
                        property.SetValue(obj, value);
                    }
                    objects.Add(obj);
                }
            }
        }
        return objects;
    }

    /// <summary>
    /// Converts a CSV file to a DataTable.
    /// </summary>
    /// <param name="path">The path of the CSV file.</param>
    /// <param name="delimiter">The delimiter used in the CSV file. Default is ','.</param>
    /// <returns>A DataTable containing the data from the CSV file.</returns>
    public static DataTable ConvertCsvToDataTable(string path, char delimiter = ',')
    {
        DataTable dataTable = new DataTable();

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("The specified CSV file does not exist.");
        }

        using (StreamReader reader = new StreamReader(path))
        {
            bool isFirstLine = true;
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                if (line == null)
                {
                    continue;
                }
                string[] values = line.Split(delimiter);

                if (isFirstLine)
                {
                    foreach (string value in values)
                    {
                        dataTable.Columns.Add(value);
                    }
                    isFirstLine = false;
                }
                else
                {
                    if (values.Length != dataTable.Columns.Count)
                    {
                        throw new InvalidDataException("The number of values in a row does not match the number of columns.");
                    }
                    dataTable.Rows.Add(values);
                }
            }
        }

        return dataTable;
    }

    /// <summary>
    /// Converts a text file to a CSV file.
    /// </summary>
    /// <param name="pathToTxt">The path to the input text file.</param>
    /// <param name="pathToCSV">The path to save the output CSV file.</param>
    /// <param name="delimiter">The character used to separate values in the text file. Default is ','.</param>
    /// <param name="saveDelimiter">The character used to separate values in the CSV file. Default is ','.</param>
    /// <returns>True if the conversion is successful, false otherwise.</returns>
    public static byte[] ConvertTextToCSV(string pathToTxt, char delimiter = ',', char saveDelimiter = ',', string[]? headers = null)
    {
        try
        {
            string[] lines = File.ReadAllLines(pathToTxt);
            StringBuilder stringBuilder = new StringBuilder();
            if (headers != null)
            {
                stringBuilder.AppendLine(string.Join(saveDelimiter, headers));
            }

            foreach (string line in lines)
            {
                string[] values = line.Split(delimiter);
                stringBuilder.AppendLine(string.Join(saveDelimiter, values));
            }
            byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
            return bytes;
        }
        catch (Exception)
        {
            return Array.Empty<byte>();
        }
    }
}