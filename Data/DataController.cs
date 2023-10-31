using DAL.Sources.Files;
using DAL.Stores;
using Models;

namespace DAL
{
	using SuperheroCollection = Dictionary<string, Superhero>;

	public static class
		DataController
	{
		public static SuperheroStore Superheroes { get; } = new(
			new JsonFile<SuperheroCollection>("superheroes.json"));
	}
}
