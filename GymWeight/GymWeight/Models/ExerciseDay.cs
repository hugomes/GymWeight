using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GymWeight.Models
{
    public class ExerciseDay
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public Day Day { get; set; }
        [NotNull, ForeignKey(typeof(Exercise))]
        public int ExerciseId { get; set; }
        [OneToMany]
        public List<SerieExerciseDay> SerieExerciseDayList { get; set; }
    }
}
