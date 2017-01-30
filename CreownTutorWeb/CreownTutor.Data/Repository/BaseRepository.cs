using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Repository
{
    public class BaseRepository
    {
        public DataEntities dbEntity { get; set; }

        public BaseRepository()
        {
            this.dbEntity = new DataEntities();
        }
    }
}
