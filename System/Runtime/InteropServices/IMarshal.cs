namespace System.Runtime.InteropServices;

[ComImport]
[Guid("00000003-0000-0000-C000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IMarshal
{
	[PreserveSig]
	int GetUnmarshalClass(ref Guid riid, nint pv, int dwDestContext, nint pvDestContext, int mshlflags, out Guid pCid);

	[PreserveSig]
	int GetMarshalSizeMax(ref Guid riid, nint pv, int dwDestContext, nint pvDestContext, int mshlflags, out int pSize);

	[PreserveSig]
	int MarshalInterface(nint pStm, ref Guid riid, nint pv, int dwDestContext, nint pvDestContext, int mshlflags);

	[PreserveSig]
	int UnmarshalInterface(nint pStm, ref Guid riid, out nint ppv);

	[PreserveSig]
	int ReleaseMarshalData(nint pStm);

	[PreserveSig]
	int DisconnectObject(int dwReserved);
}
