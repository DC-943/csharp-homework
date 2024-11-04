using michael_3038EFWebAPI.Models;

namespace michael_3038EFWebAPI.IService
{
    public interface ICourseService
    {
        public bool AddCourse(Course course);

        public bool DeleteCourse(int id);

        public Task<Course> UpdateCourseAsync(Course course);

        public List<Course> GetCourse();

        public Course? GetCourseByName(string name);


    }
}
