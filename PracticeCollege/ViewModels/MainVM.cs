using PracticeCollege.Models;
using PracticeCollege.Tools;
using PracticeCollege.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PracticeCollege.ViewModels
{
    public class MainVM : BaseVM
    {
        Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                SignalChanged();
            }
        }

        public ViewCommand ToStudentList { get; set; }
        public ViewCommand TeachersList { get; set; }
        public ViewCommand AddTeacher { get; set; }
        public ViewCommand GroupList { get; set; }
        public ViewCommand AddGroup { get; set; }

        public MainVM()
        {
            TeachersList = new ViewCommand(() => CurrentPage = new TeachersList());
            AddTeacher = new ViewCommand(() => CurrentPage = new AddTeacher());
            GroupList = new ViewCommand(() => CurrentPage = new GroupList());
            AddGroup = new ViewCommand(() => CurrentPage = new AddGroup());
            ToStudentList = new ViewCommand(() => CurrentPage = new StudentsList(this));

            CurrentPage = new StudentsList(this);
        }

        
    }
}
