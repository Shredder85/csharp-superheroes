using DAL.Repositories;
using DAL.Sources.Files;
using Models;

namespace DAL
{
	//
	/// <summary>
	/// 
	/// </summary>
	//

	public static class
		DataController
	{
		//
		/// <summary>
		/// 
		/// </summary>
		//

		public static SuperheroRepository Superheroes { get; } = new();
	}
}
