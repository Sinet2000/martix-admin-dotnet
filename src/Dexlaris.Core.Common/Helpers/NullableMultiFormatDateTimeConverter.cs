using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dexlaris.Core.Common.Helpers;

public class NullableMultiFormatDateTimeConverter<T> : JsonConverter<T?>
{
    private readonly string[] _formats =
    {
        "yyyy-MM-dd",
        "MM/dd/yyyy",
        "yyyyMMdd",
        "dd-MM-yyyy",
        "yyyy-MM-ddTHH:mm:ssZ",
        "yyyy-MM-ddTHH:mm:ss.fffZ",
        "MM-dd-yyyy HH:mm:ss",
        "yyyy-MM-dd HH:mm:ss",
        "MM/dd/yyyy HH:mm:ss",
        "yyyy-MM-ddTHH:mm:sszzz"
    };

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var dateStr = reader.GetString();
            if (string.IsNullOrEmpty(dateStr))
            {
                return default;
            }

            foreach (var format in _formats)
            {
                if (TryParseDate(dateStr, format, out var date))
                {
                    return (T?)date;
                }
            }
        }

        return default;
    }

    public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case DateTimeOffset dateTimeOffset:
                writer.WriteStringValue(dateTimeOffset.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture));
                break;
            case DateTime dateTime:
                writer.WriteStringValue(dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture));
                break;
            default:
                writer.WriteNullValue();
                break;
        }
    }

    private static bool TryParseDate(string dateStr, string format, out object? date)
    {
        if (typeof(T) == typeof(DateTimeOffset))
        {
            if (DateTimeOffset.TryParseExact(dateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOffset))
            {
                date = dateOffset;
                return true;
            }
        }
        else if (typeof(T) == typeof(DateTime))
        {
            if (DateTime.TryParseExact(dateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var dateTime))
            {
                date = dateTime;
                return true;
            }
        }

        date = null;
        return false;
    }
}