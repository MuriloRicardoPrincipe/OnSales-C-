using OnSales.Interface;
using System.Security.Claims;

namespace OnSales.Repository;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _accessor;

    public UserContext(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public Guid UserId
    {
        get
        {

            var userId = _accessor.HttpContext?
                .User?
                .FindFirst("userId")?.Value;

            if (userId is null)
                throw new UnauthorizedAccessException("Usuário não autenticado");

            return Guid.Parse(userId);
        }
    }
}