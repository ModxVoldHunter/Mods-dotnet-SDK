using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Unicode;

namespace System;

[Serializable]
[NonVersionable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class String : IComparable, IEnumerable, IConvertible, IEnumerable<char>, IComparable<string?>, IEquatable<string?>, ICloneable, ISpanParsable<string>, IParsable<string>
{
	internal static class SearchValuesStorage
	{
		public static readonly SearchValues<char> NewLineChars = SearchValues.Create("\r\f\u0085\u2028\u2029\n");
	}

	[Intrinsic]
	public static readonly string Empty;

	[NonSerialized]
	private readonly int _stringLength;

	[NonSerialized]
	private char _firstChar;

	[IndexerName("Chars")]
	public char this[int index]
	{
		[Intrinsic]
		get
		{
			if ((uint)index >= (uint)_stringLength)
			{
				ThrowHelper.ThrowIndexOutOfRangeException();
			}
			return Unsafe.Add(ref _firstChar, (nint)(uint)index);
		}
	}

	public int Length
	{
		[Intrinsic]
		get
		{
			return _stringLength;
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern string FastAllocateString(int length);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal extern void SetTrailByte(byte data);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal extern bool TryGetTrailByte(out byte data);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern string Intern();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern string IsInterned();

	public static string Intern(string str)
	{
		ArgumentNullException.ThrowIfNull(str, "str");
		return str.Intern();
	}

	public static string? IsInterned(string str)
	{
		ArgumentNullException.ThrowIfNull(str, "str");
		return str.IsInterned();
	}

	internal unsafe static void InternalCopy(string src, nint dest, int len)
	{
		if (len != 0)
		{
			Buffer.Memmove(ref *(byte*)dest, ref Unsafe.As<char, byte>(ref src.GetRawStringData()), (nuint)len);
		}
	}

	internal unsafe int GetBytesFromEncoding(byte* pbNativeBuffer, int cbNativeBuffer, Encoding encoding)
	{
		fixed (char* chars = &_firstChar)
		{
			return encoding.GetBytes(chars, Length, pbNativeBuffer, cbNativeBuffer);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool EqualsHelper(string strA, string strB)
	{
		return SpanHelpers.SequenceEqual(ref Unsafe.As<char, byte>(ref strA.GetRawStringData()), ref Unsafe.As<char, byte>(ref strB.GetRawStringData()), (uint)(strA.Length * 2));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int CompareOrdinalHelper(string strA, int indexA, int countA, string strB, int indexB, int countB)
	{
		return SpanHelpers.SequenceCompareTo(ref Unsafe.Add(ref strA.GetRawStringData(), (nint)(uint)indexA), countA, ref Unsafe.Add(ref strB.GetRawStringData(), (nint)(uint)indexB), countB);
	}

	internal static bool EqualsOrdinalIgnoreCase(string strA, string strB)
	{
		if ((object)strA == strB)
		{
			return true;
		}
		if ((object)strA == null || (object)strB == null)
		{
			return false;
		}
		if (strA.Length != strB.Length)
		{
			return false;
		}
		return EqualsOrdinalIgnoreCaseNoLengthCheck(strA, strB);
	}

	private static bool EqualsOrdinalIgnoreCaseNoLengthCheck(string strA, string strB)
	{
		return Ordinal.EqualsIgnoreCase(ref strA.GetRawStringData(), ref strB.GetRawStringData(), strB.Length);
	}

	private unsafe static int CompareOrdinalHelper(string strA, string strB)
	{
		int num = Math.Min(strA.Length, strB.Length);
		fixed (char* ptr = &strA._firstChar)
		{
			fixed (char* ptr3 = &strB._firstChar)
			{
				char* ptr2 = ptr;
				char* ptr4 = ptr3;
				if (ptr2[1] == ptr4[1])
				{
					num -= 2;
					ptr2 += 2;
					ptr4 += 2;
					while (true)
					{
						if (num >= 12)
						{
							if (*(long*)ptr2 == *(long*)ptr4)
							{
								if (*(long*)(ptr2 + 4) == *(long*)(ptr4 + 4))
								{
									if (*(long*)(ptr2 + 8) == *(long*)(ptr4 + 8))
									{
										num -= 12;
										ptr2 += 12;
										ptr4 += 12;
										continue;
									}
									ptr2 += 4;
									ptr4 += 4;
								}
								ptr2 += 4;
								ptr4 += 4;
							}
							if (*(int*)ptr2 == *(int*)ptr4)
							{
								ptr2 += 2;
								ptr4 += 2;
							}
							break;
						}
						while (true)
						{
							if (num > 0)
							{
								if (*(int*)ptr2 != *(int*)ptr4)
								{
									break;
								}
								num -= 2;
								ptr2 += 2;
								ptr4 += 2;
								continue;
							}
							return strA.Length - strB.Length;
						}
						break;
					}
					if (*ptr2 != *ptr4)
					{
						return *ptr2 - *ptr4;
					}
				}
				return ptr2[1] - ptr4[1];
			}
		}
	}

	public static int Compare(string? strA, string? strB)
	{
		return Compare(strA, strB, StringComparison.CurrentCulture);
	}

	public static int Compare(string? strA, string? strB, bool ignoreCase)
	{
		StringComparison comparisonType = (ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
		return Compare(strA, strB, comparisonType);
	}

	public static int Compare(string? strA, string? strB, StringComparison comparisonType)
	{
		if ((object)strA == strB)
		{
			CheckStringComparison(comparisonType);
			return 0;
		}
		if ((object)strA == null)
		{
			CheckStringComparison(comparisonType);
			return -1;
		}
		if ((object)strB == null)
		{
			CheckStringComparison(comparisonType);
			return 1;
		}
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.Compare(strA, strB, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.Ordinal:
			if (strA._firstChar != strB._firstChar)
			{
				return strA._firstChar - strB._firstChar;
			}
			return CompareOrdinalHelper(strA, strB);
		case StringComparison.OrdinalIgnoreCase:
			return Ordinal.CompareStringIgnoreCase(ref strA.GetRawStringData(), strA.Length, ref strB.GetRawStringData(), strB.Length);
		default:
			throw new ArgumentException(SR.NotSupported_StringComparison, "comparisonType");
		}
	}

	public static int Compare(string? strA, string? strB, CultureInfo? culture, CompareOptions options)
	{
		CultureInfo cultureInfo = culture ?? CultureInfo.CurrentCulture;
		return cultureInfo.CompareInfo.Compare(strA, strB, options);
	}

	public static int Compare(string? strA, string? strB, bool ignoreCase, CultureInfo? culture)
	{
		CompareOptions options = (ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
		return Compare(strA, strB, culture, options);
	}

	public static int Compare(string? strA, int indexA, string? strB, int indexB, int length)
	{
		return Compare(strA, indexA, strB, indexB, length, ignoreCase: false);
	}

	public static int Compare(string? strA, int indexA, string? strB, int indexB, int length, bool ignoreCase)
	{
		int num = length;
		int num2 = length;
		if ((object)strA != null)
		{
			num = Math.Min(num, strA.Length - indexA);
		}
		if ((object)strB != null)
		{
			num2 = Math.Min(num2, strB.Length - indexB);
		}
		CompareOptions options = (ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
		return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, options);
	}

	public static int Compare(string? strA, int indexA, string? strB, int indexB, int length, bool ignoreCase, CultureInfo? culture)
	{
		CompareOptions options = (ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
		return Compare(strA, indexA, strB, indexB, length, culture, options);
	}

	public static int Compare(string? strA, int indexA, string? strB, int indexB, int length, CultureInfo? culture, CompareOptions options)
	{
		CultureInfo cultureInfo = culture ?? CultureInfo.CurrentCulture;
		int num = length;
		int num2 = length;
		if ((object)strA != null)
		{
			num = Math.Min(num, strA.Length - indexA);
		}
		if ((object)strB != null)
		{
			num2 = Math.Min(num2, strB.Length - indexB);
		}
		return cultureInfo.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, options);
	}

	public static int Compare(string? strA, int indexA, string? strB, int indexB, int length, StringComparison comparisonType)
	{
		CheckStringComparison(comparisonType);
		if ((object)strA == null || (object)strB == null)
		{
			if ((object)strA == strB)
			{
				return 0;
			}
			if ((object)strA != null)
			{
				return 1;
			}
			return -1;
		}
		ArgumentOutOfRangeException.ThrowIfNegative(length, "length");
		if (indexA < 0 || indexB < 0)
		{
			string paramName = ((indexA < 0) ? "indexA" : "indexB");
			throw new ArgumentOutOfRangeException(paramName, SR.ArgumentOutOfRange_IndexMustBeLessOrEqual);
		}
		if (strA.Length - indexA < 0 || strB.Length - indexB < 0)
		{
			string paramName2 = ((strA.Length - indexA < 0) ? "indexA" : "indexB");
			throw new ArgumentOutOfRangeException(paramName2, SR.ArgumentOutOfRange_IndexMustBeLessOrEqual);
		}
		if (length == 0 || ((object)strA == strB && indexA == indexB))
		{
			return 0;
		}
		int num = Math.Min(length, strA.Length - indexA);
		int num2 = Math.Min(length, strB.Length - indexB);
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num, strB, indexB, num2, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.Compare(strA, indexA, num, strB, indexB, num2, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.Ordinal:
			return CompareOrdinalHelper(strA, indexA, num, strB, indexB, num2);
		default:
			return Ordinal.CompareStringIgnoreCase(ref Unsafe.Add(ref strA.GetRawStringData(), indexA), num, ref Unsafe.Add(ref strB.GetRawStringData(), indexB), num2);
		}
	}

	public static int CompareOrdinal(string? strA, string? strB)
	{
		if ((object)strA == strB)
		{
			return 0;
		}
		if ((object)strA == null)
		{
			return -1;
		}
		if ((object)strB == null)
		{
			return 1;
		}
		if (strA._firstChar != strB._firstChar)
		{
			return strA._firstChar - strB._firstChar;
		}
		return CompareOrdinalHelper(strA, strB);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int CompareOrdinal(ReadOnlySpan<char> strA, ReadOnlySpan<char> strB)
	{
		return SpanHelpers.SequenceCompareTo(ref MemoryMarshal.GetReference(strA), strA.Length, ref MemoryMarshal.GetReference(strB), strB.Length);
	}

	public static int CompareOrdinal(string? strA, int indexA, string? strB, int indexB, int length)
	{
		if ((object)strA == null || (object)strB == null)
		{
			if ((object)strA == strB)
			{
				return 0;
			}
			if ((object)strA != null)
			{
				return 1;
			}
			return -1;
		}
		ArgumentOutOfRangeException.ThrowIfNegative(length, "length");
		if (indexA < 0 || indexB < 0)
		{
			string paramName = ((indexA < 0) ? "indexA" : "indexB");
			throw new ArgumentOutOfRangeException(paramName, SR.ArgumentOutOfRange_IndexMustBeLessOrEqual);
		}
		int num = Math.Min(length, strA.Length - indexA);
		int num2 = Math.Min(length, strB.Length - indexB);
		if (num < 0 || num2 < 0)
		{
			string paramName2 = ((num < 0) ? "indexA" : "indexB");
			throw new ArgumentOutOfRangeException(paramName2, SR.ArgumentOutOfRange_IndexMustBeLessOrEqual);
		}
		if (length == 0 || ((object)strA == strB && indexA == indexB))
		{
			return 0;
		}
		return CompareOrdinalHelper(strA, indexA, num, strB, indexB, num2);
	}

	public int CompareTo(object? value)
	{
		if (value == null)
		{
			return 1;
		}
		if (!(value is string strB))
		{
			throw new ArgumentException(SR.Arg_MustBeString);
		}
		return CompareTo(strB);
	}

	public int CompareTo(string? strB)
	{
		return Compare(this, strB, StringComparison.CurrentCulture);
	}

	public bool EndsWith(string value)
	{
		return EndsWith(value, StringComparison.CurrentCulture);
	}

	public bool EndsWith(string value, StringComparison comparisonType)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		if ((object)this == value)
		{
			CheckStringComparison(comparisonType);
			return true;
		}
		if (value.Length == 0)
		{
			CheckStringComparison(comparisonType);
			return true;
		}
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(this, value, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.IsSuffix(this, value, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.Ordinal:
		{
			int num = Length - value.Length;
			if ((uint)num <= (uint)Length)
			{
				return this.AsSpan(num).SequenceEqual(value);
			}
			return false;
		}
		case StringComparison.OrdinalIgnoreCase:
			if (Length >= value.Length)
			{
				return Ordinal.EqualsIgnoreCase(ref Unsafe.Add(ref GetRawStringData(), Length - value.Length), ref value.GetRawStringData(), value.Length);
			}
			return false;
		default:
			throw new ArgumentException(SR.NotSupported_StringComparison, "comparisonType");
		}
	}

	public bool EndsWith(string value, bool ignoreCase, CultureInfo? culture)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		if ((object)this == value)
		{
			return true;
		}
		CultureInfo cultureInfo = culture ?? CultureInfo.CurrentCulture;
		return cultureInfo.CompareInfo.IsSuffix(this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	public bool EndsWith(char value)
	{
		if (RuntimeHelpers.IsKnownConstant(value) && value != 0)
		{
			nuint num = (uint)Length;
			return Unsafe.Add(ref _firstChar, (nint)(num - 1)) == value;
		}
		int num2 = Length - 1;
		if ((uint)num2 < (uint)Length)
		{
			return this[num2] == value;
		}
		return false;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is string text))
		{
			return false;
		}
		if (Length != text.Length)
		{
			return false;
		}
		return EqualsHelper(this, text);
	}

	[Intrinsic]
	public bool Equals([NotNullWhen(true)] string? value)
	{
		if ((object)this == value)
		{
			return true;
		}
		if ((object)value == null)
		{
			return false;
		}
		if (Length != value.Length)
		{
			return false;
		}
		return EqualsHelper(this, value);
	}

	[Intrinsic]
	public bool Equals([NotNullWhen(true)] string? value, StringComparison comparisonType)
	{
		if ((object)this == value)
		{
			CheckStringComparison(comparisonType);
			return true;
		}
		if ((object)value == null)
		{
			CheckStringComparison(comparisonType);
			return false;
		}
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.Compare(this, value, GetCaseCompareOfComparisonCulture(comparisonType)) == 0;
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.Compare(this, value, GetCaseCompareOfComparisonCulture(comparisonType)) == 0;
		case StringComparison.Ordinal:
			if (Length != value.Length)
			{
				return false;
			}
			return EqualsHelper(this, value);
		case StringComparison.OrdinalIgnoreCase:
			if (Length != value.Length)
			{
				return false;
			}
			return EqualsOrdinalIgnoreCaseNoLengthCheck(this, value);
		default:
			throw new ArgumentException(SR.NotSupported_StringComparison, "comparisonType");
		}
	}

	[Intrinsic]
	public static bool Equals(string? a, string? b)
	{
		if ((object)a == b)
		{
			return true;
		}
		if ((object)a == null || (object)b == null || a.Length != b.Length)
		{
			return false;
		}
		return EqualsHelper(a, b);
	}

	[Intrinsic]
	public static bool Equals(string? a, string? b, StringComparison comparisonType)
	{
		if ((object)a == b)
		{
			CheckStringComparison(comparisonType);
			return true;
		}
		if ((object)a == null || (object)b == null)
		{
			CheckStringComparison(comparisonType);
			return false;
		}
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.Compare(a, b, GetCaseCompareOfComparisonCulture(comparisonType)) == 0;
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.Compare(a, b, GetCaseCompareOfComparisonCulture(comparisonType)) == 0;
		case StringComparison.Ordinal:
			if (a.Length != b.Length)
			{
				return false;
			}
			return EqualsHelper(a, b);
		case StringComparison.OrdinalIgnoreCase:
			if (a.Length != b.Length)
			{
				return false;
			}
			return EqualsOrdinalIgnoreCaseNoLengthCheck(a, b);
		default:
			throw new ArgumentException(SR.NotSupported_StringComparison, "comparisonType");
		}
	}

	public static bool operator ==(string? a, string? b)
	{
		return Equals(a, b);
	}

	public static bool operator !=(string? a, string? b)
	{
		return !Equals(a, b);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode()
	{
		ulong defaultSeed = Marvin.DefaultSeed;
		return Marvin.ComputeHash32(ref Unsafe.As<char, byte>(ref _firstChar), (uint)(_stringLength * 2), (uint)defaultSeed, (uint)(defaultSeed >> 32));
	}

	public int GetHashCode(StringComparison comparisonType)
	{
		return StringComparer.FromComparison(comparisonType).GetHashCode(this);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal int GetHashCodeOrdinalIgnoreCase()
	{
		ulong defaultSeed = Marvin.DefaultSeed;
		return Marvin.ComputeHash32OrdinalIgnoreCase(ref _firstChar, _stringLength, (uint)defaultSeed, (uint)(defaultSeed >> 32));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetHashCode(ReadOnlySpan<char> value)
	{
		ulong defaultSeed = Marvin.DefaultSeed;
		return Marvin.ComputeHash32(ref Unsafe.As<char, byte>(ref MemoryMarshal.GetReference(value)), (uint)(value.Length * 2), (uint)defaultSeed, (uint)(defaultSeed >> 32));
	}

	public static int GetHashCode(ReadOnlySpan<char> value, StringComparison comparisonType)
	{
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.GetHashCode(value, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.GetHashCode(value, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.Ordinal:
			return GetHashCode(value);
		case StringComparison.OrdinalIgnoreCase:
			return GetHashCodeOrdinalIgnoreCase(value);
		default:
			ThrowHelper.ThrowArgumentException(ExceptionResource.NotSupported_StringComparison, ExceptionArgument.comparisonType);
			return 0;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int GetHashCodeOrdinalIgnoreCase(ReadOnlySpan<char> value)
	{
		ulong defaultSeed = Marvin.DefaultSeed;
		return Marvin.ComputeHash32OrdinalIgnoreCase(ref MemoryMarshal.GetReference(value), value.Length, (uint)defaultSeed, (uint)(defaultSeed >> 32));
	}

	internal unsafe int GetNonRandomizedHashCode()
	{
		fixed (char* ptr = &_firstChar)
		{
			uint num = 352654597u;
			uint num2 = num;
			uint* ptr2 = (uint*)ptr;
			int num3 = Length;
			while (num3 > 2)
			{
				num3 -= 4;
				num = (BitOperations.RotateLeft(num, 5) + num) ^ *ptr2;
				num2 = (BitOperations.RotateLeft(num2, 5) + num2) ^ ptr2[1];
				ptr2 += 2;
			}
			if (num3 > 0)
			{
				num2 = (BitOperations.RotateLeft(num2, 5) + num2) ^ *ptr2;
			}
			return (int)(num + num2 * 1566083941);
		}
	}

	internal unsafe int GetNonRandomizedHashCodeOrdinalIgnoreCase()
	{
		uint num = 352654597u;
		uint num2 = num;
		fixed (char* ptr = &_firstChar)
		{
			uint* ptr2 = (uint*)ptr;
			int num3 = Length;
			while (true)
			{
				if (num3 > 2)
				{
					uint num4 = *ptr2;
					uint num5 = ptr2[1];
					if (Utf16Utility.AllCharsInUInt32AreAscii(num4 | num5))
					{
						num3 -= 4;
						num = (BitOperations.RotateLeft(num, 5) + num) ^ (num4 | 0x200020u);
						num2 = (BitOperations.RotateLeft(num2, 5) + num2) ^ (num5 | 0x200020u);
						ptr2 += 2;
						continue;
					}
				}
				else
				{
					if (num3 <= 0)
					{
						break;
					}
					uint num6 = *ptr2;
					if (Utf16Utility.AllCharsInUInt32AreAscii(num6))
					{
						num2 = (BitOperations.RotateLeft(num2, 5) + num2) ^ (num6 | 0x200020u);
						break;
					}
				}
				goto end_IL_0011;
			}
			goto IL_00a1;
			end_IL_0011:;
		}
		return GetNonRandomizedHashCodeOrdinalIgnoreCaseSlow(this);
		IL_00a1:
		return (int)(num + num2 * 1566083941);
		unsafe static int GetNonRandomizedHashCodeOrdinalIgnoreCaseSlow(string str)
		{
			int num7 = str.Length;
			char[] array = null;
			Span<char> span = (((uint)num7 >= 64u) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(num7 + 1))) : stackalloc char[64]);
			Span<char> destination = span;
			int num8 = Ordinal.ToUpperOrdinal(str, destination);
			destination[num7] = '\0';
			uint num9 = 352654597u;
			uint num10 = num9;
			fixed (char* ptr3 = destination)
			{
				uint* ptr4 = (uint*)ptr3;
				while (num7 > 2)
				{
					num7 -= 4;
					num9 = (BitOperations.RotateLeft(num9, 5) + num9) ^ (*ptr4 | 0x200020u);
					num10 = (BitOperations.RotateLeft(num10, 5) + num10) ^ (ptr4[1] | 0x200020u);
					ptr4 += 2;
				}
				if (num7 > 0)
				{
					num10 = (BitOperations.RotateLeft(num10, 5) + num10) ^ (*ptr4 | 0x200020u);
				}
			}
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
			return (int)(num9 + num10 * 1566083941);
		}
	}

	public bool StartsWith(string value)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		return StartsWith(value, StringComparison.CurrentCulture);
	}

	[Intrinsic]
	public bool StartsWith(string value, StringComparison comparisonType)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		if ((object)this == value)
		{
			CheckStringComparison(comparisonType);
			return true;
		}
		if (value.Length == 0)
		{
			CheckStringComparison(comparisonType);
			return true;
		}
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, value, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.IsPrefix(this, value, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.Ordinal:
			if (Length < value.Length || _firstChar != value._firstChar)
			{
				return false;
			}
			if (value.Length != 1)
			{
				return SpanHelpers.SequenceEqual(ref Unsafe.As<char, byte>(ref GetRawStringData()), ref Unsafe.As<char, byte>(ref value.GetRawStringData()), (nuint)value.Length * (nuint)2u);
			}
			return true;
		case StringComparison.OrdinalIgnoreCase:
			if (Length < value.Length)
			{
				return false;
			}
			return Ordinal.EqualsIgnoreCase(ref GetRawStringData(), ref value.GetRawStringData(), value.Length);
		default:
			throw new ArgumentException(SR.NotSupported_StringComparison, "comparisonType");
		}
	}

	public bool StartsWith(string value, bool ignoreCase, CultureInfo? culture)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		if ((object)this == value)
		{
			return true;
		}
		CultureInfo cultureInfo = culture ?? CultureInfo.CurrentCulture;
		return cultureInfo.CompareInfo.IsPrefix(this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	public bool StartsWith(char value)
	{
		if (RuntimeHelpers.IsKnownConstant(value) && value != 0)
		{
			return _firstChar == value;
		}
		if (Length != 0)
		{
			return _firstChar == value;
		}
		return false;
	}

	internal static void CheckStringComparison(StringComparison comparisonType)
	{
		if ((uint)comparisonType > 5u)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.NotSupported_StringComparison, ExceptionArgument.comparisonType);
		}
	}

	internal static CompareOptions GetCaseCompareOfComparisonCulture(StringComparison comparisonType)
	{
		return (CompareOptions)(comparisonType & StringComparison.CurrentCultureIgnoreCase);
	}

	private static CompareOptions GetCompareOptionsFromOrdinalStringComparison(StringComparison comparisonType)
	{
		return (CompareOptions)(((uint)comparisonType & (uint)(0 - comparisonType)) << 28);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern String(char[]? value);

	private static string Ctor(char[] value)
	{
		if (value == null || value.Length == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(value.Length);
		nuint elementCount = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref MemoryMarshal.GetArrayDataReference(value), elementCount);
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern String(char[] value, int startIndex, int length);

	private static string Ctor(char[] value, int startIndex, int length)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		ArgumentOutOfRangeException.ThrowIfNegative(startIndex, "startIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(length, "length");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(startIndex, value.Length - length, "startIndex");
		if (length == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(length);
		nuint elementCount = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(value), startIndex), elementCount);
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(char* value);

	private unsafe static string Ctor(char* ptr)
	{
		if (ptr == null)
		{
			return Empty;
		}
		int num = wcslen(ptr);
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		nuint elementCount = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref *ptr, elementCount);
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(char* value, int startIndex, int length);

	private unsafe static string Ctor(char* ptr, int startIndex, int length)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(length, "length");
		ArgumentOutOfRangeException.ThrowIfNegative(startIndex, "startIndex");
		char* ptr2 = ptr + startIndex;
		if (ptr2 < ptr)
		{
			throw new ArgumentOutOfRangeException("startIndex", SR.ArgumentOutOfRange_PartialWCHAR);
		}
		if (length == 0)
		{
			return Empty;
		}
		if (ptr == null)
		{
			throw new ArgumentOutOfRangeException("ptr", SR.ArgumentOutOfRange_PartialWCHAR);
		}
		string text = FastAllocateString(length);
		nuint elementCount = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref *ptr2, elementCount);
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(sbyte* value);

	private unsafe static string Ctor(sbyte* value)
	{
		if (value == null)
		{
			return Empty;
		}
		int numBytes = strlen((byte*)value);
		return CreateStringForSByteConstructor((byte*)value, numBytes);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(sbyte* value, int startIndex, int length);

	private unsafe static string Ctor(sbyte* value, int startIndex, int length)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(startIndex, "startIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(length, "length");
		if (value == null)
		{
			if (length == 0)
			{
				return Empty;
			}
			ArgumentNullException.Throw("value");
		}
		byte* ptr = (byte*)(value + startIndex);
		if (ptr < value)
		{
			throw new ArgumentOutOfRangeException("value", SR.ArgumentOutOfRange_PartialWCHAR);
		}
		return CreateStringForSByteConstructor(ptr, length);
	}

	private unsafe static string CreateStringForSByteConstructor(byte* pb, int numBytes)
	{
		if (numBytes == 0)
		{
			return Empty;
		}
		int num = Interop.Kernel32.MultiByteToWideChar(0u, 1u, pb, numBytes, null, 0);
		if (num == 0)
		{
			throw new ArgumentException(SR.Arg_InvalidANSIString);
		}
		string text = FastAllocateString(num);
		fixed (char* lpWideCharStr = &text._firstChar)
		{
			num = Interop.Kernel32.MultiByteToWideChar(0u, 1u, pb, numBytes, lpWideCharStr, num);
		}
		if (num == 0)
		{
			throw new ArgumentException(SR.Arg_InvalidANSIString);
		}
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(sbyte* value, int startIndex, int length, Encoding enc);

	private unsafe static string Ctor(sbyte* value, int startIndex, int length, Encoding enc)
	{
		if (enc == null)
		{
			return new string(value, startIndex, length);
		}
		ArgumentOutOfRangeException.ThrowIfNegative(length, "length");
		ArgumentOutOfRangeException.ThrowIfNegative(startIndex, "startIndex");
		if (value == null)
		{
			if (length == 0)
			{
				return Empty;
			}
			ArgumentNullException.Throw("value");
		}
		byte* ptr = (byte*)(value + startIndex);
		if (ptr < value)
		{
			throw new ArgumentOutOfRangeException("startIndex", SR.ArgumentOutOfRange_PartialWCHAR);
		}
		return enc.GetString(new ReadOnlySpan<byte>(ptr, length));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern String(char c, int count);

	private static string Ctor(char c, int count)
	{
		if (count <= 0)
		{
			ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
			return Empty;
		}
		string text = FastAllocateString(count);
		if (c != 0)
		{
			SpanHelpers.Fill(ref text._firstChar, (uint)count, c);
		}
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern String(ReadOnlySpan<char> value);

	private static string Ctor(ReadOnlySpan<char> value)
	{
		if (value.Length == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(value.Length);
		Buffer.Memmove(ref text._firstChar, ref MemoryMarshal.GetReference(value), (uint)value.Length);
		return text;
	}

	public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
	{
		if (action == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.action);
		}
		if (length <= 0)
		{
			if (length == 0)
			{
				return Empty;
			}
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length);
		}
		string text = FastAllocateString(length);
		action(new Span<char>(ref text.GetRawStringData(), length), state);
		return text;
	}

	public static string Create(IFormatProvider? provider, [InterpolatedStringHandlerArgument("provider")] ref DefaultInterpolatedStringHandler handler)
	{
		return handler.ToStringAndClear();
	}

	public static string Create(IFormatProvider? provider, Span<char> initialBuffer, [InterpolatedStringHandlerArgument(new string[] { "provider", "initialBuffer" })] ref DefaultInterpolatedStringHandler handler)
	{
		return handler.ToStringAndClear();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static implicit operator ReadOnlySpan<char>(string? value)
	{
		if ((object)value == null)
		{
			return default(ReadOnlySpan<char>);
		}
		return new ReadOnlySpan<char>(ref value.GetRawStringData(), value.Length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool TryGetSpan(int startIndex, int count, out ReadOnlySpan<char> slice)
	{
		if ((ulong)((long)(uint)startIndex + (long)(uint)count) > (ulong)(uint)Length)
		{
			slice = default(ReadOnlySpan<char>);
			return false;
		}
		slice = new ReadOnlySpan<char>(ref Unsafe.Add(ref _firstChar, (nint)(uint)startIndex), count);
		return true;
	}

	public object Clone()
	{
		return this;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This API should not be used to create mutable strings. See https://go.microsoft.com/fwlink/?linkid=2084035 for alternatives.")]
	public static string Copy(string str)
	{
		ArgumentNullException.ThrowIfNull(str, "str");
		string text = FastAllocateString(str.Length);
		nuint elementCount = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref str._firstChar, elementCount);
		return text;
	}

	public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
	{
		ArgumentNullException.ThrowIfNull(destination, "destination");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		ArgumentOutOfRangeException.ThrowIfNegative(sourceIndex, "sourceIndex");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(count, Length - sourceIndex, "sourceIndex");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(destinationIndex, destination.Length - count, "destinationIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(destinationIndex, "destinationIndex");
		Buffer.Memmove(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(destination), destinationIndex), ref Unsafe.Add(ref _firstChar, sourceIndex), (uint)count);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyTo(Span<char> destination)
	{
		if ((uint)Length <= (uint)destination.Length)
		{
			Buffer.Memmove(ref destination._reference, ref _firstChar, (uint)Length);
		}
		else
		{
			ThrowHelper.ThrowArgumentException_DestinationTooShort();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryCopyTo(Span<char> destination)
	{
		bool result = false;
		if ((uint)Length <= (uint)destination.Length)
		{
			Buffer.Memmove(ref destination._reference, ref _firstChar, (uint)Length);
			result = true;
		}
		return result;
	}

	public char[] ToCharArray()
	{
		if (Length == 0)
		{
			return Array.Empty<char>();
		}
		char[] array = new char[Length];
		Buffer.Memmove(ref MemoryMarshal.GetArrayDataReference(array), ref _firstChar, (uint)Length);
		return array;
	}

	public char[] ToCharArray(int startIndex, int length)
	{
		ArgumentOutOfRangeException.ThrowIfGreaterThan((uint)startIndex, (uint)Length, "startIndex");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(startIndex, Length - length, "startIndex");
		if (length <= 0)
		{
			ArgumentOutOfRangeException.ThrowIfNegative(length, "length");
			return Array.Empty<char>();
		}
		char[] array = new char[length];
		Buffer.Memmove(ref MemoryMarshal.GetArrayDataReference(array), ref Unsafe.Add(ref _firstChar, startIndex), (uint)length);
		return array;
	}

	public static bool IsNullOrEmpty([NotNullWhen(false)] string? value)
	{
		if ((object)value != null)
		{
			return value.Length == 0;
		}
		return true;
	}

	public static bool IsNullOrWhiteSpace([NotNullWhen(false)] string? value)
	{
		if ((object)value == null)
		{
			return true;
		}
		for (int i = 0; i < value.Length; i++)
		{
			if (!char.IsWhiteSpace(value[i]))
			{
				return false;
			}
		}
		return true;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[NonVersionable]
	public ref readonly char GetPinnableReference()
	{
		return ref _firstChar;
	}

	internal ref char GetRawStringData()
	{
		return ref _firstChar;
	}

	internal ref ushort GetRawStringDataAsUInt16()
	{
		return ref Unsafe.As<char, ushort>(ref _firstChar);
	}

	internal unsafe static string CreateStringFromEncoding(byte* bytes, int byteLength, Encoding encoding)
	{
		int charCount = encoding.GetCharCount(bytes, byteLength);
		if (charCount == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(charCount);
		fixed (char* chars = &text._firstChar)
		{
			int chars2 = encoding.GetChars(bytes, byteLength, chars, charCount);
		}
		return text;
	}

	internal static string CreateFromChar(char c)
	{
		string text = FastAllocateString(1);
		text._firstChar = c;
		return text;
	}

	internal static string CreateFromChar(char c1, char c2)
	{
		string text = FastAllocateString(2);
		text._firstChar = c1;
		Unsafe.Add(ref text._firstChar, 1) = c2;
		return text;
	}

	public override string ToString()
	{
		return this;
	}

	public string ToString(IFormatProvider? provider)
	{
		return this;
	}

	public CharEnumerator GetEnumerator()
	{
		return new CharEnumerator(this);
	}

	IEnumerator<char> IEnumerable<char>.GetEnumerator()
	{
		return new CharEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new CharEnumerator(this);
	}

	public StringRuneEnumerator EnumerateRunes()
	{
		return new StringRuneEnumerator(this);
	}

	internal unsafe static int wcslen(char* ptr)
	{
		return SpanHelpers.IndexOfNullCharacter(ptr);
	}

	internal unsafe static int strlen(byte* ptr)
	{
		return SpanHelpers.IndexOfNullByte(ptr);
	}

	public TypeCode GetTypeCode()
	{
		return TypeCode.String;
	}

	bool IConvertible.ToBoolean(IFormatProvider provider)
	{
		return Convert.ToBoolean(this, provider);
	}

	char IConvertible.ToChar(IFormatProvider provider)
	{
		return Convert.ToChar(this, provider);
	}

	sbyte IConvertible.ToSByte(IFormatProvider provider)
	{
		return Convert.ToSByte(this, provider);
	}

	byte IConvertible.ToByte(IFormatProvider provider)
	{
		return Convert.ToByte(this, provider);
	}

	short IConvertible.ToInt16(IFormatProvider provider)
	{
		return Convert.ToInt16(this, provider);
	}

	ushort IConvertible.ToUInt16(IFormatProvider provider)
	{
		return Convert.ToUInt16(this, provider);
	}

	int IConvertible.ToInt32(IFormatProvider provider)
	{
		return Convert.ToInt32(this, provider);
	}

	uint IConvertible.ToUInt32(IFormatProvider provider)
	{
		return Convert.ToUInt32(this, provider);
	}

	long IConvertible.ToInt64(IFormatProvider provider)
	{
		return Convert.ToInt64(this, provider);
	}

	ulong IConvertible.ToUInt64(IFormatProvider provider)
	{
		return Convert.ToUInt64(this, provider);
	}

	float IConvertible.ToSingle(IFormatProvider provider)
	{
		return Convert.ToSingle(this, provider);
	}

	double IConvertible.ToDouble(IFormatProvider provider)
	{
		return Convert.ToDouble(this, provider);
	}

	decimal IConvertible.ToDecimal(IFormatProvider provider)
	{
		return Convert.ToDecimal(this, provider);
	}

	DateTime IConvertible.ToDateTime(IFormatProvider provider)
	{
		return Convert.ToDateTime(this, provider);
	}

	object IConvertible.ToType(Type type, IFormatProvider provider)
	{
		return Convert.DefaultToType(this, type, provider);
	}

	public bool IsNormalized()
	{
		return IsNormalized(NormalizationForm.FormC);
	}

	public bool IsNormalized(NormalizationForm normalizationForm)
	{
		if (Ascii.IsValid(this) && (normalizationForm == NormalizationForm.FormC || normalizationForm == NormalizationForm.FormKC || normalizationForm == NormalizationForm.FormD || normalizationForm == NormalizationForm.FormKD))
		{
			return true;
		}
		return Normalization.IsNormalized(this, normalizationForm);
	}

	public string Normalize()
	{
		return Normalize(NormalizationForm.FormC);
	}

	public string Normalize(NormalizationForm normalizationForm)
	{
		if (Ascii.IsValid(this) && (normalizationForm == NormalizationForm.FormC || normalizationForm == NormalizationForm.FormKC || normalizationForm == NormalizationForm.FormD || normalizationForm == NormalizationForm.FormKD))
		{
			return this;
		}
		return Normalization.Normalize(this, normalizationForm);
	}

	static string IParsable<string>.Parse(string s, IFormatProvider provider)
	{
		ArgumentNullException.ThrowIfNull(s, "s");
		return s;
	}

	static bool IParsable<string>.TryParse([NotNullWhen(true)] string s, IFormatProvider provider, [MaybeNullWhen(false)] out string result)
	{
		result = s;
		return (object)s != null;
	}

	static string ISpanParsable<string>.Parse(ReadOnlySpan<char> s, IFormatProvider provider)
	{
		if (s.Length > 1073741791)
		{
			ThrowHelper.ThrowFormatInvalidString();
		}
		return s.ToString();
	}

	static bool ISpanParsable<string>.TryParse(ReadOnlySpan<char> s, IFormatProvider provider, [MaybeNullWhen(false)] out string result)
	{
		if (s.Length <= 1073741791)
		{
			result = s.ToString();
			return true;
		}
		result = null;
		return false;
	}

	private static void CopyStringContent(string dest, int destPos, string src)
	{
		Buffer.Memmove(ref Unsafe.Add(ref dest._firstChar, destPos), ref src._firstChar, (uint)src.Length);
	}

	public static string Concat(object? arg0)
	{
		return arg0?.ToString() ?? Empty;
	}

	public static string Concat(object? arg0, object? arg1)
	{
		return arg0?.ToString() + arg1;
	}

	public static string Concat(object? arg0, object? arg1, object? arg2)
	{
		return arg0?.ToString() + arg1?.ToString() + arg2;
	}

	public static string Concat(params object?[] args)
	{
		ArgumentNullException.ThrowIfNull(args, "args");
		if (args.Length <= 1)
		{
			object obj;
			if (args.Length != 0)
			{
				obj = args[0]?.ToString();
				if (obj == null)
				{
					return Empty;
				}
			}
			else
			{
				obj = Empty;
			}
			return (string)obj;
		}
		string[] array = new string[args.Length];
		int num = 0;
		for (int i = 0; i < args.Length; i++)
		{
			num += (array[i] = args[i]?.ToString() ?? Empty).Length;
			if (num < 0)
			{
				ThrowHelper.ThrowOutOfMemoryException_StringTooLong();
			}
		}
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		int num2 = 0;
		foreach (string text2 in array)
		{
			CopyStringContent(text, num2, text2);
			num2 += text2.Length;
		}
		return text;
	}

	public static string Concat<T>(IEnumerable<T> values)
	{
		return JoinCore(ReadOnlySpan<char>.Empty, values);
	}

	public static string Concat(IEnumerable<string?> values)
	{
		ArgumentNullException.ThrowIfNull(values, "values");
		using IEnumerator<string> enumerator = values.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return Empty;
		}
		string current = enumerator.Current;
		if (!enumerator.MoveNext())
		{
			return current ?? Empty;
		}
		Span<char> initialBuffer = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		valueStringBuilder.Append(current);
		do
		{
			valueStringBuilder.Append(enumerator.Current);
		}
		while (enumerator.MoveNext());
		return valueStringBuilder.ToString();
	}

	public static string Concat(string? str0, string? str1)
	{
		if (IsNullOrEmpty(str0))
		{
			if (IsNullOrEmpty(str1))
			{
				return Empty;
			}
			return str1;
		}
		if (IsNullOrEmpty(str1))
		{
			return str0;
		}
		int length = str0.Length;
		int num = length + str1.Length;
		if (num < 0)
		{
			ThrowHelper.ThrowOutOfMemoryException_StringTooLong();
		}
		string text = FastAllocateString(num);
		CopyStringContent(text, 0, str0);
		CopyStringContent(text, length, str1);
		return text;
	}

	public static string Concat(string? str0, string? str1, string? str2)
	{
		if (IsNullOrEmpty(str0))
		{
			return str1 + str2;
		}
		if (IsNullOrEmpty(str1))
		{
			return str0 + str2;
		}
		if (IsNullOrEmpty(str2))
		{
			return str0 + str1;
		}
		long num = (long)str0.Length + (long)str1.Length + str2.Length;
		if (num > int.MaxValue)
		{
			ThrowHelper.ThrowOutOfMemoryException_StringTooLong();
		}
		string text = FastAllocateString((int)num);
		CopyStringContent(text, 0, str0);
		CopyStringContent(text, str0.Length, str1);
		CopyStringContent(text, str0.Length + str1.Length, str2);
		return text;
	}

	public static string Concat(string? str0, string? str1, string? str2, string? str3)
	{
		if (IsNullOrEmpty(str0))
		{
			return str1 + str2 + str3;
		}
		if (IsNullOrEmpty(str1))
		{
			return str0 + str2 + str3;
		}
		if (IsNullOrEmpty(str2))
		{
			return str0 + str1 + str3;
		}
		if (IsNullOrEmpty(str3))
		{
			return str0 + str1 + str2;
		}
		long num = (long)str0.Length + (long)str1.Length + str2.Length + str3.Length;
		if (num > int.MaxValue)
		{
			ThrowHelper.ThrowOutOfMemoryException_StringTooLong();
		}
		string text = FastAllocateString((int)num);
		CopyStringContent(text, 0, str0);
		CopyStringContent(text, str0.Length, str1);
		CopyStringContent(text, str0.Length + str1.Length, str2);
		CopyStringContent(text, str0.Length + str1.Length + str2.Length, str3);
		return text;
	}

	public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1)
	{
		int num = checked(str0.Length + str1.Length);
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		Span<char> destination = new Span<char>(ref text._firstChar, text.Length);
		str0.CopyTo(destination);
		str1.CopyTo(destination.Slice(str0.Length));
		return text;
	}

	public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2)
	{
		int num = checked(str0.Length + str1.Length + str2.Length);
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		Span<char> destination = new Span<char>(ref text._firstChar, text.Length);
		str0.CopyTo(destination);
		destination = destination.Slice(str0.Length);
		str1.CopyTo(destination);
		destination = destination.Slice(str1.Length);
		str2.CopyTo(destination);
		return text;
	}

	public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3)
	{
		int num = checked(str0.Length + str1.Length + str2.Length + str3.Length);
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		Span<char> destination = new Span<char>(ref text._firstChar, text.Length);
		str0.CopyTo(destination);
		destination = destination.Slice(str0.Length);
		str1.CopyTo(destination);
		destination = destination.Slice(str1.Length);
		str2.CopyTo(destination);
		destination = destination.Slice(str2.Length);
		str3.CopyTo(destination);
		return text;
	}

	internal static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3, ReadOnlySpan<char> str4)
	{
		int num = checked(str0.Length + str1.Length + str2.Length + str3.Length + str4.Length);
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		Span<char> destination = new Span<char>(ref text._firstChar, text.Length);
		str0.CopyTo(destination);
		destination = destination.Slice(str0.Length);
		str1.CopyTo(destination);
		destination = destination.Slice(str1.Length);
		str2.CopyTo(destination);
		destination = destination.Slice(str2.Length);
		str3.CopyTo(destination);
		destination = destination.Slice(str3.Length);
		str4.CopyTo(destination);
		return text;
	}

	public static string Concat(params string?[] values)
	{
		ArgumentNullException.ThrowIfNull(values, "values");
		if (values.Length <= 1)
		{
			object obj;
			if (values.Length != 0)
			{
				obj = values[0];
				if (obj == null)
				{
					return Empty;
				}
			}
			else
			{
				obj = Empty;
			}
			return (string)obj;
		}
		long num = 0L;
		foreach (string text in values)
		{
			if ((object)text != null)
			{
				num += text.Length;
			}
		}
		if (num > int.MaxValue)
		{
			ThrowHelper.ThrowOutOfMemoryException_StringTooLong();
		}
		int num2 = (int)num;
		if (num2 == 0)
		{
			return Empty;
		}
		string text2 = FastAllocateString(num2);
		int num3 = 0;
		foreach (string text3 in values)
		{
			if (!IsNullOrEmpty(text3))
			{
				int length = text3.Length;
				if (length > num2 - num3)
				{
					num3 = -1;
					break;
				}
				CopyStringContent(text2, num3, text3);
				num3 += length;
			}
		}
		if (num3 != num2)
		{
			return Concat((string[])values.Clone());
		}
		return text2;
	}

	public static string Format([StringSyntax("CompositeFormat")] string format, object? arg0)
	{
		return FormatHelper(null, format, new ReadOnlySpan<object>(ref arg0));
	}

	public static string Format([StringSyntax("CompositeFormat")] string format, object? arg0, object? arg1)
	{
		TwoObjects twoObjects = new TwoObjects(arg0, arg1);
		return FormatHelper(null, format, MemoryMarshal.CreateReadOnlySpan(ref twoObjects.Arg0, 2));
	}

	public static string Format([StringSyntax("CompositeFormat")] string format, object? arg0, object? arg1, object? arg2)
	{
		ThreeObjects threeObjects = new ThreeObjects(arg0, arg1, arg2);
		return FormatHelper(null, format, MemoryMarshal.CreateReadOnlySpan(ref threeObjects.Arg0, 3));
	}

	public static string Format([StringSyntax("CompositeFormat")] string format, params object?[] args)
	{
		if (args == null)
		{
			ArgumentNullException.Throw(((object)format == null) ? "format" : "args");
		}
		return FormatHelper(null, format, args);
	}

	public static string Format(IFormatProvider? provider, [StringSyntax("CompositeFormat")] string format, object? arg0)
	{
		return FormatHelper(provider, format, new ReadOnlySpan<object>(ref arg0));
	}

	public static string Format(IFormatProvider? provider, [StringSyntax("CompositeFormat")] string format, object? arg0, object? arg1)
	{
		TwoObjects twoObjects = new TwoObjects(arg0, arg1);
		return FormatHelper(provider, format, MemoryMarshal.CreateReadOnlySpan(ref twoObjects.Arg0, 2));
	}

	public static string Format(IFormatProvider? provider, [StringSyntax("CompositeFormat")] string format, object? arg0, object? arg1, object? arg2)
	{
		ThreeObjects threeObjects = new ThreeObjects(arg0, arg1, arg2);
		return FormatHelper(provider, format, MemoryMarshal.CreateReadOnlySpan(ref threeObjects.Arg0, 3));
	}

	public static string Format(IFormatProvider? provider, [StringSyntax("CompositeFormat")] string format, params object?[] args)
	{
		if (args == null)
		{
			ArgumentNullException.Throw(((object)format == null) ? "format" : "args");
		}
		return FormatHelper(provider, format, args);
	}

	private static string FormatHelper(IFormatProvider provider, string format, ReadOnlySpan<object> args)
	{
		ArgumentNullException.ThrowIfNull(format, "format");
		Span<char> initialBuffer = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		valueStringBuilder.EnsureCapacity(format.Length + args.Length * 8);
		valueStringBuilder.AppendFormatHelper(provider, format, args);
		return valueStringBuilder.ToString();
	}

	public static string Format<TArg0>(IFormatProvider? provider, CompositeFormat format, TArg0 arg0)
	{
		ArgumentNullException.ThrowIfNull(format, "format");
		format.ValidateNumberOfArgs(1);
		return Format(provider, format, arg0, 0, 0, default(ReadOnlySpan<object>));
	}

	public static string Format<TArg0, TArg1>(IFormatProvider? provider, CompositeFormat format, TArg0 arg0, TArg1 arg1)
	{
		ArgumentNullException.ThrowIfNull(format, "format");
		format.ValidateNumberOfArgs(2);
		return Format(provider, format, arg0, arg1, 0, default(ReadOnlySpan<object>));
	}

	public static string Format<TArg0, TArg1, TArg2>(IFormatProvider? provider, CompositeFormat format, TArg0 arg0, TArg1 arg1, TArg2 arg2)
	{
		ArgumentNullException.ThrowIfNull(format, "format");
		format.ValidateNumberOfArgs(3);
		return Format(provider, format, arg0, arg1, arg2, default(ReadOnlySpan<object>));
	}

	public static string Format(IFormatProvider? provider, CompositeFormat format, params object?[] args)
	{
		ArgumentNullException.ThrowIfNull(format, "format");
		ArgumentNullException.ThrowIfNull(args, "args");
		return Format(provider, format, (ReadOnlySpan<object>)args);
	}

	public static string Format(IFormatProvider? provider, CompositeFormat format, ReadOnlySpan<object?> args)
	{
		ArgumentNullException.ThrowIfNull(format, "format");
		format.ValidateNumberOfArgs(args.Length);
		return args.Length switch
		{
			0 => format.Format, 
			1 => Format(provider, format, args[0], 0, 0, args), 
			2 => Format(provider, format, args[0], args[1], 0, args), 
			_ => Format(provider, format, args[0], args[1], args[2], args), 
		};
	}

	private static string Format<TArg0, TArg1, TArg2>(IFormatProvider provider, CompositeFormat format, TArg0 arg0, TArg1 arg1, TArg2 arg2, ReadOnlySpan<object> args)
	{
		if (format._formattedCount == 0)
		{
			return format.Format;
		}
		int literalLength = format._literalLength;
		int formattedCount = format._formattedCount;
		Span<char> initialBuffer = stackalloc char[256];
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(literalLength, formattedCount, provider, initialBuffer);
		(string, int, int, string)[] segments = format._segments;
		for (int i = 0; i < segments.Length; i++)
		{
			(string, int, int, string) tuple = segments[i];
			var (text, _, _, _) = tuple;
			if ((object)text != null)
			{
				defaultInterpolatedStringHandler.AppendLiteral(text);
				continue;
			}
			int item = tuple.Item2;
			switch (item)
			{
			case 0:
				defaultInterpolatedStringHandler.AppendFormatted(arg0, tuple.Item3, tuple.Item4);
				break;
			case 1:
				defaultInterpolatedStringHandler.AppendFormatted(arg1, tuple.Item3, tuple.Item4);
				break;
			case 2:
				defaultInterpolatedStringHandler.AppendFormatted(arg2, tuple.Item3, tuple.Item4);
				break;
			default:
				defaultInterpolatedStringHandler.AppendFormatted(args[item], tuple.Item3, tuple.Item4);
				break;
			}
		}
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	public string Insert(int startIndex, string value)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		ArgumentOutOfRangeException.ThrowIfGreaterThan((uint)startIndex, (uint)Length, "startIndex");
		int length = Length;
		int length2 = value.Length;
		if (length == 0)
		{
			return value;
		}
		if (length2 == 0)
		{
			return this;
		}
		int length3 = length + length2;
		string text = FastAllocateString(length3);
		Buffer.Memmove(ref text._firstChar, ref _firstChar, (nuint)startIndex);
		Buffer.Memmove(ref Unsafe.Add(ref text._firstChar, startIndex), ref value._firstChar, (nuint)length2);
		Buffer.Memmove(ref Unsafe.Add(ref text._firstChar, startIndex + length2), ref Unsafe.Add(ref _firstChar, startIndex), (nuint)(length - startIndex));
		return text;
	}

	public static string Join(char separator, params string?[] value)
	{
		if (value == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		return JoinCore(new ReadOnlySpan<char>(ref separator), new ReadOnlySpan<string>(value));
	}

	public static string Join(string? separator, params string?[] value)
	{
		if (value == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		return JoinCore(separator.AsSpan(), new ReadOnlySpan<string>(value));
	}

	public static string Join(char separator, string?[] value, int startIndex, int count)
	{
		return JoinCore(new ReadOnlySpan<char>(ref separator), value, startIndex, count);
	}

	public static string Join(string? separator, string?[] value, int startIndex, int count)
	{
		return JoinCore(separator.AsSpan(), value, startIndex, count);
	}

	private static string JoinCore(ReadOnlySpan<char> separator, string[] value, int startIndex, int count)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		ArgumentOutOfRangeException.ThrowIfNegative(startIndex, "startIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(startIndex, value.Length - count, "startIndex");
		return JoinCore(separator, new ReadOnlySpan<string>(value, startIndex, count));
	}

	public static string Join(string? separator, IEnumerable<string?> values)
	{
		if (values is List<string> list)
		{
			return JoinCore(separator.AsSpan(), CollectionsMarshal.AsSpan(list));
		}
		if (values is string[] array)
		{
			return JoinCore(separator.AsSpan(), new ReadOnlySpan<string>(array));
		}
		if (values == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.values);
		}
		using IEnumerator<string> enumerator = values.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return Empty;
		}
		string current = enumerator.Current;
		if (!enumerator.MoveNext())
		{
			return current ?? Empty;
		}
		Span<char> initialBuffer = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		valueStringBuilder.Append(current);
		do
		{
			valueStringBuilder.Append(separator);
			valueStringBuilder.Append(enumerator.Current);
		}
		while (enumerator.MoveNext());
		return valueStringBuilder.ToString();
	}

	public static string Join(char separator, params object?[] values)
	{
		return JoinCore(new ReadOnlySpan<char>(ref separator), values);
	}

	public static string Join(string? separator, params object?[] values)
	{
		return JoinCore(separator.AsSpan(), values);
	}

	private static string JoinCore(ReadOnlySpan<char> separator, object[] values)
	{
		if (values == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.values);
		}
		if (values.Length == 0)
		{
			return Empty;
		}
		string text = values[0]?.ToString();
		if (values.Length == 1)
		{
			return text ?? Empty;
		}
		Span<char> initialBuffer = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		valueStringBuilder.Append(text);
		for (int i = 1; i < values.Length; i++)
		{
			valueStringBuilder.Append(separator);
			object obj = values[i];
			if (obj != null)
			{
				valueStringBuilder.Append(obj.ToString());
			}
		}
		return valueStringBuilder.ToString();
	}

	public static string Join<T>(char separator, IEnumerable<T> values)
	{
		return JoinCore(new ReadOnlySpan<char>(ref separator), values);
	}

	public static string Join<T>(string? separator, IEnumerable<T> values)
	{
		return JoinCore(separator.AsSpan(), values);
	}

	private static string JoinCore<T>(ReadOnlySpan<char> separator, IEnumerable<T> values)
	{
		if (typeof(T) == typeof(string))
		{
			if (values is List<string> list)
			{
				return JoinCore(separator, CollectionsMarshal.AsSpan(list));
			}
			if (values is string[] array)
			{
				return JoinCore(separator, new ReadOnlySpan<string>(array));
			}
		}
		if (values == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.values);
		}
		using IEnumerator<T> enumerator = values.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return Empty;
		}
		Span<char> initialBuffer;
		if (typeof(T) == typeof(char))
		{
			IEnumerator<char> enumerator2 = Unsafe.As<IEnumerator<char>>(enumerator);
			char current = enumerator2.Current;
			if (!enumerator2.MoveNext())
			{
				return CreateFromChar(current);
			}
			initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			valueStringBuilder.Append(current);
			do
			{
				if (!separator.IsEmpty)
				{
					valueStringBuilder.Append(separator);
				}
				current = enumerator2.Current;
				valueStringBuilder.Append(current);
			}
			while (enumerator2.MoveNext());
			return valueStringBuilder.ToString();
		}
		if (typeof(T).IsValueType && default(T) is ISpanFormattable)
		{
			T current2 = enumerator.Current;
			if (!enumerator.MoveNext())
			{
				return current2.ToString() ?? Empty;
			}
			IFormatProvider currentCulture = CultureInfo.CurrentCulture;
			initialBuffer = stackalloc char[256];
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 0, currentCulture, initialBuffer);
			defaultInterpolatedStringHandler.AppendFormatted(current2);
			do
			{
				if (!separator.IsEmpty)
				{
					defaultInterpolatedStringHandler.AppendFormatted(separator);
				}
				defaultInterpolatedStringHandler.AppendFormatted(enumerator.Current);
			}
			while (enumerator.MoveNext());
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		T current3 = enumerator.Current;
		string text = ((current3 != null) ? current3.ToString() : null);
		if (!enumerator.MoveNext())
		{
			return text ?? Empty;
		}
		initialBuffer = stackalloc char[256];
		ValueStringBuilder valueStringBuilder2 = new ValueStringBuilder(initialBuffer);
		valueStringBuilder2.Append(text);
		do
		{
			if (!separator.IsEmpty)
			{
				valueStringBuilder2.Append(separator);
			}
			current3 = enumerator.Current;
			valueStringBuilder2.Append((current3 != null) ? current3.ToString() : null);
		}
		while (enumerator.MoveNext());
		return valueStringBuilder2.ToString();
	}

	private static string JoinCore(ReadOnlySpan<char> separator, ReadOnlySpan<string> values)
	{
		if (values.Length <= 1)
		{
			object obj;
			if (!values.IsEmpty)
			{
				obj = values[0];
				if (obj == null)
				{
					return Empty;
				}
			}
			else
			{
				obj = Empty;
			}
			return (string)obj;
		}
		long num = (long)(values.Length - 1) * (long)separator.Length;
		if (num > int.MaxValue)
		{
			ThrowHelper.ThrowOutOfMemoryException_StringTooLong();
		}
		int num2 = (int)num;
		ReadOnlySpan<string> readOnlySpan = values;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			string text = readOnlySpan[i];
			if ((object)text != null)
			{
				num2 += text.Length;
				if (num2 < 0)
				{
					ThrowHelper.ThrowOutOfMemoryException_StringTooLong();
				}
			}
		}
		if (num2 == 0)
		{
			return Empty;
		}
		string text2 = FastAllocateString(num2);
		int num3 = 0;
		for (int j = 0; j < values.Length; j++)
		{
			string text3 = values[j];
			if ((object)text3 != null)
			{
				int length = text3.Length;
				if (length > num2 - num3)
				{
					num3 = -1;
					break;
				}
				CopyStringContent(text2, num3, text3);
				num3 += length;
			}
			if (j < values.Length - 1)
			{
				ref char reference = ref Unsafe.Add(ref text2._firstChar, num3);
				if (separator.Length == 1)
				{
					reference = separator[0];
				}
				else
				{
					separator.CopyTo(new Span<char>(ref reference, separator.Length));
				}
				num3 += separator.Length;
			}
		}
		if (num3 != num2)
		{
			return JoinCore(separator, values.ToArray().AsSpan());
		}
		return text2;
	}

	public string PadLeft(int totalWidth)
	{
		return PadLeft(totalWidth, ' ');
	}

	public string PadLeft(int totalWidth, char paddingChar)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(totalWidth, "totalWidth");
		int length = Length;
		int num = totalWidth - length;
		if (num <= 0)
		{
			return this;
		}
		string text = FastAllocateString(totalWidth);
		new Span<char>(ref text._firstChar, num).Fill(paddingChar);
		Buffer.Memmove(ref Unsafe.Add(ref text._firstChar, num), ref _firstChar, (nuint)length);
		return text;
	}

	public string PadRight(int totalWidth)
	{
		return PadRight(totalWidth, ' ');
	}

	public string PadRight(int totalWidth, char paddingChar)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(totalWidth, "totalWidth");
		int length = Length;
		int num = totalWidth - length;
		if (num <= 0)
		{
			return this;
		}
		string text = FastAllocateString(totalWidth);
		Buffer.Memmove(ref text._firstChar, ref _firstChar, (nuint)length);
		new Span<char>(ref Unsafe.Add(ref text._firstChar, length), num).Fill(paddingChar);
		return text;
	}

	public string Remove(int startIndex, int count)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(startIndex, "startIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		int length = Length;
		ArgumentOutOfRangeException.ThrowIfGreaterThan(count, length - startIndex, "count");
		if (count == 0)
		{
			return this;
		}
		int num = length - count;
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		Buffer.Memmove(ref text._firstChar, ref _firstChar, (nuint)startIndex);
		Buffer.Memmove(ref Unsafe.Add(ref text._firstChar, startIndex), ref Unsafe.Add(ref _firstChar, startIndex + count), (nuint)(num - startIndex));
		return text;
	}

	public string Remove(int startIndex)
	{
		if ((uint)startIndex > Length)
		{
			throw new ArgumentOutOfRangeException("startIndex", (startIndex < 0) ? SR.ArgumentOutOfRange_StartIndex : SR.ArgumentOutOfRange_StartIndexLargerThanLength);
		}
		return Substring(0, startIndex);
	}

	public string Replace(string oldValue, string? newValue, bool ignoreCase, CultureInfo? culture)
	{
		return ReplaceCore(oldValue, newValue, culture?.CompareInfo, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	public string Replace(string oldValue, string? newValue, StringComparison comparisonType)
	{
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return ReplaceCore(oldValue, newValue, CultureInfo.CurrentCulture.CompareInfo, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return ReplaceCore(oldValue, newValue, CompareInfo.Invariant, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.Ordinal:
			return Replace(oldValue, newValue);
		case StringComparison.OrdinalIgnoreCase:
			return ReplaceCore(oldValue, newValue, CompareInfo.Invariant, CompareOptions.OrdinalIgnoreCase);
		default:
			throw new ArgumentException(SR.NotSupported_StringComparison, "comparisonType");
		}
	}

	private string ReplaceCore(string oldValue, string newValue, CompareInfo ci, CompareOptions options)
	{
		ArgumentException.ThrowIfNullOrEmpty(oldValue, "oldValue");
		return ReplaceCore(this, oldValue.AsSpan(), newValue.AsSpan(), ci ?? CultureInfo.CurrentCulture.CompareInfo, options) ?? this;
	}

	private static string ReplaceCore(ReadOnlySpan<char> searchSpace, ReadOnlySpan<char> oldValue, ReadOnlySpan<char> newValue, CompareInfo compareInfo, CompareOptions options)
	{
		Span<char> initialBuffer = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		valueStringBuilder.EnsureCapacity(searchSpace.Length);
		bool flag = false;
		while (true)
		{
			int matchLength;
			int num = compareInfo.IndexOf(searchSpace, oldValue, options, out matchLength);
			if (num < 0 || matchLength == 0)
			{
				break;
			}
			valueStringBuilder.Append(searchSpace.Slice(0, num));
			valueStringBuilder.Append(newValue);
			searchSpace = searchSpace.Slice(num + matchLength);
			flag = true;
		}
		if (!flag)
		{
			valueStringBuilder.Dispose();
			return null;
		}
		valueStringBuilder.Append(searchSpace);
		return valueStringBuilder.ToString();
	}

	public string Replace(char oldChar, char newChar)
	{
		if (oldChar == newChar)
		{
			return this;
		}
		int num = IndexOf(oldChar);
		if (num < 0)
		{
			return this;
		}
		nuint num2 = (uint)(Length - num);
		string text = FastAllocateString(Length);
		int num3 = num;
		if (num3 > 0)
		{
			Buffer.Memmove(ref text._firstChar, ref _firstChar, (uint)num3);
		}
		ref ushort reference = ref Unsafe.Add(ref GetRawStringDataAsUInt16(), (uint)num3);
		ref ushort reference2 = ref Unsafe.Add(ref text.GetRawStringDataAsUInt16(), (uint)num3);
		nuint num4 = (uint)Length;
		if (Vector128.IsHardwareAccelerated && num4 >= (uint)Vector128<ushort>.Count)
		{
			nuint num5 = (num4 - num2) & (uint)(Vector128<ushort>.Count - 1);
			reference = ref Unsafe.Subtract(ref reference, num5);
			reference2 = ref Unsafe.Subtract(ref reference2, num5);
			num2 += num5;
		}
		SpanHelpers.ReplaceValueType(ref reference, ref reference2, oldChar, newChar, num2);
		return text;
	}

	public string Replace(string oldValue, string? newValue)
	{
		ArgumentException.ThrowIfNullOrEmpty(oldValue, "oldValue");
		if ((object)newValue == null)
		{
			newValue = Empty;
		}
		Span<int> initialSpan = stackalloc int[128];
		ValueListBuilder<int> valueListBuilder = new ValueListBuilder<int>(initialSpan);
		if (oldValue.Length == 1)
		{
			if (newValue.Length == 1)
			{
				return Replace(oldValue[0], newValue[0]);
			}
			char value = oldValue[0];
			int num = 0;
			if (PackedSpanHelpers.PackedIndexOfIsSupported && PackedSpanHelpers.CanUsePackedIndexOf(value))
			{
				while (true)
				{
					int num2 = PackedSpanHelpers.IndexOf(ref Unsafe.Add(ref _firstChar, num), value, Length - num);
					if (num2 < 0)
					{
						break;
					}
					valueListBuilder.Append(num + num2);
					num += num2 + 1;
				}
			}
			else
			{
				while (true)
				{
					int num3 = SpanHelpers.NonPackedIndexOfChar(ref Unsafe.Add(ref _firstChar, num), value, Length - num);
					if (num3 < 0)
					{
						break;
					}
					valueListBuilder.Append(num + num3);
					num += num3 + 1;
				}
			}
		}
		else
		{
			int num4 = 0;
			while (true)
			{
				int num5 = SpanHelpers.IndexOf(ref Unsafe.Add(ref _firstChar, num4), Length - num4, ref oldValue._firstChar, oldValue.Length);
				if (num5 < 0)
				{
					break;
				}
				valueListBuilder.Append(num4 + num5);
				num4 += num5 + oldValue.Length;
			}
		}
		if (valueListBuilder.Length == 0)
		{
			return this;
		}
		string result = ReplaceHelper(oldValue.Length, newValue, valueListBuilder.AsSpan());
		valueListBuilder.Dispose();
		return result;
	}

	private string ReplaceHelper(int oldValueLength, string newValue, ReadOnlySpan<int> indices)
	{
		long num = Length + (long)(newValue.Length - oldValueLength) * (long)indices.Length;
		if (num > int.MaxValue)
		{
			ThrowHelper.ThrowOutOfMemoryException_StringTooLong();
		}
		string text = FastAllocateString((int)num);
		Span<char> span = new Span<char>(ref text._firstChar, text.Length);
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < indices.Length; i++)
		{
			int num4 = indices[i];
			int num5 = num4 - num2;
			if (num5 != 0)
			{
				this.AsSpan(num2, num5).CopyTo(span.Slice(num3));
				num3 += num5;
			}
			num2 = num4 + oldValueLength;
			newValue.CopyTo(span.Slice(num3));
			num3 += newValue.Length;
		}
		this.AsSpan(num2).CopyTo(span.Slice(num3));
		return text;
	}

	public string ReplaceLineEndings()
	{
		return ReplaceLineEndings("\r\n");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public string ReplaceLineEndings(string replacementText)
	{
		if (!(replacementText == "\n"))
		{
			return ReplaceLineEndingsCore(replacementText);
		}
		return ReplaceLineEndingsWithLineFeed();
	}

	private string ReplaceLineEndingsCore(string replacementText)
	{
		ArgumentNullException.ThrowIfNull(replacementText, "replacementText");
		int stride;
		int num = IndexOfNewlineChar(this, replacementText, out stride);
		if (num < 0)
		{
			return this;
		}
		ReadOnlySpan<char> readOnlySpan = this.AsSpan(0, num);
		ReadOnlySpan<char> readOnlySpan2 = this.AsSpan(num + stride);
		Span<char> initialBuffer = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		while (true)
		{
			int num2 = IndexOfNewlineChar(readOnlySpan2, replacementText, out stride);
			if (num2 < 0)
			{
				break;
			}
			valueStringBuilder.Append(replacementText);
			valueStringBuilder.Append(readOnlySpan2.Slice(0, num2));
			readOnlySpan2 = readOnlySpan2.Slice(num2 + stride);
		}
		string result = Concat(readOnlySpan, valueStringBuilder.AsSpan(), replacementText, readOnlySpan2);
		valueStringBuilder.Dispose();
		return result;
	}

	private static int IndexOfNewlineChar(ReadOnlySpan<char> text, string replacementText, out int stride)
	{
		stride = 0;
		int num = 0;
		while (true)
		{
			int num2 = text.IndexOfAny(SearchValuesStorage.NewLineChars);
			if ((uint)num2 >= (uint)text.Length)
			{
				return -1;
			}
			num += num2;
			stride = 1;
			if (text[num2] == '\r')
			{
				int num3 = num2 + 1;
				if ((uint)num3 < (uint)text.Length && text[num3] == '\n')
				{
					stride = 2;
					if (replacementText != "\r\n")
					{
						return num;
					}
				}
				else if (replacementText != "\r")
				{
					return num;
				}
			}
			else if (replacementText.Length != 1 || replacementText[0] != text[num2])
			{
				break;
			}
			num += stride;
			text = text.Slice(num2 + stride);
		}
		return num;
	}

	private string ReplaceLineEndingsWithLineFeed()
	{
		int num = this.AsSpan().IndexOfAny("\r\f\u0085\u2028\u2029");
		if ((uint)num >= (uint)Length)
		{
			return this;
		}
		int num2 = ((this[num] != '\r' || (uint)(num + 1) >= (uint)Length || this[num + 1] != '\n') ? 1 : 2);
		ReadOnlySpan<char> readOnlySpan = this.AsSpan(num + num2);
		Span<char> initialBuffer = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		while (true)
		{
			int num3 = readOnlySpan.IndexOfAny("\r\f\u0085\u2028\u2029");
			if ((uint)num3 >= (uint)readOnlySpan.Length)
			{
				break;
			}
			num2 = ((readOnlySpan[num3] != '\r' || (uint)(num3 + 1) >= (uint)readOnlySpan.Length || readOnlySpan[num3 + 1] != '\n') ? 1 : 2);
			valueStringBuilder.Append('\n');
			valueStringBuilder.Append(readOnlySpan.Slice(0, num3));
			readOnlySpan = readOnlySpan.Slice(num3 + num2);
		}
		valueStringBuilder.Append('\n');
		string result = Concat(this.AsSpan(0, num), valueStringBuilder.AsSpan(), readOnlySpan);
		valueStringBuilder.Dispose();
		return result;
	}

	public string[] Split(char separator, StringSplitOptions options = StringSplitOptions.None)
	{
		return SplitInternal(new ReadOnlySpan<char>(ref separator), int.MaxValue, options);
	}

	public string[] Split(char separator, int count, StringSplitOptions options = StringSplitOptions.None)
	{
		return SplitInternal(new ReadOnlySpan<char>(ref separator), count, options);
	}

	public string[] Split(params char[]? separator)
	{
		return SplitInternal(separator, int.MaxValue, StringSplitOptions.None);
	}

	public string[] Split(char[]? separator, int count)
	{
		return SplitInternal(separator, count, StringSplitOptions.None);
	}

	public string[] Split(char[]? separator, StringSplitOptions options)
	{
		return SplitInternal(separator, int.MaxValue, options);
	}

	public string[] Split(char[]? separator, int count, StringSplitOptions options)
	{
		return SplitInternal(separator, count, options);
	}

	private string[] SplitInternal(ReadOnlySpan<char> separators, int count, StringSplitOptions options)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		CheckStringSplitOptions(options);
		ValueListBuilder<int> sepListBuilder;
		ReadOnlySpan<int> sepList;
		while (true)
		{
			if (count <= 1 || Length == 0)
			{
				return CreateSplitArrayOfThisAsSoleValue(options, count);
			}
			if (separators.IsEmpty && count > Length)
			{
				options &= ~StringSplitOptions.TrimEntries;
			}
			Span<int> initialSpan = stackalloc int[128];
			sepListBuilder = new ValueListBuilder<int>(initialSpan);
			MakeSeparatorListAny(this, separators, ref sepListBuilder);
			sepList = sepListBuilder.AsSpan();
			if (sepList.Length != 0)
			{
				break;
			}
			count = 1;
		}
		string[] result = ((options != 0) ? SplitWithPostProcessing(sepList, default(ReadOnlySpan<int>), 1, count, options) : SplitWithoutPostProcessing(sepList, default(ReadOnlySpan<int>), 1, count));
		sepListBuilder.Dispose();
		return result;
	}

	public string[] Split(string? separator, StringSplitOptions options = StringSplitOptions.None)
	{
		return SplitInternal(separator ?? Empty, null, int.MaxValue, options);
	}

	public string[] Split(string? separator, int count, StringSplitOptions options = StringSplitOptions.None)
	{
		return SplitInternal(separator ?? Empty, null, count, options);
	}

	public string[] Split(string[]? separator, StringSplitOptions options)
	{
		return SplitInternal(null, separator, int.MaxValue, options);
	}

	public string[] Split(string[]? separator, int count, StringSplitOptions options)
	{
		return SplitInternal(null, separator, count, options);
	}

	private string[] SplitInternal(string separator, string[] separators, int count, StringSplitOptions options)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		CheckStringSplitOptions(options);
		bool flag = (object)separator != null;
		if (!flag && (separators == null || separators.Length == 0))
		{
			return SplitInternal(default(ReadOnlySpan<char>), count, options);
		}
		while (true)
		{
			if (count <= 1 || Length == 0)
			{
				return CreateSplitArrayOfThisAsSoleValue(options, count);
			}
			if (!flag)
			{
				break;
			}
			if (separator.Length == 0)
			{
				count = 1;
				continue;
			}
			return SplitInternal(separator, count, options);
		}
		Span<int> initialSpan = stackalloc int[128];
		ValueListBuilder<int> sepListBuilder = new ValueListBuilder<int>(initialSpan);
		initialSpan = stackalloc int[128];
		ValueListBuilder<int> lengthListBuilder = new ValueListBuilder<int>(initialSpan);
		MakeSeparatorListAny(this, separators, ref sepListBuilder, ref lengthListBuilder);
		ReadOnlySpan<int> sepList = sepListBuilder.AsSpan();
		ReadOnlySpan<int> lengthList = lengthListBuilder.AsSpan();
		if (sepList.Length == 0)
		{
			return CreateSplitArrayOfThisAsSoleValue(options, count);
		}
		string[] result = ((options != 0) ? SplitWithPostProcessing(sepList, lengthList, 0, count, options) : SplitWithoutPostProcessing(sepList, lengthList, 0, count));
		sepListBuilder.Dispose();
		lengthListBuilder.Dispose();
		return result;
	}

	private string[] CreateSplitArrayOfThisAsSoleValue(StringSplitOptions options, int count)
	{
		if (count != 0)
		{
			string text = this;
			if ((options & StringSplitOptions.TrimEntries) != 0)
			{
				text = text.Trim();
			}
			if ((options & StringSplitOptions.RemoveEmptyEntries) == 0 || text.Length != 0)
			{
				return new string[1] { text };
			}
		}
		return Array.Empty<string>();
	}

	private string[] SplitInternal(string separator, int count, StringSplitOptions options)
	{
		Span<int> initialSpan = stackalloc int[128];
		ValueListBuilder<int> sepListBuilder = new ValueListBuilder<int>(initialSpan);
		MakeSeparatorList(this, separator, ref sepListBuilder);
		ReadOnlySpan<int> sepList = sepListBuilder.AsSpan();
		if (sepList.Length == 0)
		{
			return CreateSplitArrayOfThisAsSoleValue(options, count);
		}
		string[] result = ((options != 0) ? SplitWithPostProcessing(sepList, default(ReadOnlySpan<int>), separator.Length, count, options) : SplitWithoutPostProcessing(sepList, default(ReadOnlySpan<int>), separator.Length, count));
		sepListBuilder.Dispose();
		return result;
	}

	private string[] SplitWithoutPostProcessing(ReadOnlySpan<int> sepList, ReadOnlySpan<int> lengthList, int defaultLength, int count)
	{
		int num = 0;
		int num2 = 0;
		count--;
		int num3 = ((sepList.Length < count) ? sepList.Length : count);
		string[] array = new string[num3 + 1];
		for (int i = 0; i < num3; i++)
		{
			if (num >= Length)
			{
				break;
			}
			array[num2++] = Substring(num, sepList[i] - num);
			num = sepList[i] + (lengthList.IsEmpty ? defaultLength : lengthList[i]);
		}
		if (num < Length && num3 >= 0)
		{
			array[num2] = Substring(num);
		}
		else if (num2 == num3)
		{
			array[num2] = Empty;
		}
		return array;
	}

	private string[] SplitWithPostProcessing(ReadOnlySpan<int> sepList, ReadOnlySpan<int> lengthList, int defaultLength, int count, StringSplitOptions options)
	{
		int length = sepList.Length;
		int num = ((length < count) ? (length + 1) : count);
		string[] array = new string[num];
		int num2 = 0;
		int num3 = 0;
		ReadOnlySpan<char> span;
		for (int i = 0; i < length; i++)
		{
			span = this.AsSpan(num2, sepList[i] - num2);
			if ((options & StringSplitOptions.TrimEntries) != 0)
			{
				span = span.Trim();
			}
			if (!span.IsEmpty || (options & StringSplitOptions.RemoveEmptyEntries) == 0)
			{
				array[num3++] = span.ToString();
			}
			num2 = sepList[i] + (lengthList.IsEmpty ? defaultLength : lengthList[i]);
			if (num3 != count - 1)
			{
				continue;
			}
			if ((options & StringSplitOptions.RemoveEmptyEntries) == 0)
			{
				break;
			}
			while (++i < length)
			{
				span = this.AsSpan(num2, sepList[i] - num2);
				if ((options & StringSplitOptions.TrimEntries) != 0)
				{
					span = span.Trim();
				}
				if (!span.IsEmpty)
				{
					break;
				}
				num2 = sepList[i] + (lengthList.IsEmpty ? defaultLength : lengthList[i]);
			}
			break;
		}
		span = this.AsSpan(num2);
		if ((options & StringSplitOptions.TrimEntries) != 0)
		{
			span = span.Trim();
		}
		if (!span.IsEmpty || (options & StringSplitOptions.RemoveEmptyEntries) == 0)
		{
			array[num3++] = span.ToString();
		}
		Array.Resize(ref array, num3);
		return array;
	}

	internal static void MakeSeparatorListAny(ReadOnlySpan<char> source, ReadOnlySpan<char> separators, ref ValueListBuilder<int> sepListBuilder)
	{
		if (separators.Length == 0)
		{
			for (int i = 0; i < source.Length; i++)
			{
				if (char.IsWhiteSpace(source[i]))
				{
					sepListBuilder.Append(i);
				}
			}
			return;
		}
		if (separators.Length <= 3)
		{
			char c = separators[0];
			char c2 = ((separators.Length > 1) ? separators[1] : c);
			char c3 = ((separators.Length > 2) ? separators[2] : c2);
			if (Vector128.IsHardwareAccelerated && source.Length >= Vector128<ushort>.Count * 2)
			{
				MakeSeparatorListVectorized(source, ref sepListBuilder, c, c2, c3);
				return;
			}
			for (int j = 0; j < source.Length; j++)
			{
				char c4 = source[j];
				if (c4 == c || c4 == c2 || c4 == c3)
				{
					sepListBuilder.Append(j);
				}
			}
			return;
		}
		ProbabilisticMap source2 = new ProbabilisticMap(separators);
		ref uint charMap = ref Unsafe.As<ProbabilisticMap, uint>(ref source2);
		for (int k = 0; k < source.Length; k++)
		{
			if (ProbabilisticMap.Contains(ref charMap, separators, source[k]))
			{
				sepListBuilder.Append(k);
			}
		}
	}

	private static void MakeSeparatorListVectorized(ReadOnlySpan<char> sourceSpan, ref ValueListBuilder<int> sepListBuilder, char c, char c2, char c3)
	{
		if (!Vector128.IsHardwareAccelerated)
		{
			throw new PlatformNotSupportedException();
		}
		nuint num = 0u;
		nuint num2 = (uint)sourceSpan.Length;
		ref char reference = ref MemoryMarshal.GetReference(sourceSpan);
		Vector128<ushort> right = Vector128.Create((ushort)c);
		Vector128<ushort> right2 = Vector128.Create((ushort)c2);
		Vector128<ushort> right3 = Vector128.Create((ushort)c3);
		do
		{
			Vector128<ushort> left = Vector128.LoadUnsafe(ref reference, num);
			Vector128<ushort> vector = Vector128.Equals(left, right);
			Vector128<ushort> vector2 = Vector128.Equals(left, right2);
			Vector128<ushort> vector3 = Vector128.Equals(left, right3);
			Vector128<byte> vector4 = (vector | vector2 | vector3).AsByte();
			if (vector4 != Vector128<byte>.Zero)
			{
				uint num3 = vector4.ExtractMostSignificantBits() & 0x5555u;
				do
				{
					uint num4 = (uint)BitOperations.TrailingZeroCount(num3) / 2u;
					sepListBuilder.Append((int)(num + num4));
					num3 = BitOperations.ResetLowestSetBit(num3);
				}
				while (num3 != 0);
			}
			num += (nuint)Vector128<ushort>.Count;
		}
		while (num <= (nuint)((nint)num2 - (nint)Vector128<ushort>.Count));
		for (; num < num2; num++)
		{
			char c4 = Unsafe.Add(ref reference, num);
			if (c4 == c || c4 == c2 || c4 == c3)
			{
				sepListBuilder.Append((int)num);
			}
		}
	}

	internal static void MakeSeparatorList(ReadOnlySpan<char> source, ReadOnlySpan<char> separator, ref ValueListBuilder<int> sepListBuilder)
	{
		int num = 0;
		while (!source.IsEmpty)
		{
			int num2 = source.IndexOf(separator);
			if (num2 >= 0)
			{
				num += num2;
				sepListBuilder.Append(num);
				num += separator.Length;
				source = source.Slice(num2 + separator.Length);
				continue;
			}
			break;
		}
	}

	internal static void MakeSeparatorListAny(ReadOnlySpan<char> source, ReadOnlySpan<string> separators, ref ValueListBuilder<int> sepListBuilder, ref ValueListBuilder<int> lengthListBuilder)
	{
		for (int i = 0; i < source.Length; i++)
		{
			for (int j = 0; j < separators.Length; j++)
			{
				string text = separators[j];
				if (!IsNullOrEmpty(text))
				{
					int length = text.Length;
					if (source[i] == text[0] && length <= source.Length - i && (length == 1 || source.Slice(i, length).SequenceEqual(text)))
					{
						sepListBuilder.Append(i);
						lengthListBuilder.Append(length);
						i += length - 1;
						break;
					}
				}
			}
		}
	}

	internal static void CheckStringSplitOptions(StringSplitOptions options)
	{
		if (((uint)options & 0xFFFFFFFCu) != 0)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidFlag, ExceptionArgument.options);
		}
	}

	public string Substring(int startIndex)
	{
		if (startIndex == 0)
		{
			return this;
		}
		int num = Length - startIndex;
		if (num == 0)
		{
			return Empty;
		}
		if ((uint)startIndex > (uint)Length)
		{
			ThrowSubstringArgumentOutOfRange(startIndex, num);
		}
		return InternalSubString(startIndex, num);
	}

	public string Substring(int startIndex, int length)
	{
		if ((ulong)((long)(uint)startIndex + (long)(uint)length) > (ulong)(uint)Length)
		{
			ThrowSubstringArgumentOutOfRange(startIndex, length);
		}
		if (length == 0)
		{
			return Empty;
		}
		if (length == Length)
		{
			return this;
		}
		return InternalSubString(startIndex, length);
	}

	[DoesNotReturn]
	private void ThrowSubstringArgumentOutOfRange(int startIndex, int length)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(startIndex, "startIndex");
		if (startIndex > Length)
		{
			throw new ArgumentOutOfRangeException("startIndex", SR.ArgumentOutOfRange_StartIndexLargerThanLength);
		}
		ArgumentOutOfRangeException.ThrowIfNegative(length, "length");
		throw new ArgumentOutOfRangeException("length", SR.ArgumentOutOfRange_IndexLength);
	}

	private string InternalSubString(int startIndex, int length)
	{
		string text = FastAllocateString(length);
		nuint elementCount = (uint)length;
		Buffer.Memmove(ref text._firstChar, ref Unsafe.Add(ref _firstChar, (nint)(uint)startIndex), elementCount);
		return text;
	}

	public string ToLower()
	{
		return ToLower(null);
	}

	public string ToLower(CultureInfo? culture)
	{
		CultureInfo cultureInfo = culture ?? CultureInfo.CurrentCulture;
		return cultureInfo.TextInfo.ToLower(this);
	}

	public string ToLowerInvariant()
	{
		return TextInfo.Invariant.ToLower(this);
	}

	public string ToUpper()
	{
		return ToUpper(null);
	}

	public string ToUpper(CultureInfo? culture)
	{
		CultureInfo cultureInfo = culture ?? CultureInfo.CurrentCulture;
		return cultureInfo.TextInfo.ToUpper(this);
	}

	public string ToUpperInvariant()
	{
		return TextInfo.Invariant.ToUpper(this);
	}

	public string Trim()
	{
		if (Length != 0)
		{
			if (!char.IsWhiteSpace(_firstChar))
			{
				if (!char.IsWhiteSpace(this[Length - 1]))
				{
					goto IL_002a;
				}
			}
			return TrimWhiteSpaceHelper(TrimType.Both);
		}
		goto IL_002a;
		IL_002a:
		return this;
	}

	public unsafe string Trim(char trimChar)
	{
		if (Length != 0)
		{
			if (_firstChar != trimChar)
			{
				if (this[Length - 1] != trimChar)
				{
					goto IL_0022;
				}
			}
			return TrimHelper(&trimChar, 1, TrimType.Both);
		}
		goto IL_0022;
		IL_0022:
		return this;
	}

	public unsafe string Trim(params char[]? trimChars)
	{
		if (trimChars == null || trimChars.Length == 0)
		{
			return TrimWhiteSpaceHelper(TrimType.Both);
		}
		fixed (char* trimChars2 = &trimChars[0])
		{
			return TrimHelper(trimChars2, trimChars.Length, TrimType.Both);
		}
	}

	public string TrimStart()
	{
		return TrimWhiteSpaceHelper(TrimType.Head);
	}

	public unsafe string TrimStart(char trimChar)
	{
		return TrimHelper(&trimChar, 1, TrimType.Head);
	}

	public unsafe string TrimStart(params char[]? trimChars)
	{
		if (trimChars == null || trimChars.Length == 0)
		{
			return TrimWhiteSpaceHelper(TrimType.Head);
		}
		fixed (char* trimChars2 = &trimChars[0])
		{
			return TrimHelper(trimChars2, trimChars.Length, TrimType.Head);
		}
	}

	public string TrimEnd()
	{
		return TrimWhiteSpaceHelper(TrimType.Tail);
	}

	public unsafe string TrimEnd(char trimChar)
	{
		return TrimHelper(&trimChar, 1, TrimType.Tail);
	}

	public unsafe string TrimEnd(params char[]? trimChars)
	{
		if (trimChars == null || trimChars.Length == 0)
		{
			return TrimWhiteSpaceHelper(TrimType.Tail);
		}
		fixed (char* trimChars2 = &trimChars[0])
		{
			return TrimHelper(trimChars2, trimChars.Length, TrimType.Tail);
		}
	}

	private string TrimWhiteSpaceHelper(TrimType trimType)
	{
		int num = Length - 1;
		int i = 0;
		if ((trimType & TrimType.Head) != 0)
		{
			for (i = 0; i < Length && char.IsWhiteSpace(this[i]); i++)
			{
			}
		}
		if ((trimType & TrimType.Tail) != 0)
		{
			num = Length - 1;
			while (num >= i && char.IsWhiteSpace(this[num]))
			{
				num--;
			}
		}
		return CreateTrimmedString(i, num);
	}

	private unsafe string TrimHelper(char* trimChars, int trimCharsLength, TrimType trimType)
	{
		int num = Length - 1;
		int i = 0;
		if ((trimType & TrimType.Head) != 0)
		{
			for (i = 0; i < Length; i++)
			{
				int num2 = 0;
				char c = this[i];
				for (num2 = 0; num2 < trimCharsLength && trimChars[num2] != c; num2++)
				{
				}
				if (num2 == trimCharsLength)
				{
					break;
				}
			}
		}
		if ((trimType & TrimType.Tail) != 0)
		{
			for (num = Length - 1; num >= i; num--)
			{
				int num3 = 0;
				char c2 = this[num];
				for (num3 = 0; num3 < trimCharsLength && trimChars[num3] != c2; num3++)
				{
				}
				if (num3 == trimCharsLength)
				{
					break;
				}
			}
		}
		return CreateTrimmedString(i, num);
	}

	private string CreateTrimmedString(int start, int end)
	{
		int num = end - start + 1;
		if (num != Length)
		{
			if (num != 0)
			{
				return InternalSubString(start, num);
			}
			return Empty;
		}
		return this;
	}

	public bool Contains(string value)
	{
		if ((object)value == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		return SpanHelpers.IndexOf(ref _firstChar, Length, ref value._firstChar, value.Length) >= 0;
	}

	public bool Contains(string value, StringComparison comparisonType)
	{
		return IndexOf(value, comparisonType) >= 0;
	}

	public bool Contains(char value)
	{
		return SpanHelpers.ContainsValueType(ref Unsafe.As<char, short>(ref _firstChar), (short)value, Length);
	}

	public bool Contains(char value, StringComparison comparisonType)
	{
		return IndexOf(value, comparisonType) != -1;
	}

	public int IndexOf(char value)
	{
		return SpanHelpers.IndexOfChar(ref _firstChar, value, Length);
	}

	public int IndexOf(char value, int startIndex)
	{
		return IndexOf(value, startIndex, Length - startIndex);
	}

	public int IndexOf(char value, StringComparison comparisonType)
	{
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.IndexOf(this, value, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.Ordinal:
			return IndexOf(value);
		case StringComparison.OrdinalIgnoreCase:
			return IndexOfCharOrdinalIgnoreCase(value);
		default:
			throw new ArgumentException(SR.NotSupported_StringComparison, "comparisonType");
		}
	}

	private int IndexOfCharOrdinalIgnoreCase(char value)
	{
		if (!char.IsAscii(value))
		{
			return Ordinal.IndexOfOrdinalIgnoreCase(this, new ReadOnlySpan<char>(ref value));
		}
		if (char.IsAsciiLetter(value))
		{
			char value2 = (char)(value | 0x20u);
			char value3 = (char)(value & 0xFFFFFFDFu);
			if (!PackedSpanHelpers.PackedIndexOfIsSupported)
			{
				return SpanHelpers.IndexOfAnyChar(ref _firstChar, value3, value2, Length);
			}
			return PackedSpanHelpers.IndexOfAny(ref _firstChar, value3, value2, Length);
		}
		return SpanHelpers.IndexOfChar(ref _firstChar, value, Length);
	}

	public int IndexOf(char value, int startIndex, int count)
	{
		if ((uint)startIndex > (uint)Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLessOrEqual);
		}
		if ((uint)count > (uint)(Length - startIndex))
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
		}
		int num = SpanHelpers.IndexOfChar(ref Unsafe.Add(ref _firstChar, startIndex), value, count);
		if (num >= 0)
		{
			return num + startIndex;
		}
		return num;
	}

	public int IndexOfAny(char[] anyOf)
	{
		if (anyOf == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.anyOf);
		}
		return new ReadOnlySpan<char>(ref _firstChar, Length).IndexOfAny(anyOf);
	}

	public int IndexOfAny(char[] anyOf, int startIndex)
	{
		return IndexOfAny(anyOf, startIndex, Length - startIndex);
	}

	public int IndexOfAny(char[] anyOf, int startIndex, int count)
	{
		if (anyOf == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.anyOf);
		}
		if ((uint)startIndex > (uint)Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLessOrEqual);
		}
		if ((uint)count > (uint)(Length - startIndex))
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
		}
		int num = new ReadOnlySpan<char>(ref Unsafe.Add(ref _firstChar, startIndex), count).IndexOfAny(anyOf);
		if (num >= 0)
		{
			return num + startIndex;
		}
		return num;
	}

	public int IndexOf(string value)
	{
		return IndexOf(value, StringComparison.CurrentCulture);
	}

	public int IndexOf(string value, int startIndex)
	{
		return IndexOf(value, startIndex, StringComparison.CurrentCulture);
	}

	public int IndexOf(string value, int startIndex, int count)
	{
		return IndexOf(value, startIndex, count, StringComparison.CurrentCulture);
	}

	public int IndexOf(string value, StringComparison comparisonType)
	{
		return IndexOf(value, 0, Length, comparisonType);
	}

	public int IndexOf(string value, int startIndex, StringComparison comparisonType)
	{
		return IndexOf(value, startIndex, Length - startIndex, comparisonType);
	}

	public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType)
	{
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.IndexOf(this, value, startIndex, count, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.Ordinal:
		case StringComparison.OrdinalIgnoreCase:
			return Ordinal.IndexOf(this, value, startIndex, count, comparisonType == StringComparison.OrdinalIgnoreCase);
		default:
			throw ((object)value == null) ? new ArgumentNullException("value") : new ArgumentException(SR.NotSupported_StringComparison, "comparisonType");
		}
	}

	public int LastIndexOf(char value)
	{
		return SpanHelpers.LastIndexOfValueType(ref Unsafe.As<char, short>(ref _firstChar), (short)value, Length);
	}

	public int LastIndexOf(char value, int startIndex)
	{
		return LastIndexOf(value, startIndex, startIndex + 1);
	}

	public int LastIndexOf(char value, int startIndex, int count)
	{
		if (Length == 0)
		{
			return -1;
		}
		if ((uint)startIndex >= (uint)Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLess);
		}
		if ((uint)count > (uint)(startIndex + 1))
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
		}
		int num = startIndex + 1 - count;
		int num2 = SpanHelpers.LastIndexOfValueType(ref Unsafe.As<char, short>(ref Unsafe.Add(ref _firstChar, num)), (short)value, count);
		if (num2 >= 0)
		{
			return num2 + num;
		}
		return num2;
	}

	public int LastIndexOfAny(char[] anyOf)
	{
		if (anyOf == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.anyOf);
		}
		return new ReadOnlySpan<char>(ref _firstChar, Length).LastIndexOfAny(anyOf);
	}

	public int LastIndexOfAny(char[] anyOf, int startIndex)
	{
		return LastIndexOfAny(anyOf, startIndex, startIndex + 1);
	}

	public int LastIndexOfAny(char[] anyOf, int startIndex, int count)
	{
		if (anyOf == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.anyOf);
		}
		if (Length == 0)
		{
			return -1;
		}
		if ((uint)startIndex >= (uint)Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLess);
		}
		if (count < 0 || count - 1 > startIndex)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
		}
		int num = startIndex + 1 - count;
		int num2 = new ReadOnlySpan<char>(ref Unsafe.Add(ref _firstChar, num), count).LastIndexOfAny(anyOf);
		if (num2 >= 0)
		{
			return num2 + num;
		}
		return num2;
	}

	public int LastIndexOf(string value)
	{
		return LastIndexOf(value, Length - 1, Length, StringComparison.CurrentCulture);
	}

	public int LastIndexOf(string value, int startIndex)
	{
		return LastIndexOf(value, startIndex, startIndex + 1, StringComparison.CurrentCulture);
	}

	public int LastIndexOf(string value, int startIndex, int count)
	{
		return LastIndexOf(value, startIndex, count, StringComparison.CurrentCulture);
	}

	public int LastIndexOf(string value, StringComparison comparisonType)
	{
		return LastIndexOf(value, Length - 1, Length, comparisonType);
	}

	public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
	{
		return LastIndexOf(value, startIndex, startIndex + 1, comparisonType);
	}

	public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
	{
		switch (comparisonType)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.LastIndexOf(this, value, startIndex, count, GetCaseCompareOfComparisonCulture(comparisonType));
		case StringComparison.Ordinal:
		case StringComparison.OrdinalIgnoreCase:
			return CompareInfo.Invariant.LastIndexOf(this, value, startIndex, count, GetCompareOptionsFromOrdinalStringComparison(comparisonType));
		default:
			throw ((object)value == null) ? new ArgumentNullException("value") : new ArgumentException(SR.NotSupported_StringComparison, "comparisonType");
		}
	}
}
