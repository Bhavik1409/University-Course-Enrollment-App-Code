public class AdminController : Controller
{
    private readonly UniversityDbContext _context;

    public AdminController(UniversityDbContext context)
    {
        _context = context;
    }

    public IActionResult CourseManagement()
    {
        var courses = _context.Courses.ToList();
        return View(courses);
    }

    public IActionResult AddCourse()
    {
        // Implement view to add a new course
        return View();
    }

    [HttpPost]
    public IActionResult AddCourse(Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("CourseManagement");
        }

        return View(course);
    }

    // Implement other actions like editing and deleting courses
    // ...

}
