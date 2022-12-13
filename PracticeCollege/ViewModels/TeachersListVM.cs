using PracticeCollege.Models;
using PracticeCollege.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCollege.ViewModels
{
    public class TeachersListVM : BaseVM
    {
        List<Teacher> teachersSource;
        public List<Teacher> TeachersSource
        {
            get => teachersSource;
            set
            {
                teachersSource = value;
                SignalChanged();
            }
        }

        public Teacher SelectedTeacher { get; set; }

        public TeachersListVM()
        {
            TeachersSource = user12Context.GetInstance().Teachers.ToList();
        }
    }
}
