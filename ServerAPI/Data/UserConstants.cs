
using ServerAPI.Entities.Models;

namespace Identity.Data
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
 new UserModel(){
    Username="Njabu", Password="qwerty24", EmailAddress="njeb@gmail.com", Role="Admin", Surname="Mamba", GivenName="Njebs"
 }, 
  new UserModel(){
    Username="Mafu", Password="qwerty24", EmailAddress="mafu@gmail.com", Role="User", Surname="maziya", GivenName="Mafu"
 },
        };
    }
}