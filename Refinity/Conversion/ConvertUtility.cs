using System.Data;

namespace Refinity.Conversion
{
    public static class ConvertUtility
    {
        public static string ConvertToBase64(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }

        public static List<T> ConvertCsvToObject<T>(Stream stream, Func<string[], T> createObjectFunc, char delimiter = ',')
        {
            List<T> objects = new List<T>();

            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (line == null)
                    {
                        continue;
                    }
                    string[] values = line.Split(delimiter);

                    T obj = createObjectFunc(values);
                    objects.Add(obj);
                }
            }

            return objects;
        }

        public static DataTable ConvertCsvToDataTable(string path, char delimiter = ',')
        {
            DataTable dataTable = new DataTable();

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
                        dataTable.Rows.Add(values);
                    }
                }
            }

            return dataTable;
        }
    }
}