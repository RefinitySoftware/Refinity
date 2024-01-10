using Refinity.Strings;

string query = "from users where id = 1 select id, username, password  and password != 123456 and username = admin".CheckSQL();

Console.WriteLine(query);