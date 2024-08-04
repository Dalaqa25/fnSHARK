using API.Models;

namespace API.Interface
{
    public interface ITokenInterface
    {
        string CreateToken(AppUser user);
    }   
}