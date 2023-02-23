using it_planet.service;

namespace it_planet.handler;

public class HandlerResponsibility
{
    protected readonly Service _service;
    
    public HandlerResponsibility(Service service)
    {
        _service = service;
    }
}