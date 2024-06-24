using System.Collections.Generic;
using System.Diagnostics;

namespace System.Collections.Immutable;

internal sealed class ImmutableSortedDictionaryBuilderDebuggerProxy<TKey, TValue> where TKey : notnull
{
	private readonly ImmutableSortedDictionary<TKey, TValue>.Builder _map;

	private KeyValuePair<TKey, TValue>[] _contents;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public KeyValuePair<TKey, TValue>[] Contents => _contents ?? (_contents = _map.ToArray(_map.Count));

	public ImmutableSortedDictionaryBuilderDebuggerProxy(ImmutableSortedDictionary<TKey, TValue>.Builder map)
	{
		Requires.NotNull(map, "map");
		_map = map;
	}
}
