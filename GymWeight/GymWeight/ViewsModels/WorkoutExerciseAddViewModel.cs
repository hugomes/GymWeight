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
    public class WorkoutExerciseAddViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<WorkoutExercise> WorkoutExerciseList { get; set; }
        public List<Workout> WorkoutList { get; set; }
        public List<Exercise> ExerciseList { get; set; }
        public Workout WorkoutAdd { get; set; }
        public Exercise ExerciseAdd { get; set; }
        public WorkoutExercise WorkoutExerciseAdd { get; set; }
        public WorkoutExercise WorkoutExerciseEdit { get; set; }
        public WorkoutExercise WorkoutExerciseDelete { get; set; }

        public Command SaveCommand { get; set; }
        public Command LoadCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public WorkoutExerciseAddViewModel()
        {
            WorkoutExerciseAdd = new WorkoutExercise();
            WorkoutExerciseList = new ObservableCollection<WorkoutExercise>(new WorkoutExerciseRepository().GetAll());
            WorkoutList = new WorkoutRepository().GetAll().OrderByDescending(o => o.ExpirationDate).ToList();
            ExerciseList = new ExerciseRepository().GetAll().OrderBy(o => o.Name).ToList();
            WorkoutAdd = WorkoutList.FirstOrDefault();
            ExerciseAdd = ExerciseList.FirstOrDefault();

            SaveCommand = new Command(SaveWorkoutExercise);
            LoadCommand = new Command<WorkoutExercise>(LoadWorkoutExercise);
            DeleteCommand = new Command<WorkoutExercise>(DeleteWorkoutExercise);
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

        private void LoadWorkoutExercise(WorkoutExercise workoutExercise)
        {
            WorkoutExerciseAdd = workoutExercise;
            OnPropertyChanged("WorkoutExerciseAdd");

            WorkoutAdd = WorkoutList.FirstOrDefault(p=>p.Id == workoutExercise.WorkoutId);
            OnPropertyChanged("WorkoutAdd");
            ExerciseAdd = ExerciseList.FirstOrDefault(p=>p.Id == workoutExercise.ExerciseId);
            OnPropertyChanged("ExerciseAdd");
        }

        private void DeleteWorkoutExercise(WorkoutExercise workoutExercise)
        {
            new WorkoutExerciseRepository().Delete(workoutExercise);
            WorkoutExerciseList.Remove(workoutExercise);
        }

        private void SaveWorkoutExercise()
        {
            WorkoutExerciseAdd.ExerciseId = ExerciseAdd.Id;
            WorkoutExerciseAdd.WorkoutId = WorkoutAdd.Id;
            if (WorkoutExerciseAdd.Id == 0)
            {
                new WorkoutExerciseRepository().Save(WorkoutExerciseAdd);
                WorkoutExerciseList.Add(WorkoutExerciseAdd);
            }
            else
            {
                new WorkoutExerciseRepository().Update(WorkoutExerciseAdd);
                WorkoutExerciseList = new ObservableCollection<WorkoutExercise>(new WorkoutExerciseRepository().GetAll());
                OnPropertyChanged("WorkoutExerciseList");
            }

            WorkoutExerciseAdd = new WorkoutExercise();
            OnPropertyChanged("WorkoutExerciseAdd");
        }
    }
}
