namespace it_planet.repository.postgres;

public class RequestBodyDeserializeException : Exception
{
  private const string MESSAGE = "request body deserialize error";
  public RequestBodyDeserializeException() : base(MESSAGE){}
}