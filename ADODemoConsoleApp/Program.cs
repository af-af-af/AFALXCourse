// See https://aka.ms/new-console-template for more information
using ADODemoConsoleApp;

Console.WriteLine("Hello, World!");
var connectionString = "Data Source=DESKTOP-TTJ6DGH\\SQLEXPRESS;Initial Catalog=company;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
ADODemo demo = new ADODemo(connectionString);
Console.WriteLine("--------------------------------");
demo.RunSelectAll();
Console.WriteLine("--------------------------------");
demo.RunSelectDefinedColumnSet("first_name", "email");
Console.WriteLine("--------------------------------");
//demo.InsertEmployeeDemo();
Console.WriteLine("--------------------------------");
demo.InsertManyEmployeesDemo();