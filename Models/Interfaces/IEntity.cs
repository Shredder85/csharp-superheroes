using System.ComponentModel;

namespace Models.Interfaces
{
	//
	/// <summary>
	/// Interface that define the base model for entity classes.
	/// </summary>
	/// 
	/// <typeparam name="TIdentifier">
	/// The type of object used as an identifier.
	/// </typeparam>
	//

	public interface
		IEntity<
			TIdentifier
			>

		: INotifyPropertyChanged
	{
		/// <summary>
		/// The identifier used to uniquely identify an entity.
		/// </summary>
		/// 
		TIdentifier Id { get; }
	}
}
