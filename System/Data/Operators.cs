namespace System.Data;

internal static class Operators
{
	private static readonly string[] s_looks = new string[40]
	{
		"", "-", "+", "Not", "BetweenAnd", "In", "Between", "=", ">", "<",
		">=", "<=", "<>", "Is", "Like", "+", "-", "*", "/", "\\",
		"Mod", "**", "&", "|", "^", "~", "And", "Or", "Proc", "Iff",
		".", ".", "Null", "True", "False", "Date", "GenUniqueId()", "GenGuid()", "Guid {..}", "Is Not"
	};

	internal static bool IsArithmetical(int op)
	{
		if (op != 15 && op != 16 && op != 17 && op != 18)
		{
			return op == 20;
		}
		return true;
	}

	internal static bool IsLogical(int op)
	{
		if (op != 26 && op != 27 && op != 3 && op != 13)
		{
			return op == 39;
		}
		return true;
	}

	internal static bool IsRelational(int op)
	{
		if (7 <= op)
		{
			return op <= 12;
		}
		return false;
	}

	internal static int Priority(int op)
	{
		ReadOnlySpan<byte> readOnlySpan = new byte[32]
		{
			0, 20, 20, 9, 12, 11, 11, 13, 13, 13,
			13, 13, 13, 10, 11, 16, 16, 19, 19, 18,
			17, 21, 8, 7, 6, 9, 8, 7, 2, 22,
			23, 23
		};
		if ((uint)op >= (uint)readOnlySpan.Length)
		{
			return 24;
		}
		return readOnlySpan[op];
	}

	internal static string ToString(int op)
	{
		if ((uint)op < (uint)s_looks.Length)
		{
			return s_looks[op];
		}
		return "Unknown op";
	}
}
