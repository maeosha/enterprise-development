using Clinic.DataBase;
using Clinic.Application.Ports;
using Clinic.DataBase.EntityFramework;
using Clinic.Application.Services.Mapping;
using Microsoft.Extensions.Hosting;
using Clinic.Application.Services;
using Clinic.Api.Converter;
using Clinic.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Clinic.Api.Grpc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddGrpc();

var connectionString = builder.Configuration.GetConnectionString("ClinicDb")
                       ?? throw new InvalidOperationException("Connection string 'ClinicDb' is not configured.");

builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IPatientRepository, EfPatientRepository>();
builder.Services.AddScoped<IDoctorRepository, EfDoctorRepository>();
builder.Services.AddScoped<ISpecializationRepository, EfSpecializationRepository>();
builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

builder.Services.AddScoped<IPatientServices, PatientServices>();
builder.Services.AddScoped<IDoctorServices, DoctorServices>();
builder.Services.AddScoped<ISpecializationServices, SpecializationServices>();
builder.Services.AddScoped<IAppointmentServices, AppointmentServices>();
builder.Services.AddScoped<AnalyticsServices>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ClinicDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic API V1");
        options.RoutePrefix = "swagger"; 
    });
}

app.MapGrpcService<ContractIngestService>();
app.MapControllers();
app.Run();
