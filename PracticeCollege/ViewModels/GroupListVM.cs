using PracticeCollege.Models;
using PracticeCollege.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCollege.ViewModels
{
    public class GroupListVM : BaseVM
    {
        List<Group> groupSource;
        public List<Group> GroupSource
        {
            get { return groupSource; }
            set
            {
                groupSource = value;
                SignalChanged();
            }
        }

        public GroupListVM()
        {
            GroupSource = user12Context.GetInstance().Groups.ToList();
        }
    }
}
