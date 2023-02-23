using it_planet.models.account;
using it_planet.repository.postgres;

namespace it_planet.service.account;

public interface IAccount
{
    public PostgresAccount Registration(RegistrationInput props);
}