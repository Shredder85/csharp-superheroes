namespace DAL.Interfaces
{
	//
	/// <summary>Generic data source interface that allows you to read data from and write data to a data source.</summary>
	/// 
	/// <typeparam name="TSource">The data source object type.</typeparam>
	/// <typeparam name="TReadReturn">The type of object returned from the data source.</typeparam>
	/// <typeparam name="TWriteInput">The type of object used as input when writing data to the data source.</typeparam>
	//

	public interface
		IWriteableDataSource<
			TSource,
			TReadReturn,
			TWriteInput
			>
		
		: IDataSource<
			TSource,
			TReadReturn
			>
	{
		//
		/// <summary>Write the provided data to the data source.</summary>
		/// <param name="input">The data that should be written to the data source.</param>
		
		Task<bool> WriteAsync(TWriteInput input);

		//
		/// <summary>Delete the data source.</summary>
		
		Task<bool> DeleteAsync();
	}
}
