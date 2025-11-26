using Clinic.Api.DataBase;
using Clinic.Api.DataSeed;
using Clinic.Api.MappingProfile;
using Clinic.Api.Services;
using Clinic.Api.Converter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null; 
    });
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
builder.Services.AddSingleton<IClinicDataBase, ClinicDataBase>();
builder.Services.AddSingleton<DataSeed>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PatientServices>();
builder.Services.AddScoped<DoctorServices>();
builder.Services.AddScoped<SpecializationServices>();
builder.Services.AddScoped<AppointmentServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
