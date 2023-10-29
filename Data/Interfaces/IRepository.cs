using Models.Interfaces;

namespace DAL.Interfaces
{
	//
	/// <summary>Repository interface used as a base model for repository classes.</summary>
	/// <typeparam name="TIdentifier">The type of object used as an identifier.</typeparam>
	/// <typeparam name="TEntity">The type of object handled by the repository.</typeparam>
	//

	public interface
		IRepository<
			TIdentifier,
			TEntity
			>

		where TEntity : IEntity<TIdentifier>
		where TIdentifier : notnull
	{
		//
		/// <summary>Fetch a single entity using it's unique identifier.</summary>
		/// <param name="id">The unique identifier for the requested entity.</param>
		/// <returns>Entity | null</returns>
		//
		Task<TEntity?> SelectOne(TIdentifier id);

		//
		/// <summary>Fetch entities based on the specified critera.</summary>
		/// <typeparam name="TProperty">The type of object stored in the property.</typeparam>
		/// <typeparam name="TValue">The value to match against the specified property.</typeparam>
		/// <returns>A list of entities matching the given criteria, or null if no matches were found.</returns>
		//
		Task<List<TEntity>?> SelectBy<TProperty, TValue>(TProperty property, TValue value);

		//
		/// <summary>Fetch all entities.</summary>
		/// <returns>A list of entities from the repository.</returns>
		//
		Task<List<TEntity>> SelectAll();

		//
		/// <summary>Insert a new entity.</summary>
		/// <returns>Boolean indicating the result of the operation.</returns>
		//
		Task<bool> Insert(TEntity entity);

		//
		/// <summary>Update the provided entity.</summary>
		/// <returns>Boolean indicating the result of the operation.</returns>
		//
		Task<bool> Update(TEntity entity);

		//
		/// <summary>Delete the specified entity.</summary>
		/// <returns>Boolean indicating the result of the operation.</returns>
		//
		Task<bool> Delete(TEntity entity);
	}
}
