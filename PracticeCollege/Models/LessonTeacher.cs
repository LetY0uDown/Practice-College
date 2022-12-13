namespace PracticeCollege.Models
{
    public partial class LessonTeacher
    {
        public int? LessonId { get; set; }
        public int? TeacherId { get; set; }

        public virtual Lesson? Lesson { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
