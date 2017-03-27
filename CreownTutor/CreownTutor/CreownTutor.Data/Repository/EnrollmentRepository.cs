using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreownTutor.Data.Model;


namespace CreownTutor.Data.Repository
{
    public class EnrollmentRepository : BaseRepository
    {
        public bool Enroll(Enrollment enrollment)
        {
            var courseregis = dbEntity.CourseRegistrations.FirstOrDefault(c => c.CourseID == enrollment.Course.CourseID && c.UserID == enrollment.Course.UserID);
            if (courseregis == null)
            {
                courseregis = new CourseRegistration();
                courseregis.CourseID = enrollment.Course.CourseID;
                courseregis.UserID = enrollment.Course.UserID;//TODO:This needs to be changed
                courseregis.RegisteredDateTime = DateTime.Now;
                dbEntity.CourseRegistrations.Add(courseregis);
                dbEntity.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
