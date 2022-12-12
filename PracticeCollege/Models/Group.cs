using System;
using System.Collections.Generic;

namespace PracticeCollege.Models
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int GroupId { get; set; }
        public string? GroupNumber { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
