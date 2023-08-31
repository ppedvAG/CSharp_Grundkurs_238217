using Microsoft.Data.SqlClient;

Console.WriteLine("Hello DB");

var conString = "Server=(localdb)\\mssqllocaldb;Database=NORTHWND;Trusted_Connection=True;";
//var conString = "Server=.;Database=NORTHWIND;Trusted_Connection=True;TrustServerCertificate=True;";

var con = new SqlConnection(conString);
con.Open();

var cmd = con.CreateCommand();
cmd.CommandText = "SELECT COUNT(*) FROM Employees";
var rowCount = cmd.ExecuteScalar();
Console.WriteLine($"{rowCount} Employees gefunden");


cmd = con.CreateCommand();
cmd.CommandText = "SELECT * FROM Employees";
var reader = cmd.ExecuteReader();
while (reader.Read())
{
    var vorname = reader.GetString(reader.GetOrdinal("FirstName"));
    var gebDatum = reader.GetDateTime(reader.GetOrdinal("BirthDate"));
    Console.WriteLine($"{vorname} {gebDatum:d}");
}
