using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dexlaris.Core.Common.Helpers;

public class JsonStringTrimConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        string? value = reader.GetString();

        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return value.Trim();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            writer.WriteStringValue((string?)null);
        }
        else
        {
            writer.WriteStringValue(value.Trim());
        }
    }
}