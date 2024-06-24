namespace System.Reflection;

public abstract class ReflectionContext
{
	public abstract Assembly MapAssembly(Assembly assembly);

	public abstract TypeInfo MapType(TypeInfo type);

	public virtual TypeInfo GetTypeForObject(object value)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		return MapType(value.GetType().GetTypeInfo());
	}
}
