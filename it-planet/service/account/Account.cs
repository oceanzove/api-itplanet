using it_planet.models.account;
using it_planet.repository;
using it_planet.repository.postgres;

namespace it_planet.service.account;

public class Account : ServiceResponsibility, IAccount
{
    public Account(Repository repository) : base(repository) {}
    
    public PostgresAccount Registration(RegistrationInput props)
    {
        if (props.firstName == null || props.firstName.Trim() == "")
        {
            ThrowInvalidRequestField("invalid first name: {0}", props.firstName);
        }
        
        if (props.lastName == null || props.lastName.Trim() == "")
        {
            ThrowInvalidRequestField("invalid last name: {0}", props.lastName);
        }
        if (props.email == null || props.email.Trim() == "")
        {
            ThrowInvalidRequestField("invalid email: {0}", props.email);
        }
        if (props.password == null || props.password.Trim() == "")
        {
            ThrowInvalidRequestField("invalid password: {0}", props.password);
        }
        
        return _repository.Account.Create(
            props.firstName,
            props.lastName,
            props.email,
            props.password);
    }
}