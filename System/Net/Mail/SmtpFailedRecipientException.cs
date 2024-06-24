using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Net.Mail;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class SmtpFailedRecipientException : SmtpException
{
	private readonly string _failedRecipient;

	internal bool fatal;

	public string? FailedRecipient => _failedRecipient;

	public SmtpFailedRecipientException()
	{
	}

	public SmtpFailedRecipientException(string? message)
		: base(message)
	{
	}

	public SmtpFailedRecipientException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected SmtpFailedRecipientException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_failedRecipient = info.GetString("failedRecipient");
	}

	public SmtpFailedRecipientException(SmtpStatusCode statusCode, string? failedRecipient)
		: base(statusCode)
	{
		_failedRecipient = failedRecipient;
	}

	public SmtpFailedRecipientException(SmtpStatusCode statusCode, string? failedRecipient, string? serverResponse)
		: base(statusCode, serverResponse, _: true)
	{
		_failedRecipient = failedRecipient;
	}

	public SmtpFailedRecipientException(string? message, string? failedRecipient, Exception? innerException)
		: base(message, innerException)
	{
		_failedRecipient = failedRecipient;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		base.GetObjectData(serializationInfo, streamingContext);
		serializationInfo.AddValue("failedRecipient", _failedRecipient, typeof(string));
	}
}
