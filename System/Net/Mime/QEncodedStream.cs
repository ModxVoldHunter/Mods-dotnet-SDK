using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Mime;

internal sealed class QEncodedStream : DelegatedStream, IEncodableStream
{
	private sealed class ReadStateInfo
	{
		internal bool IsEscaped { get; set; }

		internal short Byte { get; set; } = -1;

	}

	private ReadStateInfo _readState;

	private readonly WriteStateInfoBase _writeState;

	private readonly QEncoder _encoder;

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

	private ReadStateInfo ReadState => _readState ?? (_readState = new ReadStateInfo());

	internal WriteStateInfoBase WriteState => _writeState;

	internal QEncodedStream(WriteStateInfoBase wsi)
		: base(new MemoryStream())
	{
		_writeState = wsi;
		_encoder = new QEncoder(_writeState);
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
					if (*ptr3 == 95)
					{
						*(ptr4++) = 32;
						ptr3++;
					}
					else
					{
						*(ptr4++) = *(ptr3++);
					}
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
		return _encoder.EncodeBytes(buffer, offset, count, dontDeferFinalBytes: true, shouldAppendSpaceToCRLF: true);
	}

	public int EncodeString(string value, Encoding encoding)
	{
		return _encoder.EncodeString(value, encoding);
	}

	public string GetEncodedString()
	{
		return _encoder.GetEncodedString();
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
			WriteState.Reset();
		}
		await base.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	private void FlushInternal()
	{
		if (_writeState != null && _writeState.Length > 0)
		{
			base.Write(WriteState.Buffer, 0, WriteState.Length);
			WriteState.Reset();
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
