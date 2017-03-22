using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CreownTutor.Data.Model;

namespace CreownTutor.Data.Repository
{
    public class TestRepository : BaseRepository
    {
       
        public void CreateTest(TestViewModel model)
        {
            try
            {
                Test test = new Test();
                test.TestName = model.TestName;
                test.TestDescription = model.TestDescription;
                test.Category = model.Category;
                test.TestInstructions = model.TestInstructions;
                test.AllowViewingAnswer = model.AllowViewingAnswer;
                test.IsTimeAlloted = model.IsTimeAlloted;
                test.Hour =model.Hour;
                test.Minutes = model.Minutes;
                test.Seconds = model.Seconds;
                dbEntity.Tests.Add(test);
                dbEntity.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {

            }
        }

        public List<Model.Category> GetCategories()
        {
            List<Model.Category> categories = new List<Model.Category>();
            foreach (var item in dbEntity.Categories.ToList())
            {
                int count = 0;
                count = dbEntity.Tests.Where(c => c.Category == item.CategoryID.ToString()).Count();
                categories.Add(new Model.Category() { CategoryID = item.CategoryID.ToString(), CategoryName = item.Category1, TestCount = count });
            }
            return categories;
        }
    }
}
