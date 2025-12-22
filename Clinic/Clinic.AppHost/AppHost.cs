var builder = DistributedApplication.CreateBuilder(args);

var postgresql = builder.AddPostgres("postgres")
    .AddDatabase("ClinicDb");

var api = builder.AddProject<Projects.Clinic_Api>("clinic-api")
    .WithReference(postgresql)
    .WaitFor(postgresql)
    .WithExternalHttpEndpoints();

builder.Build().Run();