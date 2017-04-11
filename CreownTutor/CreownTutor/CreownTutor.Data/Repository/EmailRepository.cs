using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Repository
{
    public class EmailRepository : BaseRepository
    {
        public void SaveEmailLog(MailMessage mail, string userId)
        {
            dbEntity.EmailLogs.Add(new EmailLog() { From = mail.From.ToString(), To = mail.To.ToString(), Subject = mail.Subject, EmailContent = mail.Body, UserID = userId, Date = DateTime.Now });
            dbEntity.SaveChanges();
        }

        public void SendPreCourseNotification(int courseid, string userid)
        {
            var usercourse = dbEntity.CourseRegistrations.FirstOrDefault(c => c.CourseID == courseid && c.UserID == userid);
            if (usercourse != null && (usercourse.PreCourseNotified == null || !usercourse.PreCourseNotified.Value))
            {
                // TODO : set current logged in user data for sending email
                bool succeed = Functions.SendEmail("rakesh.angre.creowntech@gmail.com", "Test", "Course is about to start", "Course is about to start", userid);
                if (succeed)
                {
                    usercourse.PreCourseNotified = true;
                    dbEntity.SaveChanges();
                }
            }
        }

    }
}
