namespace DAL
{
	public abstract class
		Repository<
			TSource,
			TCollection
			>

		where TCollection : notnull, new()
	{
		public Repository(DataStore<TSource, TCollection> store)=> Store = store;

		public DataStore<TSource, TCollection> Store { get; }
	}
}
