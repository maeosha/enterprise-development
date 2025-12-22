using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed Specializations
            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Терапевт" },
                    { 2, "Хирург" },
                    { 3, "Кардиолог" },
                    { 4, "Невролог" },
                    { 5, "Офтальмолог" },
                    { 6, "Отоларинголог" },
                    { 7, "Дерматолог" },
                    { 8, "Педиатр" },
                    { 9, "Гинеколог" },
                    { 10, "Уролог" }
                });

            // Seed Doctors (10 doctors)
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "PassportNumber", "BirthDate", "LastName", "FirstName", "Patronymic", "PhoneNumber", "Gender", "ExperienceYears" },
                values: new object[,]
                {
                    { 1, "AB1234567", new DateOnly(1975, 5, 15), "Иванов", "Иван", "Иванович", "+7-900-123-45-67", 0, 15 },
                    { 2, "CD2345678", new DateOnly(1980, 8, 22), "Петрова", "Мария", "Сергеевна", "+7-900-234-56-78", 1, 12 },
                    { 3, "EF3456789", new DateOnly(1972, 3, 10), "Сидоров", "Александр", "Петрович", "+7-900-345-67-89", 0, 20 },
                    { 4, "GH4567890", new DateOnly(1985, 11, 5), "Козлова", "Елена", "Владимировна", "+7-900-456-78-90", 1, 8 },
                    { 5, "IJ5678901", new DateOnly(1978, 7, 30), "Морозов", "Дмитрий", "Александрович", "+7-900-567-89-01", 0, 14 },
                    { 6, "KL6789012", new DateOnly(1982, 4, 18), "Волкова", "Анна", "Дмитриевна", "+7-900-678-90-12", 1, 10 },
                    { 7, "MN7890123", new DateOnly(1976, 9, 25), "Лебедев", "Сергей", "Викторович", "+7-900-789-01-23", 0, 16 },
                    { 8, "OP8901234", new DateOnly(1988, 1, 12), "Новикова", "Ольга", "Андреевна", "+7-900-890-12-34", 1, 6 },
                    { 9, "QR9012345", new DateOnly(1974, 6, 8), "Федоров", "Максим", "Сергеевич", "+7-900-901-23-45", 0, 18 },
                    { 10, "ST0123456", new DateOnly(1983, 12, 20), "Смирнова", "Татьяна", "Игоревна", "+7-900-012-34-56", 1, 11 }
                });

            // Seed Doctor-Specialization relationships
            migrationBuilder.InsertData(
                table: "DoctorSpecialization",
                columns: new[] { "DoctorId", "SpecializationId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 4 },
                    { 3, 1 },
                    { 4, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 6, 8 },
                    { 7, 2 },
                    { 7, 10 },
                    { 8, 9 },
                    { 9, 3 },
                    { 9, 1 },
                    { 10, 5 },
                    { 10, 6 }
                });

            // Seed Patients (10 patients)
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "PassportNumber", "BirthDate", "LastName", "FirstName", "Patronymic", "PhoneNumber", "Gender", "Address", "BloodGroup", "RhesusFactor" },
                values: new object[,]
                {
                    { 1, "KL6789012", new DateOnly(1970, 2, 14), "Смирнов", "Алексей", "Игоревич", "+7-901-111-11-11", 0, "г. Москва, ул. Ленина, д. 10, кв. 5", 0, 0 },
                    { 2, "MN7890123", new DateOnly(1975, 6, 20), "Волкова", "Анна", "Дмитриевна", "+7-901-222-22-22", 1, "г. Москва, ул. Пушкина, д. 25, кв. 12", 1, 0 },
                    { 3, "OP8901234", new DateOnly(1972, 9, 8), "Лебедев", "Сергей", "Викторович", "+7-901-333-33-33", 0, "г. Москва, пр. Мира, д. 50, кв. 8", 2, 1 },
                    { 4, "QR9012345", new DateOnly(1988, 12, 3), "Новикова", "Ольга", "Андреевна", "+7-901-444-44-44", 1, "г. Москва, ул. Гагарина, д. 15, кв. 20", 3, 0 },
                    { 5, "ST0123456", new DateOnly(1995, 4, 17), "Федоров", "Максим", "Сергеевич", "+7-901-555-55-55", 0, "г. Москва, ул. Чехова, д. 30, кв. 15", 0, 1 },
                    { 6, "UV1234567", new DateOnly(1987, 7, 22), "Кузнецова", "Екатерина", "Александровна", "+7-901-666-66-66", 1, "г. Москва, ул. Тверская, д. 5, кв. 3", 1, 1 },
                    { 7, "WX2345678", new DateOnly(1993, 11, 30), "Попов", "Андрей", "Николаевич", "+7-901-777-77-77", 0, "г. Москва, ул. Арбат, д. 20, кв. 7", 2, 0 },
                    { 8, "YZ3456789", new DateOnly(1989, 3, 15), "Соколова", "Мария", "Владимировна", "+7-901-888-88-88", 1, "г. Москва, ул. Садовая, д. 12, кв. 9", 3, 1 },
                    { 9, "AA4567890", new DateOnly(1991, 8, 5), "Михайлов", "Игорь", "Борисович", "+7-901-999-99-99", 0, "г. Москва, ул. Невский, д. 40, кв. 11", 0, 0 },
                    { 10, "BB5678901", new DateOnly(1986, 1, 28), "Павлова", "Наталья", "Сергеевна", "+7-901-000-00-00", 1, "г. Москва, ул. Красная, д. 8, кв. 4", 1, 0 }
                });

            // Seed Appointments (15 appointments)
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "PatientId", "PatientFullName", "DoctorId", "DoctorFullName", "DateTime", "RoomNumber", "IsReturnVisit" },
                values: new object[,]
                {
                    { 1, 1, "Смирнов Алексей Игоревич", 1, "Иванов Иван Иванович", new DateTime(2025, 12, 10, 10, 0, 0, 0, DateTimeKind.Utc), 101, false },
                    { 2, 2, "Волкова Анна Дмитриевна", 2, "Петрова Мария Сергеевна", new DateTime(2025, 12, 10, 11, 30, 0, 0, DateTimeKind.Utc), 205, false },
                    { 3, 3, "Лебедев Сергей Викторович", 3, "Сидоров Александр Петрович", new DateTime(2025, 8, 21, 9, 0, 0, 0, DateTimeKind.Utc), 302, true },
                    { 4, 4, "Новикова Ольга Андреевна", 4, "Козлова Елена Владимировна", new DateTime(2025, 12, 21, 14, 0, 0, 0, DateTimeKind.Utc), 401, false },
                    { 5, 5, "Федоров Максим Сергеевич", 5, "Морозов Дмитрий Александрович", new DateTime(2025, 12, 22, 10, 30, 0, 0, DateTimeKind.Utc), 503, false },
                    { 6, 6, "Кузнецова Екатерина Александровна", 6, "Волкова Анна Дмитриевна", new DateTime(2025, 12, 22, 15, 0, 0, 0, DateTimeKind.Utc), 201, false },
                    { 7, 7, "Попов Андрей Николаевич", 7, "Лебедев Сергей Викторович", new DateTime(2025, 5, 13, 9, 30, 0, 0, DateTimeKind.Utc), 305, true },
                    { 8, 8, "Соколова Мария Владимировна", 8, "Новикова Ольга Андреевна", new DateTime(2025, 6, 23, 11, 0, 0, 0, DateTimeKind.Utc), 402, false },
                    { 9, 9, "Михайлов Игорь Борисович", 9, "Федоров Максим Сергеевич", new DateTime(2025, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), 104, false },
                    { 10, 10, "Павлова Наталья Сергеевна", 10, "Смирнова Татьяна Игоревна", new DateTime(2025, 12, 24, 13, 30, 0, 0, DateTimeKind.Utc), 501, false },
                    { 11, 1, "Смирнов Алексей Игоревич", 2, "Петрова Мария Сергеевна", new DateTime(2025, 3, 25, 10, 0, 0, 0, DateTimeKind.Utc), 101, true },
                    { 12, 3, "Лебедев Сергей Викторович", 5, "Морозов Дмитрий Александрович", new DateTime(2025, 4, 25, 14, 0, 0, 0, DateTimeKind.Utc), 302, true },
                    { 13, 5, "Федоров Максим Сергеевич", 5, "Морозов Дмитрий Александрович", new DateTime(2025, 11, 26, 9, 0, 0, 0, DateTimeKind.Utc), 503, true },
                    { 14, 7, "Попов Андрей Николаевич", 7, "Лебедев Сергей Викторович", new DateTime(2025, 11, 26, 11, 30, 0, 0, DateTimeKind.Utc), 305, false },
                    { 15, 9, "Михайлов Игорь Борисович", 9, "Федоров Максим Сергеевич", new DateTime(2025, 11, 27, 10, 30, 0, 0, DateTimeKind.Utc), 104, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove seed data in reverse order
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialization",
                keyColumns: new[] { "DoctorId", "SpecializationId" },
                keyValues: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 4 },
                    { 3, 1 },
                    { 4, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 6, 8 },
                    { 7, 2 },
                    { 7, 10 },
                    { 8, 9 },
                    { 9, 3 },
                    { 9, 1 },
                    { 10, 5 },
                    { 10, 6 }
                });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }
    }
}
