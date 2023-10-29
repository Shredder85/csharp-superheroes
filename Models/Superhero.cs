using Models.Interfaces;

namespace Models
{
	public class
		Superhero
		
		: IEntity<string>
	{
		public string Id { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;
	}
}
