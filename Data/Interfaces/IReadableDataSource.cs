namespace DAL.Interfaces
{
	//
	/// <summary>Generic data source interface that allows you to read data from the data source.</summary>
	/// 
	/// <typeparam name="TSource">The data source object type.</typeparam>
	/// <typeparam name="TReadReturn">The type of object returned from the data source.</typeparam>
	//

	public interface
		IReadableDataSource<
			TSource,
			TReadReturn
			>
		: IDataSource<
			TSource
			>

		where TSource : notnull
	{
		//
		/// <summary>Reads data from the data source.</summary>
		/// <returns>TReadReturn | null</returns>
		//

		Task<TReadReturn?> ReadAsync();
	}
}
