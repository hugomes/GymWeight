using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymWeight.Models;
using SQLite;
using Xamarin.Forms;

namespace GymWeight.Repository
{
    public class ExerciseRepository
    {
        private SQLiteConnection _databaseConnection;

        public ExerciseRepository()
        {
            _databaseConnection = DependencyService.Get<IRepository.IRepository>().GetConnection();
            _databaseConnection.CreateTable<Exercise>();
        }

        public List<Exercise> GetAll()
        {
            return _databaseConnection.Table<Exercise>().ToList();
        }

        public int Save(Exercise exercise)
        {
            return _databaseConnection.Insert(exercise);
        }

        public int Update(Exercise exercise)
        {
            return _databaseConnection.Update(exercise);
        }

        public int Delete(Exercise exercise)
        {
            return _databaseConnection.Delete(exercise);
        }
    }
}
