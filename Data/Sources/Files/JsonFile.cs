using Newtonsoft.Json;

namespace DAL.Sources.Files
{
	//
	/// <summary>
	/// JSON-file data source
	/// </summary>
	/// 
	/// <typeparam name="TCollection">
	/// The anonymous type collection used to handle data
	/// </typeparam>
	//

	public class
		JsonFile<
			TCollection
			>

		: FileDataSource

		where TCollection : notnull
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

		public JsonFile(string filePath): base(filePath) { }

		//
		/// <summary>
		/// Load and deserialize the content of the source file
		/// </summary>
		/// 
		/// <returns>
		/// TCollection | null
		/// </returns>
		//

		public async Task<TCollection?> Load()
		{
			if (await ReadAsync() is string json)
			{
				return JsonConvert.DeserializeObject<TCollection>(json);
			}

			return default;
		}

		//
		/// <summary>
		/// Serialize and save the provided collection to the source file
		/// </summary>
		/// 
		/// <param name="collection">
		/// Anonymous type collection used to handle data
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public async Task<bool> Save(TCollection collection)
		{
			return await WriteAsync(
				JsonConvert.SerializeObject(collection)
				);
		}
	}
}
