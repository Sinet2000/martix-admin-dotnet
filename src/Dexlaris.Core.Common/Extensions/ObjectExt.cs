using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Dexlaris.Core.Common.Extensions
{
    public static class ObjectExt
    {
        private static readonly JsonSerializerOptions DumperSerOpts = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        public static string Dump<T>(this T data, [CallerArgumentExpression("data")] string? name = null)
        {
            string prefix = "dump: " + typeof(T).Name;

            if (name.HasValue())
            {
                prefix += $"[{name}]";
            }

            prefix += Environment.NewLine;

            return prefix + JsonSerializer.Serialize(data, DumperSerOpts);
        }
    }
}