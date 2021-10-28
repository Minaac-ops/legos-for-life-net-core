using InnoTech.LegosForLife.Security.Model;

namespace InnoTech.LegosForLife.Security
{
    public interface IAuthService
    {
        string GenerateJwtToken(LoginUser userUserName);
    }
}