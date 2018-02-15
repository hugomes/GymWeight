using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GymWeight.Models;
using GymWeight.Repository;
using Xamarin.Forms;

namespace GymWeight.ViewsModels
{
    public class SerieExerciseDayAddViewModel : INotifyPropertyChanged
    {
        public ExerciseDay ExerciseDay { get; set; }
        public ObservableCollection<SerieExerciseDay> SerieExerciseDayList { get; set; }
        public Difficulty DifficultyHard { get; set; }
        public Difficulty DifficultyGood { get; set; }
        public Difficulty DifficultyEasy { get; set; }

        public SerieExerciseDay SerieExerciseDayAdd { get; set; }
        public SerieExerciseDay SerieExerciseDayEdit { get; set; }
        public SerieExerciseDay SerieExerciseDayDelete { get; set; }

        public Command SaveDifficultyEasyCommand { get; set; }
        public Command SaveDifficultyGoodCommand { get; set; }
        public Command SaveDifficultyHardCommand { get; set; }

        public Command LoadCommand { get; set; }
        public Command DeleteCommand { get; set; }

        private int Order;

        public SerieExerciseDayAddViewModel(ExerciseDay exerciseDay)
        {
            ExerciseDay = exerciseDay;
            //SerieExerciseDayList = new ObservableCollection<SerieExerciseDay>(new SerieExerciseDayRepository().GetAll());
            SerieExerciseDayList = new ObservableCollection<SerieExerciseDay>(new SerieExerciseDayRepository().GetAll().Where(c => c.ExerciseDayId == ExerciseDay.Id));

            DifficultyHard = Difficulty.Hard;
            DifficultyGood = Difficulty.Good;
            DifficultyEasy = Difficulty.Easy;

            SerieExerciseDayAdd = new SerieExerciseDay();
            SaveDifficultyEasyCommand = new Command(SaveSerieExerciseDayDifficultyEasy);
            SaveDifficultyGoodCommand = new Command(SaveSerieExerciseDayDifficultyGood);
            SaveDifficultyHardCommand = new Command(SaveSerieExerciseDayDifficultyHard);
            LoadCommand = new Command<SerieExerciseDay>(LoadSerieExerciseDay);
            DeleteCommand = new Command<SerieExerciseDay>(DeleteSerieExerciseDay);

            Order = 0;
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

        private void LoadSerieExerciseDay(SerieExerciseDay serieExerciseDay)
        {
            SerieExerciseDayAdd = serieExerciseDay;
            OnPropertyChanged("SerieExerciseDayAdd");
        }

        private void DeleteSerieExerciseDay(SerieExerciseDay serieExerciseDay)
        {
            new SerieExerciseDayRepository().Delete(serieExerciseDay);
            SerieExerciseDayList.Remove(serieExerciseDay);
        }

        private void SaveSerieExerciseDayDifficultyEasy()
        {
            SerieExerciseDayAdd.Difficulty = DifficultyEasy;
            SaveSerieExerciseDay();
        }

        private void SaveSerieExerciseDayDifficultyGood()
        {
            SerieExerciseDayAdd.Difficulty = DifficultyGood;
            SaveSerieExerciseDay();
        }

        private void SaveSerieExerciseDayDifficultyHard()
        {
            SerieExerciseDayAdd.Difficulty = DifficultyHard;
            SaveSerieExerciseDay();
        }

        private void SaveSerieExerciseDay()
        {
            if (SerieExerciseDayAdd.Id == 0)
            {
                SerieExerciseDayAdd.ExerciseDayId = ExerciseDay.Id;
                SerieExerciseDayAdd.Order = ++Order;
                new SerieExerciseDayRepository().Save(SerieExerciseDayAdd);
                SerieExerciseDayList.Add(SerieExerciseDayAdd);
            }
            else
            {
                new SerieExerciseDayRepository().Update(SerieExerciseDayAdd);
                SerieExerciseDayList = new ObservableCollection<SerieExerciseDay>(new SerieExerciseDayRepository().GetAll());
                OnPropertyChanged("SerieExerciseDayList");
            }

            SerieExerciseDayAdd = new SerieExerciseDay();
            OnPropertyChanged("SerieExerciseDayAdd");
        }

    }
}
