using System;
using System.Collections.Generic;

namespace PracticeCollege.Models
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string? SurName { get; set; }
        public string? Name { get; set; }
        public string? PatronomicName { get; set; }
        public int? GroupId { get; set; }
        public int? DateId { get; set; }
        public bool? StatusCurator { get; set; }

        public virtual Group? Group { get; set; }
    }
}
