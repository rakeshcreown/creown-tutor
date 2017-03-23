using CreownTutor.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Repository
{
  public  class ReviewRepository:BaseRepository
    {
        public int saverating(ReviewModel model)
        {
            int result = 0;
            
            dbEntity.Reviews.Add(new Review
            {
                   // UserID = 1,
                    ReviewRating = model.Rating,
                    ReviewComments = model.ReviewComment,
                    CourseID=1,
                    SessionID=1,
                    AddedTime=DateTime.Now
            });
                dbEntity.SaveChanges();

                var newScore = (from a in dbEntity.Reviews
                                where a.SessionID.Equals(1)
                                group a by a.SessionID into aa
                                select new
                                {
                                    Score = aa.Sum(a => a.ReviewRating) / aa.Count()
                                }).FirstOrDefault();
                result = newScore.Score;
            
            return result;
        }

    }
}
