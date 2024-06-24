using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Security.Cryptography;

public class HMACSHA256 : HMAC
{
	public const int HashSizeInBits = 256;

	public const int HashSizeInBytes = 32;

	private HMACCommon _hMacCommon;

	public override byte[] Key
	{
		get
		{
			return base.Key;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			_hMacCommon.ChangeKey(value);
			base.Key = _hMacCommon.ActualKey;
		}
	}

	public HMACSHA256()
		: this(RandomNumberGenerator.GetBytes(64))
	{
	}

	public HMACSHA256(byte[] key)
	{
		ArgumentNullException.ThrowIfNull(key, "key");
		base.HashName = "SHA256";
		_hMacCommon = new HMACCommon("SHA256", key, 64);
		base.Key = _hMacCommon.ActualKey;
		base.BlockSizeValue = 64;
		HashSizeValue = _hMacCommon.HashSizeInBits;
	}

	protected override void HashCore(byte[] rgb, int ib, int cb)
	{
		_hMacCommon.AppendHashData(rgb, ib, cb);
	}

	protected override void HashCore(ReadOnlySpan<byte> source)
	{
		_hMacCommon.AppendHashData(source);
	}

	protected override byte[] HashFinal()
	{
		return _hMacCommon.FinalizeHashAndReset();
	}

	protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
	{
		return _hMacCommon.TryFinalizeHashAndReset(destination, out bytesWritten);
	}

	public override void Initialize()
	{
		_hMacCommon.Reset();
	}

	public static byte[] HashData(byte[] key, byte[] source)
	{
		ArgumentNullException.ThrowIfNull(key, "key");
		ArgumentNullException.ThrowIfNull(source, "source");
		return HashData(new ReadOnlySpan<byte>(key), new ReadOnlySpan<byte>(source));
	}

	public static byte[] HashData(ReadOnlySpan<byte> key, ReadOnlySpan<byte> source)
	{
		byte[] array = new byte[32];
		int num = HashData(key, source, array.AsSpan());
		return array;
	}

	public static int HashData(ReadOnlySpan<byte> key, ReadOnlySpan<byte> source, Span<byte> destination)
	{
		if (!TryHashData(key, source, destination, out var bytesWritten))
		{
			throw new ArgumentException(System.SR.Argument_DestinationTooShort, "destination");
		}
		return bytesWritten;
	}

	public static bool TryHashData(ReadOnlySpan<byte> key, ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
	{
		if (destination.Length < 32)
		{
			bytesWritten = 0;
			return false;
		}
		bytesWritten = HashProviderDispenser.OneShotHashProvider.MacData("SHA256", key, source, destination);
		return true;
	}

	public static int HashData(ReadOnlySpan<byte> key, Stream source, Span<byte> destination)
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		if (destination.Length < 32)
		{
			throw new ArgumentException(System.SR.Argument_DestinationTooShort, "destination");
		}
		if (!source.CanRead)
		{
			throw new ArgumentException(System.SR.Argument_StreamNotReadable, "source");
		}
		return LiteHashProvider.HmacStream("SHA256", key, source, destination);
	}

	public static byte[] HashData(ReadOnlySpan<byte> key, Stream source)
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		if (!source.CanRead)
		{
			throw new ArgumentException(System.SR.Argument_StreamNotReadable, "source");
		}
		return LiteHashProvider.HmacStream("SHA256", 32, key, source);
	}

	public static byte[] HashData(byte[] key, Stream source)
	{
		ArgumentNullException.ThrowIfNull(key, "key");
		return HashData(new ReadOnlySpan<byte>(key), source);
	}

	public static ValueTask<byte[]> HashDataAsync(ReadOnlyMemory<byte> key, Stream source, CancellationToken cancellationToken = default(CancellationToken))
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		if (!source.CanRead)
		{
			throw new ArgumentException(System.SR.Argument_StreamNotReadable, "source");
		}
		return LiteHashProvider.HmacStreamAsync("SHA256", key.Span, source, cancellationToken);
	}

	public static ValueTask<byte[]> HashDataAsync(byte[] key, Stream source, CancellationToken cancellationToken = default(CancellationToken))
	{
		ArgumentNullException.ThrowIfNull(key, "key");
		return HashDataAsync(new ReadOnlyMemory<byte>(key), source, cancellationToken);
	}

	public static ValueTask<int> HashDataAsync(ReadOnlyMemory<byte> key, Stream source, Memory<byte> destination, CancellationToken cancellationToken = default(CancellationToken))
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		if (destination.Length < 32)
		{
			throw new ArgumentException(System.SR.Argument_DestinationTooShort, "destination");
		}
		if (!source.CanRead)
		{
			throw new ArgumentException(System.SR.Argument_StreamNotReadable, "source");
		}
		return LiteHashProvider.HmacStreamAsync("SHA256", key.Span, source, destination, cancellationToken);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			HMACCommon hMacCommon = _hMacCommon;
			if (hMacCommon != null)
			{
				_hMacCommon = null;
				hMacCommon.Dispose(disposing);
			}
		}
		base.Dispose(disposing);
	}
}
