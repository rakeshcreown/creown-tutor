using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Repository
{
    public class StudentRepository:BaseRepository
    {
        public UserDetail GetStudents(int id)
        {
           return dbEntity.UserDetails.FirstOrDefault(m => m.UserID == id);
        }
    }
}
