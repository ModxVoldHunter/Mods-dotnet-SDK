using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
public sealed class EditorAttribute : Attribute
{
	private string _typeId;

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	public string? EditorBaseTypeName { get; }

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	public string EditorTypeName { get; }

	public override object TypeId
	{
		get
		{
			if (_typeId == null)
			{
				string text = EditorBaseTypeName ?? string.Empty;
				int num = text.IndexOf(',');
				if (num != -1)
				{
					text = text.Substring(0, num);
				}
				_typeId = GetType().FullName + text;
			}
			return _typeId;
		}
	}

	public EditorAttribute()
	{
		EditorTypeName = string.Empty;
		EditorBaseTypeName = string.Empty;
	}

	public EditorAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] string typeName, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] string? baseTypeName)
	{
		ArgumentNullException.ThrowIfNull(typeName, "typeName");
		EditorTypeName = typeName;
		EditorBaseTypeName = baseTypeName;
	}

	public EditorAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] string typeName, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type baseType)
	{
		ArgumentNullException.ThrowIfNull(typeName, "typeName");
		ArgumentNullException.ThrowIfNull(baseType, "baseType");
		EditorTypeName = typeName;
		EditorBaseTypeName = baseType.AssemblyQualifiedName;
	}

	public EditorAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type type, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type baseType)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ArgumentNullException.ThrowIfNull(baseType, "baseType");
		EditorTypeName = type.AssemblyQualifiedName;
		EditorBaseTypeName = baseType.AssemblyQualifiedName;
	}

	public override bool Equals(object? obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj is EditorAttribute editorAttribute && editorAttribute.EditorTypeName == EditorTypeName)
		{
			return editorAttribute.EditorBaseTypeName == EditorBaseTypeName;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
