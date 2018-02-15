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
    public class DayViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Day> DayList { get; set; }
        public List<Workout> WorkoutList { get; set; }
        public Workout WorkoutAdd { get; set; }
        public Day DayAdd { get; set; }
        public Day DayUpdate { get; set; }
        public Day DayDelete { get; set; }

        public Command SaveCommand { get; set; }
        public Command LoadCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public DayViewModel()
        {
            DayAdd = new Day();
            DayAdd.Date = DateTime.Now;
            DayList = new ObservableCollection<Day>(new DayRepository().GetAll().OrderByDescending(o=>o.Date));
            WorkoutList = new WorkoutRepository().GetAll().OrderByDescending(o => o.ExpirationDate).ToList();
            WorkoutAdd = WorkoutList.FirstOrDefault();

            SaveCommand = new Command(SaveDay);
            LoadCommand = new Command<Day>(LoadDay);
            DeleteCommand = new Command<Day>(DeleteDay);
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

        private void LoadDay(Day day)
        {
            DayAdd = day;
            OnPropertyChanged("DayAdd");

            WorkoutAdd = WorkoutList.FirstOrDefault(p=>p.Id == day.WorkoutId);
            OnPropertyChanged("WorkoutAdd");
        }

        private void DeleteDay(Day day)
        {
            new DayRepository().Delete(day);
            DayList.Remove(day);
        }

        private void SaveDay()
        {
            DayAdd.WorkoutId = WorkoutAdd.Id;
            if (DayAdd.Id == 0)
            {
                new DayRepository().Save(DayAdd);
                DayList.Add(DayAdd);
            }
            else
            {
                new DayRepository().Update(DayAdd);
                DayList = new ObservableCollection<Day>(new DayRepository().GetAll());
                OnPropertyChanged("DayList");
            }

            //DayAdd = new Day();
            //OnPropertyChanged("DayAdd");
        }
    }
}
