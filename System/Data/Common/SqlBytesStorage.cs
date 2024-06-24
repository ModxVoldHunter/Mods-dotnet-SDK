using System.Collections;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace System.Data.Common;

internal sealed class SqlBytesStorage : DataStorage
{
	private SqlBytes[] _values;

	public SqlBytesStorage(DataColumn column)
		: base(column, typeof(SqlBytes), SqlBytes.Null, SqlBytes.Null, StorageType.SqlBytes)
	{
	}

	public override object Aggregate(int[] records, AggregateType kind)
	{
		try
		{
			switch (kind)
			{
			case AggregateType.First:
				if (records.Length != 0)
				{
					return _values[records[0]];
				}
				return null;
			case AggregateType.Count:
			{
				int num = 0;
				for (int i = 0; i < records.Length; i++)
				{
					if (!IsNull(records[i]))
					{
						num++;
					}
				}
				return num;
			}
			}
		}
		catch (OverflowException)
		{
			throw ExprException.Overflow(typeof(SqlBytes));
		}
		throw ExceptionBuilder.AggregateException(kind, _dataType);
	}

	public override int Compare(int recordNo1, int recordNo2)
	{
		return 0;
	}

	public override int CompareValueTo(int recordNo, object value)
	{
		return 0;
	}

	public override void Copy(int recordNo1, int recordNo2)
	{
		_values[recordNo2] = _values[recordNo1];
	}

	public override object Get(int record)
	{
		return _values[record];
	}

	public override bool IsNull(int record)
	{
		return _values[record].IsNull;
	}

	public override void Set(int record, object value)
	{
		if (value == DBNull.Value || value == null)
		{
			_values[record] = SqlBytes.Null;
		}
		else
		{
			_values[record] = (SqlBytes)value;
		}
	}

	public override void SetCapacity(int capacity)
	{
		Array.Resize(ref _values, capacity);
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	public override object ConvertXmlToObject(string s)
	{
		SqlBinary sqlBinary = default(SqlBinary);
		string s2 = "<col>" + s + "</col>";
		StringReader input = new StringReader(s2);
		IXmlSerializable xmlSerializable = sqlBinary;
		using (XmlTextReader reader = new XmlTextReader(input))
		{
			xmlSerializable.ReadXml(reader);
		}
		return new SqlBytes((SqlBinary)(object)xmlSerializable);
	}

	[RequiresUnreferencedCode("Members from serialized types may be trimmed if not referenced directly.")]
	public override string ConvertObjectToXml(object value)
	{
		StringWriter stringWriter = new StringWriter(base.FormatProvider);
		using (XmlTextWriter writer = new XmlTextWriter(stringWriter))
		{
			((IXmlSerializable)value).WriteXml(writer);
		}
		return stringWriter.ToString();
	}

	protected override object GetEmptyStorage(int recordCount)
	{
		return new SqlBytes[recordCount];
	}

	protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex)
	{
		SqlBytes[] array = (SqlBytes[])store;
		array[storeIndex] = _values[record];
		nullbits.Set(storeIndex, IsNull(record));
	}

	protected override void SetStorage(object store, BitArray nullbits)
	{
		_values = (SqlBytes[])store;
	}
}
