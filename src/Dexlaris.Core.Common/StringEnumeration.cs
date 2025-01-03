using System.Reflection;

namespace Dexlaris.Core.Common
{
    public abstract class StringEnumeration(string code, string name) : IComparable
    {

        public string Name { get; private set; } = name;

        public string Code { get; private set; } = code;

        public static bool operator ==(StringEnumeration? left, StringEnumeration? right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(StringEnumeration left, StringEnumeration right)
        {
            return !(left == right);
        }

        public static bool operator <(StringEnumeration? left, StringEnumeration? right)
        {
            return left is null ? right is not null : left.CompareTo(right) < 0;
        }

        public static bool operator <=(StringEnumeration? left, StringEnumeration right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(StringEnumeration? left, StringEnumeration right)
        {
            return left is not null && left.CompareTo(right) > 0;
        }

        public static bool operator >=(StringEnumeration? left, StringEnumeration? right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }

        public static IEnumerable<T> GetAll<T>()
            where T : StringEnumeration
        {
            return typeof(T).GetProperties(BindingFlags.Public |
                                           BindingFlags.Static |
                                           BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>();
        }

        public static T FromValue<T>(string code)
            where T : StringEnumeration
        {
            var matchingItem = Parse<T, string>(code, "code", item => string.Equals(item.Code, code, StringComparison.OrdinalIgnoreCase));

            return matchingItem;
        }

        public static bool ContainsValue<T>(string code)
            where T : StringEnumeration
        {
            return Contains<T>(item => string.Equals(item.Code, code, StringComparison.OrdinalIgnoreCase));
        }

        public static T FromDisplayName<T>(string displayName)
            where T : StringEnumeration
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => string.Equals(item.Name, displayName, StringComparison.OrdinalIgnoreCase));

            return matchingItem;
        }

        public static bool ContainsDisplayName<T>(string displayName)
            where T : StringEnumeration
        {
            return Contains<T>(item => string.Equals(item.Name, displayName, StringComparison.OrdinalIgnoreCase));
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not StringEnumeration otherValue)
            {
                return false;
            }

            bool typeMatches = GetType().Equals(obj.GetType());
            bool valueMatches = Code.Equals(otherValue.Code, StringComparison.OrdinalIgnoreCase);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        public int CompareTo(object? obj)
        {
            if (obj is null)
            {
                return 1;
            }

            if (obj is not StringEnumeration otherValue)
            {
                return 1;
            }

            return string.Compare(Code, otherValue!.Code, StringComparison.OrdinalIgnoreCase);
        }

        private static T Parse<T, TFrom>(TFrom value, string description, Func<T, bool> predicate)
            where T : StringEnumeration
        {
            var found = GetAll<T>().FirstOrDefault(predicate);

            if (found is null)
            {
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
            }

            return found;
        }

        private static bool Contains<T>(Func<T, bool> predicate)
            where T : StringEnumeration
        {
            var found = GetAll<T>().FirstOrDefault(predicate);

            return found is not null;
        }
    }
}