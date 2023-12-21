using Refinity.Date;

try
{
    "22/02/".ToDateTime();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}