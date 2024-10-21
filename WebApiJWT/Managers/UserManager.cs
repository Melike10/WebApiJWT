using Microsoft.AspNetCore.Http.HttpResults;
using WebApiJWT.Context;
using WebApiJWT.Dtos;
using WebApiJWT.Entities;
using WebApiJWT.Services;
using WebApiJWT.Types;

namespace WebApiJWT.Managers
{
    public class UserManager : IUser
    {
        private readonly WebApiJwtDbContext _db;

        public UserManager( WebApiJwtDbContext db)
        {
            _db = db;  
        }
        public async Task<ServiceMessage> AddUser(AddUserDto userDto)
        {
            var user = new UserEntitiy {
             
              Email = userDto.Email,
              Password = userDto.Password,
              IsDeleted = false
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return new ServiceMessage() { 
            IsSucceed = true,
            Message="Register işlemi başarılı oldu."
            };
            
        }

        public async Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto userDto)
        {
            var userEntitiy = _db.Users.Where(u => u.Email.ToLower() == userDto.Email.ToLower()).FirstOrDefault();
            if (userEntitiy is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı ya da şifre hatalı"
                };
            }

            if (userEntitiy.Password != userDto.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı ya da şifre hatalı"
                };
            }

            return new ServiceMessage<UserInfoDto>
            {
                IsSucceed = true,
                Data = new UserInfoDto
                {
                    Id = userEntitiy.Id,
                    Email= userEntitiy.Email,
                    UserType = userEntitiy.UserType

                }

            };
        }
    }
}
