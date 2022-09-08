using System.ComponentModel;
using ticket_xamarin.ViewModels;
using Xamarin.Forms;

namespace ticket_xamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}