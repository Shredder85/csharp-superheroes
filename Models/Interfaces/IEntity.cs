namespace Models
{
	public interface
		
		IEntity<TIdentifier>
	{
		TIdentifier Id { get; }
	}
}
