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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
        }

    }
}