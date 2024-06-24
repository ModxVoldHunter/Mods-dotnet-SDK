using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Mime;

internal sealed class QuotedPrintableStream : DelegatedStream, IEncodableStream
{
	private sealed class ReadStateInfo
	{
		internal bool IsEscaped { get; set; }

		internal short Byte { get; set; } = -1;

	}

	private readonly bool _encodeCRLF;

	private readonly int _lineLength;

	private ReadStateInfo _readState;

	private WriteStateInfoBase _writeState;

	private static ReadOnlySpan<byte> HexDecodeMap => new byte[256]
	{
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 0, 1,
		2, 3, 4, 5, 6, 7, 8, 9, 255, 255,
		255, 255, 255, 255, 255, 10, 11, 12, 13, 14,
		15, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 10, 11, 12,
		13, 14, 15, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255
	};

	private static ReadOnlySpan<byte> HexEncodeMap => "0123456789ABCDEF"u8;

	private ReadStateInfo ReadState => _readState ?? (_readState = new ReadStateInfo());

	internal WriteStateInfoBase WriteState => _writeState ?? (_writeState = new WriteStateInfoBase(1024, null, null, _lineLength));

	internal QuotedPrintableStream(Stream stream, int lineLength)
		: base(stream)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(lineLength, "lineLength");
		_lineLength = lineLength;
	}

	internal QuotedPrintableStream(Stream stream, bool encodeCRLF)
		: this(stream, 70)
	{
		_encodeCRLF = encodeCRLF;
	}

	public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
	{
		return TaskToAsyncResult.Begin(WriteAsync(buffer, offset, count, CancellationToken.None), callback, state);
	}

	public override void Close()
	{
		FlushInternal();
		base.Close();
	}

	public unsafe int DecodeBytes(byte[] buffer, int offset, int count)
	{
		fixed (byte* ptr = buffer)
		{
			byte* ptr2 = ptr + offset;
			byte* ptr3 = ptr2;
			byte* ptr4 = ptr2;
			byte* ptr5 = ptr2 + count;
			if (ReadState.IsEscaped)
			{
				if (ReadState.Byte == -1)
				{
					if (count == 1)
					{
						ReadState.Byte = *ptr3;
						return 0;
					}
					if (*ptr3 != 13 || ptr3[1] != 10)
					{
						byte b = HexDecodeMap[*ptr3];
						byte b2 = HexDecodeMap[ptr3[1]];
						if (b == byte.MaxValue)
						{
							throw new FormatException(System.SR.Format(System.SR.InvalidHexDigit, b));
						}
						if (b2 == byte.MaxValue)
						{
							throw new FormatException(System.SR.Format(System.SR.InvalidHexDigit, b2));
						}
						*(ptr4++) = (byte)((b << 4) + b2);
					}
					ptr3 += 2;
				}
				else
				{
					if (ReadState.Byte != 13 || *ptr3 != 10)
					{
						byte b3 = HexDecodeMap[ReadState.Byte];
						byte b4 = HexDecodeMap[*ptr3];
						if (b3 == byte.MaxValue)
						{
							throw new FormatException(System.SR.Format(System.SR.InvalidHexDigit, b3));
						}
						if (b4 == byte.MaxValue)
						{
							throw new FormatException(System.SR.Format(System.SR.InvalidHexDigit, b4));
						}
						*(ptr4++) = (byte)((b3 << 4) + b4);
					}
					ptr3++;
				}
				ReadState.IsEscaped = false;
				ReadState.Byte = -1;
			}
			while (ptr3 < ptr5)
			{
				if (*ptr3 != 61)
				{
					*(ptr4++) = *(ptr3++);
					continue;
				}
				long num = ptr5 - ptr3;
				if (num != 1)
				{
					if (num != 2)
					{
						if (ptr3[1] != 13 || ptr3[2] != 10)
						{
							byte b5 = HexDecodeMap[ptr3[1]];
							byte b6 = HexDecodeMap[ptr3[2]];
							if (b5 == byte.MaxValue)
							{
								throw new FormatException(System.SR.Format(System.SR.InvalidHexDigit, b5));
							}
							if (b6 == byte.MaxValue)
							{
								throw new FormatException(System.SR.Format(System.SR.InvalidHexDigit, b6));
							}
							*(ptr4++) = (byte)((b5 << 4) + b6);
						}
						ptr3 += 3;
						continue;
					}
					ReadState.Byte = ptr3[1];
				}
				ReadState.IsEscaped = true;
				break;
			}
			return (int)(ptr4 - ptr2);
		}
	}

	public int EncodeBytes(byte[] buffer, int offset, int count)
	{
		int i;
		for (i = offset; i < count + offset; i++)
		{
			if ((_lineLength != -1 && WriteState.CurrentLineLength + 3 + 2 >= _lineLength && (buffer[i] == 32 || buffer[i] == 9 || buffer[i] == 13 || buffer[i] == 10)) || _writeState.CurrentLineLength + 3 + 2 >= 70)
			{
				if (WriteState.Buffer.Length - WriteState.Length < 3)
				{
					return i - offset;
				}
				WriteState.Append(61);
				WriteState.AppendCRLF(includeSpace: false);
			}
			if (buffer[i] == 13 && i + 1 < count + offset && buffer[i + 1] == 10)
			{
				if (WriteState.Buffer.Length - WriteState.Length < (_encodeCRLF ? 6 : 2))
				{
					return i - offset;
				}
				i++;
				if (_encodeCRLF)
				{
					WriteState.Append("=0D=0A"u8);
				}
				else
				{
					WriteState.AppendCRLF(includeSpace: false);
				}
				continue;
			}
			if ((buffer[i] < 32 && buffer[i] != 9) || buffer[i] == 61 || buffer[i] > 126)
			{
				if (WriteState.Buffer.Length - WriteState.Length < 3)
				{
					return i - offset;
				}
				WriteState.Append(61);
				WriteState.Append(HexEncodeMap[buffer[i] >> 4]);
				WriteState.Append(HexEncodeMap[buffer[i] & 0xF]);
				continue;
			}
			if (WriteState.Buffer.Length - WriteState.Length < 1)
			{
				return i - offset;
			}
			if ((buffer[i] == 9 || buffer[i] == 32) && i + 1 >= count + offset)
			{
				if (WriteState.Buffer.Length - WriteState.Length < 3)
				{
					return i - offset;
				}
				WriteState.Append(61);
				WriteState.Append(HexEncodeMap[buffer[i] >> 4]);
				WriteState.Append(HexEncodeMap[buffer[i] & 0xF]);
			}
			else
			{
				WriteState.Append(buffer[i]);
			}
		}
		return i - offset;
	}

	public int EncodeString(string value, Encoding encoding)
	{
		byte[] bytes = encoding.GetBytes(value);
		return EncodeBytes(bytes, 0, bytes.Length);
	}

	public string GetEncodedString()
	{
		return Encoding.ASCII.GetString(WriteState.Buffer, 0, WriteState.Length);
	}

	public override void EndWrite(IAsyncResult asyncResult)
	{
		TaskToAsyncResult.End(asyncResult);
	}

	public override void Flush()
	{
		FlushInternal();
		base.Flush();
	}

	public override async Task FlushAsync(CancellationToken cancellationToken)
	{
		if (_writeState != null && _writeState.Length > 0)
		{
			await WriteAsync(WriteState.Buffer.AsMemory(0, WriteState.Length), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			WriteState.BufferFlushed();
		}
		await base.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	private void FlushInternal()
	{
		if (_writeState != null && _writeState.Length > 0)
		{
			base.Write(WriteState.Buffer, 0, WriteState.Length);
			WriteState.BufferFlushed();
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		Stream.ValidateBufferArguments(buffer, offset, count);
		int num = 0;
		while (true)
		{
			num += EncodeBytes(buffer, offset + num, count - num);
			if (num < count)
			{
				FlushInternal();
				continue;
			}
			break;
		}
	}

	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		Stream.ValidateBufferArguments(buffer, offset, count);
		return WriteAsyncCore(buffer, offset, count, cancellationToken);
		async Task WriteAsyncCore(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int written = 0;
			while (true)
			{
				written += EncodeBytes(buffer, offset + written, count - written);
				if (written >= count)
				{
					break;
				}
				await FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
	}
}
