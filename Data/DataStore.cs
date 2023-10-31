using DAL.Interfaces;

namespace DAL
{
	public class
		DataStore<
			TSource,
			TCollection
			>

		where TCollection : notnull, new()
	{
		public DataStore(TSource source) => Source = source;

		public TCollection Entities { get; } = new();

		public TSource Source { get; }
	}
}
