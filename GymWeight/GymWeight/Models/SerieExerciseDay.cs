using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GymWeight.Models
{
    public class SerieExerciseDay
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull, ForeignKey(typeof(ExerciseDay))]
        public int ExerciseDayId { get; set; }
        [DefaultValue(0)]
        public int Order { get; set; }
        [NotNull]
        public int Repetitions { get; set; }
        [NotNull]
        public float Weight { get; set; }
        [NotNull]
        public Difficulty Difficulty { get; set; }
    }
}
