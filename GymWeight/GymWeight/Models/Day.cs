using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GymWeight.Models
{
    public class Day
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull, ForeignKey(typeof(Workout))]
        public int WorkoutId { get; set; }
    }
}
