using Clinic.DataBase;
using Clinic.DataBase.Interfaces;
using Clinic.DataBase.EntityFramework;
using Clinic.Api.MappingProfile;
using Microsoft.Extensions.Hosting;
using Clinic.Api.Services;
using Clinic.Api.Converter;
using Clinic.Api.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null; 
    });


var connectionString = builder.Configuration.GetConnectionString("ClinicDb")
                       ?? throw new InvalidOperationException("Connection string 'ClinicDb' is not configured.");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddScoped<IPatientDataBase, EfPatientDataBase>();
builder.Services.AddScoped<IDoctorDataBase, EfDoctorDataBase>();
builder.Services.AddScoped<ISpecializationDataBase, EfSpecializationDataBase>();
builder.Services.AddScoped<IAppointmentDataBase, EfAppointmentDataBase>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapControllers();
app.Run();
