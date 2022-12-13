using Microsoft.EntityFrameworkCore;
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
    public class StudentListVM : BaseVM
    {
        public List<Teacher> LastNameSource { get; set; }
        Teacher selectedLastName;
        public Teacher SelectedLastName
        {
            get => selectedLastName;
            set
            {
                selectedLastName = value;
                StudentList();
            }
        }

        public List<Group> GroupNumSource { get; set; }
        Group selectedGroupNum;
        public Group SelectedGroupNum
        {
            get => selectedGroupNum;
            set
            {
                selectedGroupNum = value;
                StudentList();
            }
        }

        DateTime dateStartPeriod = DateTime.Now;
        public DateTime DateStartPeriod
        {
            get => dateStartPeriod;
            set
            {
                dateStartPeriod = value;
                SignalChanged();
                StudentList();
            }
        }
        DateTime dateEndPeriod;
        public DateTime DateEndPeriod
        {
            get => dateEndPeriod;
            set
            {
                dateEndPeriod = value;
                SignalChanged();
                StudentList();
            }
        }

        List<Student> studentsSource;
        public List<Student> StudentsSource
        {
            get => studentsSource;
            set
            {
                studentsSource = value;
                SignalChanged();
            }
        }
        public Student SelectedStudent { get; set; }

        int leavingsCount;
        private DateTime standartTime;

        public int LeavingsCount
        {
            get => leavingsCount;
            set
            {
                leavingsCount = value;
                SignalChanged();
            }
        }

        public ViewCommand AddLeaving { get; set; }
        public ViewCommand DeleteLeaving { get; set; }

        void StudentList()
        {
            if ((SelectedLastName != null) && (SelectedGroupNum != null) && (DateStartPeriod != standartTime) && (DateEndPeriod != standartTime))
            {
                var studentsFromDB = user12Context.GetInstance().Students.Include(s => s.Leavings).ToList();
                List<Student> students = new List<Student>();

                var lessonTeachers = user12Context.GetInstance().LessonTeachers.Include(lt => lt.Lesson).Include(lt => lt.Teacher).ToList();

                foreach (Student student in studentsFromDB)
                {
                    var lessonTeacher = lessonTeachers.Where(lt => lt.Teacher == SelectedLastName);

                    var isStudentFitsRequest = student.GroupId == SelectedGroupNum.GroupId;

                    isStudentFitsRequest = student.Leavings.Any(l =>
                                                                lessonTeacher.Any(lt =>
                                                                                  lt.LessonId == l.LessonId));

                    if (isStudentFitsRequest)
                    {
                        student.Leavings = student.Leavings.Where(l => lessonTeacher.Any(lt =>
                                                                                         lt.LessonId == l.LessonId)).ToList();



                        students.Add(student);
                    }
                }

                StudentsSource = students;
            }
        }

        public StudentListVM(MainVM mainVM) 
        {
            DateStartPeriod = DateTime.Now;
            DateEndPeriod = DateTime.Now;

            LastNameSource = user12Context.GetInstance().Teachers.ToList();
            GroupNumSource = user12Context.GetInstance().Groups.ToList();

            AddLeaving = new ViewCommand(() =>
            {
                mainVM.CurrentPage = new AddLeaving(mainVM);
            });
            DeleteLeaving = new ViewCommand(() =>
            {
                mainVM.CurrentPage = new DeleteLeaving(SelectedLastName, SelectedGroupNum, DateStartPeriod, DateEndPeriod, SelectedStudent);
            });
        }
    }
}
