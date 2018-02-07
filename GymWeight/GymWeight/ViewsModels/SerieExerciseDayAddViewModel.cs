using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymWeight.Models;
using GymWeight.Repository;

namespace GymWeight.ViewsModels
{
    public class SerieExerciseDayAddViewModel
    {
        public List<Difficulty> DifficultyList { get; set; }
        public List<SerieExerciseDay> SerieExerciseDayList { get; set; }

        public SerieExerciseDayAddViewModel()
        {
            SerieExerciseDayList = new List<SerieExerciseDay>();
            SerieExerciseDayList.AddRange(new SerieExerciseDayRepository().GetAll());

            DifficultyList = new List<Difficulty>()
            {
                Difficulty.ICouldntFinish,
                Difficulty.IWasAbleToDoEverything,
                Difficulty.ICanDoMore
            };
        }
    }
}
