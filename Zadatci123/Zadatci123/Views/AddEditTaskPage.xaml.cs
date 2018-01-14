using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zadatci123.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddEditTaskPage : ContentPage
	{
		public AddEditTaskPage ()
		{
			InitializeComponent ();
		}

        private void SaveTaskBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
        }
    }
}