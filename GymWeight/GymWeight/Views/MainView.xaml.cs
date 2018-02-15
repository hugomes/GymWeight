using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymWeight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : MasterDetailPage
	{
		public MainView ()
		{
			InitializeComponent ();
		}

	    private void BtnWorkoutAddView_OnClicked(object sender, EventArgs e)
	    {
	        Detail = new WorkoutAddView();
	        IsPresented = false;
	    }

	    private void BtnExerciseAddView_OnClicked(object sender, EventArgs e)
	    {
	        Detail = new ExerciseAddView();
	        IsPresented = false;
	    }

	    private void BtnDayView_OnClicked(object sender, EventArgs e)
	    {
	        Detail = new DayView();
	        IsPresented = false;
	    }

	    private void BtnWorkoutExerciseAddView_OnClicked(object sender, EventArgs e)
	    {
	        Detail = new WorkoutExerciseAddView();
	        IsPresented = false;
	    }
	}
}