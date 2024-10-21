using WebApiJWT.Entities;

namespace WebApiJWT.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public  UserType UserType { get; set; }
    }
}
