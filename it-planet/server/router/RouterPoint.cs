using it_planet.handler;

namespace it_planet.server;

public class RouterPoint
{
    public string EndPoint;
    public HttpMethod Method;
    public Action<RequestContext> Handler;
    
}