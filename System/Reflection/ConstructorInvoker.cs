using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Reflection;

public sealed class ConstructorInvoker
{
	private readonly Signature _signature;

	private InvokerEmitUtil.InvokeFunc_ObjSpanArgs _invokeFunc_ObjSpanArgs;

	private InvokerEmitUtil.InvokeFunc_Obj4Args _invokeFunc_Obj4Args;

	private InvokerEmitUtil.InvokeFunc_RefArgs _invokeFunc_RefArgs;

	private MethodBase.InvokerStrategy _strategy;

	private readonly int _argCount;

	private readonly RuntimeType[] _argTypes;

	private readonly InvocationFlags _invocationFlags;

	private readonly MethodBase.InvokerArgFlags[] _invokerArgFlags;

	private readonly RuntimeConstructorInfo _method;

	private readonly bool _needsByRefStrategy;

	internal unsafe ConstructorInvoker(RuntimeConstructorInfo constructor)
		: this(constructor, constructor.Signature.Arguments)
	{
		_signature = constructor.Signature;
		_invokeFunc_RefArgs = InterpretedInvoke;
	}

	private unsafe object InterpretedInvoke(object obj, nint* args)
	{
		return RuntimeMethodHandle.InvokeMethod(obj, (void**)args, _signature, obj == null);
	}

	public static ConstructorInvoker Create(ConstructorInfo constructor)
	{
		ArgumentNullException.ThrowIfNull(constructor, "constructor");
		if (!(constructor is RuntimeConstructorInfo constructor2))
		{
			throw new ArgumentException(SR.Argument_MustBeRuntimeConstructorInfo, "constructor");
		}
		return new ConstructorInvoker(constructor2);
	}

	private ConstructorInvoker(RuntimeConstructorInfo constructor, RuntimeType[] argumentTypes)
	{
		_method = constructor;
		_invocationFlags = constructor.ComputeAndUpdateInvocationFlags();
		_argTypes = argumentTypes;
		_argCount = _argTypes.Length;
		MethodInvokerCommon.Initialize(argumentTypes, out _strategy, out _invokerArgFlags, out _needsByRefStrategy);
	}

	public object Invoke()
	{
		if (_argCount != 0)
		{
			MethodBaseInvoker.ThrowTargetParameterCountException();
		}
		return InvokeImpl(null, null, null, null);
	}

	public object Invoke(object? arg1)
	{
		if (_argCount != 1)
		{
			MethodBaseInvoker.ThrowTargetParameterCountException();
		}
		return InvokeImpl(arg1, null, null, null);
	}

	public object Invoke(object? arg1, object? arg2)
	{
		if (_argCount != 2)
		{
			MethodBaseInvoker.ThrowTargetParameterCountException();
		}
		return InvokeImpl(arg1, arg2, null, null);
	}

	public object Invoke(object? arg1, object? arg2, object? arg3)
	{
		if (_argCount != 3)
		{
			MethodBaseInvoker.ThrowTargetParameterCountException();
		}
		return InvokeImpl(arg1, arg2, arg3, null);
	}

	public object Invoke(object? arg1, object? arg2, object? arg3, object? arg4)
	{
		if (_argCount != 4)
		{
			MethodBaseInvoker.ThrowTargetParameterCountException();
		}
		return InvokeImpl(arg1, arg2, arg3, arg4);
	}

	private object InvokeImpl(object arg1, object arg2, object arg3, object arg4)
	{
		if ((_invocationFlags & (InvocationFlags.NoInvoke | InvocationFlags.NoConstructorInvoke | InvocationFlags.ContainsStackPointers)) != 0)
		{
			_method.ThrowNoInvokeException();
		}
		switch (_argCount)
		{
		case 4:
			CheckArgument(ref arg4, 3);
			goto case 3;
		case 3:
			CheckArgument(ref arg3, 2);
			goto case 2;
		case 2:
			CheckArgument(ref arg2, 1);
			goto case 1;
		case 1:
			CheckArgument(ref arg1, 0);
			break;
		}
		if (_invokeFunc_Obj4Args != null)
		{
			return _invokeFunc_Obj4Args(null, arg1, arg2, arg3, arg4);
		}
		if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_Obj4Args) == 0)
		{
			MethodInvokerCommon.DetermineStrategy_Obj4Args(ref _strategy, ref _invokeFunc_Obj4Args, _method, _needsByRefStrategy, backwardsCompat: false);
			if (_invokeFunc_Obj4Args != null)
			{
				return _invokeFunc_Obj4Args(null, arg1, arg2, arg3, arg4);
			}
		}
		return InvokeDirectByRef(arg1, arg2, arg3, arg4);
	}

	public object Invoke(Span<object?> arguments)
	{
		int length = arguments.Length;
		if (length != _argCount)
		{
			MethodBaseInvoker.ThrowTargetParameterCountException();
		}
		if (!_needsByRefStrategy)
		{
			switch (_argCount)
			{
			case 0:
				return InvokeImpl(null, null, null, null);
			case 1:
				return InvokeImpl(arguments[0], null, null, null);
			case 2:
				return InvokeImpl(arguments[0], arguments[1], null, null);
			case 3:
				return InvokeImpl(arguments[0], arguments[1], arguments[2], null);
			case 4:
				return InvokeImpl(arguments[0], arguments[1], arguments[2], arguments[3]);
			}
		}
		if ((_invocationFlags & (InvocationFlags.NoInvoke | InvocationFlags.ContainsStackPointers)) != 0)
		{
			_method.ThrowNoInvokeException();
		}
		if (length > 4)
		{
			return InvokeWithManyArgs(arguments);
		}
		return InvokeWithFewArgs(arguments);
	}

	internal object InvokeWithFewArgs(Span<object> arguments)
	{
		MethodBase.StackAllocatedArgumentsWithCopyBack stackAllocatedArgumentsWithCopyBack = default(MethodBase.StackAllocatedArgumentsWithCopyBack);
		Span<object> span = stackAllocatedArgumentsWithCopyBack._args.AsSpan(_argCount);
		Span<bool> shouldCopyBack = stackAllocatedArgumentsWithCopyBack._shouldCopyBack.AsSpan(_argCount);
		for (int i = 0; i < _argCount; i++)
		{
			object arg = arguments[i];
			shouldCopyBack[i] = CheckArgument(ref arg, i);
			span[i] = arg;
		}
		if (_invokeFunc_ObjSpanArgs != null)
		{
			return _invokeFunc_ObjSpanArgs(null, span);
		}
		if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_ObjSpanArgs) == 0)
		{
			MethodInvokerCommon.DetermineStrategy_ObjSpanArgs(ref _strategy, ref _invokeFunc_ObjSpanArgs, _method, _needsByRefStrategy, backwardsCompat: false);
			if (_invokeFunc_ObjSpanArgs != null)
			{
				return _invokeFunc_ObjSpanArgs(null, span);
			}
		}
		object result = InvokeDirectByRefWithFewArgs(span);
		CopyBack(arguments, span, shouldCopyBack);
		return result;
	}

	internal object InvokeDirectByRef(object arg1 = null, object arg2 = null, object arg3 = null, object arg4 = null)
	{
		return InvokeDirectByRefWithFewArgs(new MethodBase.StackAllocatedArguments(arg1, arg2, arg3, arg4)._args.AsSpan(_argCount));
	}

	internal unsafe object InvokeDirectByRefWithFewArgs(Span<object> copyOfArgs)
	{
		if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_RefArgs) == 0)
		{
			MethodInvokerCommon.DetermineStrategy_RefArgs(ref _strategy, ref _invokeFunc_RefArgs, _method, backwardsCompat: false);
		}
		MethodBase.StackAllocatedByRefs stackAllocatedByRefs = default(MethodBase.StackAllocatedByRefs);
		nint* ptr = (nint*)(&stackAllocatedByRefs);
		for (int i = 0; i < _argCount; i++)
		{
			Unsafe.Write((byte*)ptr + (nint)i * (nint)8, ((_invokerArgFlags[i] & MethodBase.InvokerArgFlags.IsValueType) != 0) ? ByReference.Create(ref copyOfArgs[i].GetRawData()) : ByReference.Create(ref copyOfArgs[i]));
		}
		return _invokeFunc_RefArgs(null, ptr);
	}

	internal unsafe object InvokeWithManyArgs(Span<object> arguments)
	{
		if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_ObjSpanArgs) == 0)
		{
			MethodInvokerCommon.DetermineStrategy_ObjSpanArgs(ref _strategy, ref _invokeFunc_ObjSpanArgs, _method, _needsByRefStrategy, backwardsCompat: false);
		}
		GCFrameRegistration gCFrameRegistration;
		object result;
		if (_invokeFunc_ObjSpanArgs != null)
		{
			nint* ptr = (nint*)stackalloc byte[(int)checked(unchecked((nuint)(uint)_argCount) * (nuint)8u)];
			NativeMemory.Clear(ptr, (nuint)_argCount * (nuint)8u);
			Span<object> arguments2 = new Span<object>(ref Unsafe.AsRef<object>(ptr), _argCount);
			gCFrameRegistration = new GCFrameRegistration((void**)ptr, (uint)_argCount, areByRefs: false);
			try
			{
				GCFrameRegistration.RegisterForGCReporting(&gCFrameRegistration);
				for (int i = 0; i < _argCount; i++)
				{
					object arg = arguments[i];
					CheckArgument(ref arg, i);
					arguments2[i] = arg;
				}
				result = _invokeFunc_ObjSpanArgs(null, arguments2);
			}
			finally
			{
				GCFrameRegistration.UnregisterForGCReporting(&gCFrameRegistration);
			}
		}
		else
		{
			if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_RefArgs) == 0)
			{
				MethodInvokerCommon.DetermineStrategy_RefArgs(ref _strategy, ref _invokeFunc_RefArgs, _method, backwardsCompat: false);
			}
			nint* ptr2 = (nint*)stackalloc byte[(int)checked(unchecked((nuint)(uint)(2 * _argCount)) * (nuint)8u)];
			NativeMemory.Clear(ptr2, (nuint)(2 * _argCount) * (nuint)8u);
			Span<object> arguments2 = new Span<object>(ref Unsafe.AsRef<object>(ptr2), _argCount);
			nint* ptr3 = (nint*)((byte*)ptr2 + (nint)_argCount * (nint)8);
			Span<bool> shouldCopyBack = stackalloc bool[_argCount];
			gCFrameRegistration = new GCFrameRegistration((void**)ptr2, (uint)_argCount, areByRefs: false);
			GCFrameRegistration gCFrameRegistration2 = new GCFrameRegistration((void**)ptr3, (uint)_argCount);
			try
			{
				GCFrameRegistration.RegisterForGCReporting(&gCFrameRegistration);
				GCFrameRegistration.RegisterForGCReporting(&gCFrameRegistration2);
				for (int j = 0; j < _argCount; j++)
				{
					object arg2 = arguments[j];
					shouldCopyBack[j] = CheckArgument(ref arg2, j);
					arguments2[j] = arg2;
					Unsafe.Write((byte*)ptr3 + (nint)j * (nint)8, ((_invokerArgFlags[j] & MethodBase.InvokerArgFlags.IsValueType) != 0) ? ByReference.Create(ref Unsafe.AsRef<object>((byte*)ptr2 + (nint)j * (nint)8).GetRawData()) : ByReference.Create(ref Unsafe.AsRef<object>((byte*)ptr2 + (nint)j * (nint)8)));
				}
				result = _invokeFunc_RefArgs(null, ptr3);
				CopyBack(arguments, arguments2, shouldCopyBack);
			}
			finally
			{
				GCFrameRegistration.UnregisterForGCReporting(&gCFrameRegistration2);
				GCFrameRegistration.UnregisterForGCReporting(&gCFrameRegistration);
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void CopyBack(Span<object> dest, Span<object> copyOfParameters, Span<bool> shouldCopyBack)
	{
		for (int i = 0; i < dest.Length; i++)
		{
			if (shouldCopyBack[i])
			{
				if ((_invokerArgFlags[i] & MethodBase.InvokerArgFlags.IsNullableOfT) != 0)
				{
					dest[i] = RuntimeMethodHandle.ReboxFromNullable(copyOfParameters[i]);
				}
				else
				{
					dest[i] = copyOfParameters[i];
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool CheckArgument(ref object arg, int i)
	{
		RuntimeType runtimeType = _argTypes[i];
		if (arg == null)
		{
			if ((_invokerArgFlags[i] & MethodBase.InvokerArgFlags.IsValueType_ByRef_Or_Pointer) != 0)
			{
				return runtimeType.CheckValue(ref arg);
			}
		}
		else if ((object)arg.GetType() != runtimeType)
		{
			return runtimeType.CheckValue(ref arg);
		}
		return false;
	}
}
