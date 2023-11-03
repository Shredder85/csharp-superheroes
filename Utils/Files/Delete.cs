using Utils.Debug;

namespace Utils.FileIO
{
	static public partial class
		FileSystem
	{
		//
		/// <summary>
		/// Delete the specified directory
		/// </summary>
		/// 
		/// <param name="path">
		/// The path to the directory that should be deleted
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		static public async Task<bool>
			DeleteDirectory(string path)
		{
			try
			{
				if (Directory.Exists(path))
				{
					bool isDeleted = false;
					Directory.Delete(path, true);

					do {
						isDeleted = !Directory.Exists(path);
						if (!isDeleted) await Task.Delay(100);
					}
					while (!isDeleted);

					return true;
				}

				Print.Warn("delete-directory", $"Could not find the directory ({path})");
			}

			catch (Exception exception)
			{
				Print.Error("delete-directory", exception);
			}

			return false;
		}

		//
		/// <summary>
		/// Delete the specified file
		/// </summary>
		/// 
		/// <param name="filePath">
		/// The path to the file that should be deleted
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		static public async Task<bool>
			DeleteFile(string filePath)
		{
			try
			{
				if (File.Exists(filePath))
				{
					bool isDeleted = false;
					File.Delete(filePath);

					do {
						isDeleted = !File.Exists(filePath);
						if (!isDeleted) await Task.Delay(100);
					}
					while (!isDeleted);

					return true;
				}

				Print.Warn("delete-file", $"Could not find the file ({filePath})");
			}
			catch (Exception exception)
			{
				Print.Error("delete-file", exception);
			}

			return false;
		}
	}
}
