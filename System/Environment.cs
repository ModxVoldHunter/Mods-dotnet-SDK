using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Internal.Win32;
using Microsoft.Win32.SafeHandles;

namespace System;

public static class Environment
{
	public enum SpecialFolder
	{
		ApplicationData = 26,
		CommonApplicationData = 35,
		LocalApplicationData = 28,
		Cookies = 33,
		Desktop = 0,
		Favorites = 6,
		History = 34,
		InternetCache = 32,
		Programs = 2,
		MyComputer = 17,
		MyMusic = 13,
		MyPictures = 39,
		MyVideos = 14,
		Recent = 8,
		SendTo = 9,
		StartMenu = 11,
		Startup = 7,
		System = 37,
		Templates = 21,
		DesktopDirectory = 16,
		Personal = 5,
		MyDocuments = 5,
		ProgramFiles = 38,
		CommonProgramFiles = 43,
		AdminTools = 48,
		CDBurning = 59,
		CommonAdminTools = 47,
		CommonDocuments = 46,
		CommonMusic = 53,
		CommonOemLinks = 58,
		CommonPictures = 54,
		CommonStartMenu = 22,
		CommonPrograms = 23,
		CommonStartup = 24,
		CommonDesktopDirectory = 25,
		CommonTemplates = 45,
		CommonVideos = 55,
		Fonts = 20,
		NetworkShortcuts = 19,
		PrinterShortcuts = 27,
		UserProfile = 40,
		CommonProgramFilesX86 = 44,
		ProgramFilesX86 = 42,
		Resources = 56,
		LocalizedResources = 57,
		SystemX86 = 41,
		Windows = 36
	}

	public enum SpecialFolderOption
	{
		None = 0,
		Create = 32768,
		DoNotVerify = 16384
	}

	private static class WindowsVersion
	{
		internal static readonly bool IsWindows8OrAbove = OperatingSystem.IsWindowsVersionAtLeast(6, 2);
	}

	private static volatile sbyte s_privilegedProcess;

	internal static string[] s_commandLineArgs;

	private static volatile int s_processId;

	private static volatile string s_processPath;

	private static volatile OperatingSystem s_osVersion;

	private static volatile int s_systemPageSize;

	public static extern int CurrentManagedThreadId
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	public static extern int ExitCode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		set;
	}

	public static extern int TickCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	public static extern long TickCount64
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	public static int ProcessorCount { get; } = GetProcessorCount();


	internal static bool IsSingleProcessor => ProcessorCount == 1;

	public static bool IsPrivilegedProcess
	{
		get
		{
			sbyte b = s_privilegedProcess;
			if (b == 0)
			{
				b = (s_privilegedProcess = (sbyte)(IsPrivilegedProcessCore() ? 1 : (-1)));
			}
			return b > 0;
		}
	}

	public static bool HasShutdownStarted => false;

	public static string CommandLine => PasteArguments.Paste(GetCommandLineArgs(), pasteFirstArgumentUsingArgV0Rules: true);

	public static string CurrentDirectory
	{
		get
		{
			return CurrentDirectoryCore;
		}
		set
		{
			ArgumentException.ThrowIfNullOrEmpty(value, "value");
			CurrentDirectoryCore = value;
		}
	}

	public static int ProcessId
	{
		get
		{
			int num = s_processId;
			if (num == 0)
			{
				num = (s_processId = GetProcessId());
			}
			return num;
		}
	}

	public static string? ProcessPath
	{
		get
		{
			string text = s_processPath;
			if (text == null)
			{
				Interlocked.CompareExchange(ref s_processPath, GetProcessPath() ?? "", null);
				text = s_processPath;
			}
			if (text.Length == 0)
			{
				return null;
			}
			return text;
		}
	}

	public static bool Is64BitProcess => 8 == 8;

	public static bool Is64BitOperatingSystem
	{
		get
		{
			if (1 == 0)
			{
			}
			return true;
		}
	}

	public static string NewLine => "\r\n";

	public static OperatingSystem OSVersion
	{
		get
		{
			OperatingSystem operatingSystem = s_osVersion;
			if (operatingSystem == null)
			{
				Interlocked.CompareExchange(ref s_osVersion, GetOSVersion(), null);
				operatingSystem = s_osVersion;
			}
			return operatingSystem;
		}
	}

	public static Version Version
	{
		get
		{
			string text = typeof(object).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
			ReadOnlySpan<char> readOnlySpan = text.AsSpan();
			int num = readOnlySpan.IndexOfAny('-', '+', ' ');
			if (num >= 0)
			{
				readOnlySpan = readOnlySpan.Slice(0, num);
			}
			if (!System.Version.TryParse(readOnlySpan, out Version result))
			{
				return new Version();
			}
			return result;
		}
	}

	public static string StackTrace
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return new StackTrace(fNeedFileInfo: true).ToString(System.Diagnostics.StackTrace.TraceFormat.Normal);
		}
	}

	public static int SystemPageSize
	{
		get
		{
			int num = s_systemPageSize;
			if (num == 0)
			{
				num = (s_systemPageSize = GetSystemPageSize());
			}
			return num;
		}
	}

	internal static bool IsWindows8OrAbove => WindowsVersion.IsWindows8OrAbove;

	public static string UserName
	{
		get
		{
			Span<char> initialBuffer = stackalloc char[40];
			ValueStringBuilder builder = new ValueStringBuilder(initialBuffer);
			GetUserName(ref builder);
			ReadOnlySpan<char> span = builder.AsSpan();
			int num = span.IndexOf('\\');
			if (num >= 0)
			{
				span = span.Slice(num + 1);
			}
			string result = span.ToString();
			builder.Dispose();
			return result;
		}
	}

	public static string UserDomainName
	{
		get
		{
			Span<char> initialBuffer = stackalloc char[40];
			ValueStringBuilder builder = new ValueStringBuilder(initialBuffer);
			GetUserName(ref builder);
			ReadOnlySpan<char> span = builder.AsSpan();
			int num = span.IndexOf('\\');
			if (num >= 0)
			{
				builder.Length = num;
				return builder.ToString();
			}
			initialBuffer = stackalloc char[64];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			uint cchReferencedDomainName = (uint)valueStringBuilder.Capacity;
			Span<byte> span2 = stackalloc byte[68];
			uint cbSid = 68u;
			uint peUse;
			while (!Interop.Advapi32.LookupAccountNameW(null, ref builder.GetPinnableReference(), ref MemoryMarshal.GetReference(span2), ref cbSid, ref valueStringBuilder.GetPinnableReference(), ref cchReferencedDomainName, out peUse))
			{
				int lastPInvokeError = Marshal.GetLastPInvokeError();
				if (lastPInvokeError != 122)
				{
					throw new InvalidOperationException(Marshal.GetPInvokeErrorMessage(lastPInvokeError));
				}
				valueStringBuilder.EnsureCapacity((int)cchReferencedDomainName);
			}
			builder.Dispose();
			valueStringBuilder.Length = (int)cchReferencedDomainName;
			return valueStringBuilder.ToString();
		}
	}

	private static string CurrentDirectoryCore
	{
		get
		{
			Span<char> initialBuffer = stackalloc char[260];
			ValueStringBuilder outputBuilder = new ValueStringBuilder(initialBuffer);
			uint currentDirectory;
			while ((currentDirectory = Interop.Kernel32.GetCurrentDirectory((uint)outputBuilder.Capacity, ref outputBuilder.GetPinnableReference())) > outputBuilder.Capacity)
			{
				outputBuilder.EnsureCapacity((int)currentDirectory);
			}
			if (currentDirectory == 0)
			{
				throw Win32Marshal.GetExceptionForLastWin32Error();
			}
			outputBuilder.Length = (int)currentDirectory;
			if (outputBuilder.AsSpan().Contains('~'))
			{
				string result = PathHelper.TryExpandShortFileName(ref outputBuilder, null);
				outputBuilder.Dispose();
				return result;
			}
			return outputBuilder.ToString();
		}
		set
		{
			if (!Interop.Kernel32.SetCurrentDirectory(value))
			{
				int lastPInvokeError = Marshal.GetLastPInvokeError();
				throw Win32Marshal.GetExceptionForWin32Error((lastPInvokeError == 2) ? 3 : lastPInvokeError, value);
			}
		}
	}

	public static string MachineName => Interop.Kernel32.GetComputerName() ?? throw new InvalidOperationException(SR.InvalidOperation_ComputerName);

	public static string SystemDirectory
	{
		get
		{
			Span<char> initialBuffer = stackalloc char[32];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			uint systemDirectoryW;
			while ((systemDirectoryW = Interop.Kernel32.GetSystemDirectoryW(ref valueStringBuilder.GetPinnableReference(), (uint)valueStringBuilder.Capacity)) > valueStringBuilder.Capacity)
			{
				valueStringBuilder.EnsureCapacity((int)systemDirectoryW);
			}
			if (systemDirectoryW == 0)
			{
				throw Win32Marshal.GetExceptionForLastWin32Error();
			}
			valueStringBuilder.Length = (int)systemDirectoryW;
			return valueStringBuilder.ToString();
		}
	}

	public unsafe static bool UserInteractive
	{
		get
		{
			nint processWindowStation = Interop.User32.GetProcessWindowStation();
			if (processWindowStation != IntPtr.Zero)
			{
				Interop.User32.USEROBJECTFLAGS uSEROBJECTFLAGS = default(Interop.User32.USEROBJECTFLAGS);
				uint lpnLengthNeeded = 0u;
				if (Interop.User32.GetUserObjectInformationW(processWindowStation, 1, &uSEROBJECTFLAGS, (uint)sizeof(Interop.User32.USEROBJECTFLAGS), ref lpnLengthNeeded))
				{
					return (uSEROBJECTFLAGS.dwFlags & 1) != 0;
				}
			}
			return true;
		}
	}

	public unsafe static long WorkingSet
	{
		get
		{
			Interop.Kernel32.PROCESS_MEMORY_COUNTERS ppsmemCounters = default(Interop.Kernel32.PROCESS_MEMORY_COUNTERS);
			ppsmemCounters.cb = (uint)sizeof(Interop.Kernel32.PROCESS_MEMORY_COUNTERS);
			if (!Interop.Kernel32.GetProcessMemoryInfo(Interop.Kernel32.GetCurrentProcess(), ref ppsmemCounters, ppsmemCounters.cb))
			{
				return 0L;
			}
			return (long)ppsmemCounters.WorkingSetSize;
		}
	}

	[DllImport("QCall", EntryPoint = "Environment_Exit", ExactSpelling = true)]
	[LibraryImport("QCall", EntryPoint = "Environment_Exit")]
	[DoesNotReturn]
	private static extern void _Exit(int exitCode);

	[DoesNotReturn]
	public static void Exit(int exitCode)
	{
		_Exit(exitCode);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[DoesNotReturn]
	public static extern void FailFast(string? message);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[DoesNotReturn]
	public static extern void FailFast(string? message, Exception? exception);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[DoesNotReturn]
	internal static extern void FailFast(string message, Exception exception, string errorMessage);

	private unsafe static string[] InitializeCommandLineArgs(char* exePath, int argc, char** argv)
	{
		string[] array = new string[argc + 1];
		string[] array2 = new string[argc];
		array[0] = new string(exePath);
		for (int i = 0; i < array2.Length; i++)
		{
			array[i + 1] = (array2[i] = new string(argv[i]));
		}
		s_commandLineArgs = array;
		return array2;
	}

	[DllImport("QCall", EntryPoint = "Environment_GetProcessorCount", ExactSpelling = true)]
	[LibraryImport("QCall", EntryPoint = "Environment_GetProcessorCount")]
	private static extern int GetProcessorCount();

	internal static string GetResourceStringLocal(string key)
	{
		return SR.GetResourceString(key);
	}

	public static string? GetEnvironmentVariable(string variable)
	{
		ArgumentNullException.ThrowIfNull(variable, "variable");
		return GetEnvironmentVariableCore(variable);
	}

	public static string? GetEnvironmentVariable(string variable, EnvironmentVariableTarget target)
	{
		if (target == EnvironmentVariableTarget.Process)
		{
			return GetEnvironmentVariable(variable);
		}
		ArgumentNullException.ThrowIfNull(variable, "variable");
		bool fromMachine = ValidateAndConvertRegistryTarget(target);
		return GetEnvironmentVariableFromRegistry(variable, fromMachine);
	}

	public static IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target)
	{
		if (target == EnvironmentVariableTarget.Process)
		{
			return GetEnvironmentVariables();
		}
		bool fromMachine = ValidateAndConvertRegistryTarget(target);
		return GetEnvironmentVariablesFromRegistry(fromMachine);
	}

	public static void SetEnvironmentVariable(string variable, string? value)
	{
		ValidateVariableAndValue(variable, ref value);
		SetEnvironmentVariableCore(variable, value);
	}

	public static void SetEnvironmentVariable(string variable, string? value, EnvironmentVariableTarget target)
	{
		if (target == EnvironmentVariableTarget.Process)
		{
			SetEnvironmentVariable(variable, value);
			return;
		}
		ValidateVariableAndValue(variable, ref value);
		bool fromMachine = ValidateAndConvertRegistryTarget(target);
		SetEnvironmentVariableFromRegistry(variable, value, fromMachine);
	}

	public static string[] GetCommandLineArgs()
	{
		if (s_commandLineArgs == null)
		{
			return GetCommandLineArgsNative();
		}
		return (string[])s_commandLineArgs.Clone();
	}

	public static string ExpandEnvironmentVariables(string name)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		if (name.Length == 0)
		{
			return name;
		}
		return ExpandEnvironmentVariablesCore(name);
	}

	public static string GetFolderPath(SpecialFolder folder)
	{
		return GetFolderPath(folder, SpecialFolderOption.None);
	}

	public static string GetFolderPath(SpecialFolder folder, SpecialFolderOption option)
	{
		if (!Enum.IsDefined(folder))
		{
			throw new ArgumentOutOfRangeException("folder", folder, SR.Format(SR.Arg_EnumIllegalVal, folder));
		}
		if (option != 0 && !Enum.IsDefined(option))
		{
			throw new ArgumentOutOfRangeException("option", option, SR.Format(SR.Arg_EnumIllegalVal, option));
		}
		return GetFolderPathCore(folder, option);
	}

	private static bool ValidateAndConvertRegistryTarget(EnvironmentVariableTarget target)
	{
		return target switch
		{
			EnvironmentVariableTarget.Machine => true, 
			EnvironmentVariableTarget.User => false, 
			_ => throw new ArgumentOutOfRangeException("target", target, SR.Format(SR.Arg_EnumIllegalVal, target)), 
		};
	}

	private static void ValidateVariableAndValue(string variable, ref string value)
	{
		ArgumentException.ThrowIfNullOrEmpty(variable, "variable");
		if (variable[0] == '\0')
		{
			throw new ArgumentException(SR.Argument_StringFirstCharIsZero, "variable");
		}
		if (variable.Contains('='))
		{
			throw new ArgumentException(SR.Argument_IllegalEnvVarName, "variable");
		}
		if (string.IsNullOrEmpty(value) || value[0] == '\0')
		{
			value = null;
		}
	}

	private static string GetEnvironmentVariableFromRegistry(string variable, bool fromMachine)
	{
		using RegistryKey registryKey = OpenEnvironmentKeyIfExists(fromMachine, writable: false);
		return registryKey?.GetValue(variable) as string;
	}

	private unsafe static void SetEnvironmentVariableFromRegistry(string variable, string value, bool fromMachine)
	{
		if (!fromMachine && variable.Length >= 255)
		{
			throw new ArgumentException(SR.Argument_LongEnvVarValue, "variable");
		}
		using (RegistryKey registryKey = OpenEnvironmentKeyIfExists(fromMachine, writable: true))
		{
			if (registryKey != null)
			{
				if (value == null)
				{
					registryKey.DeleteValue(variable, throwOnMissingValue: false);
				}
				else
				{
					registryKey.SetValue(variable, value);
				}
			}
		}
		fixed (char* lParam = &"Environment".GetPinnableReference())
		{
			Unsafe.SkipInit(out nint num);
			nint num2 = Interop.User32.SendMessageTimeout(new IntPtr(65535), 26, IntPtr.Zero, (nint)lParam, 0, 1000, &num);
		}
	}

	private static Hashtable GetEnvironmentVariablesFromRegistry(bool fromMachine)
	{
		Hashtable hashtable = new Hashtable();
		using (RegistryKey registryKey = OpenEnvironmentKeyIfExists(fromMachine, writable: false))
		{
			if (registryKey != null)
			{
				string[] valueNames = registryKey.GetValueNames();
				foreach (string text in valueNames)
				{
					string value = registryKey.GetValue(text, "").ToString();
					try
					{
						hashtable.Add(text, value);
					}
					catch (ArgumentException)
					{
					}
				}
			}
		}
		return hashtable;
	}

	private static RegistryKey OpenEnvironmentKeyIfExists(bool fromMachine, bool writable)
	{
		RegistryKey registryKey;
		string name;
		if (fromMachine)
		{
			registryKey = Registry.LocalMachine;
			name = "System\\CurrentControlSet\\Control\\Session Manager\\Environment";
		}
		else
		{
			registryKey = Registry.CurrentUser;
			name = "Environment";
		}
		return registryKey.OpenSubKey(name, writable);
	}

	private static void GetUserName(ref ValueStringBuilder builder)
	{
		uint lpnSize = 0u;
		while (Interop.Secur32.GetUserNameExW(2, ref builder.GetPinnableReference(), ref lpnSize) == Interop.BOOLEAN.FALSE)
		{
			if (Marshal.GetLastPInvokeError() == 234)
			{
				builder.EnsureCapacity(checked((int)lpnSize));
				continue;
			}
			builder.Length = 0;
			return;
		}
		builder.Length = (int)lpnSize;
	}

	private static string GetFolderPathCore(SpecialFolder folder, SpecialFolderOption option)
	{
		string g;
		switch (folder)
		{
		case SpecialFolder.System:
			return SystemDirectory;
		default:
			return string.Empty;
		case SpecialFolder.ApplicationData:
			g = "{3EB685DB-65F9-4CF6-A03A-E3EF65729F3D}";
			break;
		case SpecialFolder.CommonApplicationData:
			g = "{62AB5D82-FDC1-4DC3-A9DD-070D1D495D97}";
			break;
		case SpecialFolder.LocalApplicationData:
			g = "{F1B32785-6FBA-4FCF-9D55-7B8E7F157091}";
			break;
		case SpecialFolder.Cookies:
			g = "{2B0F765D-C0E9-4171-908E-08A611B84FF6}";
			break;
		case SpecialFolder.Desktop:
			g = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
			break;
		case SpecialFolder.Favorites:
			g = "{1777F761-68AD-4D8A-87BD-30B759FA33DD}";
			break;
		case SpecialFolder.History:
			g = "{D9DC8A3B-B784-432E-A781-5A1130A75963}";
			break;
		case SpecialFolder.InternetCache:
			g = "{352481E8-33BE-4251-BA85-6007CAEDCF9D}";
			break;
		case SpecialFolder.Programs:
			g = "{A77F5D77-2E2B-44C3-A6A2-ABA601054A51}";
			break;
		case SpecialFolder.MyComputer:
			g = "{0AC0837C-BBF8-452A-850D-79D08E667CA7}";
			break;
		case SpecialFolder.MyMusic:
			g = "{4BD8D571-6D19-48D3-BE97-422220080E43}";
			break;
		case SpecialFolder.MyPictures:
			g = "{33E28130-4E1E-4676-835A-98395C3BC3BB}";
			break;
		case SpecialFolder.MyVideos:
			g = "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}";
			break;
		case SpecialFolder.Recent:
			g = "{AE50C081-EBD2-438A-8655-8A092E34987A}";
			break;
		case SpecialFolder.SendTo:
			g = "{8983036C-27C0-404B-8F08-102D10DCFD74}";
			break;
		case SpecialFolder.StartMenu:
			g = "{625B53C3-AB48-4EC1-BA1F-A1EF4146FC19}";
			break;
		case SpecialFolder.Startup:
			g = "{B97D20BB-F46A-4C97-BA10-5E3608430854}";
			break;
		case SpecialFolder.Templates:
			g = "{A63293E8-664E-48DB-A079-DF759E0509F7}";
			break;
		case SpecialFolder.DesktopDirectory:
			g = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
			break;
		case SpecialFolder.Personal:
			g = "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}";
			break;
		case SpecialFolder.ProgramFiles:
			g = "{905e63b6-c1bf-494e-b29c-65b732d3d21a}";
			break;
		case SpecialFolder.CommonProgramFiles:
			g = "{F7F1ED05-9F6D-47A2-AAAE-29D317C6F066}";
			break;
		case SpecialFolder.AdminTools:
			g = "{724EF170-A42D-4FEF-9F26-B60E846FBA4F}";
			break;
		case SpecialFolder.CDBurning:
			g = "{9E52AB10-F80D-49DF-ACB8-4330F5687855}";
			break;
		case SpecialFolder.CommonAdminTools:
			g = "{D0384E7D-BAC3-4797-8F14-CBA229B392B5}";
			break;
		case SpecialFolder.CommonDocuments:
			g = "{ED4824AF-DCE4-45A8-81E2-FC7965083634}";
			break;
		case SpecialFolder.CommonMusic:
			g = "{3214FAB5-9757-4298-BB61-92A9DEAA44FF}";
			break;
		case SpecialFolder.CommonOemLinks:
			g = "{C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D}";
			break;
		case SpecialFolder.CommonPictures:
			g = "{B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5}";
			break;
		case SpecialFolder.CommonStartMenu:
			g = "{A4115719-D62E-491D-AA7C-E74B8BE3B067}";
			break;
		case SpecialFolder.CommonPrograms:
			g = "{0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8}";
			break;
		case SpecialFolder.CommonStartup:
			g = "{82A5EA35-D9CD-47C5-9629-E15D2F714E6E}";
			break;
		case SpecialFolder.CommonDesktopDirectory:
			g = "{C4AA340D-F20F-4863-AFEF-F87EF2E6BA25}";
			break;
		case SpecialFolder.CommonTemplates:
			g = "{B94237E7-57AC-4347-9151-B08C6C32D1F7}";
			break;
		case SpecialFolder.CommonVideos:
			g = "{2400183A-6185-49FB-A2D8-4A392A602BA3}";
			break;
		case SpecialFolder.Fonts:
			g = "{FD228CB7-AE11-4AE3-864C-16F3910AB8FE}";
			break;
		case SpecialFolder.NetworkShortcuts:
			g = "{C5ABBF53-E17F-4121-8900-86626FC2C973}";
			break;
		case SpecialFolder.PrinterShortcuts:
			g = "{76FC4E2D-D6AD-4519-A663-37BD56068185}";
			break;
		case SpecialFolder.UserProfile:
			g = "{5E6C858F-0E22-4760-9AFE-EA3317B67173}";
			break;
		case SpecialFolder.CommonProgramFilesX86:
			g = "{DE974D24-D9C6-4D3E-BF91-F4455120B917}";
			break;
		case SpecialFolder.ProgramFilesX86:
			g = "{7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E}";
			break;
		case SpecialFolder.Resources:
			g = "{8AD10C31-2ADB-4296-A8F7-E4701232C972}";
			break;
		case SpecialFolder.LocalizedResources:
			g = "{2A00375E-224C-49DE-B8D1-440DF7EF3DDC}";
			break;
		case SpecialFolder.SystemX86:
			g = "{D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27}";
			break;
		case SpecialFolder.Windows:
			g = "{F38BF404-1D43-42F2-9305-67DE0B28FC23}";
			break;
		}
		Guid rfid = new Guid(g);
		if (Interop.Shell32.SHGetKnownFolderPath(in rfid, (uint)option, IntPtr.Zero, out var ppszPath) != 0)
		{
			return string.Empty;
		}
		return ppszPath;
	}

	public static string[] GetLogicalDrives()
	{
		return DriveInfoInternal.GetLogicalDrives();
	}

	private unsafe static int GetSystemPageSize()
	{
		Unsafe.SkipInit(out Interop.Kernel32.SYSTEM_INFO sYSTEM_INFO);
		Interop.Kernel32.GetSystemInfo(&sYSTEM_INFO);
		return sYSTEM_INFO.dwPageSize;
	}

	private static string ExpandEnvironmentVariablesCore(string name)
	{
		Span<char> initialBuffer = stackalloc char[128];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		uint num;
		while ((num = Interop.Kernel32.ExpandEnvironmentStrings(name, ref valueStringBuilder.GetPinnableReference(), (uint)valueStringBuilder.Capacity)) > valueStringBuilder.Capacity)
		{
			valueStringBuilder.EnsureCapacity((int)num);
		}
		if (num == 0)
		{
			throw Win32Marshal.GetExceptionForLastWin32Error();
		}
		valueStringBuilder.Length = (int)(num - 1);
		return valueStringBuilder.ToString();
	}

	private unsafe static bool IsPrivilegedProcessCore()
	{
		SafeTokenHandle TokenHandle = null;
		try
		{
			if (Interop.Advapi32.OpenProcessToken(Interop.Kernel32.GetCurrentProcess(), 131080, out TokenHandle))
			{
				Interop.Advapi32.TOKEN_ELEVATION tOKEN_ELEVATION = default(Interop.Advapi32.TOKEN_ELEVATION);
				if (Interop.Advapi32.GetTokenInformation(TokenHandle, Interop.Advapi32.TOKEN_INFORMATION_CLASS.TokenElevation, &tOKEN_ELEVATION, (uint)sizeof(Interop.Advapi32.TOKEN_ELEVATION), out var _))
				{
					return tOKEN_ELEVATION.TokenIsElevated != Interop.BOOL.FALSE;
				}
			}
			throw Win32Marshal.GetExceptionForLastWin32Error();
		}
		finally
		{
			TokenHandle?.Dispose();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetProcessId()
	{
		return (int)Interop.Kernel32.GetCurrentProcessId();
	}

	private static string GetProcessPath()
	{
		Span<char> initialBuffer = stackalloc char[260];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		uint moduleFileName;
		while ((moduleFileName = Interop.Kernel32.GetModuleFileName(IntPtr.Zero, ref valueStringBuilder.GetPinnableReference(), (uint)valueStringBuilder.Capacity)) >= valueStringBuilder.Capacity)
		{
			valueStringBuilder.EnsureCapacity((int)moduleFileName);
		}
		if (moduleFileName == 0)
		{
			throw Win32Marshal.GetExceptionForLastWin32Error();
		}
		valueStringBuilder.Length = (int)moduleFileName;
		return valueStringBuilder.ToString();
	}

	private unsafe static OperatingSystem GetOSVersion()
	{
		if (Interop.NtDll.RtlGetVersionEx(out var osvi) != 0)
		{
			throw new InvalidOperationException(SR.InvalidOperation_GetVersion);
		}
		Version version = new Version((int)osvi.dwMajorVersion, (int)osvi.dwMinorVersion, (int)osvi.dwBuildNumber, 0);
		if (osvi.szCSDVersion[0] == '\0')
		{
			return new OperatingSystem(PlatformID.Win32NT, version);
		}
		return new OperatingSystem(PlatformID.Win32NT, version, new string(osvi.szCSDVersion));
	}

	private unsafe static string[] GetCommandLineArgsNative()
	{
		char* commandLine = Interop.Kernel32.GetCommandLine();
		return SegmentCommandLine(commandLine);
	}

	private unsafe static string[] SegmentCommandLine(char* cmdLine)
	{
		ArrayBuilder<string> arrayBuilder = default(ArrayBuilder<string>);
		Span<char> initialBuffer = stackalloc char[260];
		char* ptr = cmdLine;
		bool flag = false;
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		char c;
		bool flag3;
		do
		{
			if (*ptr == '"')
			{
				flag = !flag;
				c = *(ptr++);
			}
			else
			{
				c = *(ptr++);
				valueStringBuilder.Append(c);
			}
			bool flag2 = c != '\0';
			flag3 = flag2;
			if (flag3)
			{
				bool flag4 = flag;
				bool flag5 = flag4;
				if (!flag5)
				{
					bool flag6 = ((c == '\t' || c == ' ') ? true : false);
					flag5 = !flag6;
				}
				flag3 = flag5;
			}
		}
		while (flag3);
		if (c == '\0')
		{
			ptr--;
		}
		valueStringBuilder.Length--;
		arrayBuilder.Add(valueStringBuilder.ToString());
		flag = false;
		while (true)
		{
			if (*ptr != 0)
			{
				while (true)
				{
					char c2 = *ptr;
					if ((c2 != '\t' && c2 != ' ') || 1 == 0)
					{
						break;
					}
					ptr++;
				}
			}
			if (*ptr == '\0')
			{
				break;
			}
			valueStringBuilder = new ValueStringBuilder(initialBuffer);
			while (true)
			{
				bool flag7 = true;
				int num = 0;
				while (*ptr == '\\')
				{
					ptr++;
					num++;
				}
				if (*ptr == '"')
				{
					if (num % 2 == 0)
					{
						if (flag && ptr[1] == '"')
						{
							ptr++;
						}
						else
						{
							flag7 = false;
							flag = !flag;
						}
					}
					num /= 2;
				}
				while (num-- > 0)
				{
					valueStringBuilder.Append('\\');
				}
				bool flag8 = *ptr == '\0';
				bool flag9 = flag8;
				if (!flag9)
				{
					bool flag10 = !flag;
					bool flag11 = flag10;
					if (flag11)
					{
						char c2 = *ptr;
						bool flag6 = ((c2 == '\t' || c2 == ' ') ? true : false);
						flag11 = flag6;
					}
					flag9 = flag11;
				}
				if (flag9)
				{
					break;
				}
				if (flag7)
				{
					valueStringBuilder.Append(*ptr);
				}
				ptr++;
			}
			arrayBuilder.Add(valueStringBuilder.ToString());
		}
		return arrayBuilder.ToArray();
	}

	private static string GetEnvironmentVariableCore(string variable)
	{
		Span<char> initialBuffer = stackalloc char[128];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		uint environmentVariable;
		while ((environmentVariable = Interop.Kernel32.GetEnvironmentVariable(variable, ref valueStringBuilder.GetPinnableReference(), (uint)valueStringBuilder.Capacity)) > valueStringBuilder.Capacity)
		{
			valueStringBuilder.EnsureCapacity((int)environmentVariable);
		}
		if (environmentVariable == 0 && Marshal.GetLastPInvokeError() == 203)
		{
			valueStringBuilder.Dispose();
			return null;
		}
		valueStringBuilder.Length = (int)environmentVariable;
		return valueStringBuilder.ToString();
	}

	internal static string GetEnvironmentVariableCore_NoArrayPool(string variable)
	{
		Span<char> span = stackalloc char[128];
		uint environmentVariable = Interop.Kernel32.GetEnvironmentVariable(variable, ref MemoryMarshal.GetReference(span), (uint)span.Length);
		if (environmentVariable == 0 || environmentVariable > span.Length)
		{
			return null;
		}
		return span.Slice(0, (int)environmentVariable).ToString();
	}

	private static void SetEnvironmentVariableCore(string variable, string value)
	{
		if (!Interop.Kernel32.SetEnvironmentVariable(variable, value))
		{
			int lastPInvokeError = Marshal.GetLastPInvokeError();
			switch (lastPInvokeError)
			{
			case 203:
				break;
			case 206:
				throw new ArgumentException(SR.Argument_LongEnvVarValue);
			case 8:
			case 1450:
				throw new OutOfMemoryException(Marshal.GetPInvokeErrorMessage(lastPInvokeError));
			default:
				throw new ArgumentException(Marshal.GetPInvokeErrorMessage(lastPInvokeError));
			}
		}
	}

	public unsafe static IDictionary GetEnvironmentVariables()
	{
		char* environmentStringsW = Interop.Kernel32.GetEnvironmentStringsW();
		if (environmentStringsW == null)
		{
			throw new OutOfMemoryException();
		}
		try
		{
			Hashtable hashtable = new Hashtable();
			char* ptr = environmentStringsW;
			while (true)
			{
				ReadOnlySpan<char> span = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(ptr);
				if (span.IsEmpty)
				{
					break;
				}
				int num = span.IndexOf('=');
				if (num > 0)
				{
					string key = new string(span.Slice(0, num));
					string value = new string(span.Slice(num + 1));
					try
					{
						hashtable.Add(key, value);
					}
					catch (ArgumentException)
					{
					}
				}
				ptr += span.Length + 1;
			}
			return hashtable;
		}
		finally
		{
			Interop.BOOL bOOL = Interop.Kernel32.FreeEnvironmentStringsW(environmentStringsW);
		}
	}
}
