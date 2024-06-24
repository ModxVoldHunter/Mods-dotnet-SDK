using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.DataAnnotations.Schema;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class TableAttribute : Attribute
{
	private string _schema;

	public string Name { get; }

	public string? Schema
	{
		get
		{
			return _schema;
		}
		[param: DisallowNull]
		set
		{
			ArgumentException.ThrowIfNullOrWhiteSpace(value, "value");
			_schema = value;
		}
	}

	public TableAttribute(string name)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(name, "name");
		Name = name;
	}
}
