using System.ComponentModel;

namespace System.Runtime.InteropServices.ComTypes;

[ComImport]
[Guid("00000102-0000-0000-C000-000000000046")]
[EditorBrowsable(EditorBrowsableState.Never)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IEnumMoniker
{
	[PreserveSig]
	int Next(int celt, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IMoniker[] rgelt, nint pceltFetched);

	[PreserveSig]
	int Skip(int celt);

	void Reset();

	void Clone(out IEnumMoniker ppenum);
}
