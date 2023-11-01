using EQuery.Exceptions;

namespace EQuery
{
	//

	//

	public static class
		EQuery
	{
		//

		//

		public static void
			Compile(string query)
		{
			if (query.Trim() == string.Empty)
			{
				throw new QueryMissingException();
			}

			
		}
	}
}
