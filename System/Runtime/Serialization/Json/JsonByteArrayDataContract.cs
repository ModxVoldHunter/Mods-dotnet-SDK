using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization.DataContracts;

namespace System.Runtime.Serialization.Json;

internal sealed class JsonByteArrayDataContract : JsonDataContract
{
	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public JsonByteArrayDataContract(ByteArrayDataContract traditionalByteArrayDataContract)
		: base(traditionalByteArrayDataContract)
	{
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override object ReadJsonValueCore(XmlReaderDelegator jsonReader, XmlObjectSerializerReadContextComplexJson context)
	{
		if (context == null)
		{
			if (!JsonDataContract.TryReadNullAtTopLevel(jsonReader))
			{
				return jsonReader.ReadElementContentAsBase64();
			}
			return null;
		}
		return JsonDataContract.HandleReadValue(jsonReader.ReadElementContentAsBase64(), context);
	}
}
