using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GymWeight.Models
{
    public class ExerciseDay
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull, ForeignKey(typeof(Day))]
        public int DayId { get; set; }
        [NotNull, ForeignKey(typeof(Exercise))]
        public int ExerciseId { get; set; }
        [OneToMany]
        public List<SerieExerciseDay> SerieExerciseDayList { get; set; }
        [ManyToOne]
        public Exercise Exercise { get; set; }
        [ManyToOne]
        public Day Day { get; set; }
    }
}
