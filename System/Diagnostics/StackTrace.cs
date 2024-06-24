using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Diagnostics;

public class StackTrace
{
	internal enum TraceFormat
	{
		Normal,
		TrailingNewLine
	}

	public const int METHODS_TO_SKIP = 0;

	private int _numOfFrames;

	private int _methodsToSkip;

	private StackFrame[] _stackFrames;

	public virtual int FrameCount => _numOfFrames;

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetStackFramesInternal(StackFrameHelper sfh, int iSkip, bool fNeedFileInfo, Exception e);

	internal static int CalculateFramesToSkip(StackFrameHelper StackF, int iNumFrames)
	{
		int num = 0;
		for (int i = 0; i < iNumFrames; i++)
		{
			MethodBase methodBase = StackF.GetMethodBase(i);
			if (methodBase != null)
			{
				Type declaringType = methodBase.DeclaringType;
				if (declaringType == null)
				{
					break;
				}
				string @namespace = declaringType.Namespace;
				if (@namespace == null || !string.Equals(@namespace, "System.Diagnostics", StringComparison.Ordinal))
				{
					break;
				}
			}
			num++;
		}
		return num;
	}

	private void InitializeForException(Exception exception, int skipFrames, bool fNeedFileInfo)
	{
		CaptureStackTrace(skipFrames, fNeedFileInfo, exception);
	}

	private void InitializeForCurrentThread(int skipFrames, bool fNeedFileInfo)
	{
		CaptureStackTrace(skipFrames, fNeedFileInfo, null);
	}

	private void CaptureStackTrace(int skipFrames, bool fNeedFileInfo, Exception e)
	{
		_methodsToSkip = skipFrames;
		StackFrameHelper stackFrameHelper = new StackFrameHelper(null);
		stackFrameHelper.InitializeSourceInfo(0, fNeedFileInfo, e);
		_numOfFrames = stackFrameHelper.GetNumberOfFrames();
		if (_methodsToSkip > _numOfFrames)
		{
			_methodsToSkip = _numOfFrames;
		}
		if (_numOfFrames != 0)
		{
			_stackFrames = new StackFrame[_numOfFrames];
			for (int i = 0; i < _numOfFrames; i++)
			{
				_stackFrames[i] = new StackFrame(stackFrameHelper, i, fNeedFileInfo);
			}
			if (e == null)
			{
				_methodsToSkip += CalculateFramesToSkip(stackFrameHelper, _numOfFrames);
			}
			_numOfFrames -= _methodsToSkip;
			if (_numOfFrames < 0)
			{
				_numOfFrames = 0;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackTrace()
	{
		InitializeForCurrentThread(0, fNeedFileInfo: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackTrace(bool fNeedFileInfo)
	{
		InitializeForCurrentThread(0, fNeedFileInfo);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackTrace(int skipFrames)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(skipFrames, "skipFrames");
		InitializeForCurrentThread(skipFrames, fNeedFileInfo: false);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StackTrace(int skipFrames, bool fNeedFileInfo)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(skipFrames, "skipFrames");
		InitializeForCurrentThread(skipFrames, fNeedFileInfo);
	}

	public StackTrace(Exception e)
	{
		ArgumentNullException.ThrowIfNull(e, "e");
		InitializeForException(e, 0, fNeedFileInfo: false);
	}

	public StackTrace(Exception e, bool fNeedFileInfo)
	{
		ArgumentNullException.ThrowIfNull(e, "e");
		InitializeForException(e, 0, fNeedFileInfo);
	}

	public StackTrace(Exception e, int skipFrames)
	{
		ArgumentNullException.ThrowIfNull(e, "e");
		ArgumentOutOfRangeException.ThrowIfNegative(skipFrames, "skipFrames");
		InitializeForException(e, skipFrames, fNeedFileInfo: false);
	}

	public StackTrace(Exception e, int skipFrames, bool fNeedFileInfo)
	{
		ArgumentNullException.ThrowIfNull(e, "e");
		ArgumentOutOfRangeException.ThrowIfNegative(skipFrames, "skipFrames");
		InitializeForException(e, skipFrames, fNeedFileInfo);
	}

	public StackTrace(StackFrame frame)
	{
		_stackFrames = new StackFrame[1] { frame };
		_numOfFrames = 1;
	}

	public StackTrace(IEnumerable<StackFrame> frames)
	{
		ArgumentNullException.ThrowIfNull(frames, "frames");
		List<StackFrame> list = new List<StackFrame>(frames);
		_stackFrames = list.ToArray();
		_numOfFrames = list.Count;
	}

	public virtual StackFrame? GetFrame(int index)
	{
		if (_stackFrames != null && index < _numOfFrames && index >= 0)
		{
			return _stackFrames[index + _methodsToSkip];
		}
		return null;
	}

	public virtual StackFrame[] GetFrames()
	{
		if (_stackFrames == null || _numOfFrames <= 0)
		{
			return Array.Empty<StackFrame>();
		}
		StackFrame[] array = new StackFrame[_numOfFrames];
		Array.Copy(_stackFrames, _methodsToSkip, array, 0, _numOfFrames);
		return array;
	}

	public override string ToString()
	{
		return ToString(TraceFormat.TrailingNewLine);
	}

	internal string ToString(TraceFormat traceFormat)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		ToString(traceFormat, stringBuilder);
		return stringBuilder.ToString();
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "ToString is best effort when it comes to available information.")]
	internal void ToString(TraceFormat traceFormat, StringBuilder sb)
	{
		string value = (SR.UsingResourceKeys() ? "at" : SR.Word_At);
		string format = (SR.UsingResourceKeys() ? "in {0}:line {1}" : SR.StackTrace_InFileLineNumber);
		string format2 = (SR.UsingResourceKeys() ? "in {0}:token 0x{1:x}+0x{2:x}" : SR.StackTrace_InFileILOffset);
		bool flag = true;
		for (int i = 0; i < _numOfFrames; i++)
		{
			StackFrame frame = GetFrame(i);
			MethodBase method = frame?.GetMethod();
			if (!(method != null) || (!ShowInStackTrace(method) && i != _numOfFrames - 1))
			{
				continue;
			}
			if (flag)
			{
				flag = false;
			}
			else
			{
				sb.AppendLine();
			}
			sb.Append("   ").Append(value).Append(' ');
			bool flag2 = false;
			Type declaringType = method.DeclaringType;
			string name = method.Name;
			bool flag3 = false;
			if (declaringType != null && declaringType.IsDefined(typeof(CompilerGeneratedAttribute), inherit: false))
			{
				flag2 = declaringType.IsAssignableTo(typeof(IAsyncStateMachine));
				if (flag2 || declaringType.IsAssignableTo(typeof(IEnumerator)))
				{
					flag3 = TryResolveStateMachineMethod(ref method, out declaringType);
				}
			}
			if (declaringType != null)
			{
				string fullName = declaringType.FullName;
				foreach (char c in fullName)
				{
					sb.Append((c == '+') ? '.' : c);
				}
				sb.Append('.');
			}
			sb.Append(method.Name);
			if (method is MethodInfo { IsGenericMethod: not false } methodInfo)
			{
				Type[] genericArguments = methodInfo.GetGenericArguments();
				sb.Append('[');
				int k = 0;
				bool flag4 = true;
				for (; k < genericArguments.Length; k++)
				{
					if (!flag4)
					{
						sb.Append(',');
					}
					else
					{
						flag4 = false;
					}
					sb.Append(genericArguments[k].Name);
				}
				sb.Append(']');
			}
			ParameterInfo[] array = null;
			try
			{
				array = method.GetParameters();
			}
			catch
			{
			}
			if (array != null)
			{
				sb.Append('(');
				bool flag5 = true;
				for (int l = 0; l < array.Length; l++)
				{
					if (!flag5)
					{
						sb.Append(", ");
					}
					else
					{
						flag5 = false;
					}
					string value2 = "<UnknownType>";
					if (array[l].ParameterType != null)
					{
						value2 = array[l].ParameterType.Name;
					}
					sb.Append(value2);
					string name2 = array[l].Name;
					if (name2 != null)
					{
						sb.Append(' ');
						sb.Append(name2);
					}
				}
				sb.Append(')');
			}
			if (flag3)
			{
				sb.Append('+');
				sb.Append(name);
				sb.Append('(').Append(')');
			}
			if (frame.GetILOffset() != -1)
			{
				string fileName = frame.GetFileName();
				if (fileName != null)
				{
					sb.Append(' ');
					sb.AppendFormat(CultureInfo.InvariantCulture, format, fileName, frame.GetFileLineNumber());
				}
				else if (LocalAppContextSwitches.ShowILOffsets && method.ReflectedType != null)
				{
					string scopeName = method.ReflectedType.Module.ScopeName;
					try
					{
						int metadataToken = method.MetadataToken;
						sb.Append(' ');
						sb.AppendFormat(CultureInfo.InvariantCulture, format2, scopeName, metadataToken, frame.GetILOffset());
					}
					catch (InvalidOperationException)
					{
					}
				}
			}
			if (frame.IsLastFrameFromForeignExceptionStackTrace && !flag2)
			{
				sb.AppendLine();
				sb.Append(SR.UsingResourceKeys() ? "--- End of stack trace from previous location ---" : SR.Exception_EndStackTraceFromPreviousThrow);
			}
		}
		if (traceFormat == TraceFormat.TrailingNewLine)
		{
			sb.AppendLine();
		}
	}

	private static bool ShowInStackTrace(MethodBase mb)
	{
		if ((mb.MethodImplementationFlags & MethodImplAttributes.AggressiveInlining) != 0)
		{
			return false;
		}
		try
		{
			if (mb.IsDefined(typeof(StackTraceHiddenAttribute), inherit: false))
			{
				return false;
			}
			Type declaringType = mb.DeclaringType;
			if (declaringType != null && declaringType.IsDefined(typeof(StackTraceHiddenAttribute), inherit: false))
			{
				return false;
			}
		}
		catch
		{
		}
		return true;
	}

	private static bool TryResolveStateMachineMethod(ref MethodBase method, out Type declaringType)
	{
		declaringType = method.DeclaringType;
		Type declaringType2 = declaringType.DeclaringType;
		if (declaringType2 == null)
		{
			return false;
		}
		MethodInfo[] array = GetDeclaredMethods(declaringType2);
		if (array == null)
		{
			return false;
		}
		MethodInfo[] array2 = array;
		foreach (MethodInfo methodInfo in array2)
		{
			StateMachineAttribute[] array3 = (StateMachineAttribute[])Attribute.GetCustomAttributes(methodInfo, typeof(StateMachineAttribute), inherit: false);
			if (array3 == null)
			{
				continue;
			}
			bool flag = false;
			bool flag2 = false;
			StateMachineAttribute[] array4 = array3;
			foreach (StateMachineAttribute stateMachineAttribute in array4)
			{
				if (stateMachineAttribute.StateMachineType == declaringType)
				{
					flag = true;
					flag2 = flag2 || stateMachineAttribute is IteratorStateMachineAttribute || stateMachineAttribute is AsyncIteratorStateMachineAttribute;
				}
			}
			if (flag)
			{
				method = methodInfo;
				declaringType = methodInfo.DeclaringType;
				return flag2;
			}
		}
		return false;
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "Using Reflection to find the state machine's corresponding method is safe because the corresponding method is the only caller of the state machine. If the state machine is present, the corresponding method will be, too.")]
		static MethodInfo[] GetDeclaredMethods(Type type)
		{
			return type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}
	}
}
