using Utilities.FileIO;
using DAL.Interfaces;

namespace DAL.Sources.Files
{
	public class
		FileDataSource
		: IWriteableDataSource<
			string, string, string
			>
	{
		public FileDataSource(string filePath) => Source = filePath;

		public async virtual Task<string?>
			ReadAsync()
		{
			throw new NotImplementedException();
		}

		public async virtual Task 
			WriteAsync(string input)
		{
			throw new NotImplementedException();
		}

		public async virtual Task
			DeleteAsync()
		{
			throw new NotImplementedException();
		}

		public string Source { get; init; } = string.Empty;
	}
}
