namespace DAL.Interfaces.DataSource
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
