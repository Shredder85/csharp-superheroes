using DAL.Interfaces;
using Models;

namespace DAL
{
	//
	/// <summary>
	/// Contains data handling mechanisms, used as a source by repositories
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

	public class
		DataStore<
			TSource,
			TEntity
			>

		where TSource : IDataStoreSource<TEntity>
		where TEntity : Entity
	{
		//
		/// <summary>
		/// Set the data source for the store
		/// </summary>
		/// 
		/// <param name="source">
		/// The anonymous type used as the source
		/// </param>
		//

		public DataStore(TSource source) => Source = source;

		//
		/// <summary>
		/// Add a new entity to the store's collection
		/// </summary>
		/// 
		/// <param name="entity">
		/// The anonymous type entity that should be added
		/// </param>
		/// 
		/// <param name="save">
		/// Boolean specifying whether to trigger the source's save mechanism
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public Task<bool>
			Insert(TEntity entity, bool save = true)
		{
			return Task.Run(() =>
			{
				lock (Entities)
				{
					if (entity.Id == string.Empty)
					{
						do {
							entity.Id = GenerateId();
						}
						while (Entities.ContainsKey(entity.Id));
					}

					Entities.Add(entity.Id, entity);

					if (save)
					{
						Source.Save(Entities);
					}
				}

				return true;
			});
		}

		//
		/// <summary>
		/// Update the store, saving all currently stored entities
		/// </summary>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public async Task<bool>
			Update()
		{
			await Source.Save(Entities);
			
			return true;
		}

		//
		/// <summary>
		/// Remove the specified entity from the store
		/// </summary>
		/// 
		/// <param name="entity">
		/// The anonymous type entity that should be removed
		/// </param>
		/// 
		/// <returns>
		/// Boolean indicating the result of the operation
		/// </returns>
		//

		public async Task<bool>
			Delete(TEntity entity)
		{
			if (Entities.ContainsKey(entity.Id))
			{
				lock (Entities)
				{
					Entities.Remove(entity.Id);
				}

				await Source.Save(Entities);
				
				return true;
			}

			return false;
		}

		//

		//

		public Task<List<TEntity>?> 
			Select(string query)
		{
			throw new NotImplementedException();
		}

		//

		//

		public Task<TEntity?> 
			SelectOne(string query)
		{
			throw new NotImplementedException();
		}

		//
		/// <summary>
		/// Generate and return a new identifier
		/// </summary>
		/// 
		/// <returns>Globally Unique Identifier (GUID)</returns>
		//

		public string GenerateId()=> Guid.NewGuid().ToString();

		//
		/// <summary>
		/// The list of stored entities
		/// </summary>
		//

		public Dictionary<string, TEntity>
			Entities { get; } = new();

		//
		/// <summary>
		/// The source used by the store
		/// </summary>
		//

		public TSource
			Source { get; }
	}
}
