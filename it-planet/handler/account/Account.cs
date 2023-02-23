using it_planet.models.account;
using it_planet.service;

namespace it_planet.handler.Account;

public class Account : HandlerResponsibility, IAccount
{
    public Account(Service service) : base(service) {}

    public void Registration(RequestContext context)
    {
        var input = context.GetBody<RegistrationInput>();
        var account = _service.Account.Registration(input);
        var output = new RegistrationOutput
        {
            id = account.Id,
            firstName = account.FirstName,
            lastName = account.LastName,
            email = account.Email
        };
        context.SendCreated(output);
    }
}