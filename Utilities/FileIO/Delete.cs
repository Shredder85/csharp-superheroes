using System.IO;

namespace Utilities.FileIO
{
	public static partial class
		FileSystem
	{
		//
		/// <summary>Delete a specified directory.</summary>
		/// 
		/// <param name="path">The path to the directory that should be deleted.</param>
		/// <returns>Boolean (async) indicating the result of the operation.</returns>

		public static Task<bool>
			DeleteDirectory(string path)
		{
			return Task.Run(() =>
			{
				try
				{
					if (Directory.Exists(path))
					{
						Directory.Delete(path, true);
						return !Directory.Exists(path);
					}

					DevTools.Warning("file-system/delete-directory", $"Could not find the directory ({path})");
				}

				catch (Exception exception)
				{
					DevTools.Error("file-system/delete-directory", exception);
				}

				return false;
			});
		}

		//
		/// <summary>Delete a specified file.</summary>
		/// 
		/// <param name="filePath">The path to the file that should be deleted.</param>
		/// <returns>Boolean (async) indicating the result of the operation.</returns>

		public static Task<bool>
			DeleteFile(string filePath)
		{
			return Task.Run(() =>
			{
				try
				{
					if (File.Exists(filePath))
					{
						File.Delete(filePath);
						return !File.Exists(filePath);
					}

					DevTools.Warning("file-system/delete-file", $"Could not find the file ({filePath})");
				}
				catch (Exception exception)
				{
					DevTools.Error("file-system/delete-file", exception);
				}

				return false;
			});
		}
	}
}
