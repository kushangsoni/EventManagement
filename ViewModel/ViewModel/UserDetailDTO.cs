using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Entities.Entites;
namespace ViewModel
{
    public partial class UserDetailDTO
    {
        public int User_ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BranchName { get; set; }
        public int Semester { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public System.DateTime AdmissionDate { get; set; }
        
        public static IList<UserDetailDTO> GetUserDetails()
        {    
            try
            {
                IList<UserDetailDTO> userDetsils = UserDetail.GetUserDetails().Select(userDetail => new UserDetailDTO()
                {
                    User_ID = userDetail.User_ID,
                    FirstName = userDetail.FirstName,
                    MiddleName = userDetail.MiddleName,
                    LastName = userDetail.LastName,
                    BranchName = userDetail.BranchName,
                    Semester = userDetail.Semester,
                    Age = userDetail.Age,
                    Gender = userDetail.Gender,
                    Address = userDetail.Address,
                    AdmissionDate = userDetail.AdmissionDate
                    
                }).ToList();
                return userDetsils;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                
            }


        }

        public static UserDetailDTO GetUserDetail(int studentId)
        {
            
            try
            {
                UserDetail userDetail = UserDetail.GetUserDetail(studentId);
                if (userDetail != null)
                {
                    return new UserDetailDTO()
                    {

                        User_ID = userDetail.User_ID,
                        FirstName = userDetail.FirstName,
                        MiddleName = userDetail.MiddleName,
                        LastName = userDetail.LastName,
                        BranchName = userDetail.BranchName,
                        Semester = userDetail.Semester,
                        Age = userDetail.Age,
                        Gender = userDetail.Gender,
                        Address = userDetail.Address,
                        AdmissionDate = userDetail.AdmissionDate
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

        public static bool AddUserDetails(UserDetailDTO userDetail)
        {
            if (userDetail != null)
            {
                UserDetail.AddUserDetails(userDetail);

            }
                return false;
            
        }

        public static bool UpdateUserDetail(UserDetailDTO userDetail)
        {
            if (userDetail != null) {
                UserDetail.UpdateUserDetail(userDetail);
            }

            return false;
        }

        public static bool DeleteUserDetails(int? userId)
        {
            if (userId != null) {
                UserDetail.DeleteUserDetails(userId.Value);
            }

            return false;

        }

    }
}
