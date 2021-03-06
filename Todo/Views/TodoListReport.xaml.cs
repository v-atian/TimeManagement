﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OxyPlot.Axes;
using OxyPlot.Reporting;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;

namespace Todo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoReport : ContentPage
    {
        public TodoReport()
        {
            InitializeComponent();
           
        }
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }
        async void OnTodoListDisplay(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        
    }


}
