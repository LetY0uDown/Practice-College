using PracticeCollege.Tools;
using PracticeCollege.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCollege.ViewModels
{
    public class AddLeavingVM
    {
        public ViewCommand BackButton { get; set; }

        public AddLeavingVM(MainVM mainVM)
        {
            BackButton = new ViewCommand(() =>
            {
                mainVM.CurrentPage = new StudentsList(mainVM);
            });
        }
    }
}
