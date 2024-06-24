using System.Dynamic.Utils;

namespace System.Linq.Expressions.Interpreter;

internal abstract class GreaterThanInstruction : Instruction
{
	private sealed class GreaterThanSByte : GreaterThanInstruction
	{
		public GreaterThanSByte(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((sbyte)obj2 > (sbyte)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanInt16 : GreaterThanInstruction
	{
		public GreaterThanInt16(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((short)obj2 > (short)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanChar : GreaterThanInstruction
	{
		public GreaterThanChar(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((char)obj2 > (char)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanInt32 : GreaterThanInstruction
	{
		public GreaterThanInt32(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((int)obj2 > (int)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanInt64 : GreaterThanInstruction
	{
		public GreaterThanInt64(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((long)obj2 > (long)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanByte : GreaterThanInstruction
	{
		public GreaterThanByte(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((byte)obj2 > (byte)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanUInt16 : GreaterThanInstruction
	{
		public GreaterThanUInt16(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((ushort)obj2 > (ushort)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanUInt32 : GreaterThanInstruction
	{
		public GreaterThanUInt32(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((uint)obj2 > (uint)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanUInt64 : GreaterThanInstruction
	{
		public GreaterThanUInt64(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((ulong)obj2 > (ulong)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanSingle : GreaterThanInstruction
	{
		public GreaterThanSingle(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((float)obj2 > (float)obj);
			}
			return 1;
		}
	}

	private sealed class GreaterThanDouble : GreaterThanInstruction
	{
		public GreaterThanDouble(object nullValue)
			: base(nullValue)
		{
		}

		public override int Run(InterpretedFrame frame)
		{
			object obj = frame.Pop();
			object obj2 = frame.Pop();
			if (obj2 == null || obj == null)
			{
				frame.Push(_nullValue);
			}
			else
			{
				frame.Push((double)obj2 > (double)obj);
			}
			return 1;
		}
	}

	private readonly object _nullValue;

	private static Instruction s_SByte;

	private static Instruction s_Int16;

	private static Instruction s_Char;

	private static Instruction s_Int32;

	private static Instruction s_Int64;

	private static Instruction s_Byte;

	private static Instruction s_UInt16;

	private static Instruction s_UInt32;

	private static Instruction s_UInt64;

	private static Instruction s_Single;

	private static Instruction s_Double;

	private static Instruction s_liftedToNullSByte;

	private static Instruction s_liftedToNullInt16;

	private static Instruction s_liftedToNullChar;

	private static Instruction s_liftedToNullInt32;

	private static Instruction s_liftedToNullInt64;

	private static Instruction s_liftedToNullByte;

	private static Instruction s_liftedToNullUInt16;

	private static Instruction s_liftedToNullUInt32;

	private static Instruction s_liftedToNullUInt64;

	private static Instruction s_liftedToNullSingle;

	private static Instruction s_liftedToNullDouble;

	public override int ConsumedStack => 2;

	public override int ProducedStack => 1;

	public override string InstructionName => "GreaterThan";

	private GreaterThanInstruction(object nullValue)
	{
		_nullValue = nullValue;
	}

	public static Instruction Create(Type type, bool liftedToNull = false)
	{
		if (liftedToNull)
		{
			return type.GetNonNullableType().GetTypeCode() switch
			{
				TypeCode.SByte => s_liftedToNullSByte ?? (s_liftedToNullSByte = new GreaterThanSByte(null)), 
				TypeCode.Int16 => s_liftedToNullInt16 ?? (s_liftedToNullInt16 = new GreaterThanInt16(null)), 
				TypeCode.Char => s_liftedToNullChar ?? (s_liftedToNullChar = new GreaterThanChar(null)), 
				TypeCode.Int32 => s_liftedToNullInt32 ?? (s_liftedToNullInt32 = new GreaterThanInt32(null)), 
				TypeCode.Int64 => s_liftedToNullInt64 ?? (s_liftedToNullInt64 = new GreaterThanInt64(null)), 
				TypeCode.Byte => s_liftedToNullByte ?? (s_liftedToNullByte = new GreaterThanByte(null)), 
				TypeCode.UInt16 => s_liftedToNullUInt16 ?? (s_liftedToNullUInt16 = new GreaterThanUInt16(null)), 
				TypeCode.UInt32 => s_liftedToNullUInt32 ?? (s_liftedToNullUInt32 = new GreaterThanUInt32(null)), 
				TypeCode.UInt64 => s_liftedToNullUInt64 ?? (s_liftedToNullUInt64 = new GreaterThanUInt64(null)), 
				TypeCode.Single => s_liftedToNullSingle ?? (s_liftedToNullSingle = new GreaterThanSingle(null)), 
				TypeCode.Double => s_liftedToNullDouble ?? (s_liftedToNullDouble = new GreaterThanDouble(null)), 
				_ => throw ContractUtils.Unreachable, 
			};
		}
		return type.GetNonNullableType().GetTypeCode() switch
		{
			TypeCode.SByte => s_SByte ?? (s_SByte = new GreaterThanSByte(Utils.BoxedFalse)), 
			TypeCode.Int16 => s_Int16 ?? (s_Int16 = new GreaterThanInt16(Utils.BoxedFalse)), 
			TypeCode.Char => s_Char ?? (s_Char = new GreaterThanChar(Utils.BoxedFalse)), 
			TypeCode.Int32 => s_Int32 ?? (s_Int32 = new GreaterThanInt32(Utils.BoxedFalse)), 
			TypeCode.Int64 => s_Int64 ?? (s_Int64 = new GreaterThanInt64(Utils.BoxedFalse)), 
			TypeCode.Byte => s_Byte ?? (s_Byte = new GreaterThanByte(Utils.BoxedFalse)), 
			TypeCode.UInt16 => s_UInt16 ?? (s_UInt16 = new GreaterThanUInt16(Utils.BoxedFalse)), 
			TypeCode.UInt32 => s_UInt32 ?? (s_UInt32 = new GreaterThanUInt32(Utils.BoxedFalse)), 
			TypeCode.UInt64 => s_UInt64 ?? (s_UInt64 = new GreaterThanUInt64(Utils.BoxedFalse)), 
			TypeCode.Single => s_Single ?? (s_Single = new GreaterThanSingle(Utils.BoxedFalse)), 
			TypeCode.Double => s_Double ?? (s_Double = new GreaterThanDouble(Utils.BoxedFalse)), 
			_ => throw ContractUtils.Unreachable, 
		};
	}
}
