public class StudentController : Controller
{
    private readonly UniversityDbContext _context;

    public StudentController(UniversityDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var courses = _context.Courses.ToList();
        return View(courses);
    }

    public IActionResult Enroll(int courseId)
    {
        var course = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);
        if (course == null)
        {
            return NotFound();
        }

        if (course.EnrolledStudents.Count >= course.Capacity)
        {
            return RedirectToAction("Index", new { message = "Course is full. Cannot enroll." });
        }

        var student = new Student { Name = "John Doe", Email = "john.doe@example.com" };

        var enrollment = new Enrollment { StudentId = student.StudentId, CourseId = course.CourseId };
        _context.Enrollments.Add(enrollment);
        _context.SaveChanges();

        return RedirectToAction("Index", new { message = "Enrollment successful." });
    }
}
