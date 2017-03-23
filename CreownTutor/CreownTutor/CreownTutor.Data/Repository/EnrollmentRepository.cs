using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreownTutor.Data.Model;


namespace CreownTutor.Data.Repository
{
    public class EnrollmentRepository:BaseRepository
    {
        public void Enroll(Enrollment enrollment)
        {
            CourseRegistration courseregis = new CourseRegistration();
            courseregis.CourseID = enrollment.Course.CourseID;
           // courseregis.UserID =2;//TODO:This needs to be changed
            courseregis.RegisteredDateTime =DateTime.Now;
            dbEntity.CourseRegistrations.Add(courseregis);
            dbEntity.SaveChanges();
        }
    }
}
