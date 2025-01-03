namespace Dexlaris.Core.Common
{
    public class EnvironmentType(string code, string name) : StringEnumeration(code, name)
    {

        public static EnvironmentType Dev => new(nameof(Dev).ToUpper(), "Development environment");

        public static EnvironmentType Test => new(nameof(Test).ToUpper(), "Test environment");

        public static EnvironmentType Uat => new(nameof(Uat).ToUpper(), "UAT environment");

        public static EnvironmentType Prod => new(nameof(Prod).ToUpper(), "Prod environment");
    }
}