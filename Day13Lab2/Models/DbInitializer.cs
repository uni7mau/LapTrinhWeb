using Microsoft.EntityFrameworkCore;

namespace Day13Lab_231230949_14_11_2025_2.Models
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AspnetLab4Context(serviceProvider
                .GetRequiredService<DbContextOptions<AspnetLab4Context>>()))
            {
                context.Database.EnsureCreated();

                if (context.Majors.Any())
                {
                    return;
                }

                var majors = new Major[]
                {
                    new Major { MajorName = "IT" },
                    new Major { MajorName = "Economics" },
                    new Major { MajorName = "Mathematics" },
                };
                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                var learners = new Learner[]
                {
                    new Learner { FirstMidName = "Carson", LastName = "Alexander", EnrolmentDate = DateTime.Parse("2005-09-01"), MajorId = 1 },
                    new Learner { FirstMidName = "Meredith", LastName = "Alonso", EnrolmentDate = DateTime.Parse("2002-09-01"), MajorId = 2 },
                };
                foreach (var learner in learners)
                {
                    context.Learners.Add(learner);
                }
                context.SaveChanges();

                var courses = new Course[]
                {
                    new Course { CourseId = 1050, Title = "Chemistry", Credits = 3 },
                    new Course { CourseId = 4022, Title = "Microeconomics", Credits = 3 },
                    new Course { CourseId = 4041, Title = "Macroeconomics", Credits = 3 },
                };
                foreach (var course in courses)
                {
                    context.Courses.Add(course);
                }
                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                    new Enrollment { LearnerId = 1, CourseId = 1050, Grade = 5.5f },
                    new Enrollment { LearnerId = 1, CourseId = 4022, Grade = 7.5f },
                    new Enrollment { LearnerId = 2, CourseId = 1050, Grade = 3.5f },
                    new Enrollment { LearnerId = 2, CourseId = 4041, Grade = 7f },
                };
                foreach (var enrollment in enrollments)
                {
                    context.Enrollments.Add(enrollment);
                }
                context.SaveChanges();
            }
        }
    }
}
