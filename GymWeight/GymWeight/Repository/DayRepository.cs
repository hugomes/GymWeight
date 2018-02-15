
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
    public class DayRepository
    {
        private SQLiteConnection _databaseConnection;

        public DayRepository()
        {
            _databaseConnection = DependencyService.Get<IRepository.IRepository>().GetConnection();
            _databaseConnection.CreateTable<Day>();
        }

        public List<Day> GetAll()
        {
            return _databaseConnection.GetAllWithChildren<Day>().ToList();
        }

        public int Save(Day day)
        {
            return _databaseConnection.Insert(day);
        }

        public int Update(Day day)
        {
            return _databaseConnection.Update(day);
        }

        public int Delete(Day day)
        {
            return _databaseConnection.Delete(day);
        }
    }
}
