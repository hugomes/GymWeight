using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymWeight.Models;
using GymWeight.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymWeight.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExerciseDayView : ContentPage
	{
		public ExerciseDayView (Day day)
		{
			InitializeComponent ();
		    BindingContext = new ExerciseDayViewModel(day);
		}

	    private async void BtnSave_OnClicked(object sender, EventArgs e)
	    {
	        Button button = (Button)sender;
	        await Navigation.PushAsync(new SerieExerciseDayAddView((ExerciseDay)button.CommandParameter));
	    }

	    private async void MenuItem_OnClicked(object sender, EventArgs e)
	    {
	        MenuItem menuItem = (MenuItem)sender;
	        await Navigation.PushAsync(new SerieExerciseDayAddView((ExerciseDay)menuItem.CommandParameter));
	    }
    }
}