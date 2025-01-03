using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dexlaris.Core.Common.Helpers;

public class JsonNullableStringEnumConverterFactory : JsonConverterFactory
{
    private readonly JsonStringEnumConverter _stringEnumConverter;

    public JsonNullableStringEnumConverterFactory(JsonNamingPolicy? namingPolicy = null, bool allowIntegerValues = true)
    {
        _stringEnumConverter = new(namingPolicy, allowIntegerValues);
    }

    public override bool CanConvert(Type typeToConvert)
    {
        // Check if the type is a nullable enum
        if (typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            return Nullable.GetUnderlyingType(typeToConvert)?.IsEnum == true;
        }

        return typeToConvert.IsEnum;
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var underlyingType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
        var converterType = typeof(JsonNullableEnumStringConverter<>).MakeGenericType(underlyingType);

        return (JsonConverter?)Activator.CreateInstance(converterType);
    }
}