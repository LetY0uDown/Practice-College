using PracticeCollege.Models;
using PracticeCollege.Tools;
using PracticeCollege.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCollege.ViewModels
{
    public class DeleteLeavingVM : BaseVM
    {
        List<Leaving> studentSource;
        public List<Leaving> StudentSource
        {
            get => studentSource;
            set
            {
                studentSource = value;
                SignalChanged();
            }
        }

        public Leaving SelectedStudent { get; set; }

        public ViewCommand SaveButton { get; set; }

        public DeleteLeavingVM(Teacher selectedLastName, Group selectedGroupNum, DateTime dateStartPeriod, DateTime dateEndPeriod, Student selectedStudent)
        {
            StudentSource = user12Context.GetInstance().Leavings.ToList();
        }
    }
}
