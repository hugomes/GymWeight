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
    public class ExerciseAddViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Exercise> ExerciseList { get; set; }
        public Exercise ExerciseAdd { get; set; }
        public Command SaveCommand { get; set; }
        public Command LoadCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Exercise ExerciseEdit { get; set; }
        public Exercise ExerciseDelete { get; set; }

        public ExerciseAddViewModel()
        {
            ExerciseAdd = new Exercise();
            SaveCommand = new Command(SaveExercise);
            LoadCommand = new Command<Exercise>(LoadExercise);
            DeleteCommand = new Command<Exercise>(DeleteExercise);
            ExerciseList = new ObservableCollection<Exercise>(new ExerciseRepository().GetAll());
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

        private void LoadExercise(Exercise exercise)
        {
            ExerciseAdd = exercise;
            OnPropertyChanged("ExerciseAdd");
        }

        private void DeleteExercise(Exercise exercise)
        {
            new ExerciseRepository().Delete(exercise);
            ExerciseList.Remove(exercise);
        }

        private void SaveExercise()
        {
            if (ExerciseAdd.Id == 0)
            {
                new ExerciseRepository().Save(ExerciseAdd);
                ExerciseList.Add(ExerciseAdd);
            }
            else
            {
                new ExerciseRepository().Update(ExerciseAdd);
                ExerciseList = new ObservableCollection<Exercise>(new ExerciseRepository().GetAll());
                OnPropertyChanged("ExerciseList");
            }

            ExerciseAdd = new Exercise();
            OnPropertyChanged("ExerciseAdd");
        }
    }
}
