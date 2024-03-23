namespace PostgresSample;

public class User : Entity<int>
{
	public string Username { get; set; }
	public string Password { get; set; }
}
