using Refinity.Database;

var query = new QueryBuilder()
    .Select("id", "username", "password")
    .From("users")
    .Where("id", "1")
    .AndNot("password", "123456")
    .And("username", "admin")
    .Build();

Console.WriteLine(query);