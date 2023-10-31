using Models;
using Models.Interfaces;

namespace DAL.Stores
{
	//
	/// <summary>
	/// Base class for store implementations
	/// </summary>
	/// 
	/// <typeparam name="TSource">
	/// The anonymous type used as the source
	/// </typeparam>
	/// 
	/// <typeparam name="TCollection">
	/// The anonymous type collection used to handle data
	/// </typeparam>
	//

	public abstract class
		DataStore<
			TSource,
			TIdentifier,
			TEntity,
			TCollection
			>

		where TSource : notnull
		where TIdentifier : notnull
		where TEntity : Entity
		where TCollection : new()
	{
		//
		/// <summary>
		/// Set the data source as the provided source object
		/// </summary>
		/// 
		/// <param name="source">
		/// The anonymous type object to use as the data source
		/// </param>
		//

		public DataStore(TSource source) => this.source = source;

		//
		/// <summary>
		/// Fetch all entities currently stored in the store
		/// </summary>
		/// 
		/// <returns>
		/// The full dictionary of entities currently stored
		/// </returns>
		//

		public TCollection GetAll() => entities;

		public TEntity? Get(TIdentifier id)
		{
			// JAG ÄR HÄR.......

			return default;
		}

		//
		/// <summary>
		/// The entities stored in the store
		/// </summary>
		//

		protected TCollection entities = new();

		//
		/// <summary>
		/// The source object for the store
		/// </summary>
		//

		protected TSource source;
	}
}
