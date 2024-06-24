using System.Runtime.InteropServices;

namespace System.Text;

public abstract class Decoder
{
	internal DecoderFallback _fallback;

	internal DecoderFallbackBuffer _fallbackBuffer;

	public DecoderFallback? Fallback
	{
		get
		{
			return _fallback;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			if (_fallbackBuffer != null && _fallbackBuffer.Remaining > 0)
			{
				throw new ArgumentException(SR.Argument_FallbackBufferNotEmpty, "value");
			}
			_fallback = value;
			_fallbackBuffer = null;
		}
	}

	public DecoderFallbackBuffer FallbackBuffer
	{
		get
		{
			if (_fallbackBuffer == null)
			{
				_fallbackBuffer = ((_fallback != null) ? _fallback.CreateFallbackBuffer() : DecoderFallback.ReplacementFallback.CreateFallbackBuffer());
			}
			return _fallbackBuffer;
		}
	}

	internal bool InternalHasFallbackBuffer => _fallbackBuffer != null;

	public virtual void Reset()
	{
		byte[] bytes = Array.Empty<byte>();
		char[] chars = new char[GetCharCount(bytes, 0, 0, flush: true)];
		GetChars(bytes, 0, 0, chars, 0, flush: true);
		_fallbackBuffer?.Reset();
	}

	public abstract int GetCharCount(byte[] bytes, int index, int count);

	public virtual int GetCharCount(byte[] bytes, int index, int count, bool flush)
	{
		return GetCharCount(bytes, index, count);
	}

	[CLSCompliant(false)]
	public unsafe virtual int GetCharCount(byte* bytes, int count, bool flush)
	{
		ArgumentNullException.ThrowIfNull(bytes, "bytes");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		byte[] array = new byte[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = bytes[i];
		}
		return GetCharCount(array, 0, count);
	}

	public unsafe virtual int GetCharCount(ReadOnlySpan<byte> bytes, bool flush)
	{
		fixed (byte* bytes2 = &MemoryMarshal.GetNonNullPinnableReference(bytes))
		{
			return GetCharCount(bytes2, bytes.Length, flush);
		}
	}

	public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);

	public virtual int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool flush)
	{
		return GetChars(bytes, byteIndex, byteCount, chars, charIndex);
	}

	[CLSCompliant(false)]
	public unsafe virtual int GetChars(byte* bytes, int byteCount, char* chars, int charCount, bool flush)
	{
		ArgumentNullException.ThrowIfNull(bytes, "bytes");
		ArgumentNullException.ThrowIfNull(chars, "chars");
		ArgumentOutOfRangeException.ThrowIfNegative(byteCount, "byteCount");
		ArgumentOutOfRangeException.ThrowIfNegative(charCount, "charCount");
		byte[] array = new byte[byteCount];
		for (int i = 0; i < byteCount; i++)
		{
			array[i] = bytes[i];
		}
		char[] array2 = new char[charCount];
		int chars2 = GetChars(array, 0, byteCount, array2, 0, flush);
		if (chars2 < charCount)
		{
			charCount = chars2;
		}
		for (int j = 0; j < charCount; j++)
		{
			chars[j] = array2[j];
		}
		return charCount;
	}

	public unsafe virtual int GetChars(ReadOnlySpan<byte> bytes, Span<char> chars, bool flush)
	{
		fixed (byte* bytes2 = &MemoryMarshal.GetNonNullPinnableReference(bytes))
		{
			fixed (char* chars2 = &MemoryMarshal.GetNonNullPinnableReference(chars))
			{
				return GetChars(bytes2, bytes.Length, chars2, chars.Length, flush);
			}
		}
	}

	public virtual void Convert(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed)
	{
		ArgumentNullException.ThrowIfNull(bytes, "bytes");
		ArgumentNullException.ThrowIfNull(chars, "chars");
		ArgumentOutOfRangeException.ThrowIfNegative(byteIndex, "byteIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(byteCount, "byteCount");
		ArgumentOutOfRangeException.ThrowIfNegative(charIndex, "charIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(charCount, "charCount");
		if (bytes.Length - byteIndex < byteCount)
		{
			throw new ArgumentOutOfRangeException("bytes", SR.ArgumentOutOfRange_IndexCountBuffer);
		}
		if (chars.Length - charIndex < charCount)
		{
			throw new ArgumentOutOfRangeException("chars", SR.ArgumentOutOfRange_IndexCountBuffer);
		}
		for (bytesUsed = byteCount; bytesUsed > 0; bytesUsed /= 2)
		{
			if (GetCharCount(bytes, byteIndex, bytesUsed, flush) <= charCount)
			{
				charsUsed = GetChars(bytes, byteIndex, bytesUsed, chars, charIndex, flush);
				completed = bytesUsed == byteCount && (_fallbackBuffer == null || _fallbackBuffer.Remaining == 0);
				return;
			}
			flush = false;
		}
		throw new ArgumentException(SR.Argument_ConversionOverflow);
	}

	[CLSCompliant(false)]
	public unsafe virtual void Convert(byte* bytes, int byteCount, char* chars, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed)
	{
		ArgumentNullException.ThrowIfNull(bytes, "bytes");
		ArgumentNullException.ThrowIfNull(chars, "chars");
		ArgumentOutOfRangeException.ThrowIfNegative(byteCount, "byteCount");
		ArgumentOutOfRangeException.ThrowIfNegative(charCount, "charCount");
		for (bytesUsed = byteCount; bytesUsed > 0; bytesUsed /= 2)
		{
			if (GetCharCount(bytes, bytesUsed, flush) <= charCount)
			{
				charsUsed = GetChars(bytes, bytesUsed, chars, charCount, flush);
				completed = bytesUsed == byteCount && (_fallbackBuffer == null || _fallbackBuffer.Remaining == 0);
				return;
			}
			flush = false;
		}
		throw new ArgumentException(SR.Argument_ConversionOverflow);
	}

	public unsafe virtual void Convert(ReadOnlySpan<byte> bytes, Span<char> chars, bool flush, out int bytesUsed, out int charsUsed, out bool completed)
	{
		fixed (byte* bytes2 = &MemoryMarshal.GetNonNullPinnableReference(bytes))
		{
			fixed (char* chars2 = &MemoryMarshal.GetNonNullPinnableReference(chars))
			{
				Convert(bytes2, bytes.Length, chars2, chars.Length, flush, out bytesUsed, out charsUsed, out completed);
			}
		}
	}
}
