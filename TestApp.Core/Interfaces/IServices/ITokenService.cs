using TestApp.Core.Enteties.User;

namespace TestApp.Core.Interfaces.IServices
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
