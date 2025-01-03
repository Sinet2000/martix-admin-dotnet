using Ardalis.GuardClauses;
using Dexlaris.Core.Common.Extensions;

namespace Dexlaris.Core.Common
{
    public static class EnvironmentHelper
    {
        private const string NetCoreEnvVariable = "ASPNETCORE_ENVIRONMENT";
        private const string IsUatEnvVariable = "IS_UAT_ENVIRONMENT";
        private const string UseSqLiteEnvVariable = "USE_SQLITE";

        private const string StagingEnvironmentVariableValue = "Staging";
        private const string DevelopmentEnvironmentVariableValue = "Development";

        /// <summary>
        /// Set the default environment if environment variable is not set.
        /// </summary>
        public static void EnsureEnvironment()
        {
            string? env = Environment.GetEnvironmentVariable(NetCoreEnvVariable);
            if (env is null)
            {
                Environment.SetEnvironmentVariable(NetCoreEnvVariable, DevelopmentEnvironmentVariableValue);
            }
        }


        public static bool IsDevelopment()
        {
            string env = GetEnvironment(NetCoreEnvVariable);

            if (env.StartsWith(EnvironmentType.Dev.Code, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static bool IsTest()
        {
            string env = GetEnvironment(NetCoreEnvVariable);

            if (env.StartsWith(StagingEnvironmentVariableValue, StringComparison.OrdinalIgnoreCase))
            {
                return !IsUatEnvironment();
            }

            return false;
        }

        public static bool IsUat()
        {
            string env = GetEnvironment(NetCoreEnvVariable);

            if (env.StartsWith(StagingEnvironmentVariableValue, StringComparison.OrdinalIgnoreCase))
            {
                return IsUatEnvironment();
            }

            return false;
        }

        public static bool IsProduction()
        {
            string env = GetEnvironment(NetCoreEnvVariable);

            if (env.StartsWith(EnvironmentType.Prod.Code, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static string GetEnvironment(string variable)
        {
            string? env = Environment.GetEnvironmentVariable(variable);
            Guard.Against.NullOrWhiteSpace(env, NetCoreEnvVariable);

            return env;
        }

        public static string? GetSystemEnvironment()
        {
            return Environment.GetEnvironmentVariable(NetCoreEnvVariable);
        }

        public static void SetUseSqLite()
        {
            Environment.SetEnvironmentVariable(UseSqLiteEnvVariable, true.ToString());
        }

        public static bool IsSqLiteVariableSet()
        {
            return Environment.GetEnvironmentVariable(UseSqLiteEnvVariable) != null;
        }

        public static bool UseSqLite()
        {
            string? useSqLiteStr = Environment.GetEnvironmentVariable(UseSqLiteEnvVariable);

            return useSqLiteStr.ToBoolSafe();
        }

        public static EnvironmentType GetEnvironment()
        {
            if (IsDevelopment())
            {
                return EnvironmentType.Dev;
            }

            if (IsTest())
            {
                return EnvironmentType.Test;
            }

            if (IsUat())
            {
                return EnvironmentType.Uat;
            }

            if (IsProduction())
            {
                return EnvironmentType.Prod;
            }

            throw new ArgumentOutOfRangeException(NetCoreEnvVariable);
        }

        private static bool IsUatEnvironment()
        {
            string? isUatEnvStr = Environment.GetEnvironmentVariable(IsUatEnvVariable);

            return isUatEnvStr.ToBoolSafe();
        }
    }
}