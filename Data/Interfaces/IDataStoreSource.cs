using Models;

namespace DAL.Interfaces
{
	//
	/// <summary>
	/// Interface used to define data sources that are usable by data stores
	/// </summary>
	/// 
	/// <typeparam name="TCollection">
	/// The anonymous type collection used
	/// </typeparam>
	//

	public interface
		IDataStoreSource<
			TEntity
			>
		
		where TEntity : Entity
	{
		//
		/// <summary>
		/// Load the collection from the source
		/// </summary>
		/// 
		/// <returns>TCollection | null</returns>
		//

		Task<Dictionary<string, TEntity>?> Load();

		//
		/// <summary>
		/// Save the collection to the data source
		/// </summary>
		/// 
		/// <param name="collection">
		/// The anonymous type collection that should be saved
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		Task<bool> Save(Dictionary<string, TEntity> collection);
	}
}
