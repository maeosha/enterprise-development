var builder = DistributedApplication.CreateBuilder(args);

var postgresql = builder.AddPostgres("postgres")
    .AddDatabase("ClinicDb");

var api = builder.AddProject("clinic-api", "../Clinic.Api/Clinic.Api.csproj")
    .WithReference(postgresql)
    .WaitFor(postgresql)
    .WithExternalHttpEndpoints();

var appiontmentGenerator = builder.AddProject("clinic-appiontment-generator", "../Clinic.AppiontmentGenerator/Clinic.AppiontmentGenerator.csproj")
    .WithReference(postgresql)
    .WithReference(api)
    .WaitFor(postgresql)
    .WaitFor(api)
    .WithEnvironment("Grpc__Endpoint", api.GetEndpoint("https"));

builder.Build().Run();
