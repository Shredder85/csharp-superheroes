namespace Utilities.FileIO
{
	public static partial class
		FileSystem
	{
		//
		/// <summary>Create a directory if it doesn't exist.</summary>
		/// 
		/// <param name="path">The path to the directory</param>
		/// <returns>Boolean (async) indicating the result of the operation.</returns>

		public static Task<bool>
			EnsureDirectoryExists(string path)
		{
			return Task.Run(() =>
			{
				try
				{
					if (Path.GetDirectoryName(path) is string directory)
					{
						if (!Directory.Exists(directory))
						{
							Directory.CreateDirectory(directory);
						}

						return Directory.Exists(directory);
					}
				}

				catch (Exception exception)
				{
					DevTools.Error("file-system/ensure-directory-exists", exception);
				}

				return false;
			});
		}

		//
		/// <summary>Create a file if it doesn't exist.</summary>
		/// 
		/// <param name="filePath">The path to the file</param>
		/// <returns>Boolean (async) indicating the result of the operation.</returns>

		public async static Task<bool>
			EnsureFileExists(string filePath)
		{
			try
			{
				if (await EnsureDirectoryExists(filePath))
				{
					if (!File.Exists(filePath))
					{
						File.Create(filePath);
					}

					return File.Exists(filePath);
				}
			}

			catch (Exception exception)
			{
				DevTools.Error("file-system/ensure-file-exists", exception);
			}

			return false;
		}
	}
}
