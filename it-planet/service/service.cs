using it_planet.repository;
using it_planet.service.account;

namespace it_planet.service;

public class Service
{
    public IAccount Account;
    
    public Service(Repository repository)
    {
        Account = new Account(repository);
    }
}