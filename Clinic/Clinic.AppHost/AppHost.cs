using Aspire.Hosting.MySql;

var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql")
    .AddDatabase("ClinicDb");

var api = builder.AddProject<Projects.Clinic_Api>("clinic-api")
    .WithReference(mysql)  
    .WaitFor(mysql)
    .WithExternalHttpEndpoints();

builder.Build().Run();