using Utils.Debug;

namespace Utils.FileIO
{
	public static partial class
		FileSystem
	{
		//
		/// <summary>
		/// Create a directory if it doesn't exist
		/// </summary>
		/// 
		/// <param name="path">
		/// The path to the directory that should be checked
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

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
					Print.Error("ensure-directory-exists", exception);
				}

				return false;
			});
		}

		//
		/// <summary>
		/// Create a file if it doesn't exist
		/// </summary>
		/// 
		/// <param name="filePath">
		/// The path to the file that should be checked
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

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

						do { await Task.Delay(100); }
						while (!File.Exists(filePath));
					}

					return File.Exists(filePath);
				}
			}

			catch (Exception exception)
			{
				Print.Error("ensure-file-exists", exception);
			}

			return false;
		}
	}
}
