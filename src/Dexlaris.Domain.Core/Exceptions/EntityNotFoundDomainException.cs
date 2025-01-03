namespace Dexlaris.Domain.Core.Exceptions
{
    public class EntityNotFoundDomainException(Type entityType, string propName, object? findByValue)
        : DomainException(GetContext(entityType, propName), GetMessage(entityType, propName, findByValue))
    {

        private static string GetContext(Type entityType, string propName)
        {
            string entityName = entityType.Name;

            return "EntityNotFound." + entityName + "." + propName;
        }

        private static string GetMessage(Type entityType, string propName, object? findByValue)
        {
            string entityName = entityType.Name;

            return $"{entityName} not found [{propName}={findByValue}]";
        }
    }
}