using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net;

public static class Dns
{
	private static readonly Dictionary<object, Task> s_tasks = new Dictionary<object, Task>();

	public static string GetHostName()
	{
		long value = NameResolutionTelemetry.Log.BeforeResolution(string.Empty);
		string hostName;
		try
		{
			hostName = NameResolutionPal.GetHostName();
		}
		catch (Exception exception) when (LogFailure(string.Empty, value, exception))
		{
			throw;
		}
		NameResolutionTelemetry.Log.AfterResolution(string.Empty, value);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
			System.Net.NetEventSource.Info(null, hostName, "GetHostName");
		}
		return hostName;
	}

	public static IPHostEntry GetHostEntry(IPAddress address)
	{
		ArgumentNullException.ThrowIfNull(address, "address");
		if (address.Equals(IPAddress.Any) || address.Equals(IPAddress.IPv6Any))
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
				System.Net.NetEventSource.Error(address, $"Invalid address '{address}'", "GetHostEntry");
			}
			throw new ArgumentException(System.SR.net_invalid_ip_addr, "address");
		}
		IPHostEntry hostEntryCore = GetHostEntryCore(address, AddressFamily.Unspecified);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
			System.Net.NetEventSource.Info(address, $"{hostEntryCore} with {hostEntryCore.AddressList.Length} entries", "GetHostEntry");
		}
		return hostEntryCore;
	}

	public static IPHostEntry GetHostEntry(string hostNameOrAddress)
	{
		return GetHostEntry(hostNameOrAddress, AddressFamily.Unspecified);
	}

	public static IPHostEntry GetHostEntry(string hostNameOrAddress, AddressFamily family)
	{
		ArgumentNullException.ThrowIfNull(hostNameOrAddress, "hostNameOrAddress");
		IPHostEntry hostEntryCore;
		if (IPAddress.TryParse(hostNameOrAddress, out IPAddress address))
		{
			if (address.Equals(IPAddress.Any) || address.Equals(IPAddress.IPv6Any))
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
					System.Net.NetEventSource.Error(address, $"Invalid address '{address}'", "GetHostEntry");
				}
				throw new ArgumentException(System.SR.net_invalid_ip_addr, "hostNameOrAddress");
			}
			hostEntryCore = GetHostEntryCore(address, family);
		}
		else
		{
			hostEntryCore = GetHostEntryCore(hostNameOrAddress, family);
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
			System.Net.NetEventSource.Info(hostNameOrAddress, $"{hostEntryCore} with {hostEntryCore.AddressList.Length} entries", "GetHostEntry");
		}
		return hostEntryCore;
	}

	public static Task<IPHostEntry> GetHostEntryAsync(string hostNameOrAddress)
	{
		return GetHostEntryAsync(hostNameOrAddress, AddressFamily.Unspecified, CancellationToken.None);
	}

	public static Task<IPHostEntry> GetHostEntryAsync(string hostNameOrAddress, CancellationToken cancellationToken)
	{
		return GetHostEntryAsync(hostNameOrAddress, AddressFamily.Unspecified, cancellationToken);
	}

	public static Task<IPHostEntry> GetHostEntryAsync(string hostNameOrAddress, AddressFamily family, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
			Task<IPHostEntry> hostEntryCoreAsync = GetHostEntryCoreAsync(hostNameOrAddress, justReturnParsedIp: false, throwOnIIPAny: true, family, cancellationToken);
			hostEntryCoreAsync.ContinueWith(delegate(Task<IPHostEntry> t, object s)
			{
				string text = (string)s;
				if (t.Status == TaskStatus.RanToCompletion)
				{
					System.Net.NetEventSource.Info(text, $"{t.Result} with {t.Result.AddressList.Length} entries", "GetHostEntryAsync");
				}
				Exception ex = t.Exception?.InnerException;
				if (ex is SocketException ex2)
				{
					System.Net.NetEventSource.Error(text, $"{text} DNS lookup failed with {ex2.ErrorCode}", "GetHostEntryAsync");
				}
				else if (ex is OperationCanceledException)
				{
					System.Net.NetEventSource.Error(text, $"{text} DNS lookup was canceled", "GetHostEntryAsync");
				}
			}, hostNameOrAddress, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
			return hostEntryCoreAsync;
		}
		return GetHostEntryCoreAsync(hostNameOrAddress, justReturnParsedIp: false, throwOnIIPAny: true, family, cancellationToken);
	}

	public static Task<IPHostEntry> GetHostEntryAsync(IPAddress address)
	{
		ArgumentNullException.ThrowIfNull(address, "address");
		if (address.Equals(IPAddress.Any) || address.Equals(IPAddress.IPv6Any))
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
				System.Net.NetEventSource.Error(address, $"Invalid address '{address}'", "GetHostEntryAsync");
			}
			throw new ArgumentException(System.SR.net_invalid_ip_addr, "address");
		}
		return RunAsync(delegate(object s, long startingTimestamp)
		{
			IPHostEntry hostEntryCore = GetHostEntryCore((IPAddress)s, AddressFamily.Unspecified, startingTimestamp);
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
				System.Net.NetEventSource.Info((IPAddress)s, $"{hostEntryCore} with {hostEntryCore.AddressList.Length} entries", "GetHostEntryAsync");
			}
			return hostEntryCore;
		}, address, CancellationToken.None);
	}

	public static IAsyncResult BeginGetHostEntry(IPAddress address, AsyncCallback? requestCallback, object? stateObject)
	{
		return TaskToAsyncResult.Begin(GetHostEntryAsync(address), requestCallback, stateObject);
	}

	public static IAsyncResult BeginGetHostEntry(string hostNameOrAddress, AsyncCallback? requestCallback, object? stateObject)
	{
		return TaskToAsyncResult.Begin(GetHostEntryAsync(hostNameOrAddress), requestCallback, stateObject);
	}

	public static IPHostEntry EndGetHostEntry(IAsyncResult asyncResult)
	{
		ArgumentNullException.ThrowIfNull(asyncResult, "asyncResult");
		return TaskToAsyncResult.End<IPHostEntry>(asyncResult);
	}

	public static IPAddress[] GetHostAddresses(string hostNameOrAddress)
	{
		return GetHostAddresses(hostNameOrAddress, AddressFamily.Unspecified);
	}

	public static IPAddress[] GetHostAddresses(string hostNameOrAddress, AddressFamily family)
	{
		ArgumentNullException.ThrowIfNull(hostNameOrAddress, "hostNameOrAddress");
		IPAddress[] array;
		if (IPAddress.TryParse(hostNameOrAddress, out IPAddress address))
		{
			if (address.Equals(IPAddress.Any) || address.Equals(IPAddress.IPv6Any))
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
					System.Net.NetEventSource.Error(address, $"Invalid address '{address}'", "GetHostAddresses");
				}
				throw new ArgumentException(System.SR.net_invalid_ip_addr, "hostNameOrAddress");
			}
			array = ((family != 0 && address.AddressFamily != family) ? Array.Empty<IPAddress>() : new IPAddress[1] { address });
		}
		else
		{
			array = GetHostAddressesCore(hostNameOrAddress, family);
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
			System.Net.NetEventSource.Info(hostNameOrAddress, array, "GetHostAddresses");
		}
		return array;
	}

	public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress)
	{
		return (Task<IPAddress[]>)GetHostEntryOrAddressesCoreAsync(hostNameOrAddress, justReturnParsedIp: true, throwOnIIPAny: true, justAddresses: true, AddressFamily.Unspecified, CancellationToken.None);
	}

	public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress, CancellationToken cancellationToken)
	{
		return (Task<IPAddress[]>)GetHostEntryOrAddressesCoreAsync(hostNameOrAddress, justReturnParsedIp: true, throwOnIIPAny: true, justAddresses: true, AddressFamily.Unspecified, cancellationToken);
	}

	public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress, AddressFamily family, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (Task<IPAddress[]>)GetHostEntryOrAddressesCoreAsync(hostNameOrAddress, justReturnParsedIp: true, throwOnIIPAny: true, justAddresses: true, family, cancellationToken);
	}

	public static IAsyncResult BeginGetHostAddresses(string hostNameOrAddress, AsyncCallback? requestCallback, object? state)
	{
		return TaskToAsyncResult.Begin(GetHostAddressesAsync(hostNameOrAddress), requestCallback, state);
	}

	public static IPAddress[] EndGetHostAddresses(IAsyncResult asyncResult)
	{
		ArgumentNullException.ThrowIfNull(asyncResult, "asyncResult");
		return TaskToAsyncResult.End<IPAddress[]>(asyncResult);
	}

	[Obsolete("GetHostByName has been deprecated. Use GetHostEntry instead.")]
	public static IPHostEntry GetHostByName(string hostName)
	{
		ArgumentNullException.ThrowIfNull(hostName, "hostName");
		if (IPAddress.TryParse(hostName, out IPAddress address))
		{
			return CreateHostEntryForAddress(address);
		}
		return GetHostEntryCore(hostName, AddressFamily.Unspecified);
	}

	[Obsolete("BeginGetHostByName has been deprecated. Use BeginGetHostEntry instead.")]
	public static IAsyncResult BeginGetHostByName(string hostName, AsyncCallback? requestCallback, object? stateObject)
	{
		return TaskToAsyncResult.Begin(GetHostEntryCoreAsync(hostName, justReturnParsedIp: true, throwOnIIPAny: true, AddressFamily.Unspecified, CancellationToken.None), requestCallback, stateObject);
	}

	[Obsolete("EndGetHostByName has been deprecated. Use EndGetHostEntry instead.")]
	public static IPHostEntry EndGetHostByName(IAsyncResult asyncResult)
	{
		ArgumentNullException.ThrowIfNull(asyncResult, "asyncResult");
		return TaskToAsyncResult.End<IPHostEntry>(asyncResult);
	}

	[Obsolete("GetHostByAddress has been deprecated. Use GetHostEntry instead.")]
	public static IPHostEntry GetHostByAddress(string address)
	{
		ArgumentNullException.ThrowIfNull(address, "address");
		IPHostEntry hostEntryCore = GetHostEntryCore(IPAddress.Parse(address), AddressFamily.Unspecified);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
			System.Net.NetEventSource.Info(address, hostEntryCore, "GetHostByAddress");
		}
		return hostEntryCore;
	}

	[Obsolete("GetHostByAddress has been deprecated. Use GetHostEntry instead.")]
	public static IPHostEntry GetHostByAddress(IPAddress address)
	{
		ArgumentNullException.ThrowIfNull(address, "address");
		IPHostEntry hostEntryCore = GetHostEntryCore(address, AddressFamily.Unspecified);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
			System.Net.NetEventSource.Info(address, hostEntryCore, "GetHostByAddress");
		}
		return hostEntryCore;
	}

	[Obsolete("Resolve has been deprecated. Use GetHostEntry instead.")]
	public static IPHostEntry Resolve(string hostName)
	{
		ArgumentNullException.ThrowIfNull(hostName, "hostName");
		IPHostEntry iPHostEntry;
		if (IPAddress.TryParse(hostName, out IPAddress address) && (address.AddressFamily != AddressFamily.InterNetworkV6 || SocketProtocolSupportPal.OSSupportsIPv6))
		{
			try
			{
				iPHostEntry = GetHostEntryCore(address, AddressFamily.Unspecified);
			}
			catch (SocketException message)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
					System.Net.NetEventSource.Error(hostName, message, "Resolve");
				}
				iPHostEntry = CreateHostEntryForAddress(address);
			}
		}
		else
		{
			iPHostEntry = GetHostEntryCore(hostName, AddressFamily.Unspecified);
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
			System.Net.NetEventSource.Info(hostName, iPHostEntry, "Resolve");
		}
		return iPHostEntry;
	}

	[Obsolete("BeginResolve has been deprecated. Use BeginGetHostEntry instead.")]
	public static IAsyncResult BeginResolve(string hostName, AsyncCallback? requestCallback, object? stateObject)
	{
		return TaskToAsyncResult.Begin(GetHostEntryCoreAsync(hostName, justReturnParsedIp: false, throwOnIIPAny: false, AddressFamily.Unspecified, CancellationToken.None), requestCallback, stateObject);
	}

	[Obsolete("EndResolve has been deprecated. Use EndGetHostEntry instead.")]
	public static IPHostEntry EndResolve(IAsyncResult asyncResult)
	{
		IPHostEntry iPHostEntry;
		try
		{
			iPHostEntry = TaskToAsyncResult.End<IPHostEntry>(asyncResult);
		}
		catch (SocketException message)
		{
			object asyncState = TaskToAsyncResult.Unwrap(asyncResult).AsyncState;
			IPAddress iPAddress2 = ((asyncState is IPAddress iPAddress) ? iPAddress : ((!(asyncState is KeyValuePair<IPAddress, AddressFamily> keyValuePair)) ? null : keyValuePair.Key));
			IPAddress iPAddress3 = iPAddress2;
			if (iPAddress3 == null)
			{
				throw;
			}
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
				System.Net.NetEventSource.Error(null, message, "EndResolve");
			}
			iPHostEntry = CreateHostEntryForAddress(iPAddress3);
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
			System.Net.NetEventSource.Info(null, iPHostEntry, "EndResolve");
		}
		return iPHostEntry;
	}

	private static IPHostEntry GetHostEntryCore(string hostName, AddressFamily addressFamily, long? startingTimestamp = null)
	{
		return (IPHostEntry)GetHostEntryOrAddressesCore(hostName, justAddresses: false, addressFamily, startingTimestamp);
	}

	private static IPAddress[] GetHostAddressesCore(string hostName, AddressFamily addressFamily, long? startingTimestamp = null)
	{
		return (IPAddress[])GetHostEntryOrAddressesCore(hostName, justAddresses: true, addressFamily, startingTimestamp);
	}

	private static object GetHostEntryOrAddressesCore(string hostName, bool justAddresses, AddressFamily addressFamily, long? startingTimestamp = null)
	{
		ValidateHostName(hostName);
		long valueOrDefault = startingTimestamp.GetValueOrDefault();
		if (!startingTimestamp.HasValue)
		{
			valueOrDefault = NameResolutionTelemetry.Log.BeforeResolution(hostName);
			startingTimestamp = valueOrDefault;
		}
		object result;
		try
		{
			string hostName2;
			string[] aliases;
			IPAddress[] addresses;
			int nativeErrorCode;
			SocketError socketError = NameResolutionPal.TryGetAddrInfo(hostName, justAddresses, addressFamily, out hostName2, out aliases, out addresses, out nativeErrorCode);
			if (socketError != 0)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
					System.Net.NetEventSource.Error(hostName, $"{hostName} DNS lookup failed with {socketError}", "GetHostEntryOrAddressesCore");
				}
				throw CreateException(socketError, nativeErrorCode);
			}
			result = (justAddresses ? ((object)addresses) : ((object)new IPHostEntry
			{
				AddressList = addresses,
				HostName = hostName2,
				Aliases = aliases
			}));
		}
		catch (Exception exception) when (LogFailure(hostName, startingTimestamp, exception))
		{
			throw;
		}
		NameResolutionTelemetry.Log.AfterResolution(hostName, startingTimestamp);
		return result;
	}

	private static IPHostEntry GetHostEntryCore(IPAddress address, AddressFamily addressFamily, long? startingTimestamp = null)
	{
		return (IPHostEntry)GetHostEntryOrAddressesCore(address, justAddresses: false, addressFamily, startingTimestamp);
	}

	private static IPAddress[] GetHostAddressesCore(IPAddress address, AddressFamily addressFamily, long? startingTimestamp = null)
	{
		return (IPAddress[])GetHostEntryOrAddressesCore(address, justAddresses: true, addressFamily, startingTimestamp);
	}

	private static object GetHostEntryOrAddressesCore(IPAddress address, bool justAddresses, AddressFamily addressFamily, long? startingTimestamp = null)
	{
		long valueOrDefault = startingTimestamp.GetValueOrDefault();
		if (!startingTimestamp.HasValue)
		{
			valueOrDefault = NameResolutionTelemetry.Log.BeforeResolution(address);
			startingTimestamp = valueOrDefault;
		}
		string text;
		try
		{
			text = NameResolutionPal.TryGetNameInfo(address, out var errorCode, out var nativeErrorCode);
			if (errorCode != 0)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
					System.Net.NetEventSource.Error(address, $"{address} DNS lookup failed with {errorCode}", "GetHostEntryOrAddressesCore");
				}
				throw CreateException(errorCode, nativeErrorCode);
			}
		}
		catch (Exception exception) when (LogFailure(address, startingTimestamp, exception))
		{
			throw;
		}
		NameResolutionTelemetry.Log.AfterResolution(address, startingTimestamp);
		startingTimestamp = NameResolutionTelemetry.Log.BeforeResolution(text);
		object result;
		try
		{
			string hostName;
			string[] aliases;
			IPAddress[] addresses;
			int nativeErrorCode2;
			SocketError errorCode = NameResolutionPal.TryGetAddrInfo(text, justAddresses, addressFamily, out hostName, out aliases, out addresses, out nativeErrorCode2);
			if (errorCode != 0 && System.Net.NetEventSource.Log.IsEnabled())
			{
				System.Net.NetEventSource.Error(address, $"forward lookup for '{text}' failed with {errorCode}", "GetHostEntryOrAddressesCore");
			}
			result = (justAddresses ? ((object)addresses) : ((object)new IPHostEntry
			{
				HostName = hostName,
				Aliases = aliases,
				AddressList = addresses
			}));
		}
		catch (Exception exception2) when (LogFailure(text, startingTimestamp, exception2))
		{
			throw;
		}
		NameResolutionTelemetry.Log.AfterResolution(text, startingTimestamp);
		return result;
	}

	private static Task<IPHostEntry> GetHostEntryCoreAsync(string hostName, bool justReturnParsedIp, bool throwOnIIPAny, AddressFamily family, CancellationToken cancellationToken)
	{
		return (Task<IPHostEntry>)GetHostEntryOrAddressesCoreAsync(hostName, justReturnParsedIp, throwOnIIPAny, justAddresses: false, family, cancellationToken);
	}

	private static Task GetHostEntryOrAddressesCoreAsync(string hostName, bool justReturnParsedIp, bool throwOnIIPAny, bool justAddresses, AddressFamily family, CancellationToken cancellationToken)
	{
		ArgumentNullException.ThrowIfNull(hostName, "hostName");
		if (cancellationToken.IsCancellationRequested)
		{
			if (!justAddresses)
			{
				return Task.FromCanceled<IPHostEntry>(cancellationToken);
			}
			return Task.FromCanceled<IPAddress[]>(cancellationToken);
		}
		object key;
		if (IPAddress.TryParse(hostName, out IPAddress address))
		{
			if (throwOnIIPAny && (address.Equals(IPAddress.Any) || address.Equals(IPAddress.IPv6Any)))
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
					System.Net.NetEventSource.Error(hostName, $"Invalid address '{address}'", "GetHostEntryOrAddressesCoreAsync");
				}
				throw new ArgumentException(System.SR.net_invalid_ip_addr, "hostName");
			}
			if (justReturnParsedIp)
			{
				if (!justAddresses)
				{
					return Task.FromResult(CreateHostEntryForAddress(address));
				}
				return Task.FromResult((family != 0 && address.AddressFamily != family) ? Array.Empty<IPAddress>() : new IPAddress[1] { address });
			}
			key = ((family == AddressFamily.Unspecified) ? address : ((object)new KeyValuePair<IPAddress, AddressFamily>(address, family)));
		}
		else
		{
			if (NameResolutionPal.SupportsGetAddrInfoAsync)
			{
				ValidateHostName(hostName);
				Task task = ((!NameResolutionTelemetry.Log.IsEnabled() && !NameResolutionMetrics.IsEnabled()) ? NameResolutionPal.GetAddrInfoAsync(hostName, justAddresses, family, cancellationToken) : (justAddresses ? ((Task)GetAddrInfoWithTelemetryAsync<IPAddress[]>(hostName, justAddresses, family, cancellationToken)) : ((Task)GetAddrInfoWithTelemetryAsync<IPHostEntry>(hostName, justAddresses, family, cancellationToken))));
				if (task != null)
				{
					return task;
				}
			}
			key = ((family == AddressFamily.Unspecified) ? hostName : ((object)new KeyValuePair<string, AddressFamily>(hostName, family)));
		}
		if (justAddresses)
		{
			return RunAsync(delegate(object s, long startingTimestamp)
			{
				if (s is string hostName3)
				{
					return GetHostAddressesCore(hostName3, AddressFamily.Unspecified, startingTimestamp);
				}
				if (s is KeyValuePair<string, AddressFamily> keyValuePair3)
				{
					return GetHostAddressesCore(keyValuePair3.Key, keyValuePair3.Value, startingTimestamp);
				}
				if (s is IPAddress address3)
				{
					return GetHostAddressesCore(address3, AddressFamily.Unspecified, startingTimestamp);
				}
				return (s is KeyValuePair<IPAddress, AddressFamily> keyValuePair4) ? GetHostAddressesCore(keyValuePair4.Key, keyValuePair4.Value, startingTimestamp) : null;
			}, key, cancellationToken);
		}
		return RunAsync(delegate(object s, long startingTimestamp)
		{
			if (s is string hostName2)
			{
				return GetHostEntryCore(hostName2, AddressFamily.Unspecified, startingTimestamp);
			}
			if (s is KeyValuePair<string, AddressFamily> keyValuePair)
			{
				return GetHostEntryCore(keyValuePair.Key, keyValuePair.Value, startingTimestamp);
			}
			if (s is IPAddress address2)
			{
				return GetHostEntryCore(address2, AddressFamily.Unspecified, startingTimestamp);
			}
			return (s is KeyValuePair<IPAddress, AddressFamily> keyValuePair2) ? GetHostEntryCore(keyValuePair2.Key, keyValuePair2.Value, startingTimestamp) : null;
		}, key, cancellationToken);
	}

	private static Task<T> GetAddrInfoWithTelemetryAsync<T>(string hostName, bool justAddresses, AddressFamily addressFamily, CancellationToken cancellationToken) where T : class
	{
		long timestamp = Stopwatch.GetTimestamp();
		Task addrInfoAsync = NameResolutionPal.GetAddrInfoAsync(hostName, justAddresses, addressFamily, cancellationToken);
		if (addrInfoAsync != null)
		{
			return CompleteAsync(addrInfoAsync, hostName, timestamp);
		}
		return null;
		static async Task<T> CompleteAsync(Task task, string hostName, long startingTimestamp)
		{
			NameResolutionTelemetry.Log.BeforeResolution(hostName);
			Exception exception = null;
			try
			{
				return await ((Task<T>)task).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				exception = ex;
				throw;
			}
			finally
			{
				NameResolutionTelemetry.Log.AfterResolution(hostName, startingTimestamp, exception);
			}
		}
	}

	private static IPHostEntry CreateHostEntryForAddress(IPAddress address)
	{
		IPHostEntry iPHostEntry = new IPHostEntry();
		iPHostEntry.HostName = address.ToString();
		iPHostEntry.Aliases = Array.Empty<string>();
		iPHostEntry.AddressList = new IPAddress[1] { address };
		return iPHostEntry;
	}

	private static void ValidateHostName(string hostName)
	{
		if (hostName.Length > 255 || (hostName.Length == 255 && hostName[254] != '.'))
		{
			throw new ArgumentOutOfRangeException("hostName", System.SR.Format(System.SR.net_toolong, "hostName", 255.ToString(NumberFormatInfo.CurrentInfo)));
		}
	}

	private static bool LogFailure(object hostNameOrAddress, long? startingTimestamp, Exception exception)
	{
		NameResolutionTelemetry.Log.AfterResolution(hostNameOrAddress, startingTimestamp, exception);
		return false;
	}

	private static Task<TResult> RunAsync<TResult>(Func<object, long, TResult> func, object key, CancellationToken cancellationToken)
	{
		long startingTimestamp = NameResolutionTelemetry.Log.BeforeResolution(key);
		Task<TResult> task = null;
		lock (s_tasks)
		{
			s_tasks.TryGetValue(key, out var value);
			if (value == null)
			{
				value = Task.CompletedTask;
			}
			task = value.ContinueWith(delegate
			{
				try
				{
					return func(key, startingTimestamp);
				}
				finally
				{
					lock (s_tasks)
					{
						((ICollection<KeyValuePair<object, Task>>)s_tasks).Remove(new KeyValuePair<object, Task>(key, task));
					}
				}
			}, key, cancellationToken, TaskContinuationOptions.DenyChildAttach, TaskScheduler.Default);
			if (cancellationToken.CanBeCanceled)
			{
				task.ContinueWith(delegate(Task<TResult> task, object key)
				{
					lock (s_tasks)
					{
						((ICollection<KeyValuePair<object, Task>>)s_tasks).Remove(new KeyValuePair<object, Task>(key, task));
					}
				}, key, CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled | TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
			}
			s_tasks[key] = task;
		}
		return task;
	}

	private static SocketException CreateException(SocketError error, int nativeError)
	{
		return new SocketException((int)error)
		{
			HResult = nativeError
		};
	}
}
