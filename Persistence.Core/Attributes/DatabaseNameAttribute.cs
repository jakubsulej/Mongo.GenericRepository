namespace Persistence.Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class DatabaseNameAttribute : Attribute
{
    public DatabaseNameAttribute(string databaseName)
    {
        DatabaseName = databaseName;
    }

    public string DatabaseName { get; }
}
