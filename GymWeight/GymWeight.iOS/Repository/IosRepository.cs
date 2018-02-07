using System.IO;
using GymWeight.iOS.Repository;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(IosRepository))]
namespace GymWeight.iOS.Repository
{
    public class IosRepository : IRepository.IRepository
    {
        public SQLiteConnection GetConnection()
        {
            string dbName = "gymweight.db3";
            string dbPersonalPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbLibraryPath = Path.Combine(dbPersonalPath, "..", "Library");
            string dbPath = Path.Combine(dbLibraryPath, dbName);
            return new SQLiteConnection(dbPath);
        }
    }
}
