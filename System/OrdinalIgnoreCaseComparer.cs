using System.Globalization;
using System.Runtime.Serialization;

namespace System;

[Serializable]
internal sealed class OrdinalIgnoreCaseComparer : OrdinalComparer, ISerializable
{
	internal static readonly OrdinalIgnoreCaseComparer Instance = new OrdinalIgnoreCaseComparer();

	private OrdinalIgnoreCaseComparer()
		: base(ignoreCase: true)
	{
	}

	public override int Compare(string x, string y)
	{
		if ((object)x == y)
		{
			return 0;
		}
		if (x == null)
		{
			return -1;
		}
		if (y == null)
		{
			return 1;
		}
		return System.Globalization.Ordinal.CompareStringIgnoreCase(ref x.GetRawStringData(), x.Length, ref y.GetRawStringData(), y.Length);
	}

	public override bool Equals(string x, string y)
	{
		if ((object)x == y)
		{
			return true;
		}
		if (x == null || y == null)
		{
			return false;
		}
		if (x.Length != y.Length)
		{
			return false;
		}
		return System.Globalization.Ordinal.EqualsIgnoreCase(ref x.GetRawStringData(), ref y.GetRawStringData(), x.Length);
	}

	public override int GetHashCode(string obj)
	{
		if (obj == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.obj);
		}
		return obj.GetHashCodeOrdinalIgnoreCase();
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.SetType(typeof(OrdinalComparer));
		info.AddValue("_ignoreCase", value: true);
	}
}
