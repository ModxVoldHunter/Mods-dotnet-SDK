using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Data.SqlTypes;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class SqlTruncateException : SqlTypeException
{
	public SqlTruncateException()
		: this(SQLResource.TruncationMessage, null)
	{
	}

	public SqlTruncateException(string? message)
		: this(message, null)
	{
	}

	public SqlTruncateException(string? message, Exception? e)
		: base(message, e)
	{
		base.HResult = -2146232014;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private SqlTruncateException(SerializationInfo si, StreamingContext sc)
		: base(SqlTruncateExceptionSerialization(si, sc), sc)
	{
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	private static SerializationInfo SqlTruncateExceptionSerialization(SerializationInfo si, StreamingContext sc)
	{
		if (si != null && 1 == si.MemberCount)
		{
			string @string = si.GetString("SqlTruncateExceptionMessage");
			SqlTruncateException ex = new SqlTruncateException(@string);
			ex.GetObjectData(si, sc);
		}
		return si;
	}
}
