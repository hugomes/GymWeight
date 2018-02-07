using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using GymWeight.UWP.Repository;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(UwpRepository))]
namespace GymWeight.UWP.Repository
{
    class UwpRepository : IRepository.IRepository
    {
        public SQLiteConnection GetConnection()
        {
            string dbName = "gymweight.db3";
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(dbPath);
        }
    }
}
