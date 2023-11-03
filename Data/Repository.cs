using Models;

namespace DAL
{
	//
	/// <summary>
	/// Base class for repository implementations
	/// (represents a table in SQL terms)
	/// </summary>
	/// 
	/// <typeparam name="TSource">
	/// The anonymous type data source used
	/// </typeparam>
	/// 
	/// <typeparam name="TEntity">
	/// The anonymous type entity handled
	/// </typeparam>
	//

	public abstract class
		Repository<
			TSource,
			TEntity
			>

		where TSource : IDataStoreSource<TEntity>
		where TEntity : Entity
	{
		//
		/// <summary>
		/// Initialize the repository by creating a new
		/// data store using the supplied data source
		/// </summary>
		/// 
		/// <param name="source">
		/// The anonymous type data source used
		/// </param>
		//

		public Repository(TSource source)=>
			Store = new DataStore<TSource, TEntity>(source);

		//
		/// <summary>
		/// Add a new entity to the collection
		/// </summary>
		/// 
		/// <param name="entity">
		/// The anonymous type entity that should be added to the collection
		/// </param>
		/// 
		/// <param name="save">
		/// Boolean specifying whether to save the source file
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public virtual async Task<bool>
			Create(TEntity entity, bool save = true)
				=> await Store.Insert(entity, save);

		//
		/// <summary>
		/// Remove the specified entity
		/// </summary>
		/// 
		/// <param name="entity">
		/// The anonymous type entity handled
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public virtual async Task<bool>
			Remove(TEntity entity)=> await Store.Delete(entity);

		//
		/// <summary>
		/// Signal that the store should be saved
		/// </summary>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public virtual Task<bool>
			Update() => Store.Update();

		//

		//

		public virtual Task<List<TEntity>?>
			Select(string query)
		{
			throw new NotImplementedException();
		}

		//

		//

		public virtual Task<TEntity?>
			SelectOne(string query)
		{
			throw new NotImplementedException();
		}

		//
		/// <summary>
		/// The data store used
		/// </summary>
		//

		public DataStore<TSource, TEntity> Store { get; }
	}
}
