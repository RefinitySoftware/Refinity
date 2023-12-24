using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Refinity.Conversion
{
    public static class ConvertUtility
    {
        public static string ConvertToBase64(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }

        public static List<T> ConvertCsvToObject<T>(Stream stream, Func<string[], T> createObjectFunc)
        {
            List<T> objects = new List<T>();

            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    T obj = createObjectFunc(values);
                    objects.Add(obj);
                }
            }

            return objects;
        }

        public static DataTable ConvertCsvToDataTable(string path)
        {
            DataTable dataTable = new DataTable();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                bool isFirstLine = true;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

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