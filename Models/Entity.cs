using System.ComponentModel;

namespace Models
{
	/// <summary>
	/// Abstract base class for all entities
	/// </summary>

	public abstract class
		Entity

		: IEntity<
			string
			>
	{
		/// <summary>
		/// Event handler for the PropertyChanged event
		/// </summary>
		/// 
		/// <param name="propertyName">
		/// The name of the property that has changed
		/// </param>

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Event triggered when a property value changes
		/// </summary>

		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// The unique identifier for the entity
		/// </summary>

		public string Id { get; set; } = string.Empty;
	}
}
