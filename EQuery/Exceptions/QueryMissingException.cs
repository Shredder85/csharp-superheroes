namespace EQuery.Exceptions
{
	//
	/// <summary>
	/// Exception thrown when the parser is executed with no query available
	/// </summary>
	//

	public class
		QueryMissingException
		: Exception
	{
		public QueryMissingException(): base("No query provided") { }
	}
}
