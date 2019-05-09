using Entities.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class StudentMarkDTO
    {
        public int User_ID { get; set; }
        public double ArtificialIntellegence { get; set; }
        public double Python_Programming { get; set; }
        

        public static IList<StudentMarkDTO> GetStudentMarksDetails() {

            try
            {
                IList<StudentMarkDTO> studentMarksList = StudentMark.GetStudentMarksDetails().Select(studenMarksDetails => new StudentMarkDTO()
                {
                    User_ID = studenMarksDetails.User_ID,
                    ArtificialIntellegence = studenMarksDetails.ArtificialIntellegence,
                    Python_Programming = studenMarksDetails.Python_Programming

                }).ToList();
                return studentMarksList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }

        }

        public static StudentMarkDTO GetStudentMarks(int studentId) {
            try
            {
                StudentMark studentMark = StudentMark.GetStudentMarks(studentId);
                if (studentMark != null)
                {
                    return new StudentMarkDTO()
                    {

                        User_ID = studentMark.User_ID,
                        ArtificialIntellegence = studentMark.ArtificialIntellegence,
                        Python_Programming = studentMark.Python_Programming
                        
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

        public static bool AddStudentMarks(StudentMarkDTO studentMarks) {

            if (studentMarks != null)
            {
                StudentMark.AddStudentMarks(studentMarks);

            }
            return false;
        }

        public static bool UpdateStudentMarks(StudentMarkDTO studentMarks) {

            if (studentMarks != null)
            {
                StudentMark.UpdateStudentMarks(studentMarks);
            }

            return false;

        }


        public static bool DeleteStudentMarks(int? userId) {

            if (userId != null)
            {
                StudentMark.DeleteStudentMarks(userId.Value);
            }

            return false;

        }


    }

}
