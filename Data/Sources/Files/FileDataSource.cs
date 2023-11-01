using DAL.Interfaces.DataSource;
using Utilities.FileIO;

namespace DAL.Sources.Files
{
	//
	/// <summary>
	/// Basic file-based data source with read and write operations
	/// </summary>
	//

	public class
		FileDataSource

		: IReadableDataSource<
			string, string
			>,
		  IWriteableDataSource<
			  string, string
			  >
	{
		//
		/// <summary>
		/// Set the path to the source file
		/// </summary>
		/// 
		/// <param name="filePath">
		/// The path to the source file
		/// </param>
		//

		public FileDataSource(string filePath)=> Source = filePath;

		//
		/// <summary>
		/// Read the content of the source file
		/// </summary>
		/// 
		/// <returns>
		/// string | null
		/// </returns>
		//

		public async Task<string?> ReadAsync()=> await FileSystem.ReadAsync(Source);

		//
		/// <summary>
		/// Write the provided string to the source file
		/// </summary>
		/// 
		/// <param name="input">
		/// The string that should be written to the source file
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public async Task<bool> WriteAsync(string input)=> await FileSystem.WriteAsync(Source, input);

		//
		/// <summary>
		/// Delete the source file
		/// </summary>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public Task<bool> DeleteAsync()=> FileSystem.DeleteFile(Source);

		//
		/// <summary>
		/// The path to the source file
		/// </summary>
		//

		public string Source { get; init; }
	}
}
