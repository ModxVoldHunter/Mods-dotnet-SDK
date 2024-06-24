using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Runtime.Serialization.Formatters.Binary;

internal sealed class BinaryFormatterWriter
{
	private sealed class ObjectMapInfo
	{
		internal readonly int _objectId;

		private readonly int _numMembers;

		private readonly string[] _memberNames;

		private readonly Type[] _memberTypes;

		internal ObjectMapInfo(int objectId, int numMembers, string[] memberNames, Type[] memberTypes)
		{
			_objectId = objectId;
			_numMembers = numMembers;
			_memberNames = memberNames;
			_memberTypes = memberTypes;
		}

		internal bool IsCompatible(int numMembers, string[] memberNames, Type[] memberTypes)
		{
			if (_numMembers != numMembers)
			{
				return false;
			}
			for (int i = 0; i < numMembers; i++)
			{
				if (!_memberNames[i].Equals(memberNames[i]))
				{
					return false;
				}
				if (memberTypes != null && _memberTypes[i] != memberTypes[i])
				{
					return false;
				}
			}
			return true;
		}
	}

	private readonly Stream _outputStream;

	private readonly FormatterTypeStyle _formatterTypeStyle;

	private readonly ObjectWriter _objectWriter;

	private readonly BinaryWriter _dataWriter;

	private int _consecutiveNullArrayEntryCount;

	private Dictionary<string, ObjectMapInfo> _objectMapTable;

	private BinaryObject _binaryObject;

	private BinaryObjectWithMap _binaryObjectWithMap;

	private BinaryObjectWithMapTyped _binaryObjectWithMapTyped;

	private BinaryObjectString _binaryObjectString;

	private BinaryArray _binaryArray;

	private byte[] _byteBuffer;

	private MemberPrimitiveUnTyped _memberPrimitiveUnTyped;

	private MemberPrimitiveTyped _memberPrimitiveTyped;

	private ObjectNull _objectNull;

	private MemberReference _memberReference;

	private BinaryAssembly _binaryAssembly;

	internal BinaryFormatterWriter(Stream outputStream, ObjectWriter objectWriter, FormatterTypeStyle formatterTypeStyle)
	{
		_outputStream = outputStream;
		_formatterTypeStyle = formatterTypeStyle;
		_objectWriter = objectWriter;
		_dataWriter = new BinaryWriter(outputStream, Encoding.UTF8);
	}

	internal void WriteBegin()
	{
	}

	internal void WriteEnd()
	{
		_dataWriter.Flush();
	}

	internal void WriteBoolean(bool value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteByte(byte value)
	{
		_dataWriter.Write(value);
	}

	private void WriteBytes(byte[] value)
	{
		_dataWriter.Write(value);
	}

	private void WriteBytes(byte[] byteA, int offset, int size)
	{
		_dataWriter.Write(byteA, offset, size);
	}

	internal void WriteChar(char value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteChars(char[] value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteDecimal(decimal value)
	{
		WriteString(value.ToString(CultureInfo.InvariantCulture));
	}

	internal void WriteSingle(float value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteDouble(double value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteInt16(short value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteInt32(int value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteInt64(long value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteSByte(sbyte value)
	{
		WriteByte((byte)value);
	}

	internal void WriteString(string value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteTimeSpan(TimeSpan value)
	{
		WriteInt64(value.Ticks);
	}

	internal void WriteDateTime(DateTime value)
	{
		long value2 = Unsafe.As<DateTime, long>(ref value);
		WriteInt64(value2);
	}

	internal void WriteUInt16(ushort value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteUInt32(uint value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteUInt64(ulong value)
	{
		_dataWriter.Write(value);
	}

	internal void WriteObjectEnd(NameInfo memberNameInfo, NameInfo typeNameInfo)
	{
	}

	internal void WriteSerializationHeaderEnd()
	{
		MessageEnd messageEnd = new MessageEnd();
		messageEnd.Write(this);
	}

	internal void WriteSerializationHeader(int topId, int headerId, int minorVersion, int majorVersion)
	{
		SerializationHeaderRecord serializationHeaderRecord = new SerializationHeaderRecord(BinaryHeaderEnum.SerializedStreamHeader, topId, headerId, minorVersion, majorVersion);
		serializationHeaderRecord.Write(this);
	}

	internal void WriteObject(NameInfo nameInfo, NameInfo typeNameInfo, int numMembers, string[] memberNames, Type[] memberTypes, WriteObjectInfo[] memberObjectInfos)
	{
		InternalWriteItemNull();
		int num = (int)nameInfo._objectId;
		string text = ((num < 0) ? typeNameInfo.NIname : nameInfo.NIname);
		if (_objectMapTable == null)
		{
			_objectMapTable = new Dictionary<string, ObjectMapInfo>();
		}
		if (_objectMapTable.TryGetValue(text, out var value) && value.IsCompatible(numMembers, memberNames, memberTypes))
		{
			if (_binaryObject == null)
			{
				_binaryObject = new BinaryObject();
			}
			_binaryObject.Set(num, value._objectId);
			_binaryObject.Write(this);
			return;
		}
		int assemId;
		if (!typeNameInfo._transmitTypeOnObject)
		{
			if (_binaryObjectWithMap == null)
			{
				_binaryObjectWithMap = new BinaryObjectWithMap();
			}
			assemId = (int)typeNameInfo._assemId;
			_binaryObjectWithMap.Set(num, text, numMembers, memberNames, assemId);
			_binaryObjectWithMap.Write(this);
			if (value == null)
			{
				_objectMapTable.Add(text, new ObjectMapInfo(num, numMembers, memberNames, memberTypes));
			}
			return;
		}
		BinaryTypeEnum[] array = new BinaryTypeEnum[numMembers];
		object[] array2 = new object[numMembers];
		int[] array3 = new int[numMembers];
		for (int i = 0; i < numMembers; i++)
		{
			array[i] = BinaryTypeConverter.GetBinaryTypeInfo(memberTypes[i], memberObjectInfos[i], null, _objectWriter, out var typeInformation, out assemId);
			array2[i] = typeInformation;
			array3[i] = assemId;
		}
		if (_binaryObjectWithMapTyped == null)
		{
			_binaryObjectWithMapTyped = new BinaryObjectWithMapTyped();
		}
		assemId = (int)typeNameInfo._assemId;
		_binaryObjectWithMapTyped.Set(num, text, numMembers, memberNames, array, array2, array3, assemId);
		_binaryObjectWithMapTyped.Write(this);
		if (value == null)
		{
			_objectMapTable.Add(text, new ObjectMapInfo(num, numMembers, memberNames, memberTypes));
		}
	}

	internal void WriteObjectString(int objectId, string value)
	{
		InternalWriteItemNull();
		if (_binaryObjectString == null)
		{
			_binaryObjectString = new BinaryObjectString();
		}
		_binaryObjectString.Set(objectId, value);
		_binaryObjectString.Write(this);
	}

	internal void WriteSingleArray(NameInfo memberNameInfo, NameInfo arrayNameInfo, WriteObjectInfo objectInfo, NameInfo arrayElemTypeNameInfo, int length, int lowerBound, Array array)
	{
		InternalWriteItemNull();
		int[] lengthA = new int[1] { length };
		int[] lowerBoundA = null;
		BinaryArrayTypeEnum binaryArrayTypeEnum;
		if (lowerBound == 0)
		{
			binaryArrayTypeEnum = BinaryArrayTypeEnum.Single;
		}
		else
		{
			binaryArrayTypeEnum = BinaryArrayTypeEnum.SingleOffset;
			lowerBoundA = new int[1] { lowerBound };
		}
		object typeInformation;
		int assemId;
		BinaryTypeEnum binaryTypeInfo = BinaryTypeConverter.GetBinaryTypeInfo(arrayElemTypeNameInfo._type, objectInfo, arrayElemTypeNameInfo.NIname, _objectWriter, out typeInformation, out assemId);
		if (_binaryArray == null)
		{
			_binaryArray = new BinaryArray();
		}
		_binaryArray.Set((int)arrayNameInfo._objectId, 1, lengthA, lowerBoundA, binaryTypeInfo, typeInformation, binaryArrayTypeEnum, assemId);
		_binaryArray.Write(this);
		if (Converter.IsWriteAsByteArray(arrayElemTypeNameInfo._primitiveTypeEnum) && lowerBound == 0)
		{
			if (arrayElemTypeNameInfo._primitiveTypeEnum == InternalPrimitiveTypeE.Byte)
			{
				WriteBytes((byte[])array);
			}
			else if (arrayElemTypeNameInfo._primitiveTypeEnum == InternalPrimitiveTypeE.Char)
			{
				WriteChars((char[])array);
			}
			else
			{
				WriteArrayAsBytes(array, Converter.TypeLength(arrayElemTypeNameInfo._primitiveTypeEnum));
			}
		}
	}

	private void WriteArrayAsBytes(Array array, int typeLength)
	{
		InternalWriteItemNull();
		int i = 0;
		if (_byteBuffer == null)
		{
			_byteBuffer = new byte[4096];
		}
		int num;
		for (; i < array.Length; i += num)
		{
			num = Math.Min(4096 / typeLength, array.Length - i);
			int num2 = num * typeLength;
			Buffer.BlockCopy(array, i * typeLength, _byteBuffer, 0, num2);
			if (!BitConverter.IsLittleEndian)
			{
				for (int j = 0; j < num2; j += typeLength)
				{
					for (int k = 0; k < typeLength / 2; k++)
					{
						byte b = _byteBuffer[j + k];
						_byteBuffer[j + k] = _byteBuffer[j + typeLength - 1 - k];
						_byteBuffer[j + typeLength - 1 - k] = b;
					}
				}
			}
			WriteBytes(_byteBuffer, 0, num2);
		}
	}

	internal void WriteJaggedArray(NameInfo memberNameInfo, NameInfo arrayNameInfo, WriteObjectInfo objectInfo, NameInfo arrayElemTypeNameInfo, int length, int lowerBound)
	{
		InternalWriteItemNull();
		int[] lengthA = new int[1] { length };
		int[] lowerBoundA = null;
		BinaryArrayTypeEnum binaryArrayTypeEnum;
		if (lowerBound == 0)
		{
			binaryArrayTypeEnum = BinaryArrayTypeEnum.Jagged;
		}
		else
		{
			binaryArrayTypeEnum = BinaryArrayTypeEnum.JaggedOffset;
			lowerBoundA = new int[1] { lowerBound };
		}
		object typeInformation;
		int assemId;
		BinaryTypeEnum binaryTypeInfo = BinaryTypeConverter.GetBinaryTypeInfo(arrayElemTypeNameInfo._type, objectInfo, arrayElemTypeNameInfo.NIname, _objectWriter, out typeInformation, out assemId);
		if (_binaryArray == null)
		{
			_binaryArray = new BinaryArray();
		}
		_binaryArray.Set((int)arrayNameInfo._objectId, 1, lengthA, lowerBoundA, binaryTypeInfo, typeInformation, binaryArrayTypeEnum, assemId);
		_binaryArray.Write(this);
	}

	internal void WriteRectangleArray(NameInfo memberNameInfo, NameInfo arrayNameInfo, WriteObjectInfo objectInfo, NameInfo arrayElemTypeNameInfo, int rank, int[] lengthA, int[] lowerBoundA)
	{
		InternalWriteItemNull();
		BinaryArrayTypeEnum binaryArrayTypeEnum = BinaryArrayTypeEnum.Rectangular;
		object typeInformation;
		int assemId;
		BinaryTypeEnum binaryTypeInfo = BinaryTypeConverter.GetBinaryTypeInfo(arrayElemTypeNameInfo._type, objectInfo, arrayElemTypeNameInfo.NIname, _objectWriter, out typeInformation, out assemId);
		if (_binaryArray == null)
		{
			_binaryArray = new BinaryArray();
		}
		for (int i = 0; i < rank; i++)
		{
			if (lowerBoundA[i] != 0)
			{
				binaryArrayTypeEnum = BinaryArrayTypeEnum.RectangularOffset;
				break;
			}
		}
		_binaryArray.Set((int)arrayNameInfo._objectId, rank, lengthA, lowerBoundA, binaryTypeInfo, typeInformation, binaryArrayTypeEnum, assemId);
		_binaryArray.Write(this);
	}

	internal void WriteObjectByteArray(NameInfo memberNameInfo, NameInfo arrayNameInfo, WriteObjectInfo objectInfo, NameInfo arrayElemTypeNameInfo, int length, int lowerBound, byte[] byteA)
	{
		InternalWriteItemNull();
		WriteSingleArray(memberNameInfo, arrayNameInfo, objectInfo, arrayElemTypeNameInfo, length, lowerBound, byteA);
	}

	internal void WriteMember(NameInfo memberNameInfo, NameInfo typeNameInfo, object value)
	{
		InternalWriteItemNull();
		InternalPrimitiveTypeE primitiveTypeEnum = typeNameInfo._primitiveTypeEnum;
		if (memberNameInfo._transmitTypeOnMember)
		{
			if (_memberPrimitiveTyped == null)
			{
				_memberPrimitiveTyped = new MemberPrimitiveTyped();
			}
			_memberPrimitiveTyped.Set(primitiveTypeEnum, value);
			_memberPrimitiveTyped.Write(this);
		}
		else
		{
			if (_memberPrimitiveUnTyped == null)
			{
				_memberPrimitiveUnTyped = new MemberPrimitiveUnTyped();
			}
			_memberPrimitiveUnTyped.Set(primitiveTypeEnum, value);
			_memberPrimitiveUnTyped.Write(this);
		}
	}

	internal void WriteNullMember(NameInfo memberNameInfo, NameInfo typeNameInfo)
	{
		InternalWriteItemNull();
		if (_objectNull == null)
		{
			_objectNull = new ObjectNull();
		}
		if (!memberNameInfo._isArrayItem)
		{
			_objectNull.SetNullCount(1);
			_objectNull.Write(this);
			_consecutiveNullArrayEntryCount = 0;
		}
	}

	internal void WriteMemberObjectRef(NameInfo memberNameInfo, int idRef)
	{
		InternalWriteItemNull();
		if (_memberReference == null)
		{
			_memberReference = new MemberReference();
		}
		_memberReference.Set(idRef);
		_memberReference.Write(this);
	}

	internal void WriteMemberNested(NameInfo memberNameInfo)
	{
		InternalWriteItemNull();
	}

	internal void WriteMemberString(NameInfo memberNameInfo, NameInfo typeNameInfo, string value)
	{
		InternalWriteItemNull();
		WriteObjectString((int)typeNameInfo._objectId, value);
	}

	internal void WriteItem(NameInfo itemNameInfo, NameInfo typeNameInfo, object value)
	{
		InternalWriteItemNull();
		WriteMember(itemNameInfo, typeNameInfo, value);
	}

	internal void WriteNullItem(NameInfo itemNameInfo, NameInfo typeNameInfo)
	{
		_consecutiveNullArrayEntryCount++;
		InternalWriteItemNull();
	}

	internal void WriteDelayedNullItem()
	{
		_consecutiveNullArrayEntryCount++;
	}

	internal void WriteItemEnd()
	{
		InternalWriteItemNull();
	}

	private void InternalWriteItemNull()
	{
		if (_consecutiveNullArrayEntryCount > 0)
		{
			if (_objectNull == null)
			{
				_objectNull = new ObjectNull();
			}
			_objectNull.SetNullCount(_consecutiveNullArrayEntryCount);
			_objectNull.Write(this);
			_consecutiveNullArrayEntryCount = 0;
		}
	}

	internal void WriteItemObjectRef(NameInfo nameInfo, int idRef)
	{
		InternalWriteItemNull();
		WriteMemberObjectRef(nameInfo, idRef);
	}

	internal void WriteAssembly(Type type, string assemblyString, int assemId, bool isNew)
	{
		InternalWriteItemNull();
		if (assemblyString == null)
		{
			assemblyString = string.Empty;
		}
		if (isNew)
		{
			if (_binaryAssembly == null)
			{
				_binaryAssembly = new BinaryAssembly();
			}
			_binaryAssembly.Set(assemId, assemblyString);
			_binaryAssembly.Write(this);
		}
	}

	internal void WriteValue(InternalPrimitiveTypeE code, object value)
	{
		switch (code)
		{
		case InternalPrimitiveTypeE.Boolean:
			WriteBoolean(Convert.ToBoolean(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.Byte:
			WriteByte(Convert.ToByte(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.Char:
			WriteChar(Convert.ToChar(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.Double:
			WriteDouble(Convert.ToDouble(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.Int16:
			WriteInt16(Convert.ToInt16(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.Int32:
			WriteInt32(Convert.ToInt32(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.Int64:
			WriteInt64(Convert.ToInt64(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.SByte:
			WriteSByte(Convert.ToSByte(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.Single:
			WriteSingle(Convert.ToSingle(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.UInt16:
			WriteUInt16(Convert.ToUInt16(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.UInt32:
			WriteUInt32(Convert.ToUInt32(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.UInt64:
			WriteUInt64(Convert.ToUInt64(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.Decimal:
			WriteDecimal(Convert.ToDecimal(value, CultureInfo.InvariantCulture));
			break;
		case InternalPrimitiveTypeE.TimeSpan:
			WriteTimeSpan((TimeSpan)value);
			break;
		case InternalPrimitiveTypeE.DateTime:
			WriteDateTime((DateTime)value);
			break;
		default:
			throw new SerializationException(System.SR.Format(System.SR.Serialization_TypeCode, code.ToString()));
		}
	}
}
