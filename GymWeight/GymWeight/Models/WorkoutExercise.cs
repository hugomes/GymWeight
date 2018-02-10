using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GymWeight.Models
{
    public class WorkoutExercise
    {
        [ForeignKey(typeof(Workout))]
        public int WorkoutId { get; set; }

        [ForeignKey(typeof(Exercise))]
        public int ExerciseId { get; set; }
    }
}
