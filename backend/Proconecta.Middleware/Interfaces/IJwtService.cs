namespace Proconecta.Middleware.Interfaces
{
    using Proconecta.Data.DTO;

    public interface IJwtService
    {
        string GenerateJSONWebToken(UserDTO user);
    }
}
