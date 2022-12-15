using System.ComponentModel.DataAnnotations;

namespace ServerAPI.Entities.Models
{
    public class UserModel
    {
        [Key]
         public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }

     public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    }
}