using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Xml;

namespace System.Runtime.Serialization.Json;

public sealed class DataContractJsonSerializer : XmlObjectSerializer
{
	internal IList<Type> knownTypeList;

	internal Dictionary<XmlQualifiedName, DataContract> knownDataContracts;

	private EmitTypeInformation _emitTypeInformation;

	private ReadOnlyCollection<Type> _knownTypeCollection;

	private int _maxItemsInObjectGraph;

	private bool _serializeReadOnlyTypes;

	private DateTimeFormat _dateTimeFormat;

	private bool _useSimpleDictionaryFormat;

	private bool _ignoreExtensionDataObject;

	private DataContract _rootContract;

	private XmlDictionaryString _rootName;

	private bool _rootNameRequiresMapping;

	private Type _rootType;

	private ISerializationSurrogateProvider _serializationSurrogateProvider;

	internal ISerializationSurrogateProvider? SerializationSurrogateProvider
	{
		get
		{
			return _serializationSurrogateProvider;
		}
		set
		{
			_serializationSurrogateProvider = value;
		}
	}

	public bool IgnoreExtensionDataObject => _ignoreExtensionDataObject;

	public ReadOnlyCollection<Type> KnownTypes => _knownTypeCollection ?? (_knownTypeCollection = ((knownTypeList != null) ? new ReadOnlyCollection<Type>(knownTypeList) : ReadOnlyCollection<Type>.Empty));

	internal override Dictionary<XmlQualifiedName, DataContract>? KnownDataContracts
	{
		[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
		[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
		get
		{
			if (knownDataContracts == null && knownTypeList != null)
			{
				knownDataContracts = XmlObjectSerializerContext.GetDataContractsForKnownTypes(knownTypeList);
			}
			return knownDataContracts;
		}
	}

	public int MaxItemsInObjectGraph => _maxItemsInObjectGraph;

	public DateTimeFormat? DateTimeFormat => _dateTimeFormat;

	public EmitTypeInformation EmitTypeInformation => _emitTypeInformation;

	public bool SerializeReadOnlyTypes => _serializeReadOnlyTypes;

	public bool UseSimpleDictionaryFormat => _useSimpleDictionaryFormat;

	private DataContract RootContract
	{
		[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
		[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
		get
		{
			if (_rootContract == null)
			{
				_rootContract = DataContract.GetDataContract(_rootType);
				CheckIfTypeIsReference(_rootContract);
			}
			return _rootContract;
		}
	}

	private XmlDictionaryString RootName => _rootName ?? JsonGlobals.rootDictionaryString;

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public DataContractJsonSerializer(Type type)
		: this(type, (IEnumerable<Type>?)null)
	{
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public DataContractJsonSerializer(Type type, string? rootName)
		: this(type, rootName, null)
	{
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public DataContractJsonSerializer(Type type, XmlDictionaryString? rootName)
		: this(type, rootName, null)
	{
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public DataContractJsonSerializer(Type type, IEnumerable<Type>? knownTypes)
		: this(type, null, knownTypes, int.MaxValue, ignoreExtensionDataObject: false, alwaysEmitTypeInformation: false)
	{
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public DataContractJsonSerializer(Type type, string? rootName, IEnumerable<Type>? knownTypes)
		: this(type, new DataContractJsonSerializerSettings
		{
			RootName = rootName,
			KnownTypes = knownTypes
		})
	{
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public DataContractJsonSerializer(Type type, XmlDictionaryString? rootName, IEnumerable<Type>? knownTypes)
		: this(type, rootName, knownTypes, int.MaxValue, ignoreExtensionDataObject: false, alwaysEmitTypeInformation: false)
	{
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public DataContractJsonSerializer(Type type, DataContractJsonSerializerSettings? settings)
	{
		if (settings == null)
		{
			settings = new DataContractJsonSerializerSettings();
		}
		Initialize(type, (settings.RootName == null) ? null : new XmlDictionary(1).Add(settings.RootName), settings.KnownTypes, settings.MaxItemsInObjectGraph, settings.IgnoreExtensionDataObject, settings.EmitTypeInformation, settings.SerializeReadOnlyTypes, settings.DateTimeFormat, settings.UseSimpleDictionaryFormat);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal DataContractJsonSerializer(Type type, XmlDictionaryString rootName, IEnumerable<Type> knownTypes, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, bool alwaysEmitTypeInformation)
	{
		Initialize(type, rootName, knownTypes, maxItemsInObjectGraph, ignoreExtensionDataObject, alwaysEmitTypeInformation ? EmitTypeInformation.Always : EmitTypeInformation.AsNeeded, serializeReadOnlyTypes: false, null, useSimpleDictionaryFormat: false);
	}

	public ISerializationSurrogateProvider? GetSerializationSurrogateProvider()
	{
		return SerializationSurrogateProvider;
	}

	public void SetSerializationSurrogateProvider(ISerializationSurrogateProvider? provider)
	{
		SerializationSurrogateProvider = provider;
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override bool IsStartObject(XmlReader reader)
	{
		return IsStartObjectHandleExceptions(new JsonReaderDelegator(reader));
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override bool IsStartObject(XmlDictionaryReader reader)
	{
		return IsStartObjectHandleExceptions(new JsonReaderDelegator(reader));
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override object? ReadObject(Stream stream)
	{
		ArgumentNullException.ThrowIfNull(stream, "stream");
		return ReadObject(JsonReaderWriterFactory.CreateJsonReader(stream, XmlDictionaryReaderQuotas.Max));
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override object? ReadObject(XmlReader reader)
	{
		return ReadObjectHandleExceptions(new JsonReaderDelegator(reader, DateTimeFormat), verifyObjectName: true);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override object? ReadObject(XmlReader reader, bool verifyObjectName)
	{
		return ReadObjectHandleExceptions(new JsonReaderDelegator(reader, DateTimeFormat), verifyObjectName);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override object? ReadObject(XmlDictionaryReader reader)
	{
		return ReadObjectHandleExceptions(new JsonReaderDelegator(reader, DateTimeFormat), verifyObjectName: true);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override object? ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
	{
		return ReadObjectHandleExceptions(new JsonReaderDelegator(reader, DateTimeFormat), verifyObjectName);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override void WriteEndObject(XmlWriter writer)
	{
		WriteEndObjectHandleExceptions(new JsonWriterDelegator(writer));
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override void WriteEndObject(XmlDictionaryWriter writer)
	{
		WriteEndObjectHandleExceptions(new JsonWriterDelegator(writer));
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override void WriteObject(Stream stream, object? graph)
	{
		ArgumentNullException.ThrowIfNull(stream, "stream");
		XmlDictionaryWriter xmlDictionaryWriter = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8, ownsStream: false);
		WriteObject(xmlDictionaryWriter, graph);
		xmlDictionaryWriter.Flush();
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override void WriteObject(XmlWriter writer, object? graph)
	{
		WriteObjectHandleExceptions(new JsonWriterDelegator(writer, DateTimeFormat), graph);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override void WriteObject(XmlDictionaryWriter writer, object? graph)
	{
		WriteObjectHandleExceptions(new JsonWriterDelegator(writer, DateTimeFormat), graph);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override void WriteObjectContent(XmlWriter writer, object? graph)
	{
		WriteObjectContentHandleExceptions(new JsonWriterDelegator(writer, DateTimeFormat), graph);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override void WriteObjectContent(XmlDictionaryWriter writer, object? graph)
	{
		WriteObjectContentHandleExceptions(new JsonWriterDelegator(writer, DateTimeFormat), graph);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override void WriteStartObject(XmlWriter writer, object? graph)
	{
		WriteStartObjectHandleExceptions(new JsonWriterDelegator(writer), graph);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	public override void WriteStartObject(XmlDictionaryWriter writer, object? graph)
	{
		WriteStartObjectHandleExceptions(new JsonWriterDelegator(writer), graph);
	}

	internal static bool CheckIfJsonNameRequiresMapping(string jsonName)
	{
		if (jsonName != null)
		{
			if (!DataContract.IsValidNCName(jsonName))
			{
				return true;
			}
			for (int i = 0; i < jsonName.Length; i++)
			{
				if (XmlJsonWriter.CharacterNeedsEscaping(jsonName[i]))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal static bool CheckIfJsonNameRequiresMapping(XmlDictionaryString jsonName)
	{
		if (jsonName != null)
		{
			return CheckIfJsonNameRequiresMapping(jsonName.Value);
		}
		return false;
	}

	internal static bool CheckIfXmlNameRequiresMapping(string xmlName)
	{
		if (xmlName != null)
		{
			return CheckIfJsonNameRequiresMapping(ConvertXmlNameToJsonName(xmlName));
		}
		return false;
	}

	internal static bool CheckIfXmlNameRequiresMapping(XmlDictionaryString xmlName)
	{
		if (xmlName != null)
		{
			return CheckIfXmlNameRequiresMapping(xmlName.Value);
		}
		return false;
	}

	internal static string ConvertXmlNameToJsonName(string xmlName)
	{
		return XmlConvert.DecodeName(xmlName);
	}

	[return: NotNullIfNotNull("xmlName")]
	internal static XmlDictionaryString ConvertXmlNameToJsonName(XmlDictionaryString xmlName)
	{
		if (xmlName != null)
		{
			return new XmlDictionary().Add(ConvertXmlNameToJsonName(xmlName.Value));
		}
		return null;
	}

	internal static bool IsJsonLocalName(XmlReaderDelegator reader, string elementName)
	{
		if (XmlObjectSerializerReadContextComplexJson.TryGetJsonLocalName(reader, out var name))
		{
			return elementName == name;
		}
		return false;
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal static object ReadJsonValue(DataContract contract, XmlReaderDelegator reader, XmlObjectSerializerReadContextComplexJson context)
	{
		return JsonDataContract.GetJsonDataContract(contract).ReadJsonValue(reader, context);
	}

	internal static void WriteJsonNull(XmlWriterDelegator writer)
	{
		writer.WriteAttributeString(null, "type", null, "null");
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal static void WriteJsonValue(JsonDataContract contract, XmlWriterDelegator writer, object graph, XmlObjectSerializerWriteContextComplexJson context, RuntimeTypeHandle declaredTypeHandle)
	{
		contract.WriteJsonValue(writer, graph, context, declaredTypeHandle);
	}

	internal override Type GetDeserializeType()
	{
		return _rootType;
	}

	internal override Type GetSerializeType(object graph)
	{
		if (graph != null)
		{
			return graph.GetType();
		}
		return _rootType;
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal override bool InternalIsStartObject(XmlReaderDelegator reader)
	{
		if (XmlObjectSerializer.IsRootElement(reader, RootContract, RootName, XmlDictionaryString.Empty))
		{
			return true;
		}
		return IsJsonLocalName(reader, RootName.Value);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal override object InternalReadObject(XmlReaderDelegator xmlReader, bool verifyObjectName)
	{
		if (MaxItemsInObjectGraph == 0)
		{
			throw XmlObjectSerializer.CreateSerializationException(System.SR.Format(System.SR.ExceededMaxItemsQuota, MaxItemsInObjectGraph));
		}
		if (verifyObjectName)
		{
			if (!InternalIsStartObject(xmlReader))
			{
				throw XmlObjectSerializer.CreateSerializationExceptionWithReaderDetails(System.SR.Format(System.SR.ExpectingElement, XmlDictionaryString.Empty, RootName), xmlReader);
			}
		}
		else if (!XmlObjectSerializer.IsStartElement(xmlReader))
		{
			throw XmlObjectSerializer.CreateSerializationExceptionWithReaderDetails(System.SR.Format(System.SR.ExpectingElementAtDeserialize, XmlNodeType.Element), xmlReader);
		}
		DataContract rootContract = RootContract;
		if (rootContract.IsPrimitive && (object)rootContract.UnderlyingType == _rootType)
		{
			return ReadJsonValue(rootContract, xmlReader, null);
		}
		XmlObjectSerializerReadContextComplexJson xmlObjectSerializerReadContextComplexJson = XmlObjectSerializerReadContextComplexJson.CreateContext(this, rootContract);
		return xmlObjectSerializerReadContextComplexJson.InternalDeserialize(xmlReader, _rootType, rootContract, null, null);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal override void InternalWriteEndObject(XmlWriterDelegator writer)
	{
		writer.WriteEndElement();
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal override void InternalWriteObject(XmlWriterDelegator writer, object graph)
	{
		InternalWriteStartObject(writer, graph);
		InternalWriteObjectContent(writer, graph);
		InternalWriteEndObject(writer);
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal override void InternalWriteObjectContent(XmlWriterDelegator writer, object graph)
	{
		if (MaxItemsInObjectGraph == 0)
		{
			throw XmlObjectSerializer.CreateSerializationException(System.SR.Format(System.SR.ExceededMaxItemsQuota, MaxItemsInObjectGraph));
		}
		DataContract rootContract = RootContract;
		Type underlyingType = rootContract.UnderlyingType;
		Type objType = ((graph == null) ? underlyingType : graph.GetType());
		if (_serializationSurrogateProvider != null)
		{
			graph = DataContractSerializer.SurrogateToDataContractType(_serializationSurrogateProvider, graph, underlyingType, ref objType);
		}
		if (graph == null)
		{
			WriteJsonNull(writer);
			return;
		}
		if (underlyingType == objType)
		{
			if (rootContract.CanContainReferences)
			{
				XmlObjectSerializerWriteContextComplexJson xmlObjectSerializerWriteContextComplexJson = XmlObjectSerializerWriteContextComplexJson.CreateContext(this, rootContract);
				xmlObjectSerializerWriteContextComplexJson.OnHandleReference(writer, graph, canContainCyclicReference: true);
				xmlObjectSerializerWriteContextComplexJson.SerializeWithoutXsiType(rootContract, writer, graph, underlyingType.TypeHandle);
			}
			else
			{
				WriteJsonValue(JsonDataContract.GetJsonDataContract(rootContract), writer, graph, null, underlyingType.TypeHandle);
			}
			return;
		}
		XmlObjectSerializerWriteContextComplexJson xmlObjectSerializerWriteContextComplexJson2 = XmlObjectSerializerWriteContextComplexJson.CreateContext(this, RootContract);
		rootContract = GetDataContract(rootContract, underlyingType, objType);
		if (rootContract.CanContainReferences)
		{
			xmlObjectSerializerWriteContextComplexJson2.OnHandleReference(writer, graph, canContainCyclicReference: true);
			xmlObjectSerializerWriteContextComplexJson2.SerializeWithXsiTypeAtTopLevel(rootContract, writer, graph, underlyingType.TypeHandle, objType);
		}
		else
		{
			xmlObjectSerializerWriteContextComplexJson2.SerializeWithoutXsiType(rootContract, writer, graph, underlyingType.TypeHandle);
		}
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal override void InternalWriteStartObject(XmlWriterDelegator writer, object graph)
	{
		if (_rootNameRequiresMapping)
		{
			writer.WriteStartElement("a", "item", "item");
			writer.WriteAttributeString(null, "item", null, RootName.Value);
		}
		else
		{
			writer.WriteStartElement(RootName, XmlDictionaryString.Empty);
		}
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	private void AddCollectionItemTypeToKnownTypes(Type knownType)
	{
		Type type = knownType;
		Type itemType;
		while (CollectionDataContract.IsCollection(type, out itemType))
		{
			if (itemType.IsGenericType && itemType.GetGenericTypeDefinition() == Globals.TypeOfKeyValue)
			{
				itemType = Globals.TypeOfKeyValuePair.MakeGenericType(itemType.GenericTypeArguments);
			}
			knownTypeList.Add(itemType);
			type = itemType;
		}
	}

	[MemberNotNull("_rootType")]
	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	private void Initialize(Type type, IEnumerable<Type> knownTypes, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, EmitTypeInformation emitTypeInformation, bool serializeReadOnlyTypes, DateTimeFormat dateTimeFormat, bool useSimpleDictionaryFormat)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		_rootType = type;
		if (knownTypes != null)
		{
			knownTypeList = new List<Type>();
			foreach (Type knownType in knownTypes)
			{
				knownTypeList.Add(knownType);
				if (knownType != null)
				{
					AddCollectionItemTypeToKnownTypes(knownType);
				}
			}
		}
		ArgumentOutOfRangeException.ThrowIfNegative(maxItemsInObjectGraph, "maxItemsInObjectGraph");
		_maxItemsInObjectGraph = maxItemsInObjectGraph;
		_ignoreExtensionDataObject = ignoreExtensionDataObject;
		_emitTypeInformation = emitTypeInformation;
		_serializeReadOnlyTypes = serializeReadOnlyTypes;
		_dateTimeFormat = dateTimeFormat;
		_useSimpleDictionaryFormat = useSimpleDictionaryFormat;
	}

	[MemberNotNull("_rootType")]
	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	private void Initialize(Type type, XmlDictionaryString rootName, IEnumerable<Type> knownTypes, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, EmitTypeInformation emitTypeInformation, bool serializeReadOnlyTypes, DateTimeFormat dateTimeFormat, bool useSimpleDictionaryFormat)
	{
		Initialize(type, knownTypes, maxItemsInObjectGraph, ignoreExtensionDataObject, emitTypeInformation, serializeReadOnlyTypes, dateTimeFormat, useSimpleDictionaryFormat);
		_rootName = ConvertXmlNameToJsonName(rootName);
		_rootNameRequiresMapping = CheckIfJsonNameRequiresMapping(_rootName);
	}

	internal static void CheckIfTypeIsReference(DataContract dataContract)
	{
		if (dataContract.IsReference)
		{
			throw XmlObjectSerializer.CreateSerializationException(System.SR.Format(System.SR.JsonUnsupportedForIsReference, DataContract.GetClrTypeFullName(dataContract.UnderlyingType), dataContract.IsReference));
		}
	}

	[RequiresDynamicCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed.")]
	[RequiresUnreferencedCode("Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.")]
	internal static DataContract GetDataContract(DataContract declaredTypeContract, Type declaredType, Type objectType)
	{
		DataContract dataContract = DataContractSerializer.GetDataContract(declaredTypeContract, declaredType, objectType);
		CheckIfTypeIsReference(dataContract);
		return dataContract;
	}
}
