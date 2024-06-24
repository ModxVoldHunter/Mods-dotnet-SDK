using System.Numerics;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices;

public static class NativeMemory
{
	[CLSCompliant(false)]
	public unsafe static void* Alloc(nuint elementCount, nuint elementSize)
	{
		nuint byteCount = GetByteCount(elementCount, elementSize);
		return Alloc(byteCount);
	}

	[CLSCompliant(false)]
	public unsafe static void* AllocZeroed(nuint byteCount)
	{
		return AllocZeroed(byteCount, 1u);
	}

	[CLSCompliant(false)]
	public unsafe static void Clear(void* ptr, nuint byteCount)
	{
		SpanHelpers.ClearWithoutReferences(ref *(byte*)ptr, byteCount);
	}

	[CLSCompliant(false)]
	public unsafe static void Copy(void* source, void* destination, nuint byteCount)
	{
		Buffer.Memmove(ref *(byte*)destination, ref *(byte*)source, byteCount);
	}

	[CLSCompliant(false)]
	public unsafe static void Fill(void* ptr, nuint byteCount, byte value)
	{
		SpanHelpers.Fill(ref *(byte*)ptr, byteCount, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static nuint GetByteCount(nuint elementCount, nuint elementSize)
	{
		nuint num = (nuint)((nint)1 << (0x20 & 0x3F));
		if ((elementSize < num && elementCount < num) || elementSize == 0 || UIntPtr.MaxValue / elementSize >= elementCount)
		{
			return elementCount * elementSize;
		}
		return UIntPtr.MaxValue;
	}

	[CLSCompliant(false)]
	public unsafe static void* AlignedAlloc(nuint byteCount, nuint alignment)
	{
		if (!BitOperations.IsPow2(alignment))
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AlignmentMustBePow2);
		}
		void* ptr = Interop.Ucrtbase._aligned_malloc((byteCount != 0) ? byteCount : 1, alignment);
		if (ptr == null)
		{
			ThrowHelper.ThrowOutOfMemoryException();
		}
		return ptr;
	}

	[CLSCompliant(false)]
	public unsafe static void AlignedFree(void* ptr)
	{
		if (ptr != null)
		{
			Interop.Ucrtbase._aligned_free(ptr);
		}
	}

	[CLSCompliant(false)]
	public unsafe static void* AlignedRealloc(void* ptr, nuint byteCount, nuint alignment)
	{
		if (!BitOperations.IsPow2(alignment))
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AlignmentMustBePow2);
		}
		void* ptr2 = Interop.Ucrtbase._aligned_realloc(ptr, (byteCount != 0) ? byteCount : 1, alignment);
		if (ptr2 == null)
		{
			ThrowHelper.ThrowOutOfMemoryException();
		}
		return ptr2;
	}

	[CLSCompliant(false)]
	public unsafe static void* Alloc(nuint byteCount)
	{
		void* ptr = Interop.Ucrtbase.malloc(byteCount);
		if (ptr == null)
		{
			ThrowHelper.ThrowOutOfMemoryException();
		}
		return ptr;
	}

	[CLSCompliant(false)]
	public unsafe static void* AllocZeroed(nuint elementCount, nuint elementSize)
	{
		void* ptr = Interop.Ucrtbase.calloc(elementCount, elementSize);
		if (ptr == null)
		{
			ThrowHelper.ThrowOutOfMemoryException();
		}
		return ptr;
	}

	[CLSCompliant(false)]
	public unsafe static void Free(void* ptr)
	{
		if (ptr != null)
		{
			Interop.Ucrtbase.free(ptr);
		}
	}

	[CLSCompliant(false)]
	public unsafe static void* Realloc(void* ptr, nuint byteCount)
	{
		void* ptr2 = Interop.Ucrtbase.realloc(ptr, (byteCount != 0) ? byteCount : 1);
		if (ptr2 == null)
		{
			ThrowHelper.ThrowOutOfMemoryException();
		}
		return ptr2;
	}
}
