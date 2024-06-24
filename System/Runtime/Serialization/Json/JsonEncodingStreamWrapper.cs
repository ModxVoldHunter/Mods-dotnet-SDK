using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml;

namespace System.Runtime.Serialization.Json;

internal sealed class JsonEncodingStreamWrapper : Stream
{
	private enum SupportedEncoding
	{
		UTF8,
		UTF16LE,
		UTF16BE,
		None
	}

	private const int BufferLength = 128;

	private int _byteCount;

	private int _byteOffset;

	private byte[] _bytes;

	private char[] _chars;

	private Decoder _dec;

	private Encoder _enc;

	private Encoding _encoding;

	private SupportedEncoding _encodingCode;

	private readonly bool _isReading;

	private BufferedStream _stream;

	public override bool CanRead
	{
		get
		{
			if (!_isReading)
			{
				return false;
			}
			return _stream.CanRead;
		}
	}

	public override bool CanSeek => false;

	public override bool CanTimeout => _stream.CanTimeout;

	public override bool CanWrite
	{
		get
		{
			if (_isReading)
			{
				return false;
			}
			return _stream.CanWrite;
		}
	}

	public override long Length => _stream.Length;

	public override long Position
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public override int ReadTimeout
	{
		get
		{
			return _stream.ReadTimeout;
		}
		set
		{
			_stream.ReadTimeout = value;
		}
	}

	public override int WriteTimeout
	{
		get
		{
			return _stream.WriteTimeout;
		}
		set
		{
			_stream.WriteTimeout = value;
		}
	}

	public JsonEncodingStreamWrapper(Stream stream, Encoding encoding, bool isReader)
	{
		_isReading = isReader;
		if (isReader)
		{
			InitForReading(stream, encoding);
			return;
		}
		ArgumentNullException.ThrowIfNull(encoding, "encoding");
		InitForWriting(stream, encoding);
	}

	public static ArraySegment<byte> ProcessBuffer(byte[] buffer, int offset, int count, Encoding encoding)
	{
		try
		{
			SupportedEncoding supportedEncoding = GetSupportedEncoding(encoding);
			SupportedEncoding supportedEncoding2 = ((count >= 2) ? ReadEncoding(buffer[offset], buffer[offset + 1]) : SupportedEncoding.UTF8);
			if (supportedEncoding != SupportedEncoding.None && supportedEncoding != supportedEncoding2)
			{
				ThrowExpectedEncodingMismatch(supportedEncoding, supportedEncoding2);
			}
			if (supportedEncoding2 == SupportedEncoding.UTF8)
			{
				return new ArraySegment<byte>(buffer, offset, count);
			}
			return new ArraySegment<byte>(DataContractSerializer.ValidatingUTF8.GetBytes(GetEncoding(supportedEncoding2).GetChars(buffer, offset, count)));
		}
		catch (DecoderFallbackException innerException)
		{
			throw new XmlException(System.SR.JsonInvalidBytes, innerException);
		}
	}

	protected override void Dispose(bool disposing)
	{
		Flush();
		_stream.Dispose();
		base.Dispose(disposing);
	}

	public override void Flush()
	{
		_stream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return Read(new Span<byte>(buffer, offset, count));
	}

	public override int Read(Span<byte> buffer)
	{
		try
		{
			if (_byteCount == 0)
			{
				if (_encodingCode == SupportedEncoding.UTF8)
				{
					return _stream.Read(buffer);
				}
				_byteOffset = 0;
				_byteCount = _stream.Read(_bytes, _byteCount, (_chars.Length - 1) * 2);
				if (_byteCount == 0)
				{
					return 0;
				}
				CleanupCharBreak();
				int chars = _encoding.GetChars(_bytes, 0, _byteCount, _chars, 0);
				_byteCount = Encoding.UTF8.GetBytes(_chars, 0, chars, _bytes, 0);
			}
			int num = buffer.Length;
			if (_byteCount < num)
			{
				num = _byteCount;
			}
			_bytes.AsSpan(_byteOffset, num).CopyTo(buffer);
			_byteOffset += num;
			_byteCount -= num;
			return num;
		}
		catch (DecoderFallbackException innerException)
		{
			throw new XmlException(System.SR.JsonInvalidBytes, innerException);
		}
	}

	public override int ReadByte()
	{
		if (_byteCount == 0 && _encodingCode == SupportedEncoding.UTF8)
		{
			return _stream.ReadByte();
		}
		byte reference = 0;
		if (Read(new Span<byte>(ref reference)) == 0)
		{
			return -1;
		}
		return reference;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		Write(new ReadOnlySpan<byte>(buffer, offset, count));
	}

	public override void Write(ReadOnlySpan<byte> buffer)
	{
		if (_encodingCode == SupportedEncoding.UTF8)
		{
			_stream.Write(buffer);
			return;
		}
		while (buffer.Length > 0)
		{
			int num = Math.Min(_chars.Length, buffer.Length);
			int chars = _dec.GetChars(buffer.Slice(0, num), _chars, flush: false);
			_byteCount = _enc.GetBytes(_chars, 0, chars, _bytes, 0, flush: false);
			_stream.Write(_bytes, 0, _byteCount);
			buffer = buffer.Slice(num);
		}
	}

	public override void WriteByte(byte b)
	{
		if (_encodingCode == SupportedEncoding.UTF8)
		{
			_stream.WriteByte(b);
		}
		else
		{
			Write(new ReadOnlySpan<byte>(ref b));
		}
	}

	private static Encoding GetEncoding(SupportedEncoding e)
	{
		return e switch
		{
			SupportedEncoding.UTF8 => DataContractSerializer.ValidatingUTF8, 
			SupportedEncoding.UTF16LE => DataContractSerializer.ValidatingUTF16, 
			SupportedEncoding.UTF16BE => DataContractSerializer.ValidatingBEUTF16, 
			_ => throw new XmlException(System.SR.JsonEncodingNotSupported), 
		};
	}

	private static string GetEncodingName(SupportedEncoding enc)
	{
		return enc switch
		{
			SupportedEncoding.UTF8 => "utf-8", 
			SupportedEncoding.UTF16LE => "utf-16LE", 
			SupportedEncoding.UTF16BE => "utf-16BE", 
			_ => throw new XmlException(System.SR.JsonEncodingNotSupported), 
		};
	}

	private static SupportedEncoding GetSupportedEncoding(Encoding encoding)
	{
		if (encoding == null)
		{
			return SupportedEncoding.None;
		}
		if (encoding.WebName == DataContractSerializer.ValidatingUTF8.WebName)
		{
			return SupportedEncoding.UTF8;
		}
		if (encoding.WebName == DataContractSerializer.ValidatingUTF16.WebName)
		{
			return SupportedEncoding.UTF16LE;
		}
		if (encoding.WebName == DataContractSerializer.ValidatingBEUTF16.WebName)
		{
			return SupportedEncoding.UTF16BE;
		}
		throw new XmlException(System.SR.JsonEncodingNotSupported);
	}

	private static SupportedEncoding ReadEncoding(byte b1, byte b2)
	{
		if (b1 == 0 && b2 != 0)
		{
			return SupportedEncoding.UTF16BE;
		}
		if (b1 != 0 && b2 == 0)
		{
			return SupportedEncoding.UTF16LE;
		}
		if (b1 == 0 && b2 == 0)
		{
			throw new XmlException(System.SR.JsonInvalidBytes);
		}
		return SupportedEncoding.UTF8;
	}

	private static void ThrowExpectedEncodingMismatch(SupportedEncoding expEnc, SupportedEncoding actualEnc)
	{
		throw new XmlException(System.SR.Format(System.SR.JsonExpectedEncoding, GetEncodingName(expEnc), GetEncodingName(actualEnc)));
	}

	private void CleanupCharBreak()
	{
		int num = _byteOffset + _byteCount;
		if (_byteCount % 2 != 0)
		{
			int num2 = _stream.ReadByte();
			if (num2 < 0)
			{
				throw new XmlException(System.SR.JsonUnexpectedEndOfFile);
			}
			_bytes[num++] = (byte)num2;
			_byteCount++;
		}
		int num3 = ((_encodingCode != SupportedEncoding.UTF16LE) ? (_bytes[num - 1] + (_bytes[num - 2] << 8)) : (_bytes[num - 2] + (_bytes[num - 1] << 8)));
		if ((num3 & 0xDC00) != 56320 && num3 >= 55296 && num3 <= 56319)
		{
			int num4 = _stream.ReadByte();
			int num5 = _stream.ReadByte();
			if (num5 < 0)
			{
				throw new XmlException(System.SR.JsonUnexpectedEndOfFile);
			}
			_bytes[num++] = (byte)num4;
			_bytes[num++] = (byte)num5;
			_byteCount += 2;
		}
	}

	[MemberNotNull("_chars")]
	[MemberNotNull("_bytes")]
	private void EnsureBuffers()
	{
		EnsureByteBuffer();
		if (_chars == null)
		{
			_chars = new char[128];
		}
	}

	[MemberNotNull("_bytes")]
	private void EnsureByteBuffer()
	{
		if (_bytes == null)
		{
			_bytes = new byte[512];
			_byteOffset = 0;
			_byteCount = 0;
		}
	}

	private void FillBuffer(int count)
	{
		count -= _byteCount;
		if (count > 0)
		{
			_byteCount += _stream.ReadAtLeast(_bytes.AsSpan(_byteOffset + _byteCount, count), count, throwOnEndOfStream: false);
		}
	}

	private void InitForReading(Stream inputStream, Encoding expectedEncoding)
	{
		try
		{
			_stream = new BufferedStream(inputStream);
			SupportedEncoding supportedEncoding = GetSupportedEncoding(expectedEncoding);
			SupportedEncoding supportedEncoding2 = ReadEncoding();
			if (supportedEncoding != SupportedEncoding.None && supportedEncoding != supportedEncoding2)
			{
				ThrowExpectedEncodingMismatch(supportedEncoding, supportedEncoding2);
			}
			if (supportedEncoding2 != 0)
			{
				EnsureBuffers();
				FillBuffer(254);
				_encodingCode = supportedEncoding2;
				_encoding = GetEncoding(supportedEncoding2);
				CleanupCharBreak();
				int chars = _encoding.GetChars(_bytes, _byteOffset, _byteCount, _chars, 0);
				_byteOffset = 0;
				_byteCount = DataContractSerializer.ValidatingUTF8.GetBytes(_chars, 0, chars, _bytes, 0);
			}
		}
		catch (DecoderFallbackException innerException)
		{
			throw new XmlException(System.SR.JsonInvalidBytes, innerException);
		}
	}

	private void InitForWriting(Stream outputStream, Encoding writeEncoding)
	{
		_encoding = writeEncoding;
		_stream = new BufferedStream(outputStream);
		_encodingCode = GetSupportedEncoding(writeEncoding);
		if (_encodingCode != 0)
		{
			EnsureBuffers();
			_dec = DataContractSerializer.ValidatingUTF8.GetDecoder();
			_enc = _encoding.GetEncoder();
		}
	}

	private SupportedEncoding ReadEncoding()
	{
		int num = _stream.ReadByte();
		int num2 = _stream.ReadByte();
		EnsureByteBuffer();
		SupportedEncoding result;
		if (num == -1)
		{
			result = SupportedEncoding.UTF8;
			_byteCount = 0;
		}
		else if (num2 == -1)
		{
			result = SupportedEncoding.UTF8;
			_bytes[0] = (byte)num;
			_byteCount = 1;
		}
		else
		{
			result = ReadEncoding((byte)num, (byte)num2);
			_bytes[0] = (byte)num;
			_bytes[1] = (byte)num2;
			_byteCount = 2;
		}
		return result;
	}
}
