using michael_3038EFWebAPI.IService;
using michael_3038EFWebAPI.Data;
using michael_3038EFWebAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace michael_3038EFWebAPI.Service
{
    public class CourseService: ICourseService
    {
        private readonly HomeworkDBContext _homeworkDBContext;
        public CourseService(HomeworkDBContext homeworkDBContext)
        {
            this._homeworkDBContext = homeworkDBContext;
        }

        public bool AddCourse(Course course)
        {
            this._homeworkDBContext.Courses.Add(course);
            var result = this._homeworkDBContext.SaveChanges() > 0;
            return result;
        }

        public bool DeleteCourse(int id)
        {
            var deleteCourse = this._homeworkDBContext.Categories.FirstOrDefault(x => x.Id == id);
            if (deleteCourse != null)
            {
                this._homeworkDBContext.Categories.Remove(deleteCourse);
                return this._homeworkDBContext.SaveChanges() > 0;
            }
            return false;
        }

        //异步
        public async Task<Course> UpdateCourseAsync(Course course)
        {
            //thread id--get the current executing thread ID
            Console.WriteLine("UpdateCourse Thread id:  {0}", Thread.CurrentThread.ManagedThreadId);

            var updateCourse = await this._homeworkDBContext.Courses.FirstOrDefaultAsync(x => x.Id == course.Id);
            Console.WriteLine("FirstOrDefaultAsync Thread id:  {0}", Thread.CurrentThread.ManagedThreadId);

            if (updateCourse != null)
            {
                updateCourse.CourseName = course.CourseName;
                updateCourse.Description = course.Description;
                updateCourse.CategoryId = course.CategoryId;

                await this._homeworkDBContext.SaveChangesAsync();
                Console.WriteLine("SaveChangesAsync Thread id:  {0}", Thread.CurrentThread.ManagedThreadId);
                return updateCourse;
            }
            return course;
        }

        public List<Course> GetCourse()
        {
            var courseList = this._homeworkDBContext.Courses.Include(x => x.Category).ToList();

            //var courseQuery = from course in this._homeworkDBContext.Course
            //                  join category in this._homeworkDBContext.Category on course.CategoryId equals category.Id
            //                  select new Course
            //                  {
            //                      CategoryId = course.CategoryId,
            //                      Category = category,
            //                      Id = course.Id,
            //                      CourseName = course.CourseName
            //                  };
            //var courseList = courseQuery.ToList();//lazy loading

            return courseList;
        }

        public Course? GetCourseByName(string name)
        {
            return this._homeworkDBContext.Courses.FirstOrDefault(x => x.CourseName == name);//lambda expression
        }
    }
}
