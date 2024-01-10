using Refinity.IO;

[TestFixture]
public class IOTests
{
    private string testDirectoryPath = Path.Combine(Path.GetTempPath(), "TestDirectory");
    private string testFilePath = Path.Combine(Path.GetTempPath(), "TestFile.txt");

    [SetUp]
    public void Setup()
    {
        // Create a test directory and a test file for each test
        Directory.CreateDirectory(testDirectoryPath);
        File.WriteAllText(testFilePath, "Test content");
    }

    [TearDown]
    public void Teardown()
    {
        // Delete the test directory and the test file after each test
        if (Directory.Exists(testDirectoryPath))
        {
            Directory.Delete(testDirectoryPath, true);
        }

        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }
    }

    [Test]
    public void TestCreateDirectory()
    {
        string newDirectoryPath = Path.Combine(testDirectoryPath, "NewDirectory");
        IOUtility.CreateDirectory(newDirectoryPath);
        Assert.IsTrue(Directory.Exists(newDirectoryPath));
    }

    [Test]
    public void TestDeleteDirectory()
    {
        IOUtility.DeleteDirectory(testDirectoryPath);
        Assert.IsFalse(Directory.Exists(testDirectoryPath));
    }

    [Test]
    public void TestCopyDirectory()
    {
        string copyDirectoryPath = Path.Combine(testDirectoryPath, "CopyDirectory");
        IOUtility.CopyDirectory(testDirectoryPath, copyDirectoryPath);
        Assert.IsTrue(Directory.Exists(copyDirectoryPath));
    }

    [Test]
    public void TestMoveDirectory()
    {
        string moveDirectoryPath = Path.Combine(testDirectoryPath, "MoveDirectory");
        IOUtility.MoveDirectory(testDirectoryPath, moveDirectoryPath);
        Assert.IsFalse(Directory.Exists(testDirectoryPath));
        Assert.IsFalse(Directory.Exists(moveDirectoryPath));
    }

    [Test]
    public void TestCopyFile()
    {
        string copyFilePath = Path.Combine(testDirectoryPath, "CopyFile.txt");
        IOUtility.CopyFile(testFilePath, copyFilePath);
        Assert.IsTrue(File.Exists(copyFilePath));
    }

    [Test]
    public void TestMoveFile()
    {
        string moveFilePath = Path.Combine(testDirectoryPath, "MoveFile.txt");
        IOUtility.MoveFile(testFilePath, moveFilePath);
        Assert.IsFalse(File.Exists(testFilePath));
        Assert.IsTrue(File.Exists(moveFilePath));
    }

    [Test]
    public void TestDeleteFile()
    {
        IOUtility.DeleteFile(testFilePath);
        Assert.IsFalse(File.Exists(testFilePath));
    }

    [Test]
    public void TestReadFile()
    {
        string contents = IOUtility.ReadFile(testFilePath);
        Assert.That(contents, Is.EqualTo("Test content"));
    }

    [Test]
    public void TestWriteFile()
    {
        string newContents = "New test content";
        IOUtility.WriteFile(testFilePath, newContents, false);
        string contents = File.ReadAllText(testFilePath);
        Assert.That(contents, Is.EqualTo(newContents));
    }
}