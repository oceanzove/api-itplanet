using it_planet.handler.Account;
using it_planet.server;
using it_planet.service;
using IAccount = it_planet.handler.Account.IAccount;

namespace it_planet.handler;

public class Handler
{
    public readonly IAccount Account;
    
    public Handler(Service service)
    {
        Account = new Account.Account(service);
    }

    public Router GetRouter()
    {
        var router = new Router();
        
        router.POST("/registration", Account.Registration);

        return router;
    }
}