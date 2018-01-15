using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zadatci123.Logic;
using Zadatci123.Models;

namespace Zadatci123.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompletedTasksPage : ContentPage
	{
		public CompletedTasksPage ()
		{
			InitializeComponent ();
		}

        public void SetItemsSource()
        {
            tasksListView.ItemsSource = Constants.TasksList.Where(t => t.IsCompleted == true).OrderByDescending(t => t.DueDate);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetItemsSource();
        }

        private async void TasksListRefreshing(object sender, EventArgs e)
        {
            Constants.TasksList = await TaskLogic.GetTasks();
            tasksListView.IsRefreshing = false;
            SetItemsSource();
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

        public async void OnDelete(object sender, EventArgs e)
        {
            MenuItem menuItem = ((MenuItem)sender);
            TaskItem taskItem = (TaskItem)menuItem.CommandParameter;
            await TaskLogic.DeleteTask(taskItem);
            SetItemsSource();
        }
    }
}