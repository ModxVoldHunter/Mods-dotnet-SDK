using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.Arm;

[CLSCompliant(false)]
public abstract class AdvSimd : ArmBase
{
	public new abstract class Arm64 : ArmBase.Arm64
	{
		public new static bool IsSupported
		{
			[Intrinsic]
			get
			{
				return false;
			}
		}

		public static Vector128<double> Abs(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> Abs(Vector128<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> AbsSaturate(Vector128<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> AbsSaturateScalar(Vector64<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> AbsSaturateScalar(Vector64<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> AbsSaturateScalar(Vector64<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> AbsSaturateScalar(Vector64<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> AbsScalar(Vector64<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> AbsoluteCompareGreaterThan(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> AbsoluteCompareGreaterThanScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> AbsoluteCompareGreaterThanScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> AbsoluteCompareGreaterThanOrEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> AbsoluteCompareGreaterThanOrEqualScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> AbsoluteCompareGreaterThanOrEqualScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> AbsoluteCompareLessThan(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> AbsoluteCompareLessThanScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> AbsoluteCompareLessThanScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> AbsoluteCompareLessThanOrEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> AbsoluteCompareLessThanOrEqualScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> AbsoluteCompareLessThanOrEqualScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> AbsoluteDifference(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> AbsoluteDifferenceScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> AbsoluteDifferenceScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Add(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> AddAcross(Vector64<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> AddAcross(Vector64<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> AddAcross(Vector64<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> AddAcross(Vector64<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> AddAcross(Vector128<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> AddAcross(Vector128<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> AddAcross(Vector128<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> AddAcross(Vector128<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> AddAcross(Vector128<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> AddAcross(Vector128<uint> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> AddAcrossWidening(Vector64<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> AddAcrossWidening(Vector64<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> AddAcrossWidening(Vector64<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> AddAcrossWidening(Vector64<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> AddAcrossWidening(Vector128<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> AddAcrossWidening(Vector128<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> AddAcrossWidening(Vector128<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> AddAcrossWidening(Vector128<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> AddAcrossWidening(Vector128<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> AddAcrossWidening(Vector128<uint> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> AddPairwise(Vector128<byte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> AddPairwise(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> AddPairwise(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> AddPairwise(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> AddPairwise(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> AddPairwise(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> AddPairwise(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> AddPairwise(Vector128<ushort> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> AddPairwise(Vector128<uint> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> AddPairwise(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> AddPairwiseScalar(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> AddPairwiseScalar(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> AddPairwiseScalar(Vector128<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> AddPairwiseScalar(Vector128<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> AddSaturate(Vector64<byte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> AddSaturate(Vector64<short> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> AddSaturate(Vector64<int> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> AddSaturate(Vector64<sbyte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> AddSaturate(Vector64<ushort> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> AddSaturate(Vector64<uint> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> AddSaturate(Vector128<byte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> AddSaturate(Vector128<short> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> AddSaturate(Vector128<int> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> AddSaturate(Vector128<long> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> AddSaturate(Vector128<sbyte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> AddSaturate(Vector128<ushort> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> AddSaturate(Vector128<uint> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> AddSaturate(Vector128<ulong> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> AddSaturateScalar(Vector64<byte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> AddSaturateScalar(Vector64<byte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> AddSaturateScalar(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> AddSaturateScalar(Vector64<short> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> AddSaturateScalar(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> AddSaturateScalar(Vector64<int> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> AddSaturateScalar(Vector64<long> left, Vector64<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> AddSaturateScalar(Vector64<sbyte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> AddSaturateScalar(Vector64<sbyte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> AddSaturateScalar(Vector64<ushort> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> AddSaturateScalar(Vector64<ushort> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> AddSaturateScalar(Vector64<uint> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> AddSaturateScalar(Vector64<uint> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> AddSaturateScalar(Vector64<ulong> left, Vector64<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Ceiling(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> CompareEqual(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> CompareEqual(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> CompareEqualScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> CompareEqualScalar(Vector64<long> left, Vector64<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> CompareEqualScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> CompareEqualScalar(Vector64<ulong> left, Vector64<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareGreaterThan(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> CompareGreaterThan(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> CompareGreaterThan(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> CompareGreaterThanScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> CompareGreaterThanScalar(Vector64<long> left, Vector64<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> CompareGreaterThanScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> CompareGreaterThanScalar(Vector64<ulong> left, Vector64<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareGreaterThanOrEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> CompareGreaterThanOrEqual(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> CompareGreaterThanOrEqual(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> CompareGreaterThanOrEqualScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> CompareGreaterThanOrEqualScalar(Vector64<long> left, Vector64<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> CompareGreaterThanOrEqualScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> CompareGreaterThanOrEqualScalar(Vector64<ulong> left, Vector64<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareLessThan(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> CompareLessThan(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> CompareLessThan(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> CompareLessThanScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> CompareLessThanScalar(Vector64<long> left, Vector64<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> CompareLessThanScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> CompareLessThanScalar(Vector64<ulong> left, Vector64<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareLessThanOrEqual(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> CompareLessThanOrEqual(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> CompareLessThanOrEqual(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> CompareLessThanOrEqualScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> CompareLessThanOrEqualScalar(Vector64<long> left, Vector64<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> CompareLessThanOrEqualScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> CompareLessThanOrEqualScalar(Vector64<ulong> left, Vector64<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> CompareTest(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> CompareTest(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> CompareTest(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> CompareTestScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> CompareTestScalar(Vector64<long> left, Vector64<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> CompareTestScalar(Vector64<ulong> left, Vector64<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ConvertToDouble(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ConvertToDouble(Vector128<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ConvertToDouble(Vector128<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> ConvertToDoubleScalar(Vector64<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> ConvertToDoubleScalar(Vector64<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ConvertToDoubleUpper(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ConvertToInt64RoundAwayFromZero(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> ConvertToInt64RoundAwayFromZeroScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ConvertToInt64RoundToEven(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> ConvertToInt64RoundToEvenScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ConvertToInt64RoundToNegativeInfinity(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> ConvertToInt64RoundToNegativeInfinityScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ConvertToInt64RoundToPositiveInfinity(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> ConvertToInt64RoundToPositiveInfinityScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ConvertToInt64RoundToZero(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> ConvertToInt64RoundToZeroScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> ConvertToSingleLower(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> ConvertToSingleRoundToOddLower(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> ConvertToSingleRoundToOddUpper(Vector64<float> lower, Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> ConvertToSingleUpper(Vector64<float> lower, Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> ConvertToUInt64RoundAwayFromZero(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> ConvertToUInt64RoundAwayFromZeroScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> ConvertToUInt64RoundToEven(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> ConvertToUInt64RoundToEvenScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> ConvertToUInt64RoundToNegativeInfinity(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> ConvertToUInt64RoundToNegativeInfinityScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> ConvertToUInt64RoundToPositiveInfinity(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> ConvertToUInt64RoundToPositiveInfinityScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> ConvertToUInt64RoundToZero(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ulong> ConvertToUInt64RoundToZeroScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> Divide(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Divide(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> Divide(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> DuplicateSelectedScalarToVector128(Vector128<double> value, [ConstantExpected(Max = 1)] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> DuplicateSelectedScalarToVector128(Vector128<long> value, [ConstantExpected(Max = 1)] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> DuplicateSelectedScalarToVector128(Vector128<ulong> value, [ConstantExpected(Max = 1)] byte index)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> DuplicateToVector128(double value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> DuplicateToVector128(long value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> DuplicateToVector128(ulong value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ExtractNarrowingSaturateScalar(Vector64<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ExtractNarrowingSaturateScalar(Vector64<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ExtractNarrowingSaturateScalar(Vector64<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ExtractNarrowingSaturateScalar(Vector64<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ExtractNarrowingSaturateScalar(Vector64<uint> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ExtractNarrowingSaturateScalar(Vector64<ulong> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ExtractNarrowingSaturateUnsignedScalar(Vector64<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ExtractNarrowingSaturateUnsignedScalar(Vector64<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ExtractNarrowingSaturateUnsignedScalar(Vector64<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Floor(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> FusedMultiplyAdd(Vector128<double> addend, Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplyAddByScalar(Vector64<float> addend, Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> FusedMultiplyAddByScalar(Vector128<double> addend, Vector128<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> FusedMultiplyAddByScalar(Vector128<float> addend, Vector128<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplyAddBySelectedScalar(Vector64<float> addend, Vector64<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplyAddBySelectedScalar(Vector64<float> addend, Vector64<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> FusedMultiplyAddBySelectedScalar(Vector128<double> addend, Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> FusedMultiplyAddBySelectedScalar(Vector128<float> addend, Vector128<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> FusedMultiplyAddBySelectedScalar(Vector128<float> addend, Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> FusedMultiplyAddScalarBySelectedScalar(Vector64<double> addend, Vector64<double> left, Vector128<double> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplyAddScalarBySelectedScalar(Vector64<float> addend, Vector64<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplyAddScalarBySelectedScalar(Vector64<float> addend, Vector64<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> FusedMultiplySubtract(Vector128<double> minuend, Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplySubtractByScalar(Vector64<float> minuend, Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> FusedMultiplySubtractByScalar(Vector128<double> minuend, Vector128<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> FusedMultiplySubtractByScalar(Vector128<float> minuend, Vector128<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplySubtractBySelectedScalar(Vector64<float> minuend, Vector64<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplySubtractBySelectedScalar(Vector64<float> minuend, Vector64<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> FusedMultiplySubtractBySelectedScalar(Vector128<double> minuend, Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> FusedMultiplySubtractBySelectedScalar(Vector128<float> minuend, Vector128<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> FusedMultiplySubtractBySelectedScalar(Vector128<float> minuend, Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> FusedMultiplySubtractScalarBySelectedScalar(Vector64<double> minuend, Vector64<double> left, Vector128<double> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplySubtractScalarBySelectedScalar(Vector64<float> minuend, Vector64<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> FusedMultiplySubtractScalarBySelectedScalar(Vector64<float> minuend, Vector64<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> InsertSelectedScalar(Vector64<byte> result, [ConstantExpected(Max = 7)] byte resultIndex, Vector64<byte> value, [ConstantExpected(Max = 7)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> InsertSelectedScalar(Vector64<byte> result, [ConstantExpected(Max = 7)] byte resultIndex, Vector128<byte> value, [ConstantExpected(Max = 15)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> InsertSelectedScalar(Vector64<short> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector64<short> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> InsertSelectedScalar(Vector64<short> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector128<short> value, [ConstantExpected(Max = 7)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> InsertSelectedScalar(Vector64<int> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector64<int> value, [ConstantExpected(Max = 1)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> InsertSelectedScalar(Vector64<int> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector128<int> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> InsertSelectedScalar(Vector64<sbyte> result, [ConstantExpected(Max = 7)] byte resultIndex, Vector64<sbyte> value, [ConstantExpected(Max = 7)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> InsertSelectedScalar(Vector64<sbyte> result, [ConstantExpected(Max = 7)] byte resultIndex, Vector128<sbyte> value, [ConstantExpected(Max = 15)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> InsertSelectedScalar(Vector64<float> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector64<float> value, [ConstantExpected(Max = 1)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> InsertSelectedScalar(Vector64<float> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector128<float> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> InsertSelectedScalar(Vector64<ushort> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector64<ushort> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> InsertSelectedScalar(Vector64<ushort> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector128<ushort> value, [ConstantExpected(Max = 7)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> InsertSelectedScalar(Vector64<uint> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector64<uint> value, [ConstantExpected(Max = 1)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> InsertSelectedScalar(Vector64<uint> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector128<uint> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> InsertSelectedScalar(Vector128<byte> result, [ConstantExpected(Max = 15)] byte resultIndex, Vector64<byte> value, [ConstantExpected(Max = 7)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> InsertSelectedScalar(Vector128<byte> result, [ConstantExpected(Max = 15)] byte resultIndex, Vector128<byte> value, [ConstantExpected(Max = 15)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> InsertSelectedScalar(Vector128<double> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector128<double> value, [ConstantExpected(Max = 1)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> InsertSelectedScalar(Vector128<short> result, [ConstantExpected(Max = 7)] byte resultIndex, Vector64<short> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> InsertSelectedScalar(Vector128<short> result, [ConstantExpected(Max = 7)] byte resultIndex, Vector128<short> value, [ConstantExpected(Max = 7)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> InsertSelectedScalar(Vector128<int> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector64<int> value, [ConstantExpected(Max = 1)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> InsertSelectedScalar(Vector128<int> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector128<int> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> InsertSelectedScalar(Vector128<long> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector128<long> value, [ConstantExpected(Max = 1)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> InsertSelectedScalar(Vector128<sbyte> result, [ConstantExpected(Max = 15)] byte resultIndex, Vector64<sbyte> value, [ConstantExpected(Max = 7)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> InsertSelectedScalar(Vector128<sbyte> result, [ConstantExpected(Max = 15)] byte resultIndex, Vector128<sbyte> value, [ConstantExpected(Max = 15)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> InsertSelectedScalar(Vector128<float> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector64<float> value, [ConstantExpected(Max = 1)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> InsertSelectedScalar(Vector128<float> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector128<float> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> InsertSelectedScalar(Vector128<ushort> result, [ConstantExpected(Max = 7)] byte resultIndex, Vector64<ushort> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> InsertSelectedScalar(Vector128<ushort> result, [ConstantExpected(Max = 7)] byte resultIndex, Vector128<ushort> value, [ConstantExpected(Max = 7)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> InsertSelectedScalar(Vector128<uint> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector64<uint> value, [ConstantExpected(Max = 1)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> InsertSelectedScalar(Vector128<uint> result, [ConstantExpected(Max = 3)] byte resultIndex, Vector128<uint> value, [ConstantExpected(Max = 3)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> InsertSelectedScalar(Vector128<ulong> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector128<ulong> value, [ConstantExpected(Max = 1)] byte valueIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector128<double> LoadAndReplicateToVector128(double* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector128<long> LoadAndReplicateToVector128(long* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static Vector128<ulong> LoadAndReplicateToVector128(ulong* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<byte> Value1, Vector64<byte> Value2) LoadPairVector64(byte* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<double> Value1, Vector64<double> Value2) LoadPairVector64(double* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<short> Value1, Vector64<short> Value2) LoadPairVector64(short* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<int> Value1, Vector64<int> Value2) LoadPairVector64(int* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<long> Value1, Vector64<long> Value2) LoadPairVector64(long* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<sbyte> Value1, Vector64<sbyte> Value2) LoadPairVector64(sbyte* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<float> Value1, Vector64<float> Value2) LoadPairVector64(float* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<ushort> Value1, Vector64<ushort> Value2) LoadPairVector64(ushort* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<uint> Value1, Vector64<uint> Value2) LoadPairVector64(uint* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<ulong> Value1, Vector64<ulong> Value2) LoadPairVector64(ulong* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<int> Value1, Vector64<int> Value2) LoadPairScalarVector64(int* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<float> Value1, Vector64<float> Value2) LoadPairScalarVector64(float* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<uint> Value1, Vector64<uint> Value2) LoadPairScalarVector64(uint* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<byte> Value1, Vector128<byte> Value2) LoadPairVector128(byte* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<double> Value1, Vector128<double> Value2) LoadPairVector128(double* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<short> Value1, Vector128<short> Value2) LoadPairVector128(short* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<int> Value1, Vector128<int> Value2) LoadPairVector128(int* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<long> Value1, Vector128<long> Value2) LoadPairVector128(long* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<sbyte> Value1, Vector128<sbyte> Value2) LoadPairVector128(sbyte* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<float> Value1, Vector128<float> Value2) LoadPairVector128(float* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<ushort> Value1, Vector128<ushort> Value2) LoadPairVector128(ushort* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<uint> Value1, Vector128<uint> Value2) LoadPairVector128(uint* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<ulong> Value1, Vector128<ulong> Value2) LoadPairVector128(ulong* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<byte> Value1, Vector64<byte> Value2) LoadPairVector64NonTemporal(byte* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<double> Value1, Vector64<double> Value2) LoadPairVector64NonTemporal(double* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<short> Value1, Vector64<short> Value2) LoadPairVector64NonTemporal(short* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<int> Value1, Vector64<int> Value2) LoadPairVector64NonTemporal(int* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<long> Value1, Vector64<long> Value2) LoadPairVector64NonTemporal(long* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<sbyte> Value1, Vector64<sbyte> Value2) LoadPairVector64NonTemporal(sbyte* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<float> Value1, Vector64<float> Value2) LoadPairVector64NonTemporal(float* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<ushort> Value1, Vector64<ushort> Value2) LoadPairVector64NonTemporal(ushort* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<uint> Value1, Vector64<uint> Value2) LoadPairVector64NonTemporal(uint* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<ulong> Value1, Vector64<ulong> Value2) LoadPairVector64NonTemporal(ulong* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<int> Value1, Vector64<int> Value2) LoadPairScalarVector64NonTemporal(int* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<float> Value1, Vector64<float> Value2) LoadPairScalarVector64NonTemporal(float* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector64<uint> Value1, Vector64<uint> Value2) LoadPairScalarVector64NonTemporal(uint* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<byte> Value1, Vector128<byte> Value2) LoadPairVector128NonTemporal(byte* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<double> Value1, Vector128<double> Value2) LoadPairVector128NonTemporal(double* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<short> Value1, Vector128<short> Value2) LoadPairVector128NonTemporal(short* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<int> Value1, Vector128<int> Value2) LoadPairVector128NonTemporal(int* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<long> Value1, Vector128<long> Value2) LoadPairVector128NonTemporal(long* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<sbyte> Value1, Vector128<sbyte> Value2) LoadPairVector128NonTemporal(sbyte* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<float> Value1, Vector128<float> Value2) LoadPairVector128NonTemporal(float* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<ushort> Value1, Vector128<ushort> Value2) LoadPairVector128NonTemporal(ushort* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<uint> Value1, Vector128<uint> Value2) LoadPairVector128NonTemporal(uint* address)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static (Vector128<ulong> Value1, Vector128<ulong> Value2) LoadPairVector128NonTemporal(ulong* address)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Max(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> MaxAcross(Vector64<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MaxAcross(Vector64<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> MaxAcross(Vector64<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> MaxAcross(Vector64<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> MaxAcross(Vector128<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MaxAcross(Vector128<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MaxAcross(Vector128<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> MaxAcross(Vector128<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MaxAcross(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> MaxAcross(Vector128<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> MaxAcross(Vector128<uint> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MaxNumber(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MaxNumberAcross(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MaxNumberPairwise(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MaxNumberPairwise(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> MaxNumberPairwise(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MaxNumberPairwiseScalar(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> MaxNumberPairwiseScalar(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> MaxPairwise(Vector128<byte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MaxPairwise(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> MaxPairwise(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> MaxPairwise(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> MaxPairwise(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> MaxPairwise(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> MaxPairwise(Vector128<ushort> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> MaxPairwise(Vector128<uint> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MaxPairwiseScalar(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> MaxPairwiseScalar(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> MaxScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MaxScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Min(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> MinAcross(Vector64<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MinAcross(Vector64<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> MinAcross(Vector64<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> MinAcross(Vector64<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> MinAcross(Vector128<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MinAcross(Vector128<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MinAcross(Vector128<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> MinAcross(Vector128<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MinAcross(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> MinAcross(Vector128<ushort> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> MinAcross(Vector128<uint> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MinNumber(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MinNumberAcross(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MinNumberPairwise(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MinNumberPairwise(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> MinNumberPairwise(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MinNumberPairwiseScalar(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> MinNumberPairwiseScalar(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> MinPairwise(Vector128<byte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MinPairwise(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> MinPairwise(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> MinPairwise(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> MinPairwise(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> MinPairwise(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> MinPairwise(Vector128<ushort> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> MinPairwise(Vector128<uint> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MinPairwiseScalar(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> MinPairwiseScalar(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> MinScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MinScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Multiply(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MultiplyByScalar(Vector128<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MultiplyBySelectedScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MultiplyDoublingSaturateHighScalar(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingSaturateHighScalar(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingWideningAndAddSaturateScalar(Vector64<int> addend, Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> MultiplyDoublingWideningAndAddSaturateScalar(Vector64<long> addend, Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64<int> minuend, Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64<long> minuend, Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingWideningSaturateScalar(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> MultiplyDoublingWideningSaturateScalar(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<int> addend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<int> addend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<long> addend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<long> addend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<int> minuend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<int> minuend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<long> minuend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<long> minuend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MultiplyExtended(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MultiplyExtended(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> MultiplyExtended(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MultiplyExtendedByScalar(Vector128<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MultiplyExtendedBySelectedScalar(Vector64<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MultiplyExtendedBySelectedScalar(Vector64<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> MultiplyExtendedBySelectedScalar(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> MultiplyExtendedBySelectedScalar(Vector128<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> MultiplyExtendedBySelectedScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> MultiplyExtendedScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MultiplyExtendedScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> MultiplyExtendedScalarBySelectedScalar(Vector64<double> left, Vector128<double> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MultiplyExtendedScalarBySelectedScalar(Vector64<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> MultiplyExtendedScalarBySelectedScalar(Vector64<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MultiplyRoundedDoublingSaturateHighScalar(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyRoundedDoublingSaturateHighScalar(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> MultiplyScalarBySelectedScalar(Vector64<double> left, Vector128<double> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Negate(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> Negate(Vector128<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> NegateSaturate(Vector128<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> NegateSaturateScalar(Vector64<short> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> NegateSaturateScalar(Vector64<int> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> NegateSaturateScalar(Vector64<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> NegateSaturateScalar(Vector64<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<long> NegateScalar(Vector64<long> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ReciprocalEstimate(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> ReciprocalEstimateScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> ReciprocalEstimateScalar(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> ReciprocalExponentScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> ReciprocalExponentScalar(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ReciprocalSquareRootEstimate(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> ReciprocalSquareRootEstimateScalar(Vector64<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> ReciprocalSquareRootEstimateScalar(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ReciprocalSquareRootStep(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> ReciprocalSquareRootStepScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> ReciprocalSquareRootStepScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ReciprocalStep(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<double> ReciprocalStepScalar(Vector64<double> left, Vector64<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> ReciprocalStepScalar(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> RoundAwayFromZero(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> RoundToNearest(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> RoundToNegativeInfinity(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> RoundToPositiveInfinity(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> RoundToZero(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ShiftArithmeticRoundedSaturateScalar(Vector64<short> value, Vector64<short> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ShiftArithmeticRoundedSaturateScalar(Vector64<int> value, Vector64<int> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ShiftArithmeticRoundedSaturateScalar(Vector64<sbyte> value, Vector64<sbyte> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ShiftArithmeticSaturateScalar(Vector64<short> value, Vector64<short> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ShiftArithmeticSaturateScalar(Vector64<int> value, Vector64<int> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ShiftArithmeticSaturateScalar(Vector64<sbyte> value, Vector64<sbyte> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ShiftLeftLogicalSaturateScalar(Vector64<byte> value, [ConstantExpected(Max = 63)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ShiftLeftLogicalSaturateScalar(Vector64<short> value, [ConstantExpected(Max = 31)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ShiftLeftLogicalSaturateScalar(Vector64<int> value, [ConstantExpected(Max = 15)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ShiftLeftLogicalSaturateScalar(Vector64<sbyte> value, [ConstantExpected(Max = 63)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ShiftLeftLogicalSaturateScalar(Vector64<ushort> value, [ConstantExpected(Max = 31)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ShiftLeftLogicalSaturateScalar(Vector64<uint> value, [ConstantExpected(Max = 15)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ShiftLeftLogicalSaturateUnsignedScalar(Vector64<short> value, [ConstantExpected(Max = 31)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ShiftLeftLogicalSaturateUnsignedScalar(Vector64<int> value, [ConstantExpected(Max = 15)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ShiftLeftLogicalSaturateUnsignedScalar(Vector64<sbyte> value, [ConstantExpected(Max = 63)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ShiftLogicalRoundedSaturateScalar(Vector64<byte> value, Vector64<sbyte> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ShiftLogicalRoundedSaturateScalar(Vector64<short> value, Vector64<short> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ShiftLogicalRoundedSaturateScalar(Vector64<int> value, Vector64<int> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ShiftLogicalRoundedSaturateScalar(Vector64<sbyte> value, Vector64<sbyte> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ShiftLogicalRoundedSaturateScalar(Vector64<ushort> value, Vector64<short> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ShiftLogicalRoundedSaturateScalar(Vector64<uint> value, Vector64<int> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ShiftLogicalSaturateScalar(Vector64<byte> value, Vector64<sbyte> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ShiftLogicalSaturateScalar(Vector64<short> value, Vector64<short> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ShiftLogicalSaturateScalar(Vector64<int> value, Vector64<int> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ShiftLogicalSaturateScalar(Vector64<sbyte> value, Vector64<sbyte> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ShiftLogicalSaturateScalar(Vector64<ushort> value, Vector64<short> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ShiftLogicalSaturateScalar(Vector64<uint> value, Vector64<int> count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ShiftRightArithmeticNarrowingSaturateScalar(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ShiftRightArithmeticNarrowingSaturateScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ShiftRightArithmeticNarrowingSaturateScalar(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ShiftRightArithmeticNarrowingSaturateUnsignedScalar(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ShiftRightArithmeticNarrowingSaturateUnsignedScalar(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ShiftRightArithmeticNarrowingSaturateUnsignedScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ShiftRightArithmeticRoundedNarrowingSaturateScalar(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ShiftRightArithmeticRoundedNarrowingSaturateScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ShiftRightArithmeticRoundedNarrowingSaturateScalar(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedScalar(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedScalar(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ShiftRightLogicalNarrowingSaturateScalar(Vector64<ushort> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ShiftRightLogicalNarrowingSaturateScalar(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ShiftRightLogicalNarrowingSaturateScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ShiftRightLogicalNarrowingSaturateScalar(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ShiftRightLogicalNarrowingSaturateScalar(Vector64<uint> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ShiftRightLogicalNarrowingSaturateScalar(Vector64<ulong> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<ushort> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<uint> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<ulong> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> Sqrt(Vector64<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Sqrt(Vector128<double> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> Sqrt(Vector128<float> value)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(byte* address, Vector64<byte> value1, Vector64<byte> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(double* address, Vector64<double> value1, Vector64<double> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(short* address, Vector64<short> value1, Vector64<short> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(int* address, Vector64<int> value1, Vector64<int> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(long* address, Vector64<long> value1, Vector64<long> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(sbyte* address, Vector64<sbyte> value1, Vector64<sbyte> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(float* address, Vector64<float> value1, Vector64<float> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(ushort* address, Vector64<ushort> value1, Vector64<ushort> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(uint* address, Vector64<uint> value1, Vector64<uint> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(ulong* address, Vector64<ulong> value1, Vector64<ulong> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(byte* address, Vector128<byte> value1, Vector128<byte> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(double* address, Vector128<double> value1, Vector128<double> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(short* address, Vector128<short> value1, Vector128<short> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(int* address, Vector128<int> value1, Vector128<int> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(long* address, Vector128<long> value1, Vector128<long> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(sbyte* address, Vector128<sbyte> value1, Vector128<sbyte> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(float* address, Vector128<float> value1, Vector128<float> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(ushort* address, Vector128<ushort> value1, Vector128<ushort> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(uint* address, Vector128<uint> value1, Vector128<uint> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePair(ulong* address, Vector128<ulong> value1, Vector128<ulong> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(byte* address, Vector64<byte> value1, Vector64<byte> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(double* address, Vector64<double> value1, Vector64<double> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(short* address, Vector64<short> value1, Vector64<short> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(int* address, Vector64<int> value1, Vector64<int> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(long* address, Vector64<long> value1, Vector64<long> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(sbyte* address, Vector64<sbyte> value1, Vector64<sbyte> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(float* address, Vector64<float> value1, Vector64<float> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(ushort* address, Vector64<ushort> value1, Vector64<ushort> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(uint* address, Vector64<uint> value1, Vector64<uint> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(ulong* address, Vector64<ulong> value1, Vector64<ulong> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(byte* address, Vector128<byte> value1, Vector128<byte> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(double* address, Vector128<double> value1, Vector128<double> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(short* address, Vector128<short> value1, Vector128<short> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(int* address, Vector128<int> value1, Vector128<int> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(long* address, Vector128<long> value1, Vector128<long> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(sbyte* address, Vector128<sbyte> value1, Vector128<sbyte> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(float* address, Vector128<float> value1, Vector128<float> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(ushort* address, Vector128<ushort> value1, Vector128<ushort> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(uint* address, Vector128<uint> value1, Vector128<uint> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairNonTemporal(ulong* address, Vector128<ulong> value1, Vector128<ulong> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairScalar(int* address, Vector64<int> value1, Vector64<int> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairScalar(float* address, Vector64<float> value1, Vector64<float> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairScalar(uint* address, Vector64<uint> value1, Vector64<uint> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairScalarNonTemporal(int* address, Vector64<int> value1, Vector64<int> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairScalarNonTemporal(float* address, Vector64<float> value1, Vector64<float> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public unsafe static void StorePairScalarNonTemporal(uint* address, Vector64<uint> value1, Vector64<uint> value2)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> Subtract(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> SubtractSaturateScalar(Vector64<byte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> SubtractSaturateScalar(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> SubtractSaturateScalar(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> SubtractSaturateScalar(Vector64<sbyte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> SubtractSaturateScalar(Vector64<ushort> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> SubtractSaturateScalar(Vector64<uint> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ReverseElementBits(Vector64<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ReverseElementBits(Vector64<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ReverseElementBits(Vector128<byte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ReverseElementBits(Vector128<sbyte> value)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> TransposeEven(Vector64<byte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> TransposeEven(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> TransposeEven(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> TransposeEven(Vector64<sbyte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> TransposeEven(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> TransposeEven(Vector64<ushort> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> TransposeEven(Vector64<uint> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> TransposeEven(Vector128<byte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> TransposeEven(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> TransposeEven(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> TransposeEven(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> TransposeEven(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> TransposeEven(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> TransposeEven(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> TransposeEven(Vector128<ushort> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> TransposeEven(Vector128<uint> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> TransposeEven(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> TransposeOdd(Vector64<byte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> TransposeOdd(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> TransposeOdd(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> TransposeOdd(Vector64<sbyte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> TransposeOdd(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> TransposeOdd(Vector64<ushort> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> TransposeOdd(Vector64<uint> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> TransposeOdd(Vector128<byte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> TransposeOdd(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> TransposeOdd(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> TransposeOdd(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> TransposeOdd(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> TransposeOdd(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> TransposeOdd(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> TransposeOdd(Vector128<ushort> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> TransposeOdd(Vector128<uint> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> TransposeOdd(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> UnzipEven(Vector64<byte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> UnzipEven(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> UnzipEven(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> UnzipEven(Vector64<sbyte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> UnzipEven(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> UnzipEven(Vector64<ushort> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> UnzipEven(Vector64<uint> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> UnzipEven(Vector128<byte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> UnzipEven(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> UnzipEven(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> UnzipEven(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> UnzipEven(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> UnzipEven(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> UnzipEven(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> UnzipEven(Vector128<ushort> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> UnzipEven(Vector128<uint> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> UnzipEven(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> UnzipOdd(Vector64<byte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> UnzipOdd(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> UnzipOdd(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> UnzipOdd(Vector64<sbyte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> UnzipOdd(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> UnzipOdd(Vector64<ushort> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> UnzipOdd(Vector64<uint> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> UnzipOdd(Vector128<byte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> UnzipOdd(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> UnzipOdd(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> UnzipOdd(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> UnzipOdd(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> UnzipOdd(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> UnzipOdd(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> UnzipOdd(Vector128<ushort> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> UnzipOdd(Vector128<uint> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> UnzipOdd(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> VectorTableLookup(Vector128<byte> table, Vector128<byte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> VectorTableLookup(Vector128<sbyte> table, Vector128<sbyte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> VectorTableLookup((Vector128<byte>, Vector128<byte>) table, Vector128<byte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> VectorTableLookup((Vector128<sbyte>, Vector128<sbyte>) table, Vector128<sbyte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> VectorTableLookup((Vector128<byte>, Vector128<byte>, Vector128<byte>) table, Vector128<byte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> VectorTableLookup((Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>) table, Vector128<sbyte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> VectorTableLookup((Vector128<byte>, Vector128<byte>, Vector128<byte>, Vector128<byte>) table, Vector128<byte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> VectorTableLookup((Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>) table, Vector128<sbyte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> VectorTableLookupExtension(Vector128<byte> defaultValues, Vector128<byte> table, Vector128<byte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> VectorTableLookupExtension(Vector128<sbyte> defaultValues, Vector128<sbyte> table, Vector128<sbyte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> VectorTableLookupExtension(Vector128<byte> defaultValues, (Vector128<byte>, Vector128<byte>) table, Vector128<byte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> VectorTableLookupExtension(Vector128<sbyte> defaultValues, (Vector128<sbyte>, Vector128<sbyte>) table, Vector128<sbyte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> VectorTableLookupExtension(Vector128<byte> defaultValues, (Vector128<byte>, Vector128<byte>, Vector128<byte>) table, Vector128<byte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> VectorTableLookupExtension(Vector128<sbyte> defaultValues, (Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>) table, Vector128<sbyte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> VectorTableLookupExtension(Vector128<byte> defaultValues, (Vector128<byte>, Vector128<byte>, Vector128<byte>, Vector128<byte>) table, Vector128<byte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> VectorTableLookupExtension(Vector128<sbyte> defaultValues, (Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>) table, Vector128<sbyte> byteIndexes)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ZipHigh(Vector64<byte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ZipHigh(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ZipHigh(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ZipHigh(Vector64<sbyte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> ZipHigh(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ZipHigh(Vector64<ushort> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ZipHigh(Vector64<uint> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ZipHigh(Vector128<byte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ZipHigh(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> ZipHigh(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> ZipHigh(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ZipHigh(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ZipHigh(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> ZipHigh(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> ZipHigh(Vector128<ushort> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> ZipHigh(Vector128<uint> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> ZipHigh(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<byte> ZipLow(Vector64<byte> left, Vector64<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<short> ZipLow(Vector64<short> left, Vector64<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<int> ZipLow(Vector64<int> left, Vector64<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<sbyte> ZipLow(Vector64<sbyte> left, Vector64<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<float> ZipLow(Vector64<float> left, Vector64<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<ushort> ZipLow(Vector64<ushort> left, Vector64<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector64<uint> ZipLow(Vector64<uint> left, Vector64<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<byte> ZipLow(Vector128<byte> left, Vector128<byte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<double> ZipLow(Vector128<double> left, Vector128<double> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<short> ZipLow(Vector128<short> left, Vector128<short> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<int> ZipLow(Vector128<int> left, Vector128<int> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<long> ZipLow(Vector128<long> left, Vector128<long> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<sbyte> ZipLow(Vector128<sbyte> left, Vector128<sbyte> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<float> ZipLow(Vector128<float> left, Vector128<float> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ushort> ZipLow(Vector128<ushort> left, Vector128<ushort> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<uint> ZipLow(Vector128<uint> left, Vector128<uint> right)
		{
			throw new PlatformNotSupportedException();
		}

		public static Vector128<ulong> ZipLow(Vector128<ulong> left, Vector128<ulong> right)
		{
			throw new PlatformNotSupportedException();
		}
	}

	public new static bool IsSupported
	{
		[Intrinsic]
		get
		{
			return false;
		}
	}

	public static Vector64<ushort> Abs(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Abs(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Abs(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Abs(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Abs(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Abs(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Abs(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Abs(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> AbsSaturate(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> AbsSaturate(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> AbsSaturate(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AbsSaturate(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AbsSaturate(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> AbsSaturate(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> AbsScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> AbsScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> AbsoluteCompareGreaterThan(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> AbsoluteCompareGreaterThan(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> AbsoluteCompareGreaterThanOrEqual(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> AbsoluteCompareGreaterThanOrEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> AbsoluteCompareLessThan(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> AbsoluteCompareLessThan(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> AbsoluteCompareLessThanOrEqual(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> AbsoluteCompareLessThanOrEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> AbsoluteDifference(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> AbsoluteDifference(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> AbsoluteDifference(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> AbsoluteDifference(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> AbsoluteDifference(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> AbsoluteDifference(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> AbsoluteDifference(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> AbsoluteDifference(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AbsoluteDifference(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AbsoluteDifference(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> AbsoluteDifference(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> AbsoluteDifference(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AbsoluteDifference(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AbsoluteDifference(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> AbsoluteDifferenceAdd(Vector64<byte> addend, Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> AbsoluteDifferenceAdd(Vector64<short> addend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> AbsoluteDifferenceAdd(Vector64<int> addend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> AbsoluteDifferenceAdd(Vector64<sbyte> addend, Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> AbsoluteDifferenceAdd(Vector64<ushort> addend, Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> AbsoluteDifferenceAdd(Vector64<uint> addend, Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> AbsoluteDifferenceAdd(Vector128<byte> addend, Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AbsoluteDifferenceAdd(Vector128<short> addend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AbsoluteDifferenceAdd(Vector128<int> addend, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> AbsoluteDifferenceAdd(Vector128<sbyte> addend, Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AbsoluteDifferenceAdd(Vector128<ushort> addend, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AbsoluteDifferenceAdd(Vector128<uint> addend, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AbsoluteDifferenceWideningLower(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AbsoluteDifferenceWideningLower(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AbsoluteDifferenceWideningLower(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AbsoluteDifferenceWideningLower(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AbsoluteDifferenceWideningLower(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AbsoluteDifferenceWideningLower(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AbsoluteDifferenceWideningLowerAndAdd(Vector128<ushort> addend, Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AbsoluteDifferenceWideningLowerAndAdd(Vector128<int> addend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AbsoluteDifferenceWideningLowerAndAdd(Vector128<long> addend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AbsoluteDifferenceWideningLowerAndAdd(Vector128<short> addend, Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AbsoluteDifferenceWideningLowerAndAdd(Vector128<uint> addend, Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AbsoluteDifferenceWideningLowerAndAdd(Vector128<ulong> addend, Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AbsoluteDifferenceWideningUpper(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AbsoluteDifferenceWideningUpper(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AbsoluteDifferenceWideningUpper(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AbsoluteDifferenceWideningUpper(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AbsoluteDifferenceWideningUpper(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AbsoluteDifferenceWideningUpper(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AbsoluteDifferenceWideningUpperAndAdd(Vector128<ushort> addend, Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AbsoluteDifferenceWideningUpperAndAdd(Vector128<int> addend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AbsoluteDifferenceWideningUpperAndAdd(Vector128<long> addend, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AbsoluteDifferenceWideningUpperAndAdd(Vector128<short> addend, Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AbsoluteDifferenceWideningUpperAndAdd(Vector128<uint> addend, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AbsoluteDifferenceWideningUpperAndAdd(Vector128<ulong> addend, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Add(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Add(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Add(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Add(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Add(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> Add(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Add(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Add(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Add(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Add(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Add(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Add(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Add(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Add(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Add(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Add(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> AddHighNarrowingLower(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> AddHighNarrowingLower(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> AddHighNarrowingLower(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> AddHighNarrowingLower(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> AddHighNarrowingLower(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> AddHighNarrowingLower(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> AddHighNarrowingUpper(Vector64<byte> lower, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AddHighNarrowingUpper(Vector64<short> lower, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AddHighNarrowingUpper(Vector64<int> lower, Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> AddHighNarrowingUpper(Vector64<sbyte> lower, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AddHighNarrowingUpper(Vector64<ushort> lower, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AddHighNarrowingUpper(Vector64<uint> lower, Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> AddPairwise(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> AddPairwise(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> AddPairwise(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> AddPairwise(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> AddPairwise(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> AddPairwise(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> AddPairwise(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> AddPairwiseWidening(Vector64<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> AddPairwiseWidening(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> AddPairwiseWidening(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> AddPairwiseWidening(Vector64<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AddPairwiseWidening(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AddPairwiseWidening(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AddPairwiseWidening(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AddPairwiseWidening(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AddPairwiseWidening(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AddPairwiseWidening(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> AddPairwiseWideningAndAdd(Vector64<ushort> addend, Vector64<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> AddPairwiseWideningAndAdd(Vector64<int> addend, Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> AddPairwiseWideningAndAdd(Vector64<short> addend, Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> AddPairwiseWideningAndAdd(Vector64<uint> addend, Vector64<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AddPairwiseWideningAndAdd(Vector128<ushort> addend, Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AddPairwiseWideningAndAdd(Vector128<int> addend, Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AddPairwiseWideningAndAdd(Vector128<long> addend, Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AddPairwiseWideningAndAdd(Vector128<short> addend, Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AddPairwiseWideningAndAdd(Vector128<uint> addend, Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AddPairwiseWideningAndAdd(Vector128<ulong> addend, Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> AddPairwiseWideningAndAddScalar(Vector64<long> addend, Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> AddPairwiseWideningAndAddScalar(Vector64<ulong> addend, Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> AddPairwiseWideningScalar(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> AddPairwiseWideningScalar(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> AddRoundedHighNarrowingLower(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> AddRoundedHighNarrowingLower(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> AddRoundedHighNarrowingLower(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> AddRoundedHighNarrowingLower(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> AddRoundedHighNarrowingLower(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> AddRoundedHighNarrowingLower(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> AddRoundedHighNarrowingUpper(Vector64<byte> lower, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AddRoundedHighNarrowingUpper(Vector64<short> lower, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AddRoundedHighNarrowingUpper(Vector64<int> lower, Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> AddRoundedHighNarrowingUpper(Vector64<sbyte> lower, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AddRoundedHighNarrowingUpper(Vector64<ushort> lower, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AddRoundedHighNarrowingUpper(Vector64<uint> lower, Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> AddSaturate(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> AddSaturate(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> AddSaturate(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> AddSaturate(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> AddSaturate(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> AddSaturate(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> AddSaturate(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AddSaturate(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AddSaturate(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AddSaturate(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> AddSaturate(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AddSaturate(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AddSaturate(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AddSaturate(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> AddSaturateScalar(Vector64<long> left, Vector64<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> AddSaturateScalar(Vector64<ulong> left, Vector64<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> AddScalar(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> AddScalar(Vector64<long> left, Vector64<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> AddScalar(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> AddScalar(Vector64<ulong> left, Vector64<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AddWideningLower(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AddWideningLower(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AddWideningLower(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AddWideningLower(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AddWideningLower(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AddWideningLower(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AddWideningLower(Vector128<short> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AddWideningLower(Vector128<int> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AddWideningLower(Vector128<long> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AddWideningLower(Vector128<ushort> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AddWideningLower(Vector128<uint> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AddWideningLower(Vector128<ulong> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AddWideningUpper(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AddWideningUpper(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AddWideningUpper(Vector128<short> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> AddWideningUpper(Vector128<int> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AddWideningUpper(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> AddWideningUpper(Vector128<long> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> AddWideningUpper(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> AddWideningUpper(Vector128<ushort> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AddWideningUpper(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> AddWideningUpper(Vector128<uint> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AddWideningUpper(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> AddWideningUpper(Vector128<ulong> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> And(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> And(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> And(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> And(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> And(Vector64<long> left, Vector64<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> And(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> And(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> And(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> And(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> And(Vector64<ulong> left, Vector64<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> And(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> And(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> And(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> And(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> And(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> And(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> And(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> And(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> And(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> And(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> BitwiseClear(Vector64<byte> value, Vector64<byte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> BitwiseClear(Vector64<double> value, Vector64<double> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> BitwiseClear(Vector64<short> value, Vector64<short> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> BitwiseClear(Vector64<int> value, Vector64<int> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> BitwiseClear(Vector64<long> value, Vector64<long> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> BitwiseClear(Vector64<sbyte> value, Vector64<sbyte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> BitwiseClear(Vector64<float> value, Vector64<float> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> BitwiseClear(Vector64<ushort> value, Vector64<ushort> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> BitwiseClear(Vector64<uint> value, Vector64<uint> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> BitwiseClear(Vector64<ulong> value, Vector64<ulong> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> BitwiseClear(Vector128<byte> value, Vector128<byte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> BitwiseClear(Vector128<double> value, Vector128<double> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> BitwiseClear(Vector128<short> value, Vector128<short> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> BitwiseClear(Vector128<int> value, Vector128<int> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> BitwiseClear(Vector128<long> value, Vector128<long> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> BitwiseClear(Vector128<sbyte> value, Vector128<sbyte> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> BitwiseClear(Vector128<float> value, Vector128<float> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> BitwiseClear(Vector128<ushort> value, Vector128<ushort> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> BitwiseClear(Vector128<uint> value, Vector128<uint> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> BitwiseClear(Vector128<ulong> value, Vector128<ulong> mask)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> BitwiseSelect(Vector64<byte> select, Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> BitwiseSelect(Vector64<double> select, Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> BitwiseSelect(Vector64<short> select, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> BitwiseSelect(Vector64<int> select, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> BitwiseSelect(Vector64<long> select, Vector64<long> left, Vector64<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> BitwiseSelect(Vector64<sbyte> select, Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> BitwiseSelect(Vector64<float> select, Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> BitwiseSelect(Vector64<ushort> select, Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> BitwiseSelect(Vector64<uint> select, Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> BitwiseSelect(Vector64<ulong> select, Vector64<ulong> left, Vector64<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> BitwiseSelect(Vector128<byte> select, Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> BitwiseSelect(Vector128<double> select, Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> BitwiseSelect(Vector128<short> select, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> BitwiseSelect(Vector128<int> select, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> BitwiseSelect(Vector128<long> select, Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> BitwiseSelect(Vector128<sbyte> select, Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> BitwiseSelect(Vector128<float> select, Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> BitwiseSelect(Vector128<ushort> select, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> BitwiseSelect(Vector128<uint> select, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> BitwiseSelect(Vector128<ulong> select, Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Ceiling(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Ceiling(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> CeilingScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> CeilingScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> CompareEqual(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> CompareEqual(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> CompareEqual(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> CompareEqual(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> CompareEqual(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> CompareEqual(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> CompareEqual(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareEqual(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> CompareEqual(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> CompareEqual(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> CompareEqual(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> CompareEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareEqual(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareEqual(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> CompareGreaterThan(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> CompareGreaterThan(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> CompareGreaterThan(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> CompareGreaterThan(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> CompareGreaterThan(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> CompareGreaterThan(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> CompareGreaterThan(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareGreaterThan(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> CompareGreaterThan(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> CompareGreaterThan(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> CompareGreaterThan(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> CompareGreaterThan(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareGreaterThan(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareGreaterThan(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> CompareGreaterThanOrEqual(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> CompareGreaterThanOrEqual(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> CompareGreaterThanOrEqual(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> CompareGreaterThanOrEqual(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> CompareGreaterThanOrEqual(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> CompareGreaterThanOrEqual(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> CompareGreaterThanOrEqual(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareGreaterThanOrEqual(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> CompareGreaterThanOrEqual(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> CompareGreaterThanOrEqual(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> CompareGreaterThanOrEqual(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> CompareGreaterThanOrEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareGreaterThanOrEqual(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareGreaterThanOrEqual(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> CompareLessThan(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> CompareLessThan(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> CompareLessThan(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> CompareLessThan(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> CompareLessThan(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> CompareLessThan(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> CompareLessThan(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareLessThan(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> CompareLessThan(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> CompareLessThan(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> CompareLessThan(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> CompareLessThan(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareLessThan(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareLessThan(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> CompareLessThanOrEqual(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> CompareLessThanOrEqual(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> CompareLessThanOrEqual(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> CompareLessThanOrEqual(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> CompareLessThanOrEqual(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> CompareLessThanOrEqual(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> CompareLessThanOrEqual(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareLessThanOrEqual(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> CompareLessThanOrEqual(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> CompareLessThanOrEqual(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> CompareLessThanOrEqual(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> CompareLessThanOrEqual(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareLessThanOrEqual(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareLessThanOrEqual(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> CompareTest(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> CompareTest(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> CompareTest(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> CompareTest(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> CompareTest(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> CompareTest(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> CompareTest(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> CompareTest(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> CompareTest(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> CompareTest(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> CompareTest(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> CompareTest(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> CompareTest(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> CompareTest(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundAwayFromZero(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToInt32RoundAwayFromZero(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundAwayFromZeroScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundToEven(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToInt32RoundToEven(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundToEvenScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundToNegativeInfinity(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToInt32RoundToNegativeInfinity(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundToNegativeInfinityScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundToPositiveInfinity(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToInt32RoundToPositiveInfinity(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundToPositiveInfinityScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundToZero(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ConvertToInt32RoundToZero(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ConvertToInt32RoundToZeroScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> ConvertToSingle(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> ConvertToSingle(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertToSingle(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ConvertToSingle(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> ConvertToSingleScalar(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> ConvertToSingleScalar(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundAwayFromZero(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToUInt32RoundAwayFromZero(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundAwayFromZeroScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundToEven(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToUInt32RoundToEven(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundToEvenScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundToNegativeInfinity(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToUInt32RoundToNegativeInfinity(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundToNegativeInfinityScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundToPositiveInfinity(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToUInt32RoundToPositiveInfinity(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundToPositiveInfinityScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundToZero(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ConvertToUInt32RoundToZero(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ConvertToUInt32RoundToZeroScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> DivideScalar(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> DivideScalar(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> DuplicateSelectedScalarToVector64(Vector64<byte> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> DuplicateSelectedScalarToVector64(Vector64<short> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> DuplicateSelectedScalarToVector64(Vector64<int> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> DuplicateSelectedScalarToVector64(Vector64<float> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> DuplicateSelectedScalarToVector64(Vector64<sbyte> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> DuplicateSelectedScalarToVector64(Vector64<ushort> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> DuplicateSelectedScalarToVector64(Vector64<uint> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> DuplicateSelectedScalarToVector64(Vector128<byte> value, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> DuplicateSelectedScalarToVector64(Vector128<short> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> DuplicateSelectedScalarToVector64(Vector128<int> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> DuplicateSelectedScalarToVector64(Vector128<float> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> DuplicateSelectedScalarToVector64(Vector128<sbyte> value, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> DuplicateSelectedScalarToVector64(Vector128<ushort> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> DuplicateSelectedScalarToVector64(Vector128<uint> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> DuplicateSelectedScalarToVector128(Vector64<byte> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> DuplicateSelectedScalarToVector128(Vector64<short> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> DuplicateSelectedScalarToVector128(Vector64<int> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> DuplicateSelectedScalarToVector128(Vector64<float> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> DuplicateSelectedScalarToVector128(Vector64<sbyte> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> DuplicateSelectedScalarToVector128(Vector64<ushort> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> DuplicateSelectedScalarToVector128(Vector64<uint> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> DuplicateSelectedScalarToVector128(Vector128<byte> value, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> DuplicateSelectedScalarToVector128(Vector128<short> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> DuplicateSelectedScalarToVector128(Vector128<int> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> DuplicateSelectedScalarToVector128(Vector128<float> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> DuplicateSelectedScalarToVector128(Vector128<sbyte> value, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> DuplicateSelectedScalarToVector128(Vector128<ushort> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> DuplicateSelectedScalarToVector128(Vector128<uint> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> DuplicateToVector64(byte value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> DuplicateToVector64(short value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> DuplicateToVector64(int value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> DuplicateToVector64(sbyte value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> DuplicateToVector64(float value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> DuplicateToVector64(ushort value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> DuplicateToVector64(uint value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> DuplicateToVector128(byte value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> DuplicateToVector128(short value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> DuplicateToVector128(int value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> DuplicateToVector128(sbyte value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> DuplicateToVector128(float value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> DuplicateToVector128(ushort value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> DuplicateToVector128(uint value)
	{
		throw new PlatformNotSupportedException();
	}

	public static byte Extract(Vector64<byte> vector, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static short Extract(Vector64<short> vector, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static int Extract(Vector64<int> vector, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static sbyte Extract(Vector64<sbyte> vector, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static float Extract(Vector64<float> vector, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static ushort Extract(Vector64<ushort> vector, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint Extract(Vector64<uint> vector, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static byte Extract(Vector128<byte> vector, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static double Extract(Vector128<double> vector, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static short Extract(Vector128<short> vector, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static int Extract(Vector128<int> vector, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static long Extract(Vector128<long> vector, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static sbyte Extract(Vector128<sbyte> vector, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static float Extract(Vector128<float> vector, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static ushort Extract(Vector128<ushort> vector, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static uint Extract(Vector128<uint> vector, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static ulong Extract(Vector128<ulong> vector, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ExtractNarrowingLower(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ExtractNarrowingLower(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ExtractNarrowingLower(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ExtractNarrowingLower(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ExtractNarrowingLower(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ExtractNarrowingLower(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ExtractNarrowingSaturateLower(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ExtractNarrowingSaturateLower(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ExtractNarrowingSaturateLower(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ExtractNarrowingSaturateLower(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ExtractNarrowingSaturateLower(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ExtractNarrowingSaturateLower(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ExtractNarrowingSaturateUnsignedLower(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ExtractNarrowingSaturateUnsignedLower(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ExtractNarrowingSaturateUnsignedLower(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ExtractNarrowingSaturateUnsignedUpper(Vector64<byte> lower, Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ExtractNarrowingSaturateUnsignedUpper(Vector64<ushort> lower, Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ExtractNarrowingSaturateUnsignedUpper(Vector64<uint> lower, Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ExtractNarrowingSaturateUpper(Vector64<byte> lower, Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ExtractNarrowingSaturateUpper(Vector64<short> lower, Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ExtractNarrowingSaturateUpper(Vector64<int> lower, Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ExtractNarrowingSaturateUpper(Vector64<sbyte> lower, Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ExtractNarrowingSaturateUpper(Vector64<ushort> lower, Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ExtractNarrowingSaturateUpper(Vector64<uint> lower, Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ExtractNarrowingUpper(Vector64<byte> lower, Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ExtractNarrowingUpper(Vector64<short> lower, Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ExtractNarrowingUpper(Vector64<int> lower, Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ExtractNarrowingUpper(Vector64<sbyte> lower, Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ExtractNarrowingUpper(Vector64<ushort> lower, Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ExtractNarrowingUpper(Vector64<uint> lower, Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ExtractVector64(Vector64<byte> upper, Vector64<byte> lower, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ExtractVector64(Vector64<short> upper, Vector64<short> lower, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ExtractVector64(Vector64<int> upper, Vector64<int> lower, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ExtractVector64(Vector64<sbyte> upper, Vector64<sbyte> lower, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> ExtractVector64(Vector64<float> upper, Vector64<float> lower, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ExtractVector64(Vector64<ushort> upper, Vector64<ushort> lower, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ExtractVector64(Vector64<uint> upper, Vector64<uint> lower, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ExtractVector128(Vector128<byte> upper, Vector128<byte> lower, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> ExtractVector128(Vector128<double> upper, Vector128<double> lower, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ExtractVector128(Vector128<short> upper, Vector128<short> lower, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ExtractVector128(Vector128<int> upper, Vector128<int> lower, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ExtractVector128(Vector128<long> upper, Vector128<long> lower, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ExtractVector128(Vector128<sbyte> upper, Vector128<sbyte> lower, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ExtractVector128(Vector128<float> upper, Vector128<float> lower, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ExtractVector128(Vector128<ushort> upper, Vector128<ushort> lower, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ExtractVector128(Vector128<uint> upper, Vector128<uint> lower, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ExtractVector128(Vector128<ulong> upper, Vector128<ulong> lower, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Floor(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Floor(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> FloorScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> FloorScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> FusedAddHalving(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> FusedAddHalving(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> FusedAddHalving(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> FusedAddHalving(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> FusedAddHalving(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> FusedAddHalving(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> FusedAddHalving(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> FusedAddHalving(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> FusedAddHalving(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> FusedAddHalving(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> FusedAddHalving(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> FusedAddHalving(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> FusedAddRoundedHalving(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> FusedAddRoundedHalving(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> FusedAddRoundedHalving(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> FusedAddRoundedHalving(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> FusedAddRoundedHalving(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> FusedAddRoundedHalving(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> FusedAddRoundedHalving(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> FusedAddRoundedHalving(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> FusedAddRoundedHalving(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> FusedAddRoundedHalving(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> FusedAddRoundedHalving(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> FusedAddRoundedHalving(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> FusedMultiplyAdd(Vector64<float> addend, Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplyAdd(Vector128<float> addend, Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> FusedMultiplyAddNegatedScalar(Vector64<double> addend, Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> FusedMultiplyAddNegatedScalar(Vector64<float> addend, Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> FusedMultiplyAddScalar(Vector64<double> addend, Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> FusedMultiplyAddScalar(Vector64<float> addend, Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> FusedMultiplySubtract(Vector64<float> minuend, Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> FusedMultiplySubtract(Vector128<float> minuend, Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> FusedMultiplySubtractNegatedScalar(Vector64<double> minuend, Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> FusedMultiplySubtractNegatedScalar(Vector64<float> minuend, Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> FusedMultiplySubtractScalar(Vector64<double> minuend, Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> FusedMultiplySubtractScalar(Vector64<float> minuend, Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> FusedSubtractHalving(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> FusedSubtractHalving(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> FusedSubtractHalving(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> FusedSubtractHalving(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> FusedSubtractHalving(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> FusedSubtractHalving(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> FusedSubtractHalving(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> FusedSubtractHalving(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> FusedSubtractHalving(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> FusedSubtractHalving(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> FusedSubtractHalving(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> FusedSubtractHalving(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Insert(Vector64<byte> vector, [ConstantExpected(Max = 7)] byte index, byte data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Insert(Vector64<short> vector, [ConstantExpected(Max = 3)] byte index, short data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Insert(Vector64<int> vector, [ConstantExpected(Max = 1)] byte index, int data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Insert(Vector64<sbyte> vector, [ConstantExpected(Max = 7)] byte index, sbyte data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Insert(Vector64<float> vector, [ConstantExpected(Max = 1)] byte index, float data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> Insert(Vector64<ushort> vector, [ConstantExpected(Max = 3)] byte index, ushort data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Insert(Vector64<uint> vector, [ConstantExpected(Max = 1)] byte index, uint data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Insert(Vector128<byte> vector, [ConstantExpected(Max = 15)] byte index, byte data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Insert(Vector128<double> vector, [ConstantExpected(Max = 1)] byte index, double data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Insert(Vector128<short> vector, [ConstantExpected(Max = 7)] byte index, short data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Insert(Vector128<int> vector, [ConstantExpected(Max = 3)] byte index, int data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Insert(Vector128<long> vector, [ConstantExpected(Max = 1)] byte index, long data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Insert(Vector128<sbyte> vector, [ConstantExpected(Max = 15)] byte index, sbyte data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Insert(Vector128<float> vector, [ConstantExpected(Max = 3)] byte index, float data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Insert(Vector128<ushort> vector, [ConstantExpected(Max = 7)] byte index, ushort data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Insert(Vector128<uint> vector, [ConstantExpected(Max = 3)] byte index, uint data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Insert(Vector128<ulong> vector, [ConstantExpected(Max = 1)] byte index, ulong data)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> InsertScalar(Vector128<double> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> InsertScalar(Vector128<long> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector64<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> InsertScalar(Vector128<ulong> result, [ConstantExpected(Max = 1)] byte resultIndex, Vector64<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> LeadingSignCount(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> LeadingSignCount(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> LeadingSignCount(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> LeadingSignCount(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> LeadingSignCount(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> LeadingSignCount(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> LeadingZeroCount(Vector64<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> LeadingZeroCount(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> LeadingZeroCount(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> LeadingZeroCount(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> LeadingZeroCount(Vector64<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> LeadingZeroCount(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> LeadingZeroCount(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> LeadingZeroCount(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> LeadingZeroCount(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> LeadingZeroCount(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> LeadingZeroCount(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> LeadingZeroCount(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<byte> LoadAndInsertScalar(Vector64<byte> value, [ConstantExpected(Max = 7)] byte index, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<short> LoadAndInsertScalar(Vector64<short> value, [ConstantExpected(Max = 3)] byte index, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<int> LoadAndInsertScalar(Vector64<int> value, [ConstantExpected(Max = 1)] byte index, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<sbyte> LoadAndInsertScalar(Vector64<sbyte> value, [ConstantExpected(Max = 7)] byte index, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<float> LoadAndInsertScalar(Vector64<float> value, [ConstantExpected(Max = 1)] byte index, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<ushort> LoadAndInsertScalar(Vector64<ushort> value, [ConstantExpected(Max = 3)] byte index, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<uint> LoadAndInsertScalar(Vector64<uint> value, [ConstantExpected(Max = 1)] byte index, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<byte> LoadAndInsertScalar(Vector128<byte> value, [ConstantExpected(Max = 15)] byte index, byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<double> LoadAndInsertScalar(Vector128<double> value, [ConstantExpected(Max = 1)] byte index, double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<short> LoadAndInsertScalar(Vector128<short> value, [ConstantExpected(Max = 7)] byte index, short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<int> LoadAndInsertScalar(Vector128<int> value, [ConstantExpected(Max = 3)] byte index, int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<long> LoadAndInsertScalar(Vector128<long> value, [ConstantExpected(Max = 1)] byte index, long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<sbyte> LoadAndInsertScalar(Vector128<sbyte> value, [ConstantExpected(Max = 15)] byte index, sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<float> LoadAndInsertScalar(Vector128<float> value, [ConstantExpected(Max = 3)] byte index, float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ushort> LoadAndInsertScalar(Vector128<ushort> value, [ConstantExpected(Max = 7)] byte index, ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<uint> LoadAndInsertScalar(Vector128<uint> value, [ConstantExpected(Max = 3)] byte index, uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ulong> LoadAndInsertScalar(Vector128<ulong> value, [ConstantExpected(Max = 1)] byte index, ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<byte> LoadAndReplicateToVector64(byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<short> LoadAndReplicateToVector64(short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<int> LoadAndReplicateToVector64(int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<sbyte> LoadAndReplicateToVector64(sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<float> LoadAndReplicateToVector64(float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<ushort> LoadAndReplicateToVector64(ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<uint> LoadAndReplicateToVector64(uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<byte> LoadAndReplicateToVector128(byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<short> LoadAndReplicateToVector128(short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<int> LoadAndReplicateToVector128(int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<sbyte> LoadAndReplicateToVector128(sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<float> LoadAndReplicateToVector128(float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ushort> LoadAndReplicateToVector128(ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<uint> LoadAndReplicateToVector128(uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<byte> LoadVector64(byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<double> LoadVector64(double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<short> LoadVector64(short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<int> LoadVector64(int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<long> LoadVector64(long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<sbyte> LoadVector64(sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<float> LoadVector64(float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<ushort> LoadVector64(ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<uint> LoadVector64(uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector64<ulong> LoadVector64(ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<byte> LoadVector128(byte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<double> LoadVector128(double* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<short> LoadVector128(short* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<int> LoadVector128(int* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<long> LoadVector128(long* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<sbyte> LoadVector128(sbyte* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<float> LoadVector128(float* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ushort> LoadVector128(ushort* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<uint> LoadVector128(uint* address)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static Vector128<ulong> LoadVector128(ulong* address)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Max(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Max(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Max(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Max(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Max(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> Max(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Max(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Max(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Max(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Max(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Max(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Max(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Max(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Max(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MaxNumber(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MaxNumber(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> MaxNumberScalar(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MaxNumberScalar(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> MaxPairwise(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MaxPairwise(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MaxPairwise(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> MaxPairwise(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MaxPairwise(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MaxPairwise(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MaxPairwise(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Min(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Min(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Min(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Min(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Min(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> Min(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Min(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Min(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Min(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Min(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Min(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Min(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Min(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Min(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MinNumber(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MinNumber(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> MinNumberScalar(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MinNumberScalar(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> MinPairwise(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MinPairwise(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MinPairwise(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> MinPairwise(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MinPairwise(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MinPairwise(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MinPairwise(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Multiply(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Multiply(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Multiply(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Multiply(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Multiply(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> Multiply(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Multiply(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Multiply(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Multiply(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Multiply(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Multiply(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Multiply(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Multiply(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Multiply(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> MultiplyAdd(Vector64<byte> addend, Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyAdd(Vector64<short> addend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyAdd(Vector64<int> addend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> MultiplyAdd(Vector64<sbyte> addend, Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplyAdd(Vector64<ushort> addend, Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplyAdd(Vector64<uint> addend, Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> MultiplyAdd(Vector128<byte> addend, Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyAdd(Vector128<short> addend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyAdd(Vector128<int> addend, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> MultiplyAdd(Vector128<sbyte> addend, Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyAdd(Vector128<ushort> addend, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyAdd(Vector128<uint> addend, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyAddByScalar(Vector64<short> addend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyAddByScalar(Vector64<int> addend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplyAddByScalar(Vector64<ushort> addend, Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplyAddByScalar(Vector64<uint> addend, Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyAddByScalar(Vector128<short> addend, Vector128<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyAddByScalar(Vector128<int> addend, Vector128<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyAddByScalar(Vector128<ushort> addend, Vector128<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyAddByScalar(Vector128<uint> addend, Vector128<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyAddBySelectedScalar(Vector64<short> addend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyAddBySelectedScalar(Vector64<short> addend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyAddBySelectedScalar(Vector64<int> addend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyAddBySelectedScalar(Vector64<int> addend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplyAddBySelectedScalar(Vector64<ushort> addend, Vector64<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplyAddBySelectedScalar(Vector64<ushort> addend, Vector64<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplyAddBySelectedScalar(Vector64<uint> addend, Vector64<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplyAddBySelectedScalar(Vector64<uint> addend, Vector64<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyAddBySelectedScalar(Vector128<short> addend, Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyAddBySelectedScalar(Vector128<short> addend, Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyAddBySelectedScalar(Vector128<int> addend, Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyAddBySelectedScalar(Vector128<int> addend, Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyAddBySelectedScalar(Vector128<ushort> addend, Vector128<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyAddBySelectedScalar(Vector128<ushort> addend, Vector128<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyAddBySelectedScalar(Vector128<uint> addend, Vector128<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyAddBySelectedScalar(Vector128<uint> addend, Vector128<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyByScalar(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyByScalar(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MultiplyByScalar(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplyByScalar(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplyByScalar(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyByScalar(Vector128<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyByScalar(Vector128<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MultiplyByScalar(Vector128<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyByScalar(Vector128<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyByScalar(Vector128<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyBySelectedScalar(Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyBySelectedScalar(Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyBySelectedScalar(Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyBySelectedScalar(Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MultiplyBySelectedScalar(Vector64<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MultiplyBySelectedScalar(Vector64<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplyBySelectedScalar(Vector64<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplyBySelectedScalar(Vector64<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplyBySelectedScalar(Vector64<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplyBySelectedScalar(Vector64<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyBySelectedScalar(Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyBySelectedScalar(Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalar(Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalar(Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MultiplyBySelectedScalar(Vector128<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> MultiplyBySelectedScalar(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyBySelectedScalar(Vector128<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyBySelectedScalar(Vector128<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalar(Vector128<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalar(Vector128<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningLower(Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningLower(Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningLower(Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningLower(Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningLower(Vector64<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningLower(Vector64<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningLower(Vector64<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningLower(Vector64<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<int> addend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<int> addend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<long> addend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<long> addend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<uint> addend, Vector64<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<uint> addend, Vector64<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<ulong> addend, Vector64<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<ulong> addend, Vector64<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<int> minuend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<int> minuend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<long> minuend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<long> minuend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<uint> minuend, Vector64<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<uint> minuend, Vector64<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<ulong> minuend, Vector64<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<ulong> minuend, Vector64<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningUpper(Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningUpper(Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningUpper(Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningUpper(Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningUpper(Vector128<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningUpper(Vector128<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningUpper(Vector128<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningUpper(Vector128<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<int> addend, Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<int> addend, Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<long> addend, Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<long> addend, Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<uint> addend, Vector128<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<uint> addend, Vector128<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<ulong> addend, Vector128<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<ulong> addend, Vector128<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<int> minuend, Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<int> minuend, Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<long> minuend, Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<long> minuend, Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<uint> minuend, Vector128<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<uint> minuend, Vector128<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<ulong> minuend, Vector128<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<ulong> minuend, Vector128<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyDoublingByScalarSaturateHigh(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyDoublingByScalarSaturateHigh(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyDoublingByScalarSaturateHigh(Vector128<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingByScalarSaturateHigh(Vector128<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyDoublingBySelectedScalarSaturateHigh(Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyDoublingBySelectedScalarSaturateHigh(Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyDoublingBySelectedScalarSaturateHigh(Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyDoublingBySelectedScalarSaturateHigh(Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyDoublingBySelectedScalarSaturateHigh(Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyDoublingBySelectedScalarSaturateHigh(Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingBySelectedScalarSaturateHigh(Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingBySelectedScalarSaturateHigh(Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyDoublingSaturateHigh(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyDoublingSaturateHigh(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyDoublingSaturateHigh(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingSaturateHigh(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningLowerAndAddSaturate(Vector128<int> addend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningLowerAndAddSaturate(Vector128<long> addend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningLowerAndSubtractSaturate(Vector128<int> minuend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningLowerAndSubtractSaturate(Vector128<long> minuend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningLowerByScalarAndAddSaturate(Vector128<int> addend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningLowerByScalarAndAddSaturate(Vector128<long> addend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningLowerByScalarAndSubtractSaturate(Vector128<int> minuend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningLowerByScalarAndSubtractSaturate(Vector128<long> minuend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningLowerBySelectedScalarAndAddSaturate(Vector128<int> addend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningLowerBySelectedScalarAndAddSaturate(Vector128<int> addend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningLowerBySelectedScalarAndAddSaturate(Vector128<long> addend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningLowerBySelectedScalarAndAddSaturate(Vector128<long> addend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningLowerBySelectedScalarAndSubtractSaturate(Vector128<int> minuend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningLowerBySelectedScalarAndSubtractSaturate(Vector128<int> minuend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningLowerBySelectedScalarAndSubtractSaturate(Vector128<long> minuend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningLowerBySelectedScalarAndSubtractSaturate(Vector128<long> minuend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningSaturateLower(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningSaturateLower(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningSaturateLowerByScalar(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningSaturateLowerByScalar(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningSaturateLowerBySelectedScalar(Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningSaturateLowerBySelectedScalar(Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningSaturateLowerBySelectedScalar(Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningSaturateLowerBySelectedScalar(Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningSaturateUpper(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningSaturateUpper(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningSaturateUpperByScalar(Vector128<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningSaturateUpperByScalar(Vector128<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningSaturateUpperBySelectedScalar(Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningSaturateUpperBySelectedScalar(Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningSaturateUpperBySelectedScalar(Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningSaturateUpperBySelectedScalar(Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningUpperAndAddSaturate(Vector128<int> addend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningUpperAndAddSaturate(Vector128<long> addend, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningUpperAndSubtractSaturate(Vector128<int> minuend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningUpperAndSubtractSaturate(Vector128<long> minuend, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningUpperByScalarAndAddSaturate(Vector128<int> addend, Vector128<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningUpperByScalarAndAddSaturate(Vector128<long> addend, Vector128<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningUpperByScalarAndSubtractSaturate(Vector128<int> minuend, Vector128<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningUpperByScalarAndSubtractSaturate(Vector128<long> minuend, Vector128<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningUpperBySelectedScalarAndAddSaturate(Vector128<int> addend, Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningUpperBySelectedScalarAndAddSaturate(Vector128<int> addend, Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningUpperBySelectedScalarAndAddSaturate(Vector128<long> addend, Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningUpperBySelectedScalarAndAddSaturate(Vector128<long> addend, Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningUpperBySelectedScalarAndSubtractSaturate(Vector128<int> minuend, Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyDoublingWideningUpperBySelectedScalarAndSubtractSaturate(Vector128<int> minuend, Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningUpperBySelectedScalarAndSubtractSaturate(Vector128<long> minuend, Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyDoublingWideningUpperBySelectedScalarAndSubtractSaturate(Vector128<long> minuend, Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyRoundedDoublingByScalarSaturateHigh(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyRoundedDoublingByScalarSaturateHigh(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyRoundedDoublingByScalarSaturateHigh(Vector128<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyRoundedDoublingByScalarSaturateHigh(Vector128<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplyRoundedDoublingSaturateHigh(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplyRoundedDoublingSaturateHigh(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyRoundedDoublingSaturateHigh(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyRoundedDoublingSaturateHigh(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> MultiplyScalar(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MultiplyScalar(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MultiplyScalarBySelectedScalar(Vector64<float> left, Vector64<float> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> MultiplyScalarBySelectedScalar(Vector64<float> left, Vector128<float> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> MultiplySubtract(Vector64<byte> minuend, Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplySubtract(Vector64<short> minuend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplySubtract(Vector64<int> minuend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> MultiplySubtract(Vector64<sbyte> minuend, Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplySubtract(Vector64<ushort> minuend, Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplySubtract(Vector64<uint> minuend, Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> MultiplySubtract(Vector128<byte> minuend, Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplySubtract(Vector128<short> minuend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplySubtract(Vector128<int> minuend, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> MultiplySubtract(Vector128<sbyte> minuend, Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplySubtract(Vector128<ushort> minuend, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplySubtract(Vector128<uint> minuend, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplySubtractByScalar(Vector64<short> minuend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplySubtractByScalar(Vector64<int> minuend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplySubtractByScalar(Vector64<ushort> minuend, Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplySubtractByScalar(Vector64<uint> minuend, Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplySubtractByScalar(Vector128<short> minuend, Vector128<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplySubtractByScalar(Vector128<int> minuend, Vector128<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplySubtractByScalar(Vector128<ushort> minuend, Vector128<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplySubtractByScalar(Vector128<uint> minuend, Vector128<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplySubtractBySelectedScalar(Vector64<short> minuend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> MultiplySubtractBySelectedScalar(Vector64<short> minuend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplySubtractBySelectedScalar(Vector64<int> minuend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> MultiplySubtractBySelectedScalar(Vector64<int> minuend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplySubtractBySelectedScalar(Vector64<ushort> minuend, Vector64<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> MultiplySubtractBySelectedScalar(Vector64<ushort> minuend, Vector64<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplySubtractBySelectedScalar(Vector64<uint> minuend, Vector64<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> MultiplySubtractBySelectedScalar(Vector64<uint> minuend, Vector64<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplySubtractBySelectedScalar(Vector128<short> minuend, Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplySubtractBySelectedScalar(Vector128<short> minuend, Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplySubtractBySelectedScalar(Vector128<int> minuend, Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplySubtractBySelectedScalar(Vector128<int> minuend, Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplySubtractBySelectedScalar(Vector128<ushort> minuend, Vector128<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplySubtractBySelectedScalar(Vector128<ushort> minuend, Vector128<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplySubtractBySelectedScalar(Vector128<uint> minuend, Vector128<uint> left, Vector64<uint> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplySubtractBySelectedScalar(Vector128<uint> minuend, Vector128<uint> left, Vector128<uint> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyWideningLower(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningLower(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyWideningLower(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyWideningLower(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningLower(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyWideningLower(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyWideningLowerAndAdd(Vector128<ushort> addend, Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningLowerAndAdd(Vector128<int> addend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyWideningLowerAndAdd(Vector128<long> addend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyWideningLowerAndAdd(Vector128<short> addend, Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningLowerAndAdd(Vector128<uint> addend, Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyWideningLowerAndAdd(Vector128<ulong> addend, Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyWideningLowerAndSubtract(Vector128<ushort> minuend, Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningLowerAndSubtract(Vector128<int> minuend, Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyWideningLowerAndSubtract(Vector128<long> minuend, Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyWideningLowerAndSubtract(Vector128<short> minuend, Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningLowerAndSubtract(Vector128<uint> minuend, Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyWideningLowerAndSubtract(Vector128<ulong> minuend, Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyWideningUpper(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningUpper(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyWideningUpper(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyWideningUpper(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningUpper(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyWideningUpper(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyWideningUpperAndAdd(Vector128<ushort> addend, Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningUpperAndAdd(Vector128<int> addend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyWideningUpperAndAdd(Vector128<long> addend, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyWideningUpperAndAdd(Vector128<short> addend, Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningUpperAndAdd(Vector128<uint> addend, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyWideningUpperAndAdd(Vector128<ulong> addend, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> MultiplyWideningUpperAndSubtract(Vector128<ushort> minuend, Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> MultiplyWideningUpperAndSubtract(Vector128<int> minuend, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> MultiplyWideningUpperAndSubtract(Vector128<long> minuend, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> MultiplyWideningUpperAndSubtract(Vector128<short> minuend, Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> MultiplyWideningUpperAndSubtract(Vector128<uint> minuend, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> MultiplyWideningUpperAndSubtract(Vector128<ulong> minuend, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Negate(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Negate(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Negate(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Negate(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Negate(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Negate(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Negate(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Negate(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> NegateSaturate(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> NegateSaturate(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> NegateSaturate(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> NegateSaturate(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> NegateSaturate(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> NegateSaturate(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> NegateScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> NegateScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Not(Vector64<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> Not(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Not(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Not(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> Not(Vector64<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Not(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Not(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> Not(Vector64<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Not(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> Not(Vector64<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Not(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Not(Vector128<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Not(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Not(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Not(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Not(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Not(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Not(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Not(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Not(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Or(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> Or(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Or(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Or(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> Or(Vector64<long> left, Vector64<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Or(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Or(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> Or(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Or(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> Or(Vector64<ulong> left, Vector64<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Or(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Or(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Or(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Or(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Or(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Or(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Or(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Or(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Or(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Or(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> OrNot(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> OrNot(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> OrNot(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> OrNot(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> OrNot(Vector64<long> left, Vector64<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> OrNot(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> OrNot(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> OrNot(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> OrNot(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> OrNot(Vector64<ulong> left, Vector64<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> OrNot(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> OrNot(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> OrNot(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> OrNot(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> OrNot(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> OrNot(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> OrNot(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> OrNot(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> OrNot(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> OrNot(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> PolynomialMultiply(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> PolynomialMultiply(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> PolynomialMultiply(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> PolynomialMultiply(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> PolynomialMultiplyWideningLower(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> PolynomialMultiplyWideningLower(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> PolynomialMultiplyWideningUpper(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> PolynomialMultiplyWideningUpper(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> PopCount(Vector64<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> PopCount(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> PopCount(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> PopCount(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> ReciprocalEstimate(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ReciprocalEstimate(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReciprocalEstimate(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ReciprocalEstimate(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> ReciprocalSquareRootEstimate(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ReciprocalSquareRootEstimate(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReciprocalSquareRootEstimate(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ReciprocalSquareRootEstimate(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> ReciprocalSquareRootStep(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReciprocalSquareRootStep(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> ReciprocalStep(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> ReciprocalStep(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ReverseElement16(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ReverseElement16(Vector64<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ReverseElement16(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ReverseElement16(Vector64<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ReverseElement16(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ReverseElement16(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ReverseElement16(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ReverseElement16(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ReverseElement32(Vector64<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ReverseElement32(Vector64<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ReverseElement32(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ReverseElement32(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ReverseElement8(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ReverseElement8(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ReverseElement8(Vector64<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ReverseElement8(Vector64<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ReverseElement8(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ReverseElement8(Vector64<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ReverseElement8(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ReverseElement8(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ReverseElement8(Vector128<long> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ReverseElement8(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ReverseElement8(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ReverseElement8(Vector128<ulong> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundAwayFromZero(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RoundAwayFromZero(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> RoundAwayFromZeroScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundAwayFromZeroScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundToNearest(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RoundToNearest(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> RoundToNearestScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundToNearestScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundToNegativeInfinity(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RoundToNegativeInfinity(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> RoundToNegativeInfinityScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundToNegativeInfinityScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundToPositiveInfinity(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RoundToPositiveInfinity(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> RoundToPositiveInfinityScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundToPositiveInfinityScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundToZero(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> RoundToZero(Vector128<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> RoundToZeroScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> RoundToZeroScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftArithmetic(Vector64<short> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftArithmetic(Vector64<int> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftArithmetic(Vector64<sbyte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftArithmetic(Vector128<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftArithmetic(Vector128<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftArithmetic(Vector128<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftArithmetic(Vector128<sbyte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftArithmeticRounded(Vector64<short> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftArithmeticRounded(Vector64<int> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftArithmeticRounded(Vector64<sbyte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftArithmeticRounded(Vector128<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftArithmeticRounded(Vector128<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftArithmeticRounded(Vector128<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftArithmeticRounded(Vector128<sbyte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftArithmeticRoundedSaturate(Vector64<short> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftArithmeticRoundedSaturate(Vector64<int> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftArithmeticRoundedSaturate(Vector64<sbyte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftArithmeticRoundedSaturate(Vector128<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftArithmeticRoundedSaturate(Vector128<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftArithmeticRoundedSaturate(Vector128<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftArithmeticRoundedSaturate(Vector128<sbyte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftArithmeticRoundedSaturateScalar(Vector64<long> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftArithmeticRoundedScalar(Vector64<long> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftArithmeticSaturate(Vector64<short> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftArithmeticSaturate(Vector64<int> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftArithmeticSaturate(Vector64<sbyte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftArithmeticSaturate(Vector128<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftArithmeticSaturate(Vector128<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftArithmeticSaturate(Vector128<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftArithmeticSaturate(Vector128<sbyte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftArithmeticSaturateScalar(Vector64<long> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftArithmeticScalar(Vector64<long> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftLeftAndInsert(Vector64<byte> left, Vector64<byte> right, [ConstantExpected(Max = 63)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftLeftAndInsert(Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 31)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftLeftAndInsert(Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 15)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftLeftAndInsert(Vector64<sbyte> left, Vector64<sbyte> right, [ConstantExpected(Max = 63)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftLeftAndInsert(Vector64<ushort> left, Vector64<ushort> right, [ConstantExpected(Max = 31)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftLeftAndInsert(Vector64<uint> left, Vector64<uint> right, [ConstantExpected(Max = 15)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftLeftAndInsert(Vector128<byte> left, Vector128<byte> right, [ConstantExpected(Max = 127)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLeftAndInsert(Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 63)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftLeftAndInsert(Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 31)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftLeftAndInsert(Vector128<long> left, Vector128<long> right, [ConstantExpected(Max = 15)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftLeftAndInsert(Vector128<sbyte> left, Vector128<sbyte> right, [ConstantExpected(Max = 127)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLeftAndInsert(Vector128<ushort> left, Vector128<ushort> right, [ConstantExpected(Max = 63)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLeftAndInsert(Vector128<uint> left, Vector128<uint> right, [ConstantExpected(Max = 31)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLeftAndInsert(Vector128<ulong> left, Vector128<ulong> right, [ConstantExpected(Max = 15)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftLeftAndInsertScalar(Vector64<long> left, Vector64<long> right, [ConstantExpected(Max = 7)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftLeftAndInsertScalar(Vector64<ulong> left, Vector64<ulong> right, [ConstantExpected(Max = 7)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftLeftLogical(Vector64<byte> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftLeftLogical(Vector64<short> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftLeftLogical(Vector64<int> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftLeftLogical(Vector64<sbyte> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftLeftLogical(Vector64<ushort> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftLeftLogical(Vector64<uint> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftLeftLogical(Vector128<byte> value, [ConstantExpected(Max = 127)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLeftLogical(Vector128<short> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftLeftLogical(Vector128<long> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftLeftLogical(Vector128<sbyte> value, [ConstantExpected(Max = 127)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLeftLogical(Vector128<ushort> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLeftLogical(Vector128<uint> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLeftLogical(Vector128<ulong> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftLeftLogicalSaturate(Vector64<byte> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftLeftLogicalSaturate(Vector64<short> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftLeftLogicalSaturate(Vector64<int> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftLeftLogicalSaturate(Vector64<sbyte> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftLeftLogicalSaturate(Vector64<ushort> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftLeftLogicalSaturate(Vector64<uint> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftLeftLogicalSaturate(Vector128<byte> value, [ConstantExpected(Max = 127)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLeftLogicalSaturate(Vector128<short> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftLeftLogicalSaturate(Vector128<int> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftLeftLogicalSaturate(Vector128<long> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftLeftLogicalSaturate(Vector128<sbyte> value, [ConstantExpected(Max = 127)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLeftLogicalSaturate(Vector128<ushort> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLeftLogicalSaturate(Vector128<uint> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLeftLogicalSaturate(Vector128<ulong> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftLeftLogicalSaturateScalar(Vector64<long> value, [ConstantExpected(Max = 7)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftLeftLogicalSaturateScalar(Vector64<ulong> value, [ConstantExpected(Max = 7)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftLeftLogicalSaturateUnsigned(Vector64<short> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftLeftLogicalSaturateUnsigned(Vector64<int> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftLeftLogicalSaturateUnsigned(Vector64<sbyte> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLeftLogicalSaturateUnsigned(Vector128<short> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLeftLogicalSaturateUnsigned(Vector128<int> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLeftLogicalSaturateUnsigned(Vector128<long> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftLeftLogicalSaturateUnsigned(Vector128<sbyte> value, [ConstantExpected(Max = 127)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftLeftLogicalSaturateUnsignedScalar(Vector64<long> value, [ConstantExpected(Max = 7)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftLeftLogicalScalar(Vector64<long> value, [ConstantExpected(Max = 7)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftLeftLogicalScalar(Vector64<ulong> value, [ConstantExpected(Max = 7)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLeftLogicalWideningLower(Vector64<byte> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftLeftLogicalWideningLower(Vector64<short> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftLeftLogicalWideningLower(Vector64<int> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLeftLogicalWideningLower(Vector64<sbyte> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLeftLogicalWideningLower(Vector64<ushort> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLeftLogicalWideningLower(Vector64<uint> value, [ConstantExpected(Max = 15)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLeftLogicalWideningUpper(Vector128<byte> value, [ConstantExpected(Max = 127)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftLeftLogicalWideningUpper(Vector128<short> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftLeftLogicalWideningUpper(Vector128<int> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLeftLogicalWideningUpper(Vector128<sbyte> value, [ConstantExpected(Max = 127)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLeftLogicalWideningUpper(Vector128<ushort> value, [ConstantExpected(Max = 63)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLeftLogicalWideningUpper(Vector128<uint> value, [ConstantExpected(Max = 31)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftLogical(Vector64<byte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftLogical(Vector64<short> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftLogical(Vector64<int> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftLogical(Vector64<sbyte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftLogical(Vector64<ushort> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftLogical(Vector64<uint> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftLogical(Vector128<byte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLogical(Vector128<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftLogical(Vector128<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftLogical(Vector128<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftLogical(Vector128<sbyte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLogical(Vector128<ushort> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLogical(Vector128<uint> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLogical(Vector128<ulong> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftLogicalRounded(Vector64<byte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftLogicalRounded(Vector64<short> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftLogicalRounded(Vector64<int> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftLogicalRounded(Vector64<sbyte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftLogicalRounded(Vector64<ushort> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftLogicalRounded(Vector64<uint> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftLogicalRounded(Vector128<byte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLogicalRounded(Vector128<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftLogicalRounded(Vector128<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftLogicalRounded(Vector128<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftLogicalRounded(Vector128<sbyte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLogicalRounded(Vector128<ushort> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLogicalRounded(Vector128<uint> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLogicalRounded(Vector128<ulong> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftLogicalRoundedSaturate(Vector64<byte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftLogicalRoundedSaturate(Vector64<short> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftLogicalRoundedSaturate(Vector64<int> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftLogicalRoundedSaturate(Vector64<sbyte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftLogicalRoundedSaturate(Vector64<ushort> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftLogicalRoundedSaturate(Vector64<uint> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftLogicalRoundedSaturate(Vector128<byte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLogicalRoundedSaturate(Vector128<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftLogicalRoundedSaturate(Vector128<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftLogicalRoundedSaturate(Vector128<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftLogicalRoundedSaturate(Vector128<sbyte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLogicalRoundedSaturate(Vector128<ushort> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLogicalRoundedSaturate(Vector128<uint> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLogicalRoundedSaturate(Vector128<ulong> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftLogicalRoundedSaturateScalar(Vector64<long> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftLogicalRoundedSaturateScalar(Vector64<ulong> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftLogicalRoundedScalar(Vector64<long> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftLogicalRoundedScalar(Vector64<ulong> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftLogicalSaturate(Vector64<byte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftLogicalSaturate(Vector64<short> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftLogicalSaturate(Vector64<int> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftLogicalSaturate(Vector64<sbyte> value, Vector64<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftLogicalSaturate(Vector64<ushort> value, Vector64<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftLogicalSaturate(Vector64<uint> value, Vector64<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftLogicalSaturate(Vector128<byte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftLogicalSaturate(Vector128<short> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftLogicalSaturate(Vector128<int> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftLogicalSaturate(Vector128<long> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftLogicalSaturate(Vector128<sbyte> value, Vector128<sbyte> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftLogicalSaturate(Vector128<ushort> value, Vector128<short> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftLogicalSaturate(Vector128<uint> value, Vector128<int> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftLogicalSaturate(Vector128<ulong> value, Vector128<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftLogicalSaturateScalar(Vector64<long> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftLogicalSaturateScalar(Vector64<ulong> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftLogicalScalar(Vector64<long> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftLogicalScalar(Vector64<ulong> value, Vector64<long> count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightAndInsert(Vector64<byte> left, Vector64<byte> right, [ConstantExpected(Min = 1, Max = 64)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightAndInsert(Vector64<short> left, Vector64<short> right, [ConstantExpected(Min = 1, Max = 32)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightAndInsert(Vector64<int> left, Vector64<int> right, [ConstantExpected(Min = 1, Max = 16)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightAndInsert(Vector64<sbyte> left, Vector64<sbyte> right, [ConstantExpected(Min = 1, Max = 64)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightAndInsert(Vector64<ushort> left, Vector64<ushort> right, [ConstantExpected(Min = 1, Max = 32)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightAndInsert(Vector64<uint> left, Vector64<uint> right, [ConstantExpected(Min = 1, Max = 16)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightAndInsert(Vector128<byte> left, Vector128<byte> right, [ConstantExpected(Min = 1, Max = 128)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightAndInsert(Vector128<short> left, Vector128<short> right, [ConstantExpected(Min = 1, Max = 64)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightAndInsert(Vector128<int> left, Vector128<int> right, [ConstantExpected(Min = 1, Max = 32)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightAndInsert(Vector128<long> left, Vector128<long> right, [ConstantExpected(Min = 1, Max = 16)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightAndInsert(Vector128<sbyte> left, Vector128<sbyte> right, [ConstantExpected(Min = 1, Max = 128)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightAndInsert(Vector128<ushort> left, Vector128<ushort> right, [ConstantExpected(Min = 1, Max = 64)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightAndInsert(Vector128<uint> left, Vector128<uint> right, [ConstantExpected(Min = 1, Max = 32)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftRightAndInsert(Vector128<ulong> left, Vector128<ulong> right, [ConstantExpected(Min = 1, Max = 16)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftRightAndInsertScalar(Vector64<long> left, Vector64<long> right, [ConstantExpected(Min = 1, Max = 8)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftRightAndInsertScalar(Vector64<ulong> left, Vector64<ulong> right, [ConstantExpected(Min = 1, Max = 8)] byte shift)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightArithmetic(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightArithmetic(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightArithmetic(Vector64<sbyte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightArithmetic(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightArithmetic(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightArithmetic(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightArithmetic(Vector128<sbyte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightArithmeticAdd(Vector64<short> addend, Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightArithmeticAdd(Vector64<int> addend, Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightArithmeticAdd(Vector64<sbyte> addend, Vector64<sbyte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightArithmeticAdd(Vector128<short> addend, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightArithmeticAdd(Vector128<int> addend, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightArithmeticAdd(Vector128<long> addend, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightArithmeticAdd(Vector128<sbyte> addend, Vector128<sbyte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftRightArithmeticAddScalar(Vector64<long> addend, Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightArithmeticNarrowingSaturateLower(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightArithmeticNarrowingSaturateLower(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightArithmeticNarrowingSaturateLower(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightArithmeticNarrowingSaturateUnsignedLower(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightArithmeticNarrowingSaturateUnsignedLower(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightArithmeticNarrowingSaturateUnsignedLower(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightArithmeticNarrowingSaturateUnsignedUpper(Vector64<byte> lower, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightArithmeticNarrowingSaturateUnsignedUpper(Vector64<ushort> lower, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightArithmeticNarrowingSaturateUnsignedUpper(Vector64<uint> lower, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightArithmeticNarrowingSaturateUpper(Vector64<short> lower, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightArithmeticNarrowingSaturateUpper(Vector64<int> lower, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightArithmeticNarrowingSaturateUpper(Vector64<sbyte> lower, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightArithmeticRounded(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightArithmeticRounded(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightArithmeticRounded(Vector64<sbyte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightArithmeticRounded(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightArithmeticRounded(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightArithmeticRounded(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightArithmeticRounded(Vector128<sbyte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightArithmeticRoundedAdd(Vector64<short> addend, Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightArithmeticRoundedAdd(Vector64<int> addend, Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightArithmeticRoundedAdd(Vector64<sbyte> addend, Vector64<sbyte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightArithmeticRoundedAdd(Vector128<short> addend, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightArithmeticRoundedAdd(Vector128<int> addend, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightArithmeticRoundedAdd(Vector128<long> addend, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightArithmeticRoundedAdd(Vector128<sbyte> addend, Vector128<sbyte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftRightArithmeticRoundedAddScalar(Vector64<long> addend, Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightArithmeticRoundedNarrowingSaturateLower(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightArithmeticRoundedNarrowingSaturateLower(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightArithmeticRoundedNarrowingSaturateLower(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper(Vector64<byte> lower, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper(Vector64<ushort> lower, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper(Vector64<uint> lower, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightArithmeticRoundedNarrowingSaturateUpper(Vector64<short> lower, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightArithmeticRoundedNarrowingSaturateUpper(Vector64<int> lower, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightArithmeticRoundedNarrowingSaturateUpper(Vector64<sbyte> lower, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftRightArithmeticRoundedScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftRightArithmeticScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightLogical(Vector64<byte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightLogical(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightLogical(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightLogical(Vector64<sbyte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightLogical(Vector64<ushort> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightLogical(Vector64<uint> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightLogical(Vector128<byte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightLogical(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightLogical(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightLogical(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightLogical(Vector128<sbyte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightLogical(Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightLogical(Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftRightLogical(Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightLogicalAdd(Vector64<byte> addend, Vector64<byte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightLogicalAdd(Vector64<short> addend, Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightLogicalAdd(Vector64<int> addend, Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightLogicalAdd(Vector64<sbyte> addend, Vector64<sbyte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightLogicalAdd(Vector64<ushort> addend, Vector64<ushort> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightLogicalAdd(Vector64<uint> addend, Vector64<uint> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightLogicalAdd(Vector128<byte> addend, Vector128<byte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightLogicalAdd(Vector128<short> addend, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightLogicalAdd(Vector128<int> addend, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightLogicalAdd(Vector128<long> addend, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightLogicalAdd(Vector128<sbyte> addend, Vector128<sbyte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightLogicalAdd(Vector128<ushort> addend, Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightLogicalAdd(Vector128<uint> addend, Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftRightLogicalAdd(Vector128<ulong> addend, Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftRightLogicalAddScalar(Vector64<long> addend, Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftRightLogicalAddScalar(Vector64<ulong> addend, Vector64<ulong> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightLogicalNarrowingLower(Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightLogicalNarrowingLower(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightLogicalNarrowingLower(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightLogicalNarrowingLower(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightLogicalNarrowingLower(Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightLogicalNarrowingLower(Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightLogicalNarrowingSaturateLower(Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightLogicalNarrowingSaturateLower(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightLogicalNarrowingSaturateLower(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightLogicalNarrowingSaturateLower(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightLogicalNarrowingSaturateLower(Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightLogicalNarrowingSaturateLower(Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightLogicalNarrowingSaturateUpper(Vector64<byte> lower, Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightLogicalNarrowingSaturateUpper(Vector64<short> lower, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightLogicalNarrowingSaturateUpper(Vector64<int> lower, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightLogicalNarrowingSaturateUpper(Vector64<sbyte> lower, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightLogicalNarrowingSaturateUpper(Vector64<ushort> lower, Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightLogicalNarrowingSaturateUpper(Vector64<uint> lower, Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightLogicalNarrowingUpper(Vector64<byte> lower, Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightLogicalNarrowingUpper(Vector64<short> lower, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightLogicalNarrowingUpper(Vector64<int> lower, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightLogicalNarrowingUpper(Vector64<sbyte> lower, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightLogicalNarrowingUpper(Vector64<ushort> lower, Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightLogicalNarrowingUpper(Vector64<uint> lower, Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightLogicalRounded(Vector64<byte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightLogicalRounded(Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightLogicalRounded(Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightLogicalRounded(Vector64<sbyte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightLogicalRounded(Vector64<ushort> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightLogicalRounded(Vector64<uint> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightLogicalRounded(Vector128<byte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightLogicalRounded(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightLogicalRounded(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightLogicalRounded(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightLogicalRounded(Vector128<sbyte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightLogicalRounded(Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightLogicalRounded(Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftRightLogicalRounded(Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightLogicalRoundedAdd(Vector64<byte> addend, Vector64<byte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightLogicalRoundedAdd(Vector64<short> addend, Vector64<short> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightLogicalRoundedAdd(Vector64<int> addend, Vector64<int> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightLogicalRoundedAdd(Vector64<sbyte> addend, Vector64<sbyte> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightLogicalRoundedAdd(Vector64<ushort> addend, Vector64<ushort> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightLogicalRoundedAdd(Vector64<uint> addend, Vector64<uint> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightLogicalRoundedAdd(Vector128<byte> addend, Vector128<byte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightLogicalRoundedAdd(Vector128<short> addend, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightLogicalRoundedAdd(Vector128<int> addend, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ShiftRightLogicalRoundedAdd(Vector128<long> addend, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightLogicalRoundedAdd(Vector128<sbyte> addend, Vector128<sbyte> value, [ConstantExpected(Min = 1, Max = 128)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightLogicalRoundedAdd(Vector128<ushort> addend, Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightLogicalRoundedAdd(Vector128<uint> addend, Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ShiftRightLogicalRoundedAdd(Vector128<ulong> addend, Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftRightLogicalRoundedAddScalar(Vector64<long> addend, Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftRightLogicalRoundedAddScalar(Vector64<ulong> addend, Vector64<ulong> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightLogicalRoundedNarrowingLower(Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightLogicalRoundedNarrowingLower(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightLogicalRoundedNarrowingLower(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightLogicalRoundedNarrowingLower(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightLogicalRoundedNarrowingLower(Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightLogicalRoundedNarrowingLower(Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<byte> lower, Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<short> lower, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<int> lower, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<sbyte> lower, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<ushort> lower, Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<uint> lower, Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> ShiftRightLogicalRoundedNarrowingUpper(Vector64<byte> lower, Vector128<ushort> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ShiftRightLogicalRoundedNarrowingUpper(Vector64<short> lower, Vector128<int> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ShiftRightLogicalRoundedNarrowingUpper(Vector64<int> lower, Vector128<long> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> ShiftRightLogicalRoundedNarrowingUpper(Vector64<sbyte> lower, Vector128<short> value, [ConstantExpected(Min = 1, Max = 64)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ShiftRightLogicalRoundedNarrowingUpper(Vector64<ushort> lower, Vector128<uint> value, [ConstantExpected(Min = 1, Max = 32)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ShiftRightLogicalRoundedNarrowingUpper(Vector64<uint> lower, Vector128<ulong> value, [ConstantExpected(Min = 1, Max = 16)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftRightLogicalRoundedScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftRightLogicalRoundedScalar(Vector64<ulong> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> ShiftRightLogicalScalar(Vector64<long> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> ShiftRightLogicalScalar(Vector64<ulong> value, [ConstantExpected(Min = 1, Max = 8)] byte count)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> SignExtendWideningLower(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> SignExtendWideningLower(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> SignExtendWideningLower(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> SignExtendWideningUpper(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> SignExtendWideningUpper(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> SignExtendWideningUpper(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> SqrtScalar(Vector64<double> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> SqrtScalar(Vector64<float> value)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(byte* address, Vector64<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(double* address, Vector64<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(short* address, Vector64<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(int* address, Vector64<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(long* address, Vector64<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(sbyte* address, Vector64<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(float* address, Vector64<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(ushort* address, Vector64<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(uint* address, Vector64<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(ulong* address, Vector64<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(byte* address, Vector128<byte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(double* address, Vector128<double> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(short* address, Vector128<short> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(int* address, Vector128<int> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(long* address, Vector128<long> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(sbyte* address, Vector128<sbyte> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(float* address, Vector128<float> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(ushort* address, Vector128<ushort> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(uint* address, Vector128<uint> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void Store(ulong* address, Vector128<ulong> source)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(byte* address, Vector64<byte> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(short* address, Vector64<short> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(int* address, Vector64<int> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(sbyte* address, Vector64<sbyte> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(float* address, Vector64<float> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(ushort* address, Vector64<ushort> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(uint* address, Vector64<uint> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(byte* address, Vector128<byte> value, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(double* address, Vector128<double> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(short* address, Vector128<short> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(int* address, Vector128<int> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(long* address, Vector128<long> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(sbyte* address, Vector128<sbyte> value, [ConstantExpected(Max = 15)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(float* address, Vector128<float> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(ushort* address, Vector128<ushort> value, [ConstantExpected(Max = 7)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(uint* address, Vector128<uint> value, [ConstantExpected(Max = 3)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public unsafe static void StoreSelectedScalar(ulong* address, Vector128<ulong> value, [ConstantExpected(Max = 1)] byte index)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Subtract(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Subtract(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Subtract(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Subtract(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Subtract(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> Subtract(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Subtract(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Subtract(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Subtract(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Subtract(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Subtract(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Subtract(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Subtract(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Subtract(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Subtract(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Subtract(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> SubtractHighNarrowingLower(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> SubtractHighNarrowingLower(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> SubtractHighNarrowingLower(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> SubtractHighNarrowingLower(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> SubtractHighNarrowingLower(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> SubtractHighNarrowingLower(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> SubtractHighNarrowingUpper(Vector64<byte> lower, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> SubtractHighNarrowingUpper(Vector64<short> lower, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> SubtractHighNarrowingUpper(Vector64<int> lower, Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> SubtractHighNarrowingUpper(Vector64<sbyte> lower, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> SubtractHighNarrowingUpper(Vector64<ushort> lower, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> SubtractHighNarrowingUpper(Vector64<uint> lower, Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> SubtractRoundedHighNarrowingLower(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> SubtractRoundedHighNarrowingLower(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> SubtractRoundedHighNarrowingLower(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> SubtractRoundedHighNarrowingLower(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> SubtractRoundedHighNarrowingLower(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> SubtractRoundedHighNarrowingLower(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> SubtractRoundedHighNarrowingUpper(Vector64<byte> lower, Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> SubtractRoundedHighNarrowingUpper(Vector64<short> lower, Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> SubtractRoundedHighNarrowingUpper(Vector64<int> lower, Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> SubtractRoundedHighNarrowingUpper(Vector64<sbyte> lower, Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> SubtractRoundedHighNarrowingUpper(Vector64<ushort> lower, Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> SubtractRoundedHighNarrowingUpper(Vector64<uint> lower, Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> SubtractSaturate(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> SubtractSaturate(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> SubtractSaturate(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> SubtractSaturate(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> SubtractSaturate(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> SubtractSaturate(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> SubtractSaturate(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> SubtractSaturate(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> SubtractSaturate(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> SubtractSaturate(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> SubtractSaturate(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> SubtractSaturate(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> SubtractSaturate(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> SubtractSaturate(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> SubtractSaturateScalar(Vector64<long> left, Vector64<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> SubtractSaturateScalar(Vector64<ulong> left, Vector64<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> SubtractScalar(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> SubtractScalar(Vector64<long> left, Vector64<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> SubtractScalar(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> SubtractScalar(Vector64<ulong> left, Vector64<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> SubtractWideningLower(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> SubtractWideningLower(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> SubtractWideningLower(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> SubtractWideningLower(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> SubtractWideningLower(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> SubtractWideningLower(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> SubtractWideningLower(Vector128<short> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> SubtractWideningLower(Vector128<int> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> SubtractWideningLower(Vector128<long> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> SubtractWideningLower(Vector128<ushort> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> SubtractWideningLower(Vector128<uint> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> SubtractWideningLower(Vector128<ulong> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> SubtractWideningUpper(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> SubtractWideningUpper(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> SubtractWideningUpper(Vector128<short> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> SubtractWideningUpper(Vector128<int> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> SubtractWideningUpper(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> SubtractWideningUpper(Vector128<long> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> SubtractWideningUpper(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> SubtractWideningUpper(Vector128<ushort> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> SubtractWideningUpper(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> SubtractWideningUpper(Vector128<uint> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> SubtractWideningUpper(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> SubtractWideningUpper(Vector128<ulong> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> VectorTableLookup(Vector128<byte> table, Vector64<byte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> VectorTableLookup(Vector128<sbyte> table, Vector64<sbyte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> VectorTableLookup((Vector128<byte>, Vector128<byte>) table, Vector64<byte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> VectorTableLookup((Vector128<sbyte>, Vector128<sbyte>) table, Vector64<sbyte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> VectorTableLookup((Vector128<byte>, Vector128<byte>, Vector128<byte>) table, Vector64<byte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> VectorTableLookup((Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>) table, Vector64<sbyte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> VectorTableLookup((Vector128<byte>, Vector128<byte>, Vector128<byte>, Vector128<byte>) table, Vector64<byte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> VectorTableLookup((Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>) table, Vector64<sbyte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> VectorTableLookupExtension(Vector64<byte> defaultValues, Vector128<byte> table, Vector64<byte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> VectorTableLookupExtension(Vector64<sbyte> defaultValues, Vector128<sbyte> table, Vector64<sbyte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> VectorTableLookupExtension(Vector64<byte> defaultValues, (Vector128<byte>, Vector128<byte>) table, Vector64<byte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> VectorTableLookupExtension(Vector64<sbyte> defaultValues, (Vector128<sbyte>, Vector128<sbyte>) table, Vector64<sbyte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> VectorTableLookupExtension(Vector64<byte> defaultValues, (Vector128<byte>, Vector128<byte>, Vector128<byte>) table, Vector64<byte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> VectorTableLookupExtension(Vector64<sbyte> defaultValues, (Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>) table, Vector64<sbyte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> VectorTableLookupExtension(Vector64<byte> defaultValues, (Vector128<byte>, Vector128<byte>, Vector128<byte>, Vector128<byte>) table, Vector64<byte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> VectorTableLookupExtension(Vector64<sbyte> defaultValues, (Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>, Vector128<sbyte>) table, Vector64<sbyte> byteIndexes)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<byte> Xor(Vector64<byte> left, Vector64<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<double> Xor(Vector64<double> left, Vector64<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<short> Xor(Vector64<short> left, Vector64<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<int> Xor(Vector64<int> left, Vector64<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<long> Xor(Vector64<long> left, Vector64<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<sbyte> Xor(Vector64<sbyte> left, Vector64<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<float> Xor(Vector64<float> left, Vector64<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ushort> Xor(Vector64<ushort> left, Vector64<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<uint> Xor(Vector64<uint> left, Vector64<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector64<ulong> Xor(Vector64<ulong> left, Vector64<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<byte> Xor(Vector128<byte> left, Vector128<byte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<double> Xor(Vector128<double> left, Vector128<double> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> Xor(Vector128<short> left, Vector128<short> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> Xor(Vector128<int> left, Vector128<int> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> Xor(Vector128<long> left, Vector128<long> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<sbyte> Xor(Vector128<sbyte> left, Vector128<sbyte> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<float> Xor(Vector128<float> left, Vector128<float> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> Xor(Vector128<ushort> left, Vector128<ushort> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> Xor(Vector128<uint> left, Vector128<uint> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> Xor(Vector128<ulong> left, Vector128<ulong> right)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ZeroExtendWideningLower(Vector64<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ZeroExtendWideningLower(Vector64<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ZeroExtendWideningLower(Vector64<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ZeroExtendWideningLower(Vector64<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ZeroExtendWideningLower(Vector64<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ZeroExtendWideningLower(Vector64<uint> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ushort> ZeroExtendWideningUpper(Vector128<byte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<int> ZeroExtendWideningUpper(Vector128<short> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<long> ZeroExtendWideningUpper(Vector128<int> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<short> ZeroExtendWideningUpper(Vector128<sbyte> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<uint> ZeroExtendWideningUpper(Vector128<ushort> value)
	{
		throw new PlatformNotSupportedException();
	}

	public static Vector128<ulong> ZeroExtendWideningUpper(Vector128<uint> value)
	{
		throw new PlatformNotSupportedException();
	}
}
