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
    public class WorkoutAddViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Workout> WorkoutList { get; set; }
        public Workout WorkoutAdd { get; set; }
        public Command SaveCommand { get; set; }
        public Command LoadCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Workout WorkoutEdit { get; set; }
        public Workout WorkoutDelete { get; set; }

        public WorkoutAddViewModel()
        {
            WorkoutAdd = new Workout();
            WorkoutAdd.ExpirationDate = DateTime.Now.AddMonths(3);
            SaveCommand = new Command(SaveWorkout);
            LoadCommand = new Command<Workout>(LoadWorkout);
            DeleteCommand = new Command<Workout>(DeleteWorkout);
            WorkoutList = new ObservableCollection<Workout>(new WorkoutRepository().GetAll());
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

        private void LoadWorkout(Workout workout)
        {
            WorkoutAdd = workout;
            OnPropertyChanged("WorkoutAdd");
        }

        private void DeleteWorkout(Workout workout)
        {
            new WorkoutRepository().Delete(workout);
            WorkoutList.Remove(workout);
        }

        private void SaveWorkout()
        {
            if (WorkoutAdd.Id == 0)
            {
                new WorkoutRepository().Save(WorkoutAdd);
                WorkoutList.Add(WorkoutAdd);
            }
            else
            {
                new WorkoutRepository().Update(WorkoutAdd);
                WorkoutList = new ObservableCollection<Workout>(new WorkoutRepository().GetAll());
                OnPropertyChanged("WorkoutList");
            }

            WorkoutAdd = new Workout(){ExpirationDate = DateTime.Now.AddMonths(3)};
            OnPropertyChanged("WorkoutAdd");
        }
    }
}
