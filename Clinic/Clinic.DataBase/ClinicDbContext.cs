using Clinic.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DataBase;

/// <summary>
/// EF Core <see cref="DbContext"/> for the Clinic application. Configures entities
/// and relationships for patients, doctors, specializations and appointments.
/// </summary>
public class ClinicDbContext : DbContext
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options){}

    /// <summary>
    /// DbSet of patients.
    /// </summary>
    public DbSet<Patient> Patients => Set<Patient>();

    /// <summary>
    /// DbSet of doctors.
    /// </summary>
    public DbSet<Doctor> Doctors => Set<Doctor>();

    /// <summary>
    /// DbSet of specializations.
    /// </summary>
    public DbSet<Specialization> Specializations => Set<Specialization>();

    /// <summary>
    /// DbSet of appointments.
    /// </summary>
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Patient entity
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id);   
            entity.Property(e => e.PassportNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.BirthDate).IsRequired();
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Gender).IsRequired().HasConversion<int>();
            entity.Property(e => e.Address).IsRequired().HasMaxLength(200);
            entity.Property(e => e.BloodGroup).IsRequired().HasConversion<int>();
            entity.Property(e => e.RhesusFactor).IsRequired().HasConversion<int>();
        });

        // Configure Doctor entity
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PassportNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.BirthDate).IsRequired();
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Gender).IsRequired().HasConversion<int>();
            entity.Property(e => e.ExperienceYears).IsRequired();
            
            // Configure many-to-many relationship with Specialization
            entity.HasMany(d => d.Specializations)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "DoctorSpecialization",
                    j => j.HasOne<Specialization>().WithMany().HasForeignKey("SpecializationId"),
                    j => j.HasOne<Doctor>().WithMany().HasForeignKey("DoctorId"),
                    j => j.HasKey("DoctorId", "SpecializationId"));
        });

        // Configure Specialization entity
        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        // Configure Appointment entity
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PatientId).IsRequired();
            entity.Property(e => e.PatientFullName).IsRequired().HasMaxLength(300);
            entity.Property(e => e.DoctorId).IsRequired();
            entity.Property(e => e.DoctorFullName).IsRequired().HasMaxLength(300);
            entity.Property(e => e.DateTime).IsRequired();
            entity.Property(e => e.RoomNumber).IsRequired();
            entity.Property(e => e.IsReturnVisit).IsRequired();
            
            // Configure foreign key relationships
            entity.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}


