using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GymWeight.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public int Series{ get; set; }
        [NotNull]
        public int Repetitions { get; set; }
        [ManyToMany(typeof(WorkoutExercise))]
        public List<Workout> WorkoutList { get; set; }
    }
}
