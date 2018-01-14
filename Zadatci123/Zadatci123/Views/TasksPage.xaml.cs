﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zadatci123.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TasksPage : ContentPage
	{
		public TasksPage ()
		{
			InitializeComponent ();
		}

        private void AddTask_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddEditTaskPage());
        }
    }
}