using PracticeCollege.Models;
using PracticeCollege.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCollege.ViewModels
{
    public class AddGroupVM : BaseVM
    {
        public Group GroupNum { get; set; }

        List<Teacher> teachersSource { get; set; }
        public List<Teacher> TeachersSource
        {
            get => teachersSource;
            set
            {
                teachersSource = value;
                SignalChanged();
            }
        }

        Teacher selectedTeacher;
        public Teacher SelectedTeacher
        {
            get => selectedTeacher;
            set
            {
                selectedTeacher = value;
                SignalChanged();
            }
        }

        public AddGroupVM()
        {
            TeachersSource = user12Context.GetInstance().Teachers.ToList();
        }
    }
}
