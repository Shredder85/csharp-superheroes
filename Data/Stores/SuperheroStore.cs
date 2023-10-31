using DAL.Sources.Files;
using Models;

namespace DAL.Stores
{
	using SuperheroCollection = Dictionary<string, Superhero>;

	//
	/// <summary>
	/// Superhero data store
	/// </summary>
	//

	public class
		SuperheroStore
		: DataStore<
			JsonFile<
				SuperheroCollection
				>,
			string,
			Superhero,
			SuperheroCollection
			>
	{
		//
		/// <summary>
		/// Set the data source
		/// </summary>
		/// 
		/// <param name="source">
		/// The data source that should be used
		/// </param>
		//

		public SuperheroStore(JsonFile<SuperheroCollection> source): base(source) { }
	}
}
