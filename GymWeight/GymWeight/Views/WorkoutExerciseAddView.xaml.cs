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
	public partial class WorkoutExerciseAddView : ContentPage
	{
		public WorkoutExerciseAddView ()
		{
			InitializeComponent ();
		    BindingContext = new WorkoutExerciseAddViewModel();
		}
	}
}