using System;
using System.Collections.Generic;

namespace PracticeCollege.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Leavings = new HashSet<Leaving>();
        }

        public int Id { get; set; }
        public string? LessonName { get; set; }

        public virtual ICollection<Leaving> Leavings { get; set; }
    }
}
