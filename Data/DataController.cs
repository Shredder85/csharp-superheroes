using DAL.Repositories;

namespace DAL
{
	//
	/// <summary>
	/// Represents a database in SQL terms
	/// </summary>
	//

	public static class
		DataController
	{
		//
		/// <summary>
		/// The superhero repository (representing a table in SQL terms)
		/// </summary>
		//

		public static SuperheroRepository Superheroes { get; } = new();
	}
}
