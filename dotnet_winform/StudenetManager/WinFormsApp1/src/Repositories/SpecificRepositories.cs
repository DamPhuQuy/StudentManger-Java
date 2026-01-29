using StudentManagement.Models;

namespace StudentManagement.Repositories;

// Specific repositories inheriting from generic repository
public class StudentRepository : Repository<Student>
{
    public StudentRepository() : base(s => s.StudentId) { }
}

public class CourseRepository : Repository<Course>
{
    public CourseRepository() : base(c => c.CourseId) { }
}

public class GradeRepository : Repository<Grade>
{
    public GradeRepository() : base(g => g.GradeId) { }
}

public class EnrollmentRepository : Repository<Enrollment>
{
    public EnrollmentRepository() : base(e => e.EnrollmentId) { }
}

public class UserRepository : Repository<User>
{
    public UserRepository() : base(u => u.UserId) { }
}
