namespace it_planet.repository.postgres.queries.location;

public class PostgresLocation
{
    [PostgresName("id")]
    public long Id { get; set; }
    [PostgresName("latitude")]
    public double Latitude { get; set; }
    [PostgresName("longitude")] 
    public double Longitude { get; set; }

  
}