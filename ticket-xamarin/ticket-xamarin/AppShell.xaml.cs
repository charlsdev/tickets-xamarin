using System;
using System.Collections.Generic;
using ticket_xamarin.ViewModels;
using ticket_xamarin.Views;
using Xamarin.Forms;

namespace ticket_xamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
