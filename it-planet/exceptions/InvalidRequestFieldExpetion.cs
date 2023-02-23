namespace it_planet.repository.postgres;

public class InvalidRequestFieldExpetion : Exception
{
    public InvalidRequestFieldExpetion(string message) : base(message) {}
    
}