using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dexlaris.Core.Common.Helpers;

public class JsonNullableEnumStringConverter<TEnum> : JsonConverter<TEnum?>
    where TEnum : struct, Enum
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(TEnum?);
    }

    public override TEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException();
        }

        var enumText = reader.GetString();
        foreach (var field in typeof(TEnum).GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
            {
                if (attribute.Value == enumText)
                {
                    return (TEnum)field.GetValue(null)!;
                }
            }
            else if (field.Name == enumText)
            {
                return (TEnum)field.GetValue(null)!;
            }
        }

        throw new JsonException($"Unable to convert \"{enumText}\" to Enum \"{typeof(TEnum)}\".");
    }

    public override void Write(Utf8JsonWriter writer, TEnum? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        var field = typeof(TEnum).GetField(value.ToString()!);
        if (field == null)
        {
            throw new JsonException($"Unable to convert Enum \"{typeof(TEnum)}\" to its string representation.");
        }

        if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
        {
            writer.WriteStringValue(attribute.Value);
        }
        else
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}