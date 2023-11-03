namespace Utilities.FileIO
{
	public static partial class
		FileSystem
	{
		//
		/// <summary>
		/// Write the provided content to the specified file
		/// </summary>
		/// 
		/// <param name="filePath">
		/// The path to the file
		/// </param>
		/// 
		/// <param name="content">
		/// The data that should be added to the file
		/// </param>
		/// 
		/// <param name="overwrite">
		/// Boolean indicating if the current content should be overwritten
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public static Task<bool>
			WriteAsync(string filePath, string content, bool overwrite = true)
		{
			return Task.Run(()=>
			{
				try
				{
					lock(typeof(FileSystem))
					{
						using var file = new FileStream(
							path: filePath,
							share: FileShare.None,
							access: FileAccess.Write,
							mode: overwrite ? FileMode.Open : FileMode.Append
							);

						using var writer = new StreamWriter(file);
						writer.WriteAsync(content);
					}

					return true;
				}
				catch (Exception exception)
				{
					DevTools.Error("file-system/write-async", exception);
				}

				return false;
			});
		}

		//
		/// <summary>
		/// Append the given content to the specified file
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

		public static Task<bool>
			AppendAsync(string path, string content) =>
				WriteAsync(path, content, overwrite: false);
	}
}
