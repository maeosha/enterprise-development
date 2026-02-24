if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("DOTNET_DASHBOARD_OTLP_ENDPOINT_URL")) &&
    string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("DOTNET_DASHBOARD_OTLP_HTTP_ENDPOINT_URL")))
{
    Environment.SetEnvironmentVariable("DOTNET_DASHBOARD_OTLP_ENDPOINT_URL", "http://127.0.0.1:4317");
    Environment.SetEnvironmentVariable("DOTNET_DASHBOARD_OTLP_HTTP_ENDPOINT_URL", "http://127.0.0.1:4318");
}

if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("ASPIRE_ALLOW_UNSECURED_TRANSPORT")))
{
    Environment.SetEnvironmentVariable("ASPIRE_ALLOW_UNSECURED_TRANSPORT", "true");
}

var builder = DistributedApplication.CreateBuilder(args);

var postgresql = builder.AddPostgres("postgres")
    .AddDatabase("ClinicDb");

var api = builder.AddProject("clinic-api", "../Clinic.Api/Clinic.Api.csproj")
    .WithReference(postgresql)
    .WithExternalHttpEndpoints();

var appointmentGenerator = builder.AddProject("clinic-appointment-generator", "../Clinic.AppointmentGenerator/Clinic.AppointmentGenerator.csproj")
    .WithReference(postgresql)
    .WithEnvironment("Grpc__Endpoint", api.GetEndpoint("https"));

builder.Build().Run();
