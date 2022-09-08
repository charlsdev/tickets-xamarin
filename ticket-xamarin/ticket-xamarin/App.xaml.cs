using System;
using System.IO;
using ticket_xamarin.Controllers;
using ticket_xamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ticket_xamarin
{
    public partial class App : Application
    {
        private static SQLiteCtrl ctrlTicket;

        public static SQLiteCtrl MyDatabase
        {
            get
            {
                if (ctrlTicket == null)
                {
                    ctrlTicket = new SQLiteCtrl(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TicketDB.mb3"));
                }

                return ctrlTicket;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
