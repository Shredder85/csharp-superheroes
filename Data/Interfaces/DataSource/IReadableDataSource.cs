namespace DAL.Interfaces.DataSource
{
    //
    /// <summary>
    /// Generic data source interface that allow you to read data from the data source.
    /// </summary>
    /// 
    /// <typeparam name="TSource">
    /// The anonymous type used as a data source
    /// </typeparam>
    /// 
    /// <typeparam name="TReadReturn">
    /// The anonymous type returned as output
    /// </typeparam>
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
        /// <summary>
        /// Read data from the data source
        /// </summary>
        /// 
        /// <returns>TReadReturn | null</returns>
        //

        Task<TReadReturn?> ReadAsync();
    }
}
