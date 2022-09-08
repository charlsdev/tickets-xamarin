using System;
using System.Collections.Generic;
using System.ComponentModel;
using ticket_xamarin.Models;
using ticket_xamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ticket_xamarin.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Ticket Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}