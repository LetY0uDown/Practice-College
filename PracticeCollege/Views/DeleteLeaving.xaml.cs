using PracticeCollege.Models;
using PracticeCollege.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticeCollege.Views
{
    /// <summary>
    /// Логика взаимодействия для DeleteLeaving.xaml
    /// </summary>
    public partial class DeleteLeaving : Page
    {
        public DeleteLeaving(Teacher selectedLastName, Group selectedGroupNum, DateTime dateStartPeriod, DateTime dateEndPeriod, Student selectedStudent)
        {
            InitializeComponent();
            DataContext = new DeleteLeavingVM(selectedLastName, selectedGroupNum, dateStartPeriod, dateEndPeriod, selectedStudent);
        }
    }
}
