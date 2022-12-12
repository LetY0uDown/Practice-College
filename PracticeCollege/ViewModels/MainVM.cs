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

        public MainVM()
        {
            CurrentPage = new StudentsList(this);
        }

        
    }
}
