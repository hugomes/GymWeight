using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GymWeight.Models;
using GymWeight.Repository;
using Xamarin.Forms;

namespace GymWeight.ViewsModels
{
    public class ExerciseDayViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ExerciseDay> ExerciseDayList { get; set; }
        public List<Exercise> ExerciseList { get; set; }
        public Exercise ExerciseAdd { get; set; }
        public Day DayAdd { get; set; }
        public ExerciseDay ExerciseDayAdd { get; set; }
        public ExerciseDay ExerciseDayUpdate { get; set; }
        public ExerciseDay ExerciseDayDelete { get; set; }

        public Command SaveCommand { get; set; }
        public Command LoadCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public ExerciseDayViewModel(Day day)
        {
            DayAdd = day;
            ExerciseDayAdd = new ExerciseDay();
            ExerciseDayList = new ObservableCollection<ExerciseDay>(new ExerciseDayRepository().GetAll().Where(p=>p.DayId == day.Id));
            ExerciseList = new WorkoutRepository().GetAll().FirstOrDefault(p=>p.Id == day.WorkoutId).ExerciseList;
            ExerciseAdd = ExerciseList.FirstOrDefault();

            SaveCommand = new Command(SaveExerciseDay);
            LoadCommand = new Command<ExerciseDay>(LoadExerciseDay);
            DeleteCommand = new Command<ExerciseDay>(DeleteExerciseDay);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void LoadExerciseDay(ExerciseDay day)
        {
            ExerciseDayAdd = day;
            OnPropertyChanged("ExerciseDayAdd");

            ExerciseAdd = ExerciseList.FirstOrDefault(p=>p.Id == day.ExerciseId);
            OnPropertyChanged("ExerciseAdd");
        }

        private void DeleteExerciseDay(ExerciseDay day)
        {
            new ExerciseDayRepository().Delete(day);
            ExerciseDayList.Remove(day);
        }

        private void SaveExerciseDay()
        {
            ExerciseDayAdd.ExerciseId = ExerciseAdd.Id;
            ExerciseDayAdd.Exercise = ExerciseAdd;
            ExerciseDayAdd.DayId = DayAdd.Id;
            ExerciseDayAdd.Day = DayAdd;
            if (ExerciseDayAdd.Id == 0)
            {
                new ExerciseDayRepository().Save(ExerciseDayAdd);
                ExerciseDayList.Add(ExerciseDayAdd);
            }
            else
            {
                new ExerciseDayRepository().Update(ExerciseDayAdd);
                ExerciseDayList = new ObservableCollection<ExerciseDay>(new ExerciseDayRepository().GetAll());
                OnPropertyChanged("ExerciseDayList");
            }

            ExerciseDayAdd = new ExerciseDay();
            OnPropertyChanged("ExerciseDayAdd");
        }
    }
}
