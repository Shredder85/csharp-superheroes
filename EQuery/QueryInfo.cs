using EQuery.Interfaces;

namespace EQuery
{
	public class
		QueryInfo
	{
		public Dictionary<string, IQueryClause> Clauses { get; } = new();
	}
}
