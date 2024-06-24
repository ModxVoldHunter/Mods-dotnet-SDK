namespace System.Transactions.DtcProxyShim;

internal enum OletxTransactionStatus
{
	OLETX_TRANSACTION_STATUS_NONE = 0,
	OLETX_TRANSACTION_STATUS_OPENNORMAL = 1,
	OLETX_TRANSACTION_STATUS_OPENREFUSED = 2,
	OLETX_TRANSACTION_STATUS_PREPARING = 4,
	OLETX_TRANSACTION_STATUS_PREPARED = 8,
	OLETX_TRANSACTION_STATUS_PREPARERETAINING = 16,
	OLETX_TRANSACTION_STATUS_PREPARERETAINED = 32,
	OLETX_TRANSACTION_STATUS_COMMITTING = 64,
	OLETX_TRANSACTION_STATUS_COMMITRETAINING = 128,
	OLETX_TRANSACTION_STATUS_ABORTING = 256,
	OLETX_TRANSACTION_STATUS_ABORTED = 512,
	OLETX_TRANSACTION_STATUS_COMMITTED = 1024,
	OLETX_TRANSACTION_STATUS_HEURISTIC_ABORT = 2048,
	OLETX_TRANSACTION_STATUS_HEURISTIC_COMMIT = 4096,
	OLETX_TRANSACTION_STATUS_HEURISTIC_DAMAGE = 8192,
	OLETX_TRANSACTION_STATUS_HEURISTIC_DANGER = 16384,
	OLETX_TRANSACTION_STATUS_FORCED_ABORT = 32768,
	OLETX_TRANSACTION_STATUS_FORCED_COMMIT = 65536,
	OLETX_TRANSACTION_STATUS_INDOUBT = 131072,
	OLETX_TRANSACTION_STATUS_CLOSED = 262144,
	OLETX_TRANSACTION_STATUS_OPEN = 3,
	OLETX_TRANSACTION_STATUS_NOTPREPARED = 524227,
	OLETX_TRANSACTION_STATUS_ALL = 524287
}
