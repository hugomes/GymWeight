using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymWeight.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace GymWeight.Repository
{
    public class WorkoutRepository
    {
        private SQLiteConnection _databaseConnection;

        public WorkoutRepository()
        {
            _databaseConnection = DependencyService.Get<IRepository.IRepository>().GetConnection();
            _databaseConnection.CreateTable<Workout>();
        }

        public List<Workout> GetAll()
        {
            return _databaseConnection.GetAllWithChildren<Workout>().ToList();
        }

        public int Save(Workout workout)
        {
            return _databaseConnection.Insert(workout);
        }

        public int Update(Workout workout)
        {
            return _databaseConnection.Update(workout);
        }

        public int Delete(Workout workout)
        {
            return _databaseConnection.Delete(workout);
        }
    }
}
