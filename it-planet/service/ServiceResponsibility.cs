using it_planet.repository;
using it_planet.repository.postgres;

namespace it_planet.service;

public class ServiceResponsibility
{
    protected readonly Repository _repository;
    
    public ServiceResponsibility(Repository repository)
    {
        _repository = repository;
    }

    protected void ThrowInvalidRequestField(string? template, params string[] args)
    {
        var message = String.Format(template ?? "",  args);
        throw new InvalidRequestFieldExpetion(message);
    }
}