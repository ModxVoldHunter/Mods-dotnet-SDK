using System.Threading;

namespace System.Transactions;

internal sealed class VolatileEnlistmentInDoubt : VolatileEnlistmentState
{
	internal override void EnterState(InternalEnlistment enlistment)
	{
		enlistment.State = this;
		Monitor.Exit(enlistment.Transaction);
		try
		{
			TransactionsEtwProvider log = TransactionsEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.EnlistmentStatus(TraceSourceType.TraceSourceLtm, enlistment.EnlistmentTraceId, NotificationCall.InDoubt);
			}
			enlistment.EnlistmentNotification.InDoubt(enlistment.PreparingEnlistment);
		}
		finally
		{
			Monitor.Enter(enlistment.Transaction);
		}
	}

	internal override void EnlistmentDone(InternalEnlistment enlistment)
	{
		VolatileEnlistmentState.VolatileEnlistmentEnded.EnterState(enlistment);
	}
}
