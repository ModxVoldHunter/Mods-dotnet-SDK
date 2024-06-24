namespace System.Security.Cryptography.X509Certificates;

public sealed class X509KeyUsageExtension : X509Extension
{
	private bool _decoded;

	private X509KeyUsageFlags _keyUsages;

	public X509KeyUsageFlags KeyUsages
	{
		get
		{
			if (!_decoded)
			{
				X509Pal.Instance.DecodeX509KeyUsageExtension(base.RawData, out _keyUsages);
				_decoded = true;
			}
			return _keyUsages;
		}
	}

	public X509KeyUsageExtension()
		: base(Oids.KeyUsageOid)
	{
		_decoded = true;
	}

	public X509KeyUsageExtension(AsnEncodedData encodedKeyUsage, bool critical)
		: base(Oids.KeyUsageOid, encodedKeyUsage.RawData, critical)
	{
	}

	public X509KeyUsageExtension(X509KeyUsageFlags keyUsages, bool critical)
		: base(Oids.KeyUsageOid, X509Pal.Instance.EncodeX509KeyUsageExtension(keyUsages), critical, skipCopy: true)
	{
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		base.CopyFrom(asnEncodedData);
		_decoded = false;
	}
}
