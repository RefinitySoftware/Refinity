using System.Data;
using System.Reflection;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refinity.Enums;
using Refinity.Strings;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Refinity.Conversion;

/// <summary>
/// Represents a utility for converting files.
/// </summary>
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

    public static string ConvertImageToBase64(string imagePath)
    {
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        return Convert.ToBase64String(imageBytes);
    }

    public static void ConvertBase64ToImage(string base64String, string outputPath)
    {
        byte[] imageBytes = Convert.FromBase64String(base64String);
        File.WriteAllBytes(outputPath, imageBytes);
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
    /// Converts an XML string to a JSON string.
    /// </summary>
    /// <param name="xml">The XML string to convert.</param>
    /// <returns>The JSON string representation of the XML.</returns>
    public static string ConvertXmlToJson(string xml)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xml);
        string json = JsonConvert.SerializeXmlNode(xmlDoc);
        return json;
    }

    /// <summary>
    /// Converts a JSON string to an XML string.
    /// </summary>
    /// <param name="json">The JSON string to convert.</param>
    /// <returns>The XML string representation of the JSON.</returns>
    public static string ConvertJsonToXml(string json)
    {
        XmlDocument? xmlDoc = JsonConvert.DeserializeXmlNode(json);
        if (xmlDoc == null)
        {
            throw new Exception("Failed to deserialize JSON to XML.");
        }
        return xmlDoc.OuterXml;
    }

    /// <summary>
    /// Converts a DataTable to a CSV file.
    /// </summary>
    /// <param name="dataTable">The DataTable to convert.</param>
    /// <param name="delimiter">The delimiter used to separate values in the CSV file. Default is ','.</param>
    public static string ConvertDataTableToCsv(DataTable dataTable, char delimiter = ',')
    {
        StringBuilder stringBuilder = new StringBuilder();

        // Append headers
        stringBuilder.AppendLine(string.Join(delimiter, dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName)));

        // Append rows
        foreach (DataRow row in dataTable.Rows)
        {
            stringBuilder.AppendLine(string.Join(delimiter, row.ItemArray));
        }

        // Save to file
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Converts an XML string to a CSV string.
    /// </summary>
    /// <param name="xml">The XML string to convert.</param>
    /// <param name="delimiter">The delimiter character used in the CSV string. Default is ','.</param>
    /// <returns>The CSV string representation of the XML data.</returns>
    public static string ConvertXmlToCsv(string xml, char delimiter = ',')
    {
        XmlDocument? xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xml);
        if (xmlDoc == null)
            throw new Exception("Failed to load XML.");

        StringBuilder stringBuilder = new StringBuilder();

        // Get all XML elements
        XmlNodeList? xmlNodes = xmlDoc.DocumentElement?.SelectNodes("//*");
        if (xmlNodes == null)
            throw new Exception("Failed to get XML nodes.");

        if (xmlNodes != null)
        {
            // Append headers
            stringBuilder.AppendLine(string.Join(delimiter, xmlNodes.Cast<XmlNode>().Select(node => node.Name)));
        }

        // Append values
        foreach (XmlNode node in xmlNodes!)
        {
            stringBuilder.AppendLine(string.Join(delimiter, node.ChildNodes.Cast<XmlNode>().Select(childNode => childNode.InnerText)));
        }

        return stringBuilder.ToString();
    }

    /// <summary>
    /// Converts a JSON string to a CSV string.
    /// </summary>
    /// <param name="json">The JSON string to convert.</param>
    /// <param name="delimiter">The delimiter character used in the CSV string. Default is ','.</param>
    /// <returns>The CSV string representation of the JSON data.</returns>
    public static string ConvertJsonToCsv(string json, char delimiter = ',')
    {
        // Deserialize the JSON string to a dynamic object
        dynamic jsonObject = JsonConvert.DeserializeObject(json);

        // Create a list to store the CSV rows
        List<string> csvRows = new List<string>();

        // Get the headers from the first object in the JSON array
        var firstObject = jsonObject[0];
        var headers = ((JObject)firstObject).Properties().Select(p => p.Name);

        // Add the headers to the CSV rows
        csvRows.Add(string.Join(delimiter, headers));

        // Add the values for each object in the JSON array
        foreach (var obj in jsonObject)
        {
            var values = ((JObject)obj).Properties().Select(p => p.Value.ToString());
            csvRows.Add(string.Join(delimiter, values));
        }

        // Join the CSV rows into a single string
        string csv = string.Join(Environment.NewLine, csvRows);

        return csv;
    }

    /// <summary>
    /// Converts a CSV file to JSON format.
    /// </summary>
    /// <param name="path">The path to the CSV file.</param>
    /// <param name="delimiter">The delimiter used in the CSV file. Default is ','.</param>
    /// <returns>The JSON representation of the CSV data.</returns>
    public static string ConvertCsvToJson(string path, char delimiter = ',')
    {
        DataTable dataTable = new DataTable();

        using (StreamReader reader = new StreamReader(path))
        {
            string[] headers = reader.ReadLine().Split(delimiter);
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }

            while (!reader.EndOfStream)
            {
                string[] values = reader.ReadLine().Split(delimiter);
                DataRow row = dataTable.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    row[i] = values[i];
                }
                dataTable.Rows.Add(row);
            }
        }

        string json = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
        return json;
    }

    /// <summary>
    /// Converts a text file to a CSV file.
    /// </summary>
    /// <param name="pathToTxt">The path to the input text file.</param>
    /// <param name="delimiter">The character used to separate values in the text file. Default is ','.</param>
    /// <param name="saveDelimiter">The character used to separate values in the CSV file. Default is ','.</param>
    /// <param name="headers">The headers to use in the CSV file. Default is null.</param>
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

    /// <summary>
    /// Converts a value from one unit of measurement to another.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="fromUnit">The unit of measurement to convert from.</param>
    /// <param name="toUnit">The unit of measurement to convert to.</param>
    /// <returns>The converted value.</returns>
    public static double ConvertMeasurement(double value, MeasurementUnit fromUnit, MeasurementUnit toUnit)
    {
        const double metersInMile = 1609.34;
        const double metersInKilometer = 1000;
        const double metersInYard = 0.9144;
        const double metersInFoot = 0.3048;
        const double metersInInch = 0.0254;

        double baseconversion = 0;

        switch (fromUnit)
        {
            case MeasurementUnit.Meter:
                baseconversion = value;
                break;
            case MeasurementUnit.Mile:
                baseconversion = value * metersInMile;
                break;
            case MeasurementUnit.Kilometer:
                baseconversion = value * metersInKilometer;
                break;
            case MeasurementUnit.Centimeters:
                baseconversion = value / 100;
                break;
            case MeasurementUnit.Millimeters:
                baseconversion = value / 1000;
                break;
            case MeasurementUnit.Yard:
                baseconversion = value * metersInYard;
                break;
            case MeasurementUnit.Foot:
                baseconversion = value * metersInFoot;
                break;
            case MeasurementUnit.Inch:
                baseconversion = value * metersInInch;
                break;
        }

        double convertedValue = 0;

        switch (toUnit)
        {
            case MeasurementUnit.Meter:
                convertedValue = baseconversion;
                break;
            case MeasurementUnit.Mile:
                convertedValue = baseconversion / metersInMile;
                break;
            case MeasurementUnit.Kilometer:
                convertedValue = baseconversion / metersInKilometer;
                break;
            case MeasurementUnit.Centimeters:
                convertedValue = baseconversion * 100;
                break;
            case MeasurementUnit.Millimeters:
                convertedValue = baseconversion * 1000;
                break;
            case MeasurementUnit.Yard:
                convertedValue = baseconversion / metersInYard;
                break;
            case MeasurementUnit.Foot:
                convertedValue = baseconversion / metersInFoot;
                break;
            case MeasurementUnit.Inch:
                convertedValue = baseconversion / metersInInch;
                break;
        }

        return convertedValue;
    }

    /// <summary>
    /// Converts the text from a file to binary data.
    /// </summary>
    /// <param name="textFilePath">The path of the text file.</param>
    /// <returns>An array of bytes representing the binary data.</returns>
    public static byte[] ConvertTextToBinary(string textFilePath)
    {
        string text = File.ReadAllText(textFilePath);
        return Encoding.UTF8.GetBytes(text);
    }

    /// <summary>
    /// Converts a binary file to text using UTF-8 encoding.
    /// </summary>
    /// <param name="binaryFilePath">The path of the binary file to convert.</param>
    /// <returns>The text representation of the binary file.</returns>
    public static string ConvertBinaryToText(string binaryFilePath)
    {
        byte[] binaryData = File.ReadAllBytes(binaryFilePath);
        return Encoding.UTF8.GetString(binaryData);
    }

    /// <summary>
    /// Converts a PDF file to text.
    /// </summary>
    /// <param name="pdfPath">The path of the PDF file.</param>
    /// <returns>The extracted text from the PDF file.</returns>
    public static string ConvertPdfToText(string pdfPath)
    {
        using (PdfReader reader = new PdfReader(pdfPath))
        {
            StringBuilder text = new StringBuilder();

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
            }

            return text.ToString();
        }
    }



}