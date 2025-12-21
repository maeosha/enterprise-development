using System.Text.Json;
using System.Text.Json.Serialization;

namespace Clinic.Api.Converter;

/// <summary>
/// Custom JSON converter for DateOnly type, handling serialization and deserialization using the "yyyy-MM-dd" format.
/// </summary>
public class DateConverter : JsonConverter<DateOnly>
{
    private const string Format = "yyyy-MM-dd";

    /// <summary>
    /// Deserializes a JSON string in "yyyy-MM-dd" format to a DateOnly object.
    /// </summary>
    /// <param name="reader">The UTF-8 JSON reader.</param>
    /// <param name="type">The type to convert (DateOnly).</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The parsed DateOnly value.</returns>
    public override DateOnly Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        => DateOnly.ParseExact(reader.GetString()!, Format);

    /// <summary>
    /// Serializes a DateOnly object to a JSON string in "yyyy-MM-dd" format.
    /// </summary>
    /// <param name="writer">The UTF-8 JSON writer.</param>
    /// <param name="value">The DateOnly value to serialize.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(Format));
}