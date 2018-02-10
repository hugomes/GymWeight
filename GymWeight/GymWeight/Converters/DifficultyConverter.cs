using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymWeight.Models;
using Xamarin.Forms;

namespace GymWeight.Converters
{
    public class DifficultyConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Difficulty difficulty = (Difficulty) value;
            string returnString = "";
            switch (difficulty)
            {
                case Difficulty.Hard:
                    returnString = "Hard.png";
                    break;
                case Difficulty.Good:
                    returnString = "Good.png";
                    break;
                case Difficulty.Easy:
                    returnString = "Easy.png";
                    break;
            }

            return returnString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
