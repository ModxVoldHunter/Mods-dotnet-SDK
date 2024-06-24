using System.Collections.ObjectModel;
using System.Reflection;

namespace System.Runtime.Serialization;

public interface ISerializationSurrogateProvider2 : ISerializationSurrogateProvider
{
	object? GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType);

	object? GetCustomDataToExport(Type runtimeType, Type dataContractType);

	void GetKnownCustomDataTypes(Collection<Type> customDataTypes);

	Type? GetReferencedTypeOnImport(string typeName, string typeNamespace, object? customData);
}
