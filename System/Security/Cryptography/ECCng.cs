using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography;

internal static class ECCng
{
	internal static global::Interop.BCrypt.ECC_CURVE_ALG_ID_ENUM GetHashAlgorithmId(HashAlgorithmName? name)
	{
		if (!name.HasValue || string.IsNullOrEmpty(name.Value.Name))
		{
			return global::Interop.BCrypt.ECC_CURVE_ALG_ID_ENUM.BCRYPT_NO_CURVE_GENERATION_ALG_ID;
		}
		global::Interop.Crypt32.CRYPT_OID_INFO cRYPT_OID_INFO = global::Interop.Crypt32.FindOidInfo(global::Interop.Crypt32.CryptOidInfoKeyType.CRYPT_OID_INFO_NAME_KEY, name.Value.Name, OidGroup.HashAlgorithm, fallBackToAllGroups: false);
		if (cRYPT_OID_INFO.AlgId == -1)
		{
			throw new CryptographicException(System.SR.Cryptography_UnknownHashAlgorithm, name.Value.Name);
		}
		return (global::Interop.BCrypt.ECC_CURVE_ALG_ID_ENUM)cRYPT_OID_INFO.AlgId;
	}

	internal static HashAlgorithmName? GetHashAlgorithmName(global::Interop.BCrypt.ECC_CURVE_ALG_ID_ENUM hashId)
	{
		global::Interop.Crypt32.CRYPT_OID_INFO cRYPT_OID_INFO = global::Interop.Crypt32.FindAlgIdOidInfo(hashId);
		if (cRYPT_OID_INFO.AlgId == -1)
		{
			return null;
		}
		return new HashAlgorithmName(cRYPT_OID_INFO.Name);
	}

	internal unsafe static byte[] GetNamedCurveBlob(ref ECParameters parameters, bool ecdh)
	{
		bool flag = parameters.D != null;
		int num = sizeof(global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB) + parameters.Q.X.Length + parameters.Q.Y.Length;
		if (flag)
		{
			num += parameters.D.Length;
		}
		byte[] array = new byte[num];
		fixed (byte* ptr = &array[0])
		{
			global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB* ptr2 = (global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB*)ptr;
			ptr2->Magic = (ecdh ? EcdhCurveNameToMagicNumber(parameters.Curve.Oid.FriendlyName, flag) : EcdsaCurveNameToMagicNumber(parameters.Curve.Oid.FriendlyName, flag));
			ptr2->cbKey = parameters.Q.X.Length;
			int offset = sizeof(global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB);
			global::Interop.BCrypt.Emit(array, ref offset, parameters.Q.X);
			global::Interop.BCrypt.Emit(array, ref offset, parameters.Q.Y);
			if (flag)
			{
				global::Interop.BCrypt.Emit(array, ref offset, parameters.D);
			}
		}
		return array;
	}

	internal unsafe static byte[] GetPrimeCurveBlob(ref ECParameters parameters, bool ecdh)
	{
		bool flag = parameters.D != null;
		ECCurve curve = parameters.Curve;
		int num = sizeof(global::Interop.BCrypt.BCRYPT_ECCFULLKEY_BLOB) + curve.Prime.Length + curve.A.Length + curve.B.Length + curve.G.X.Length + curve.G.Y.Length + curve.Order.Length + curve.Cofactor.Length + ((curve.Seed != null) ? curve.Seed.Length : 0) + parameters.Q.X.Length + parameters.Q.Y.Length;
		if (flag)
		{
			num += parameters.D.Length;
		}
		byte[] array = new byte[num];
		fixed (byte* ptr = &array[0])
		{
			global::Interop.BCrypt.BCRYPT_ECCFULLKEY_BLOB* ptr2 = (global::Interop.BCrypt.BCRYPT_ECCFULLKEY_BLOB*)ptr;
			ptr2->Version = 1;
			ptr2->Magic = ((!flag) ? (ecdh ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_GENERIC_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC) : (ecdh ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_GENERIC_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC));
			ptr2->cbCofactor = curve.Cofactor.Length;
			ptr2->cbFieldLength = parameters.Q.X.Length;
			ptr2->cbSeed = ((curve.Seed != null) ? curve.Seed.Length : 0);
			ptr2->cbSubgroupOrder = curve.Order.Length;
			ptr2->CurveGenerationAlgId = GetHashAlgorithmId(curve.Hash);
			ptr2->CurveType = ConvertToCurveTypeEnum(curve.CurveType);
			int offset = sizeof(global::Interop.BCrypt.BCRYPT_ECCFULLKEY_BLOB);
			global::Interop.BCrypt.Emit(array, ref offset, curve.Prime);
			global::Interop.BCrypt.Emit(array, ref offset, curve.A);
			global::Interop.BCrypt.Emit(array, ref offset, curve.B);
			global::Interop.BCrypt.Emit(array, ref offset, curve.G.X);
			global::Interop.BCrypt.Emit(array, ref offset, curve.G.Y);
			global::Interop.BCrypt.Emit(array, ref offset, curve.Order);
			global::Interop.BCrypt.Emit(array, ref offset, curve.Cofactor);
			if (curve.Seed != null)
			{
				global::Interop.BCrypt.Emit(array, ref offset, curve.Seed);
			}
			global::Interop.BCrypt.Emit(array, ref offset, parameters.Q.X);
			global::Interop.BCrypt.Emit(array, ref offset, parameters.Q.Y);
			if (flag)
			{
				global::Interop.BCrypt.Emit(array, ref offset, parameters.D);
			}
		}
		return array;
	}

	internal unsafe static void ExportNamedCurveParameters(ref ECParameters ecParams, byte[] ecBlob, bool includePrivateParameters)
	{
		global::Interop.BCrypt.KeyBlobMagicNumber magic = (global::Interop.BCrypt.KeyBlobMagicNumber)BitConverter.ToInt32(ecBlob, 0);
		CheckMagicValueOfKey(magic, includePrivateParameters);
		if (ecBlob.Length < sizeof(global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB))
		{
			throw global::Interop.NCrypt.ErrorCode.E_FAIL.ToCryptographicException();
		}
		fixed (byte* ptr = &ecBlob[0])
		{
			global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB* ptr2 = (global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB*)ptr;
			int offset = sizeof(global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB);
			ecParams.Q = new ECPoint
			{
				X = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbKey),
				Y = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbKey)
			};
			if (includePrivateParameters)
			{
				ecParams.D = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbKey);
			}
		}
	}

	internal unsafe static void ExportPrimeCurveParameters(ref ECParameters ecParams, byte[] ecBlob, bool includePrivateParameters)
	{
		global::Interop.BCrypt.KeyBlobMagicNumber magic = (global::Interop.BCrypt.KeyBlobMagicNumber)BitConverter.ToInt32(ecBlob, 0);
		CheckMagicValueOfKey(magic, includePrivateParameters);
		if (ecBlob.Length < sizeof(global::Interop.BCrypt.BCRYPT_ECCFULLKEY_BLOB))
		{
			throw global::Interop.NCrypt.ErrorCode.E_FAIL.ToCryptographicException();
		}
		fixed (byte* ptr = &ecBlob[0])
		{
			global::Interop.BCrypt.BCRYPT_ECCFULLKEY_BLOB* ptr2 = (global::Interop.BCrypt.BCRYPT_ECCFULLKEY_BLOB*)ptr;
			ECCurve curve = default(ECCurve);
			curve.CurveType = ConvertToCurveTypeEnum(ptr2->CurveType);
			curve.Hash = GetHashAlgorithmName(ptr2->CurveGenerationAlgId);
			int offset = sizeof(global::Interop.BCrypt.BCRYPT_ECCFULLKEY_BLOB);
			curve.Prime = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbFieldLength);
			curve.A = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbFieldLength);
			curve.B = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbFieldLength);
			curve.G = new ECPoint
			{
				X = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbFieldLength),
				Y = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbFieldLength)
			};
			curve.Order = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbSubgroupOrder);
			curve.Cofactor = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbCofactor);
			curve.Seed = ((ptr2->cbSeed == 0) ? null : global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbSeed));
			ecParams.Q = new ECPoint
			{
				X = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbFieldLength),
				Y = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbFieldLength)
			};
			if (includePrivateParameters)
			{
				ecParams.D = global::Interop.BCrypt.Consume(ecBlob, ref offset, ptr2->cbSubgroupOrder);
			}
			ecParams.Curve = curve;
		}
	}

	internal unsafe static byte[] GetPrimeCurveParameterBlob(ref ECCurve curve)
	{
		int num = sizeof(global::Interop.BCrypt.BCRYPT_ECC_PARAMETER_HEADER) + curve.Prime.Length + curve.A.Length + curve.B.Length + curve.G.X.Length + curve.G.Y.Length + curve.Order.Length + curve.Cofactor.Length + ((curve.Seed != null) ? curve.Seed.Length : 0);
		byte[] array = new byte[num];
		fixed (byte* ptr = &array[0])
		{
			global::Interop.BCrypt.BCRYPT_ECC_PARAMETER_HEADER* ptr2 = (global::Interop.BCrypt.BCRYPT_ECC_PARAMETER_HEADER*)ptr;
			ptr2->Version = 1;
			ptr2->cbCofactor = curve.Cofactor.Length;
			ptr2->cbFieldLength = curve.A.Length;
			ptr2->cbSeed = ((curve.Seed != null) ? curve.Seed.Length : 0);
			ptr2->cbSubgroupOrder = curve.Order.Length;
			ptr2->CurveGenerationAlgId = GetHashAlgorithmId(curve.Hash);
			ptr2->CurveType = ConvertToCurveTypeEnum(curve.CurveType);
			int offset = sizeof(global::Interop.BCrypt.BCRYPT_ECC_PARAMETER_HEADER);
			global::Interop.BCrypt.Emit(array, ref offset, curve.Prime);
			global::Interop.BCrypt.Emit(array, ref offset, curve.A);
			global::Interop.BCrypt.Emit(array, ref offset, curve.B);
			global::Interop.BCrypt.Emit(array, ref offset, curve.G.X);
			global::Interop.BCrypt.Emit(array, ref offset, curve.G.Y);
			global::Interop.BCrypt.Emit(array, ref offset, curve.Order);
			global::Interop.BCrypt.Emit(array, ref offset, curve.Cofactor);
			if (curve.Seed != null)
			{
				global::Interop.BCrypt.Emit(array, ref offset, curve.Seed);
			}
		}
		return array;
	}

	private static void CheckMagicValueOfKey(global::Interop.BCrypt.KeyBlobMagicNumber magic, bool includePrivateParameters)
	{
		if (includePrivateParameters)
		{
			if (!IsMagicValueOfKeyPrivate(magic))
			{
				throw new CryptographicException(System.SR.Cryptography_NotValidPrivateKey);
			}
		}
		else if (!IsMagicValueOfKeyPublic(magic))
		{
			throw new CryptographicException(System.SR.Cryptography_NotValidPublicOrPrivateKey);
		}
	}

	private static bool IsMagicValueOfKeyPrivate(global::Interop.BCrypt.KeyBlobMagicNumber magic)
	{
		switch (magic)
		{
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_P256_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P256_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_P384_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P384_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_P521_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P521_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_GENERIC_MAGIC:
			return true;
		default:
			return false;
		}
	}

	private static bool IsMagicValueOfKeyPublic(global::Interop.BCrypt.KeyBlobMagicNumber magic)
	{
		switch (magic)
		{
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_P256_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P256_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_P384_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P384_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_P521_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P521_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC:
		case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_GENERIC_MAGIC:
			return true;
		default:
			return IsMagicValueOfKeyPrivate(magic);
		}
	}

	private static global::Interop.BCrypt.KeyBlobMagicNumber EcdsaCurveNameToMagicNumber(string name, bool includePrivateParameters)
	{
		return CngKey.EcdsaCurveNameToAlgorithm(name).Algorithm switch
		{
			"ECDSA_P256" => includePrivateParameters ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P256_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P256_MAGIC, 
			"ECDSA_P384" => includePrivateParameters ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P384_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P384_MAGIC, 
			"ECDSA_P521" => includePrivateParameters ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P521_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P521_MAGIC, 
			_ => includePrivateParameters ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC, 
		};
	}

	private static global::Interop.BCrypt.KeyBlobMagicNumber EcdhCurveNameToMagicNumber(string name, bool includePrivateParameters)
	{
		return CngKey.EcdhCurveNameToAlgorithm(name).Algorithm switch
		{
			"ECDH_P256" => includePrivateParameters ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_P256_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_P256_MAGIC, 
			"ECDH_P384" => includePrivateParameters ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_P384_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_P384_MAGIC, 
			"ECDH_P521" => includePrivateParameters ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_P521_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_P521_MAGIC, 
			_ => includePrivateParameters ? global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_GENERIC_MAGIC : global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_GENERIC_MAGIC, 
		};
	}

	private static global::Interop.BCrypt.ECC_CURVE_TYPE_ENUM ConvertToCurveTypeEnum(ECCurve.ECCurveType value)
	{
		return (global::Interop.BCrypt.ECC_CURVE_TYPE_ENUM)value;
	}

	private static ECCurve.ECCurveType ConvertToCurveTypeEnum(global::Interop.BCrypt.ECC_CURVE_TYPE_ENUM value)
	{
		return (ECCurve.ECCurveType)value;
	}

	internal static SafeNCryptKeyHandle ImportKeyBlob(string blobType, ReadOnlySpan<byte> keyBlob, string curveName, SafeNCryptProviderHandle provider)
	{
		global::Interop.NCrypt.ErrorCode errorCode;
		SafeNCryptKeyHandle phKey;
		using (SafeUnicodeStringHandle safeUnicodeStringHandle = new SafeUnicodeStringHandle(curveName))
		{
			global::Interop.BCrypt.BCryptBufferDesc structure = default(global::Interop.BCrypt.BCryptBufferDesc);
			global::Interop.BCrypt.BCryptBuffer structure2 = default(global::Interop.BCrypt.BCryptBuffer);
			nint num = IntPtr.Zero;
			nint num2 = IntPtr.Zero;
			try
			{
				num = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
				num2 = Marshal.AllocHGlobal(Marshal.SizeOf(structure2));
				structure2.cbBuffer = (curveName.Length + 1) * 2;
				structure2.BufferType = global::Interop.BCrypt.CngBufferDescriptors.NCRYPTBUFFER_ECC_CURVE_NAME;
				structure2.pvBuffer = safeUnicodeStringHandle.DangerousGetHandle();
				Marshal.StructureToPtr(structure2, num2, fDeleteOld: false);
				structure.cBuffers = 1;
				structure.pBuffers = num2;
				structure.ulVersion = 0;
				Marshal.StructureToPtr(structure, num, fDeleteOld: false);
				errorCode = global::Interop.NCrypt.NCryptImportKey(provider, IntPtr.Zero, blobType, num, out phKey, ref MemoryMarshal.GetReference(keyBlob), keyBlob.Length, 0);
			}
			finally
			{
				Marshal.FreeHGlobal(num);
				Marshal.FreeHGlobal(num2);
			}
		}
		if (errorCode != 0)
		{
			Exception ex = errorCode.ToCryptographicException();
			phKey.Dispose();
			if (errorCode == global::Interop.NCrypt.ErrorCode.NTE_INVALID_PARAMETER)
			{
				throw new PlatformNotSupportedException(System.SR.Format(System.SR.Cryptography_CurveNotSupported, curveName), ex);
			}
			throw ex;
		}
		return phKey;
	}

	internal static CngKey ImportKeyBlob(byte[] ecBlob, string curveName, bool includePrivateParameters)
	{
		CngKeyBlobFormat format = (includePrivateParameters ? CngKeyBlobFormat.EccPrivateBlob : CngKeyBlobFormat.EccPublicBlob);
		CngKey cngKey = CngKey.Import(ecBlob, curveName, format);
		cngKey.ExportPolicy |= CngExportPolicies.AllowPlaintextExport;
		return cngKey;
	}

	internal static CngKey ImportFullKeyBlob(byte[] ecBlob, bool includePrivateParameters)
	{
		CngKeyBlobFormat format = (includePrivateParameters ? CngKeyBlobFormat.EccFullPrivateBlob : CngKeyBlobFormat.EccFullPublicBlob);
		CngKey cngKey = CngKey.Import(ecBlob, format);
		cngKey.ExportPolicy |= CngExportPolicies.AllowPlaintextExport;
		return cngKey;
	}

	internal static byte[] ExportKeyBlob(CngKey key, bool includePrivateParameters)
	{
		CngKeyBlobFormat format = (includePrivateParameters ? CngKeyBlobFormat.EccPrivateBlob : CngKeyBlobFormat.EccPublicBlob);
		return key.Export(format);
	}

	internal static byte[] ExportFullKeyBlob(CngKey key, bool includePrivateParameters)
	{
		CngKeyBlobFormat format = (includePrivateParameters ? CngKeyBlobFormat.EccFullPrivateBlob : CngKeyBlobFormat.EccFullPublicBlob);
		return key.Export(format);
	}

	internal static byte[] ExportKeyBlob(CngKey key, bool includePrivateParameters, out CngKeyBlobFormat format, out string curveName)
	{
		curveName = key.GetCurveName(out var _);
		bool flag = false;
		if (string.IsNullOrEmpty(curveName))
		{
			curveName = null;
			flag = true;
			format = (includePrivateParameters ? CngKeyBlobFormat.EccFullPrivateBlob : CngKeyBlobFormat.EccFullPublicBlob);
		}
		else
		{
			format = (includePrivateParameters ? CngKeyBlobFormat.EccPrivateBlob : CngKeyBlobFormat.EccPublicBlob);
		}
		byte[] array = key.Export(format);
		if (flag)
		{
			FixupGenericBlob(array);
		}
		return array;
	}

	private unsafe static void FixupGenericBlob(byte[] blob)
	{
		if (blob.Length <= sizeof(global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB))
		{
			return;
		}
		fixed (byte* ptr = blob)
		{
			global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB* ptr2 = (global::Interop.BCrypt.BCRYPT_ECCKEY_BLOB*)ptr;
			switch (ptr2->Magic)
			{
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_P256_MAGIC:
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_P384_MAGIC:
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_P521_MAGIC:
				ptr2->Magic = global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PUBLIC_GENERIC_MAGIC;
				break;
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_P256_MAGIC:
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_P384_MAGIC:
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_P521_MAGIC:
				ptr2->Magic = global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDH_PRIVATE_GENERIC_MAGIC;
				break;
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P256_MAGIC:
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P384_MAGIC:
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_P521_MAGIC:
				ptr2->Magic = global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC;
				break;
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P256_MAGIC:
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P384_MAGIC:
			case global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_P521_MAGIC:
				ptr2->Magic = global::Interop.BCrypt.KeyBlobMagicNumber.BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC;
				break;
			}
		}
	}
}
