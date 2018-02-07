using SQLite;
using System.IO;
using GymWeight.Droid.Repository;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidRepository))]
namespace GymWeight.Droid.Repository
{
    public class AndroidRepository : IRepository.IRepository
    {
        public SQLiteConnection GetConnection()
        {
            string dbName = "gymweight.db3";
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(dbPath);
        }
    }
}
