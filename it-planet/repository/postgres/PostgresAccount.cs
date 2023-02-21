namespace it_planet.repository.postgres;

public class PostgresAccount
{
    [PostgresName("id")]
    public long Id { get; set; }
    [PostgresName("first_name")]
    public string FirstName { get; set; }
    [PostgresName("last_name")]
    public string LastName { get; set; }
    [PostgresName("email")]
    public string Email { get; set; }
    [PostgresName("password")]
    public string Password { get; set; }
}