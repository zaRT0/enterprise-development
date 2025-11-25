var builder = DistributedApplication.CreateBuilder(args);

var mssql = builder.AddMySql("mysql");
var mssqlDb = mssql.AddDatabase("AirlineDb");

builder.AddProject<Projects.Airline_Api>("AirlineAppAPI")
    .WithReference(mssqlDb, "DefaultConnection")
    .WaitFor(mssqlDb);

builder.Build().Run();