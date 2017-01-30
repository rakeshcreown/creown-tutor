using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Repository
{
    public class CourseRepository : BaseRepository
    {
        public List<Category> ShowCategories(string searchKeyword = "")
        {
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                return dbEntity.Categories.Where(c => c.Category1.ToLower().Contains(searchKeyword.ToLower())).ToList();
            }
            return dbEntity.Categories.ToList();
        }

        public void ShowCourses(string category = "")
        {

        }
    }
}
