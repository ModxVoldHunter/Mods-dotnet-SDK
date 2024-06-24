using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
public sealed class DebuggerTypeProxyAttribute : Attribute
{
	private Type _target;

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
	public string ProxyTypeName { get; }

	public Type? Target
	{
		get
		{
			return _target;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			TargetTypeName = value.AssemblyQualifiedName;
			_target = value;
		}
	}

	public string? TargetTypeName { get; set; }

	public DebuggerTypeProxyAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ProxyTypeName = type.AssemblyQualifiedName;
	}

	public DebuggerTypeProxyAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] string typeName)
	{
		ProxyTypeName = typeName;
	}
}
