using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CreownTutor.Data
{
    public class Functions
    {
        public static bool SendEmail(string toEmail, string toName, string subject,
           string body, string userid = "", IEnumerable<string> ccEmails = null, IEnumerable<string> bccEmails = null
           )
        {
            string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            string smtpPort = ConfigurationManager.AppSettings["SmtpPort"];
            string smtpEnableSsl = ConfigurationManager.AppSettings["SmtpEnableSsl"];
            string smtpName = ConfigurationManager.AppSettings["SmtpName"];
            string smtpEmail = ConfigurationManager.AppSettings["SmtpEmail"];
            string smtpUserName = ConfigurationManager.AppSettings["SmtpUserName"];
            string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

            string debugMode = ConfigurationManager.AppSettings["DebugMode"];
            string debugEmail = ConfigurationManager.AppSettings["DebugEmail"];

            bool debug = (String.Compare(debugMode, Boolean.TrueString, true) == 0);

            if (debug)
            {
                // Don't send emails to users if running in debug mode
                toEmail = debugEmail;
            }

            string strTemplate = "";
            string strPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplates/PreCourseStartNotification.html");

            using (StreamReader reader = new StreamReader(strPath))
            {
                strTemplate = reader.ReadToEnd();
            }

            string strBody = strTemplate.Replace("[Content]", body).Replace("[Subject]", subject);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(smtpEmail, smtpName);

            if (String.IsNullOrEmpty(toEmail) == false)
            {
                mail.To.Add(new MailAddress(toEmail, toName));
            }

            if (ccEmails != null)
            {
                foreach (string email in ccEmails)
                {
                    if (String.IsNullOrEmpty(email) == false)
                    {
                        // Don't send emails to users if running in debug mode
                        mail.CC.Add(debug ? debugEmail : email);
                    }
                }
            }

            if (bccEmails != null)
            {
                foreach (string email in bccEmails)
                {
                    if (String.IsNullOrEmpty(email) == false)
                    {
                        // Don't send emails to users if running in debug mode
                        mail.Bcc.Add(debug ? debugEmail : email);
                    }
                }
            }

            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = strBody;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtpServer;
            smtp.Port = Convert.ToInt32(smtpPort);
            smtp.EnableSsl = Convert.ToBoolean(smtpEnableSsl);
            smtp.Credentials = new NetworkCredential(smtpUserName, smtpPassword);

            try
            {
                smtp.Send(mail);
                new Repository.EmailRepository().SaveEmailLog(mail, userid);
                return true;
            }
            catch (Exception ex)
            {
                //asd
                string s = "";
            }
            return false;
        }

    }
}