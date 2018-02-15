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
    public class ExerciseDayRepository
    {
        private SQLiteConnection _databaseConnection;

        public ExerciseDayRepository()
        {
            _databaseConnection = DependencyService.Get<IRepository.IRepository>().GetConnection();
            _databaseConnection.CreateTable<ExerciseDay>();
        }

        public List<ExerciseDay> GetAll()
        {
            return _databaseConnection.GetAllWithChildren<ExerciseDay>();
        }

        public int Save(ExerciseDay exerciseDay)
        {
            return _databaseConnection.Insert(exerciseDay);
        }

        public int Update(ExerciseDay exerciseDay)
        {
            return _databaseConnection.Update(exerciseDay);
        }

        public int Delete(ExerciseDay exerciseDay)
        {
            return _databaseConnection.Delete(exerciseDay);
        }
    }
}
