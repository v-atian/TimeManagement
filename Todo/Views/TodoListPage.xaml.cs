﻿using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtTodoId = -1;
			listView.ItemsSource = await App.Database.GetItemsAsync();
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = new TodoItem()
			});
		}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
			Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);

			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as TodoItem
			});
		}
       void StartTimeCount(object sender, EventArgs e)
        {
            //Get the start button
            Button startbtn = (Button)sender;
            startbtn.Text = "Pause";

            //Get the parent node
            var stLayout = startbtn.Parent;
            //Find the time button
            Button timebtn = stLayout.FindByName<Button>("TimeButton");

            //Start Time Count Down
            int IniTimeCount= Convert.ToInt32(timebtn.Text);
            
            Device.StartTimer(TimeSpan.FromSeconds(1), ()=> {

                IniTimeCount--;
                if (IniTimeCount < 0)
                {
                    startbtn.Text = "Start";
                    return false;
                }
                timebtn.Text = IniTimeCount.ToString();
                return true;
            });
        }
    }

}
