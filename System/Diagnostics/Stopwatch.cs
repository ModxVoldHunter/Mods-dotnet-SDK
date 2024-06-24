using System.Runtime.CompilerServices;

namespace System.Diagnostics;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class Stopwatch
{
	private long _elapsed;

	private long _startTimeStamp;

	private bool _isRunning;

	public static readonly long Frequency = QueryPerformanceFrequency();

	public static readonly bool IsHighResolution = true;

	private static readonly double s_tickFrequency = 10000000.0 / (double)Frequency;

	public bool IsRunning => _isRunning;

	public TimeSpan Elapsed => new TimeSpan(GetElapsedDateTimeTicks());

	public long ElapsedMilliseconds => GetElapsedDateTimeTicks() / 10000;

	public long ElapsedTicks => GetRawElapsedTicks();

	private string DebuggerDisplay => $"{Elapsed} (IsRunning = {_isRunning})";

	public Stopwatch()
	{
		Reset();
	}

	public void Start()
	{
		if (!_isRunning)
		{
			_startTimeStamp = GetTimestamp();
			_isRunning = true;
		}
	}

	public static Stopwatch StartNew()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		return stopwatch;
	}

	public void Stop()
	{
		if (_isRunning)
		{
			long timestamp = GetTimestamp();
			long num = timestamp - _startTimeStamp;
			_elapsed += num;
			_isRunning = false;
			if (_elapsed < 0)
			{
				_elapsed = 0L;
			}
		}
	}

	public void Reset()
	{
		_elapsed = 0L;
		_isRunning = false;
		_startTimeStamp = 0L;
	}

	public void Restart()
	{
		_elapsed = 0L;
		_startTimeStamp = GetTimestamp();
		_isRunning = true;
	}

	public override string ToString()
	{
		return Elapsed.ToString();
	}

	public static long GetTimestamp()
	{
		return QueryPerformanceCounter();
	}

	public static TimeSpan GetElapsedTime(long startingTimestamp)
	{
		return GetElapsedTime(startingTimestamp, GetTimestamp());
	}

	public static TimeSpan GetElapsedTime(long startingTimestamp, long endingTimestamp)
	{
		return new TimeSpan((long)((double)(endingTimestamp - startingTimestamp) * s_tickFrequency));
	}

	private long GetRawElapsedTicks()
	{
		long num = _elapsed;
		if (_isRunning)
		{
			long timestamp = GetTimestamp();
			long num2 = timestamp - _startTimeStamp;
			num += num2;
		}
		return num;
	}

	private long GetElapsedDateTimeTicks()
	{
		return (long)((double)GetRawElapsedTicks() * s_tickFrequency);
	}

	private unsafe static long QueryPerformanceFrequency()
	{
		Unsafe.SkipInit(out long result);
		Interop.BOOL bOOL = Interop.Kernel32.QueryPerformanceFrequency(&result);
		return result;
	}

	private unsafe static long QueryPerformanceCounter()
	{
		Unsafe.SkipInit(out long result);
		Interop.BOOL bOOL = Interop.Kernel32.QueryPerformanceCounter(&result);
		return result;
	}
}
