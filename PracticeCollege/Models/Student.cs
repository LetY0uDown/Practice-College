﻿using System.Collections.Generic;

namespace PracticeCollege.Models
{
    public partial class Student
    {
        public Student()
        {
            Leavings = new List<Leaving>();
        }

        public int Id { get; set; }
        public string? SurName { get; set; }
        public string? Name { get; set; }
        public string? PatronomicName { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual List<Leaving> Leavings { get; set; }
    }
}