using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket_xamarin.Models;
using ticket_xamarin.ViewModels;
using ticket_xamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ticket_xamarin.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private async void DeleteVenta_Clicked(object sender, EventArgs e)
        {
            Button param = (Button)sender;
            string id = param.CommandParameter.ToString();

            Ticket ticket = new Ticket()
            {
                Id = Convert.ToInt32(id),
            };

            var opt = await DisplayAlert("Información", "Deseas eliminar la venta con id: " + id, "Sí", "No");

            if (opt)
            {
                await App.MyDatabase.DeleteVenta(ticket);
                OnAppearing();
            }
            else
            {
                return;
            }
        }
    }
}