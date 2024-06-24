namespace System.Runtime.Serialization.Formatters.Binary;

internal sealed class BinaryCrossAppDomainString : IStreamable
{
	internal int _objectId;

	internal int _value;

	internal BinaryCrossAppDomainString()
	{
	}

	public void Write(BinaryFormatterWriter output)
	{
		output.WriteByte(19);
		output.WriteInt32(_objectId);
		output.WriteInt32(_value);
	}

	public void Read(BinaryParser input)
	{
		_objectId = input.ReadInt32();
		_value = input.ReadInt32();
	}
}
