using System.Threading;
using System.Threading.Tasks;

namespace System.Net;

internal static class TaskExtensions
{
	public static TaskCompletionSource<TResult> ToApm<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
	{
		TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>(state);
		task.ContinueWith(delegate(Task<TResult> completedTask)
		{
			bool flag = false;
			if (completedTask.IsFaulted ? tcs.TrySetException(completedTask.Exception.InnerExceptions) : ((!completedTask.IsCanceled) ? tcs.TrySetResult(completedTask.Result) : tcs.TrySetCanceled()))
			{
				callback?.Invoke(tcs.Task);
			}
		}, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
		return tcs;
	}
}
