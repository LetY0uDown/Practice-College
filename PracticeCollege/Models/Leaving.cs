using System;
using System.Collections.Generic;

namespace PracticeCollege.Models
{
    public partial class Leaving
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? LessonId { get; set; }
        public DateTime? LeavingDate { get; set; }
        public int? LessonNum { get; set; }

        public virtual Lesson? Lesson { get; set; }
        public virtual Student? Student { get; set; }
    }
}
