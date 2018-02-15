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
    public class WorkoutExercise
    {
        [PrimaryKey, AutoIncrement]
        public  int Id { get; set; }

        [ForeignKey(typeof(Workout))]
        public int WorkoutId { get; set; }

        [ForeignKey(typeof(Exercise))]
        public int ExerciseId { get; set; }
        [DefaultValue(0)]
        public int Order { get; set; }

        [ManyToOne]
        public Exercise Exercise { get; set; }
        [ManyToOne]
        public Workout Workout { get; set; }
    }
}
