using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Eeop.Services;
using Eeop.Views;
using Eeop.Interfaces;
using Eeop.Models;


namespace Eeop
{
    public partial class App : Application
    {
        public const string dbfilename = "eeopapp.db";
        public App()
        {
            InitializeComponent();

            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(dbfilename);
            using (var db = new ApplicationContext(dbPath))
            {
               db.Database.EnsureCreated();
            }
            MainPage = new NavigationPage(new MainPage());
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
