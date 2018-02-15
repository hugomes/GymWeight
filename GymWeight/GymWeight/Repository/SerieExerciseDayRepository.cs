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
    public class SerieExerciseDayRepository
    {
        private SQLiteConnection _databaseConnection;

        public SerieExerciseDayRepository()
        {
            _databaseConnection = DependencyService.Get<IRepository.IRepository>().GetConnection();
            _databaseConnection.CreateTable<SerieExerciseDay>();
        }

        public List<SerieExerciseDay> GetAll()
        {
            return _databaseConnection.GetAllWithChildren<SerieExerciseDay>().ToList();
        }

        public int Save(SerieExerciseDay serieExerciseDay)
        {
            return _databaseConnection.Insert(serieExerciseDay);
        }

        public int Update(SerieExerciseDay serieExerciseDay)
        {
            return _databaseConnection.Update(serieExerciseDay);
        }

        public int Delete(SerieExerciseDay serieExerciseDay)
        {
            return _databaseConnection.Delete(serieExerciseDay);
        }
    }
}
