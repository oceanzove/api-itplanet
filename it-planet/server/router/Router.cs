using System.Net;
using it_planet.handler;
using it_planet.repository.postgres;

namespace it_planet.server;

public class Router
{

    private readonly List<RouterPoint> _routerPoints;
    public Router()
    {
        _routerPoints = new List<RouterPoint>();

    }

    public void POST(string endPoint, Action<RequestContext> handler )
    {
        var routerPoint = new RouterPoint()
        {
            Method = HttpMethod.Post,
            EndPoint =  endPoint,
            Handler =  handler
        };
        _routerPoints.Add(routerPoint);
    }
    /// <summary>
    /// Обрабатывает входящий запрос и определяет ему оброботчик
    /// </summary>
    /// <param name="context">контекст текущего запроса</param>
    public void HandleRequest(RequestContext context)
    {
        var currentEndPoint = context.GetEndPoint();
        var currentMethod = context.GetMethod();
        foreach (var routerPoint in _routerPoints)
        {
            if (currentEndPoint == routerPoint.EndPoint && currentMethod == routerPoint.Method.ToString())
            {
                try
                {
                    routerPoint.Handler(context);
                }
                catch (InvalidRequestFieldExpetion err)
                {
                    context.SendBadRequest(err.Message);
                }
                return;
            }
        }

        context.SendNotFound();
    }   
}