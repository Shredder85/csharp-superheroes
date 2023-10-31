namespace DAL.Interfaces
{
	public interface
		IDataSource<
			TSource
			>

		where TSource : notnull
	{
		//
		/// <summary>
		/// The data source object used
		/// </summary>
		//

		TSource Source { get; }
	}
}
