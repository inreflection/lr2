var builder = WebApplication.CreateBuilder();
var app = builder.Build();

var basePath = Environment.CurrentDirectory;

builder.Configuration.AddXmlFile(Path.Combine(basePath, "microsoft.xml"));
builder.Configuration.AddIniFile(Path.Combine(basePath, "google.ini"));
builder.Configuration.AddJsonFile(Path.Combine(basePath, "apple.json"));
builder.Configuration.AddJsonFile(Path.Combine(basePath, "person.json"));


var microsoft = new Company();
var google = new Company();
var apple = new Company();
var person = new Person();

app.Configuration.Bind(microsoft);
app.Configuration.Bind("Google", google);
app.Configuration.Bind("Apple", apple);
app.Configuration.Bind("Person", person);

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"{microsoft.name} - {microsoft.employees}\n");
    await context.Response.WriteAsync($"{google.name} - {google.employees}\n");
    await context.Response.WriteAsync($"{apple.name} - {apple.employees}\n");

    string companyWithMaxEmployees = Company.GetCompanyWithMaxEmployees(microsoft, apple, google);
    await context.Response.WriteAsync($"The company with the largest number of employees: {companyWithMaxEmployees}\n");

    await context.Response.WriteAsync($"Person\nname: {person.name}\nage: {person.age}\ntype of employment: {person.typeOfEmployment}");
});

app.Run();
