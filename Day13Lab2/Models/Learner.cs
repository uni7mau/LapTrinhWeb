using System;
using System.Collections.Generic;

namespace Day13Lab_231230949_14_11_2025_2.Models;

public partial class Learner
{
    public int LearnerId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstMidName { get; set; } = null!;

    public DateTime EnrolmentDate { get; set; }

    public int MajorId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Major? Major { get; set; } = null!;
}
