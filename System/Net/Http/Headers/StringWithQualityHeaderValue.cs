using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Net.Http.Headers;

public class StringWithQualityHeaderValue : ICloneable
{
	private readonly string _value;

	private readonly double _quality;

	public string Value => _value;

	public double? Quality
	{
		get
		{
			if (_quality != double.PositiveInfinity)
			{
				return _quality;
			}
			return null;
		}
	}

	public StringWithQualityHeaderValue(string value)
	{
		HeaderUtilities.CheckValidToken(value, "value");
		_value = value;
		_quality = double.PositiveInfinity;
	}

	public StringWithQualityHeaderValue(string value, double quality)
	{
		HeaderUtilities.CheckValidToken(value, "value");
		ArgumentOutOfRangeException.ThrowIfNegative(quality, "quality");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(quality, 1.0, "quality");
		_value = value;
		_quality = quality;
	}

	private StringWithQualityHeaderValue(StringWithQualityHeaderValue source)
	{
		_value = source._value;
		_quality = source._quality;
	}

	public override string ToString()
	{
		if (_quality == double.PositiveInfinity)
		{
			return _value;
		}
		IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
		IFormatProvider provider = invariantCulture;
		Span<char> initialBuffer = stackalloc char[128];
		DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(4, 2, invariantCulture, initialBuffer);
		handler.AppendFormatted(_value);
		handler.AppendLiteral("; q=");
		handler.AppendFormatted(_quality, "0.0##");
		return string.Create(provider, initialBuffer, ref handler);
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is StringWithQualityHeaderValue stringWithQualityHeaderValue && string.Equals(_value, stringWithQualityHeaderValue._value, StringComparison.OrdinalIgnoreCase))
		{
			return _quality == stringWithQualityHeaderValue._quality;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(StringComparer.OrdinalIgnoreCase.GetHashCode(_value), _quality);
	}

	public static StringWithQualityHeaderValue Parse(string input)
	{
		int index = 0;
		return (StringWithQualityHeaderValue)GenericHeaderParser.SingleValueStringWithQualityParser.ParseValue(input, null, ref index);
	}

	public static bool TryParse([NotNullWhen(true)] string? input, [NotNullWhen(true)] out StringWithQualityHeaderValue? parsedValue)
	{
		int index = 0;
		parsedValue = null;
		if (GenericHeaderParser.SingleValueStringWithQualityParser.TryParseValue(input, null, ref index, out var parsedValue2))
		{
			parsedValue = (StringWithQualityHeaderValue)parsedValue2;
			return true;
		}
		return false;
	}

	internal static int GetStringWithQualityLength(string input, int startIndex, out object parsedValue)
	{
		parsedValue = null;
		if (string.IsNullOrEmpty(input) || startIndex >= input.Length)
		{
			return 0;
		}
		int tokenLength = HttpRuleParser.GetTokenLength(input, startIndex);
		if (tokenLength == 0)
		{
			return 0;
		}
		string value = input.Substring(startIndex, tokenLength);
		int num = startIndex + tokenLength;
		num += HttpRuleParser.GetWhitespaceLength(input, num);
		if (num == input.Length || input[num] != ';')
		{
			parsedValue = new StringWithQualityHeaderValue(value);
			return num - startIndex;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(input, num);
		if (!TryReadQuality(input, out var quality, ref num))
		{
			return 0;
		}
		parsedValue = new StringWithQualityHeaderValue(value, quality);
		return num - startIndex;
	}

	private static bool TryReadQuality(string input, out double quality, ref int index)
	{
		int num = index;
		quality = 0.0;
		if (num == input.Length || (input[num] != 'q' && input[num] != 'Q'))
		{
			return false;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(input, num);
		if (num == input.Length || input[num] != '=')
		{
			return false;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(input, num);
		if (num == input.Length)
		{
			return false;
		}
		int numberLength = HttpRuleParser.GetNumberLength(input, num, allowDecimal: true);
		if (numberLength == 0)
		{
			return false;
		}
		if (!double.TryParse(input.AsSpan(num, numberLength), NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out quality))
		{
			return false;
		}
		if (quality < 0.0 || quality > 1.0)
		{
			return false;
		}
		num += numberLength;
		num += HttpRuleParser.GetWhitespaceLength(input, num);
		index = num;
		return true;
	}

	object ICloneable.Clone()
	{
		return new StringWithQualityHeaderValue(this);
	}
}
