using DAL.Sources.Files;
using Models;

namespace DAL.Repositories
{
	//
	/// <summary>
	/// Superhero repository (represents a table in SQL terms)
	/// </summary>
	//

	public class
		SuperheroRepository
		: Repository<
			JsonFile<Superhero>,
			Superhero
			>
	{
		//
		/// <summary>
		/// Initiate the repository, supplying a source to the data store
		/// </summary>
		//

		public SuperheroRepository(): base(
			new JsonFile<Superhero>("superheroes.json")
			) { }
	}
}
