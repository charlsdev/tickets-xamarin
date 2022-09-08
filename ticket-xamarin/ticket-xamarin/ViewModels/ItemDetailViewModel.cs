using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ticket_xamarin.Models;
using Xamarin.Forms;

namespace ticket_xamarin.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        public string cedula;
        public string nameCompleto;
        public string origen;
        public string destino;
        public string precio;
        public string cantidad;
        public string iva;
        public string totPagar;

        public string Id { get; set; }

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

        public string Iva
        {
            get => iva;
            set => SetProperty(ref iva, value);
        }

        public string TotPagar
        {
            get => totPagar;
            set => SetProperty(ref totPagar, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            IsBusy = true;

            try
            {
                var item = await App.MyDatabase.OneVenta(Convert.ToInt32(itemId));

                if (item != null)
                {
                    Cedula = item.Cedula;
                    NameCompleto = item.NameCompleto;
                    Origen = item.Origen;
                    Destino = item.Destino;
                    Precio = item.Precio;
                    Cantidad = item.Cantidad;
                    Iva = item.Iva;
                    TotPagar = item.TotPagar;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Item");
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
