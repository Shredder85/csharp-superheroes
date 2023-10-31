using Models.Interfaces;

namespace DAL.Interfaces
{
	//
	/// <summary>
	/// Repository interface used as a base model for repository classes
	/// </summary>
	/// 
	/// <typeparam name="TIdentifier">
	/// The anonymous type used as an identifier
	/// </typeparam>
	/// 
	/// <typeparam name="TEntity">
	/// The anonymous type handled by the repository
	/// </typeparam>
	//

	public interface
		IRepository<
			TSource,
			TIdentifier,
			TEntity
			>

		where TEntity : IEntity<TIdentifier>
		where TIdentifier : notnull
	{
		//
		/// <summary>
		/// Fetch a single entity using it's unique identifier
		/// </summary>
		/// 
		/// <param name="id">
		/// The unique identifier for the requested entity
		/// </param>
		/// 
		/// <returns>Entity | null</returns>
		
		Task<TEntity?> SelectOne(TIdentifier id);

		//
		/// <summary>
		/// Retrieve a list of all the stored entities
		/// </summary>
		/// 
		/// <returns>
		/// The list of entities currently stored in the repository
		/// </returns>
		
		Task<List<TEntity>> SelectAll();

		//
		/// <summary>
		/// Add a new entity to the repository
		/// </summary>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//
		Task<bool> Insert(TEntity entity);

		//
		/// <summary>
		/// Update the provided entity
		/// </summary>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		Task<bool> Update(TEntity entity);

		//
		/// <summary>
		/// Delete the specified entity from the repository
		/// </summary>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		Task<bool> Delete(TEntity entity);

		//
		/// <summary>
		/// The the data source for the repository
		/// </summary>
		//

		TSource Source { get; }
	}
}
