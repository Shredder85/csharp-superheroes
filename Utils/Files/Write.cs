using Utils.Debug;

namespace Utils.FileIO
{
	public static partial class
		FileSystem
	{
		//
		/// <summary>
		/// Write the provided data to the specified file
		/// </summary>
		/// 
		/// <param name="filePath">
		/// The path to the file
		/// </param>
		/// 
		/// <param name="content">
		/// The data that should be written to the file
		/// </param>
		/// 
		/// <param name="append">
		/// Boolean indicating if the current content should be overwritten
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		static public async Task<bool>
			WriteAsync(string filePath, string content, bool append = false)
		{
			try
			{
				using var file = new FileStream(
					path: filePath,
					share: FileShare.None,
					access: FileAccess.Write,
					mode: append ? FileMode.Append : FileMode.Open
					);

				using var writer = new StreamWriter(file);
				await writer.WriteAsync(content);

				return true;
			}
			catch (Exception exception)
			{
				Print.Error("write-async", exception);
			}

			return false;
		}

		//
		/// <summary>
		/// Append the provided content to the specified file
		/// </summary>
		/// 
		/// <param name="path">
		/// The path to the file
		/// </param>
		/// 
		/// <param name="content">
		/// The data that should be added to the file
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		static public async Task<bool>
			AppendAsync(string path, string content)
			=> await WriteAsync(path, content, append: true);
	}
}
