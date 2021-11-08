using InnoTech.LegosForLife.Security.Model;

namespace InnoTech.LegosForLife.Security
{
    public interface IAuthService
    {
        string GenerateJwtToken(LoginUser userUserName);
        
        bool UserHasPermission(LoginUser user, string permission);
    }
}