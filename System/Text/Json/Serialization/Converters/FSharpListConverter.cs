using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class FSharpListConverter<TList, TElement> : IEnumerableDefaultConverter<TList, TElement> where TList : IEnumerable<TElement>
{
	private readonly Func<IEnumerable<TElement>, TList> _listConstructor;

	internal override bool SupportsCreateObjectDelegate => false;

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public FSharpListConverter()
	{
		_listConstructor = FSharpCoreReflectionProxy.Instance.CreateFSharpListConstructor<TList, TElement>();
	}

	protected override void Add(in TElement value, ref ReadStack state)
	{
		((List<TElement>)state.Current.ReturnValue).Add(value);
	}

	protected override void CreateCollection(ref Utf8JsonReader reader, scoped ref ReadStack state, JsonSerializerOptions options)
	{
		state.Current.ReturnValue = new List<TElement>();
	}

	protected override void ConvertCollection(ref ReadStack state, JsonSerializerOptions options)
	{
		state.Current.ReturnValue = _listConstructor((List<TElement>)state.Current.ReturnValue);
	}
}
