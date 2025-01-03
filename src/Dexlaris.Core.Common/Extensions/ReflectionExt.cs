using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Ardalis.GuardClauses;

namespace Dexlaris.Core.Common.Extensions
{
    public static class ReflectionExt
    {
        public static object? GetPropertyValue(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName)?.GetValue(obj);
        }

        public static string? GetPropertyValueAsString(this object obj, string propertyName)
        {
            return GetPropertyValue(obj, propertyName)?.ToString();
        }

        public static bool Implements<TInterface>(this Type type)
            where TInterface : class
        {
            var interfaceType = typeof(TInterface);

            if (!interfaceType.IsInterface)
            {
                throw new InvalidOperationException($"{interfaceType.Name} is not the interface");
            }

            return interfaceType.IsAssignableFrom(type);
        }

        public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public static string GetNameFromTypeDisplayAttribute(Type type, out string? description, out string? externalCode)
        {
            var displayAttribute = type.GetCustomAttribute<DisplayAttribute>();
            Guard.Against.Null(displayAttribute);
            Guard.Against.NullOrEmpty(displayAttribute.Name);
            string name = displayAttribute.Name;
            description = displayAttribute.Description;
            externalCode = displayAttribute.ShortName;

            return name;
        }

        public static string? TryGetNameFromTypeDisplayAttribute(FieldInfo fi, out string? description)
        {
            description = null;
            // externalCode = null;
            var displayAttribute = fi.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute is null)
            {
                return null;
            }

            Guard.Against.NullOrEmpty(displayAttribute.Name);
            string name = displayAttribute.Name;
            description = displayAttribute.Description;
            // externalCode = displayAttribute.ShortName;

            return name;
        }

        public static string GetFieldByName(Type type, string name)
        {
            var codeField = GetConstantTypeFields(type).FirstOrDefault(fi => fi.Name == name);
            if (codeField is null)
            {
                return type.Name;
            }

            return (string)codeField.GetRawConstantValue()!;
        }

        public static IEnumerable<string> GetStaticStringArrayPropertyValuesFromType(Type staticType)
        {
            var props = GetTypeStaticPublicProperties(staticType).Where(t => t.PropertyType == typeof(string[]));
            foreach (var prop in props)
            {
                var values = prop.GetValue(null);
                Guard.Against.Null(values, message: $"Property {prop.Name} is null");

                foreach (var value in (string[])values)
                {
                    yield return value;
                }
            }
        }

        private static IEnumerable<PropertyInfo> GetTypeStaticPublicProperties(Type staticType)
        {
            return staticType.GetProperties(
                BindingFlags.Public
                | BindingFlags.Static
                | BindingFlags.FlattenHierarchy);
        }

        public static IEnumerable<FieldInfo> GetConstantTypeFields(Type staticType)
        {
            return staticType.GetFields(
                    BindingFlags.Public
                    | BindingFlags.Static
                    | BindingFlags.FlattenHierarchy)
                .Where(fi => fi is { IsLiteral: true, IsInitOnly: false });
        }

        public static IEnumerable<Type> GetTypeSubClasses(Type staticType)
        {
            var subClasses = staticType.GetNestedTypes(
                BindingFlags.Public
                | BindingFlags.Static
                | BindingFlags.FlattenHierarchy);

            foreach (var subClass in subClasses)
            {
                if (subClass.IsClass)
                {
                    yield return subClass;
                }
            }
        }
    }
}