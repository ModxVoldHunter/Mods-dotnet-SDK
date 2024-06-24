using System.Runtime.Versioning;
using System.Text;

namespace System.IO;

public sealed class FileInfo : FileSystemInfo
{
	public override string Name => _name ?? (_name = Path.GetFileName(OriginalPath));

	public long Length
	{
		get
		{
			if ((base.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
			{
				throw new FileNotFoundException(SR.Format(SR.IO_FileNotFound_FileName, FullPath), FullPath);
			}
			return base.LengthCore;
		}
	}

	public string? DirectoryName => Path.GetDirectoryName(FullPath);

	public DirectoryInfo? Directory
	{
		get
		{
			string directoryName = DirectoryName;
			if (directoryName == null)
			{
				return null;
			}
			return new DirectoryInfo(directoryName);
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return (base.Attributes & FileAttributes.ReadOnly) != 0;
		}
		set
		{
			if (value)
			{
				base.Attributes |= FileAttributes.ReadOnly;
			}
			else
			{
				base.Attributes &= ~FileAttributes.ReadOnly;
			}
		}
	}

	public override bool Exists
	{
		get
		{
			try
			{
				return base.ExistsCore;
			}
			catch
			{
				return false;
			}
		}
	}

	public FileInfo(string fileName)
		: this(fileName ?? throw new ArgumentNullException("fileName"), null, null, isNormalized: false)
	{
	}

	internal FileInfo(string originalPath, string fullPath = null, string fileName = null, bool isNormalized = false)
	{
		OriginalPath = originalPath;
		if (fullPath == null)
		{
			fullPath = originalPath;
		}
		FullPath = (isNormalized ? (fullPath ?? originalPath) : Path.GetFullPath(fullPath));
		_name = fileName;
	}

	public FileStream Open(FileStreamOptions options)
	{
		return File.Open(base.NormalizedPath, options);
	}

	public StreamReader OpenText()
	{
		return new StreamReader(base.NormalizedPath, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
	}

	public StreamWriter CreateText()
	{
		return CreateStreamWriter(append: false);
	}

	public StreamWriter AppendText()
	{
		return CreateStreamWriter(append: true);
	}

	public FileInfo CopyTo(string destFileName)
	{
		return CopyTo(destFileName, overwrite: false);
	}

	public FileInfo CopyTo(string destFileName, bool overwrite)
	{
		ArgumentException.ThrowIfNullOrEmpty(destFileName, "destFileName");
		string fullPath = Path.GetFullPath(destFileName);
		FileSystem.CopyFile(FullPath, fullPath, overwrite);
		return new FileInfo(fullPath, null, null, isNormalized: true);
	}

	public FileStream Create()
	{
		FileStream result = File.Create(base.NormalizedPath);
		Invalidate();
		return result;
	}

	public override void Delete()
	{
		FileSystem.DeleteFile(FullPath);
		Invalidate();
	}

	public FileStream Open(FileMode mode)
	{
		return Open(mode, (mode == FileMode.Append) ? FileAccess.Write : FileAccess.ReadWrite, FileShare.None);
	}

	public FileStream Open(FileMode mode, FileAccess access)
	{
		return Open(mode, access, FileShare.None);
	}

	public FileStream Open(FileMode mode, FileAccess access, FileShare share)
	{
		return new FileStream(base.NormalizedPath, mode, access, share);
	}

	public FileStream OpenRead()
	{
		return new FileStream(base.NormalizedPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: false);
	}

	public FileStream OpenWrite()
	{
		return new FileStream(base.NormalizedPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
	}

	public void MoveTo(string destFileName)
	{
		MoveTo(destFileName, overwrite: false);
	}

	public void MoveTo(string destFileName, bool overwrite)
	{
		ArgumentException.ThrowIfNullOrEmpty(destFileName, "destFileName");
		string fullPath = Path.GetFullPath(destFileName);
		if (!new DirectoryInfo(Path.GetDirectoryName(FullName)).Exists)
		{
			throw new DirectoryNotFoundException(SR.Format(SR.IO_PathNotFound_Path, FullName));
		}
		if (!Exists)
		{
			throw new FileNotFoundException(SR.Format(SR.IO_FileNotFound_FileName, FullName), FullName);
		}
		FileSystem.MoveFile(FullPath, fullPath, overwrite);
		FullPath = fullPath;
		OriginalPath = destFileName;
		_name = Path.GetFileName(fullPath);
		Invalidate();
	}

	public FileInfo Replace(string destinationFileName, string? destinationBackupFileName)
	{
		return Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors: false);
	}

	public FileInfo Replace(string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors)
	{
		ArgumentNullException.ThrowIfNull(destinationFileName, "destinationFileName");
		FileSystem.ReplaceFile(FullPath, Path.GetFullPath(destinationFileName), (destinationBackupFileName != null) ? Path.GetFullPath(destinationBackupFileName) : null, ignoreMetadataErrors);
		return new FileInfo(destinationFileName);
	}

	[SupportedOSPlatform("windows")]
	public void Decrypt()
	{
		File.Decrypt(FullPath);
	}

	[SupportedOSPlatform("windows")]
	public void Encrypt()
	{
		File.Encrypt(FullPath);
	}

	private StreamWriter CreateStreamWriter(bool append)
	{
		StreamWriter result = new StreamWriter(base.NormalizedPath, append);
		Invalidate();
		return result;
	}
}
