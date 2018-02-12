
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
    public class WorkoutExerciseRepository
    {
        private SQLiteConnection _databaseConnection;

        public WorkoutExerciseRepository()
        {
            _databaseConnection = DependencyService.Get<IRepository.IRepository>().GetConnection();
            _databaseConnection.CreateTable<WorkoutExercise>();
        }

        public List<WorkoutExercise> GetAll()
        {
            return _databaseConnection.GetAllWithChildren<WorkoutExercise>().ToList();
        }

        public int Save(WorkoutExercise workoutExercise)
        {
            return _databaseConnection.Insert(workoutExercise);
        }

        public int Update(WorkoutExercise workoutExercise)
        {
            return _databaseConnection.Update(workoutExercise);
        }

        public int Delete(WorkoutExercise workoutExercise)
        {
            return _databaseConnection.Delete(workoutExercise);
        }
    }
}
