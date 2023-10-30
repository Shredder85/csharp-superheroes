using Utilities.FileIO;
using DAL.Interfaces;

namespace DAL.Sources.Files
{
	//
	/// <summary>Object representing a file-based data source.</summary>

	public class
		FileDataSource
		: IWriteableDataSource<
			string, string, string
			>
	{
		public FileDataSource(string filePath) => Source = filePath;

		//
		/// <summary>Read data from the source file (async).</summary>
		/// <returns></returns>

		public async virtual Task<string?>
			ReadAsync() => await FileSystem.ReadAsync(Source);

		//
		/// <summary>Write data to the source file (async).</summary>
		/// 
		/// <param name="input"></param>
		/// <returns></returns>

		public async virtual Task<bool>
			WriteAsync(string input) => await FileSystem.WriteAsync(Source, input);

		//
		/// <summary>Delete the source file (async).</summary>
		/// <returns></returns>

		public async virtual Task<bool>
			DeleteAsync() => await FileSystem.DeleteFile(Source);

		//
		/// <summary></summary>

		public string Source { get; init; } = string.Empty;
	}
}
