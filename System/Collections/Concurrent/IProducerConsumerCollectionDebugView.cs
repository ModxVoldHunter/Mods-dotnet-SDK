using System.Diagnostics;

namespace System.Collections.Concurrent;

internal sealed class IProducerConsumerCollectionDebugView<T>
{
	private readonly IProducerConsumerCollection<T> _collection;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public T[] Items => _collection.ToArray();

	public IProducerConsumerCollectionDebugView(IProducerConsumerCollection<T> collection)
	{
		ArgumentNullException.ThrowIfNull(collection, "collection");
		_collection = collection;
	}
}
