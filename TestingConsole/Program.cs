using Refinity.Database;
using Refinity.Enums;

var query = new QueryBuilder()
    .Select("id", "name")
    .From("users")
    .Where("id", Operators.Equal, "1")
    .And("name", Operators.NotEqual, "John Doe")
    .Build();

Console.WriteLine(query);