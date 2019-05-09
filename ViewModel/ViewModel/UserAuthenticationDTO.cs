using Entities.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public  class UserAuthenticationDTO
    {
        public int User_ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public static UserAuthenticationDTO GetUserAuthentication(string userName, string password) {


            try
            {
                UserAuthentication userAuthentication = UserAuthentication.GetUserAuthentication(userName,password);
                if (userAuthentication != null)
                {
                    return new UserAuthenticationDTO()
                    {

                        User_ID = userAuthentication.User_ID,
                        UserName = userAuthentication.UserName,
                        Password = userAuthentication.Password,
                        Type = userAuthentication.Type

                    };
                }
                else
                {
                    return null;
                }


            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }




        }

        public static bool AddUserAuthenticationDTO(UserAuthenticationDTO user) {
            if (user != null)
            {
                UserAuthentication.AddUserAuthentication(user);

            }
            return false;

        }

        public static bool UppdateUserAuthenticationDTO(UserAuthenticationDTO user)
        {
            if (user != null)
            {
                UserAuthentication.UppdateUserAuthentication(user);
            }

            return false;
        }

        public static bool DeleteUserAuthenticationDTO(int? userId)
        {
            if (userId != null)
            {
                UserAuthentication.DeleteUserAuthentication(userId.Value);
            }

            return false;
        }



    }
}
