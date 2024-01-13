using Refinity.Conversion;

public class TestObjectForCSV
{
    public string? Column1 { get; set; }
    public string? Column2 { get; set; }
    public string? Column3 { get; set; }
}

[TestFixture]
public class ConvertUtilityTests
{
    string path = "../net8.0/TestFiles/test.csv";
    [Test]
    public void ConvertToBase64_ValidFile_ReturnsBase64String()
    {
        // Arrange
        // Act
        var result = ConvertUtility.ConvertToBase64(path);

        // Assert
        Assert.IsNotNull(result);
        // Add more assertions based on your expected output
    }

    [Test]
    public void ConvertCsvToObject_ValidCsv_ReturnsObjectList()
    {
        // Arrange
        Stream stream = new MemoryStream(); // Use a valid CSV stream
        char delimiter = ',';
        bool ignoreCaseHeader = false;

        // Act
        var result = ConvertUtility.ConvertCsvToObject<TestObjectForCSV>(stream, delimiter, ignoreCaseHeader);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<List<TestObjectForCSV>>(result);
        // Add more assertions based on your expected output
    }

    [Test]
    public void ConvertCsvToDataTable_ValidCsv_ReturnsDataTable()
    {
        // Act
        var result = ConvertUtility.ConvertCsvToDataTable(path);

        // Assert
        Assert.IsNotNull(result);
        // Add more assertions based on your expected output
    }

    [Test]
    public void ConvertXmlToJson_ValidXml_ReturnsJson()
    {
        // Arrange
        string xml = "<root><test>value</test></root>";

        // Act
        var result = ConvertUtility.ConvertXmlToJson(xml);

        // Assert
        Assert.IsNotNull(result);
        // Add more assertions based on your expected output
    }
}