using PracticeCollege.Models;
using PracticeCollege.Tools;
using PracticeCollege.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeCollege.ViewModels;

public class AddLeavingVM : BaseVM
{
    public AddLeavingVM(MainVM mainVM)
    {
        Students = user12Context.GetInstance().Students.ToList();
        Lessons = user12Context.GetInstance().Lessons.ToList();

        BackButton = new ViewCommand(() =>
        {
            mainVM.CurrentPage = new StudentsList(mainVM);
        });

        SaveCommand = new(() =>
        {
            var leaving = new Leaving
            {
                Lesson = SelectedLesson,
                LessonId = SelectedLesson.Id,
                Student = SelectedStudent,
                StudentId = SelectedStudent.Id,
                LeavingDate = LeavingDate,
                LessonNum = LessonNumber
            };

            user12Context.GetInstance().Leavings.Add(leaving);
            user12Context.GetInstance().SaveChanges();

            BackButton.Execute(null);
        });
    }

    private Student _selectedStudent;
    private Lesson _selectedLesson;
    private DateTime _leavingDate = DateTime.Now;
    private int _lessonNumber;

    public DateTime LeavingDate
    { 
        get => _leavingDate;
        set
        {
            _leavingDate = value;
            SignalChanged();
        }
    }

    public ViewCommand SaveCommand { get; set; }

    public int LessonNumber
    {
        get => _lessonNumber;
        set
        {
            _lessonNumber = value;
            SignalChanged();
        }
    }

    public ViewCommand BackButton { get; set; }

    public List<Student> Students { get; set; }
    public Student SelectedStudent
    {
        get => _selectedStudent;
        set
        {
            _selectedStudent = value;
            SignalChanged();
        }
    }

    public List<Lesson> Lessons { get; set; }
    public Lesson SelectedLesson
    {
        get => _selectedLesson;
        set
        {
            _selectedLesson = value;
            SignalChanged();
        }
    }    
}