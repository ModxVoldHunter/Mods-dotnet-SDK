using System.Net.Sockets;

namespace System.Net.NetworkInformation;

internal sealed class SystemUnicastIPAddressInformation : UnicastIPAddressInformation
{
	private readonly long _dhcpLeaseLifetime;

	private readonly SystemIPAddressInformation _innerInfo;

	private readonly IPAddress _ipv4Mask;

	private readonly PrefixOrigin _prefixOrigin;

	private readonly SuffixOrigin _suffixOrigin;

	private readonly DuplicateAddressDetectionState _dadState;

	private readonly uint _validLifetime;

	private readonly uint _preferredLifetime;

	private readonly byte _prefixLength;

	public override IPAddress Address => _innerInfo.Address;

	public override IPAddress IPv4Mask
	{
		get
		{
			if (Address.AddressFamily != AddressFamily.InterNetwork)
			{
				return IPAddress.Any;
			}
			return _ipv4Mask;
		}
	}

	public override int PrefixLength => _prefixLength;

	public override bool IsTransient => _innerInfo.IsTransient;

	public override bool IsDnsEligible => _innerInfo.IsDnsEligible;

	public override PrefixOrigin PrefixOrigin => _prefixOrigin;

	public override SuffixOrigin SuffixOrigin => _suffixOrigin;

	public override DuplicateAddressDetectionState DuplicateAddressDetectionState => _dadState;

	public override long AddressValidLifetime => _validLifetime;

	public override long AddressPreferredLifetime => _preferredLifetime;

	public override long DhcpLeaseLifetime => _dhcpLeaseLifetime;

	internal SystemUnicastIPAddressInformation(in global::Interop.IpHlpApi.IpAdapterUnicastAddress adapterAddress)
	{
		IPAddress iPAddress = adapterAddress.address.MarshalIPAddress();
		_innerInfo = new SystemIPAddressInformation(iPAddress, adapterAddress.flags);
		_prefixOrigin = adapterAddress.prefixOrigin;
		_suffixOrigin = adapterAddress.suffixOrigin;
		_dadState = adapterAddress.dadState;
		_validLifetime = adapterAddress.validLifetime;
		_preferredLifetime = adapterAddress.preferredLifetime;
		_dhcpLeaseLifetime = adapterAddress.leaseLifetime;
		_prefixLength = adapterAddress.prefixLength;
		if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
		{
			_ipv4Mask = UnicastIPAddressInformation.PrefixLengthToSubnetMask(_prefixLength, iPAddress.AddressFamily);
		}
	}

	internal unsafe static UnicastIPAddressInformationCollection MarshalUnicastIpAddressInformationCollection(nint ptr)
	{
		UnicastIPAddressInformationCollection unicastIPAddressInformationCollection = new UnicastIPAddressInformationCollection();
		for (global::Interop.IpHlpApi.IpAdapterUnicastAddress* ptr2 = (global::Interop.IpHlpApi.IpAdapterUnicastAddress*)ptr; ptr2 != null; ptr2 = ptr2->next)
		{
			unicastIPAddressInformationCollection.InternalAdd(new SystemUnicastIPAddressInformation(in *ptr2));
		}
		return unicastIPAddressInformationCollection;
	}
}
