using WebApiJWT.Dtos;
using WebApiJWT.Types;

namespace WebApiJWT.Services
{
    public interface IUser
    {
        Task<ServiceMessage> AddUser(AddUserDto userDto);
        Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto userDto);
        
    }
}
