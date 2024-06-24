using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Data;

[Serializable]
[TypeForwardedFrom("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class DeletedRowInaccessibleException : DataException
{
	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected DeletedRowInaccessibleException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public DeletedRowInaccessibleException()
		: base(System.SR.DataSet_DefaultDeletedRowInaccessibleException)
	{
		base.HResult = -2146232031;
	}

	public DeletedRowInaccessibleException(string? s)
		: base(s)
	{
		base.HResult = -2146232031;
	}

	public DeletedRowInaccessibleException(string? message, Exception? innerException)
		: base(message, innerException)
	{
		base.HResult = -2146232031;
	}
}
