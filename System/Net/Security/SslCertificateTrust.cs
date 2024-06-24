using System.Security.Cryptography.X509Certificates;

namespace System.Net.Security;

public sealed class SslCertificateTrust
{
	internal X509Store _store;

	internal X509Certificate2Collection _trustList;

	internal bool _sendTrustInHandshake;

	public static SslCertificateTrust CreateForX509Store(X509Store store, bool sendTrustInHandshake = false)
	{
		if (sendTrustInHandshake && store.Location != StoreLocation.LocalMachine)
		{
			throw new PlatformNotSupportedException(System.SR.net_ssl_trust_store);
		}
		if (sendTrustInHandshake && !OperatingSystem.IsLinux() && !OperatingSystem.IsMacOS() && !OperatingSystem.IsWindowsVersionAtLeast(6, 2))
		{
			throw new PlatformNotSupportedException(System.SR.net_ssl_trust_handshake);
		}
		if (!store.IsOpen)
		{
			store.Open(OpenFlags.OpenExistingOnly);
		}
		SslCertificateTrust sslCertificateTrust = new SslCertificateTrust();
		sslCertificateTrust._store = store;
		sslCertificateTrust._sendTrustInHandshake = sendTrustInHandshake;
		return sslCertificateTrust;
	}

	public static SslCertificateTrust CreateForX509Collection(X509Certificate2Collection trustList, bool sendTrustInHandshake = false)
	{
		if (sendTrustInHandshake)
		{
			throw new PlatformNotSupportedException(System.SR.net_ssl_trust_collection);
		}
		SslCertificateTrust sslCertificateTrust = new SslCertificateTrust();
		sslCertificateTrust._trustList = trustList;
		sslCertificateTrust._sendTrustInHandshake = sendTrustInHandshake;
		return sslCertificateTrust;
	}

	private SslCertificateTrust()
	{
	}
}
