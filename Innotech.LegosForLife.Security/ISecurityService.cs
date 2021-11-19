using InnoTech.LegosForLife.Security.Models;

namespace InnoTech.LegosForLife.Security
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string username, string password);
    }
}