namespace DAL.Interfaces.DataSource
{
	//
	/// <summary>
	/// Generic data source interface that allows you to read
	/// data from and write data to a data source.
	/// </summary>
	/// 
	/// <typeparam name="TSource">
	/// The anonymous type used as a source
	/// </typeparam>
	/// 
	/// <typeparam name="TWriteInput">
	/// The anonymous type used as input
	/// </typeparam>
	//

	public interface
        IWriteableDataSource<
            TSource,
            TWriteInput
            >

        : IDataSource<
            TSource
            >

        where TSource : notnull
    {
        //
        /// <summary>
        /// Write the provided data to the data source.
        /// </summary>
        /// 
        /// <param name="input">
        /// The data that should be written to the data source.
        /// </param>
        //

        Task<bool> WriteAsync(TWriteInput input);

        //
        /// <summary>
        /// Delete the data source
        /// </summary>
        //

        Task<bool> DeleteAsync();
    }
}
