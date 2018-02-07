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
                case Difficulty.ICouldntFinish:
                    returnString = "I couldn't finish";
                    break;
                case Difficulty.IWasAbleToDoEverything:
                    returnString = "I was able to do everything";
                    break;
                case Difficulty.ICanDoMore:
                    returnString = "I was able to do everything";
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
