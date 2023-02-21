namespace it_planet.repository.postgres.queries.account;

public class PostgresQueriesAccount : IQueriesAccount
{
    public string Create()
    {
        return "INSERT INTO \"Account\" (first_name, last_name, email, password) " +
               "VALUES ($1, $2, $3, $4) RETURNING *";
    }

    public string Get()
    {
        return "SELECT * FROM \"Account\" WHERE email=$1 and password=$2";
    }
}