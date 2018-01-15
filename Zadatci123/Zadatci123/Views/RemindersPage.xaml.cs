using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zadatci123.Logic;

namespace Zadatci123.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RemindersPage : ContentPage
	{
		public RemindersPage ()
		{
			InitializeComponent ();
		}

        public void SetItemsSource()
        {
            tasksListView.ItemsSource = Constants.TasksList.Where(t => t.RemindMe == true && t.IsCompleted == false && t.DueDate >= DateTime.Now).OrderBy(t => t.DueDate);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetItemsSource();
        }

        private async void TasksListRefreshing(object sender, EventArgs e)
        {
            Constants.TasksList = await TaskLogic.GetTasks();
            SetItemsSource();
            tasksListView.IsRefreshing = false;
        }

        private async void RefreshTasks_Clicked(object sender, EventArgs e)
        {
            tasksListView.IsRefreshing = true;
            Constants.TasksList = await TaskLogic.GetTasks();
            SetItemsSource();
            tasksListView.IsRefreshing = false;
        }

        private void OnSelectedTask(object sender, EventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}