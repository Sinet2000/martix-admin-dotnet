using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Dexlaris.Core.Common.Helpers;

/// <summary>
/// Helper class for JSON serialization and deserialization with customizable options.
/// </summary>
public static class JsonHelper
{
    /// <summary>
    /// Lazy-initialized JsonSerializerOptions for default JSON serialization settings.
    /// </summary>
    private static Lazy<JsonSerializerOptions> JsonOptLazy => new(GetJsonOptions);

    public static string Serialize<T>(T value) => JsonSerializer.Serialize(value, JsonOptLazy.Value);

    public static T? Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, JsonOptLazy.Value);

    public static T? Deserialize<T>(Stream json) => JsonSerializer.Deserialize<T>(json, JsonOptLazy.Value);

    public static bool TryDeserialize<T>(string json, out T? result)
    {
        if (string.IsNullOrEmpty(json))
        {
            result = default;

            return true;
        }

        result = default!;
        try
        {
            result = Deserialize<T>(json);

            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }

    private static JsonSerializerOptions GetJsonOptions()
    {
        var jsonOpt = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),

            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

            // Ignore properties with null or default values when serializing
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull,

            // Ignore cycles in object graphs to prevent infinite loops
            ReferenceHandler = ReferenceHandler.IgnoreCycles,

            // Make property name comparison case-insensitive during deserialization
            PropertyNameCaseInsensitive = true,

            // Allow JSON objects and arrays to have trailing commas
            AllowTrailingCommas = true,
        };
        jsonOpt.Converters.Add(new JsonStringEnumConverter());
        jsonOpt.Converters.Add(new JsonNullableStringEnumConverterFactory());
        jsonOpt.Converters.Add(new NullableMultiFormatDateTimeConverter<DateTime>());
        jsonOpt.Converters.Add(new NullableMultiFormatDateTimeConverter<DateTimeOffset>());

        return jsonOpt;
    }
}