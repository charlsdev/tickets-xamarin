using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using ticket_xamarin.Controllers;
using ticket_xamarin.Models;
using Xamarin.Forms;

namespace ticket_xamarin.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public string cedula;
        public string nameCompleto;
        public string origen;
        public string destino;
        public string precio;
        public string cantidad;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(cedula)
                && !string.IsNullOrWhiteSpace(nameCompleto)
                && !string.IsNullOrWhiteSpace(origen)
                && !string.IsNullOrWhiteSpace(destino)
                && !string.IsNullOrWhiteSpace(precio)
                && !string.IsNullOrWhiteSpace(cantidad);
        }

        public string Cedula
        {
            get => cedula;
            set => SetProperty(ref cedula, value);
        }

        public string NameCompleto
        {
            get => nameCompleto;
            set => SetProperty(ref nameCompleto, value);
        }

        public string Origen
        {
            get => origen;
            set => SetProperty(ref origen, value);
        }

        public string Destino
        {
            get => destino;
            set => SetProperty(ref destino, value);
        }

        public string Precio
        {
            get => precio;
            set => SetProperty(ref precio, value);
        }

        public string Cantidad
        {
            get => cantidad;
            set => SetProperty(ref cantidad, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var tot = Convert.ToDouble(Precio) * Convert.ToDouble(Cantidad);
            var iva = tot * 0.12;

            Ticket newTicket = new Ticket()
            {
                Cedula = Cedula,
                NameCompleto = NameCompleto,
                Origen = Origen,
                Destino = Destino,
                Precio = Precio,
                Cantidad = Cantidad,
                Iva = Convert.ToString(iva),
                TotPagar = Convert.ToString(tot)
            };

            await App.MyDatabase.CreateVenta(newTicket);

            await Shell.Current.GoToAsync("..");
        }
    }
}
