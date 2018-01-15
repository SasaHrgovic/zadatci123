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
	public partial class AddEditTaskPage : ContentPage
	{
        private TaskItem _taskItem;
		public AddEditTaskPage ()
		{
			InitializeComponent ();
            taskDueDate.MinimumDate = DateTime.Now;
            taskDueTime.Time = DateTime.Now.TimeOfDay;
        }

        public AddEditTaskPage(TaskItem taskItem)
        {
            InitializeComponent();
            _taskItem = taskItem;
            taskDueDate.MinimumDate = DateTime.Now;
            SetEntries();
        }

        private void SetEntries()
        {
            taskName.Text = _taskItem.Name;
            taskPriority.SelectedIndex = _taskItem.Priority;
            taskDueDate.Date = _taskItem.DueDate.Date;
            taskDueTime.Time = _taskItem.DueDate.TimeOfDay;
            taskReminder.IsToggled = _taskItem.RemindMe;
        }

        private async void SaveTaskBtn_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(taskName.Text))
            {
                await DisplayAlert("Greška!", "Naziv zadatka je obavezan", "OK");
                return;
            }

            taskActivityIndicator.IsVisible = true;
            saveTaskBtn.IsEnabled = false;

            DateTime date = taskDueDate.Date;
            date.Add(taskDueTime.Time);

            string taskPriorityStr;
            if (taskPriority.SelectedIndex == -1)
            {
                taskPriority.SelectedIndex = 0;
                taskPriorityStr = "Niski";
            }
            else taskPriorityStr = taskPriority.SelectedItem.ToString();

            TaskItem taskItem = new TaskItem()
            {
                Name = taskName.Text,
                Priority = taskPriority.SelectedIndex,
                PriorityText = taskPriorityStr,
                DueDate = date,
                RemindMe = taskReminder.IsToggled
            };

            bool success = false;
            if (_taskItem != null) success = await TaskLogic.EditTask(taskItem, _taskItem);
            else success = await TaskLogic.AddTask(taskItem);

            if (success) await Navigation.PopAsync(false);
            else await DisplayAlert("Greška!", "Zadatak nije spremljen", "OK");

            taskActivityIndicator.IsVisible = false;
            saveTaskBtn.IsEnabled = true;

        }
    }
}