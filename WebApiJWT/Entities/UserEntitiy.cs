namespace WebApiJWT.Entities
{
    public class UserEntitiy
    {
        public UserEntitiy()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string  Email { get; set; }
        public string  Password { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        User,Admin
    }
}
