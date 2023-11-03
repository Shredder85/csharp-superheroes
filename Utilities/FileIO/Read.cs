namespace Utilities.FileIO
{
	public static partial class
		FileSystem
	{
		//
		/// <summary>
		/// Read the content of the specified file
		/// </summary>
		/// 
		/// <param name="filePath">
		/// The path to the file
		/// </param>
		/// 
		/// <returns>
		/// The content of the specified file, or null if the read failed
		/// </returns>
		//

		public static async
			Task<string?> ReadAsync(string filePath)
		{
			try
			{
				using var stream= new FileStream
				(
					filePath,
					bufferSize: 4096,
					useAsync: true,

					mode: FileMode.Open,
					access: FileAccess.Read,
					share: FileShare.Read
				);

				using var reader = new StreamReader(stream);
				return await reader.ReadToEndAsync();
			}

			catch
			{
				DevTools.Warning("file-system/read-async", $"Unable to read file ({filePath})");
				
				return null;
			}
		}
	}
}
