using Eeop.Interfaces;
using Eeop.Models;
using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eeop.Views
{
    

    public partial class MainPage :ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetTitleIconImageSource (this, "logo1");

            
            //var editor = new Editor { AutoSize = EditorAutoSizeOption.TextChanges };
            
    

        }

        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.dbfilename);
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                clientsList.ItemsSource = db.ClientProfiles.ToList();
            }


            base.OnAppearing();
           
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ClientProfile selectedClient = (ClientProfile)e.SelectedItem;
            ClientPage clientPage = new ClientPage();
            clientPage.BindingContext = selectedClient;
            await Navigation.PushAsync(clientPage);

        }

        private async void CreateClient(object sender, EventArgs e)
        {
            ClientProfile client = new ClientProfile();
            ClientOnCreate clientPage = new ClientOnCreate();
            clientPage.BindingContext = client;
            await Navigation.PushAsync(clientPage);

        }

        private async void ToNotes(object sender, EventArgs e)
        {
         

                await Navigation.PushAsync(new MainNotePage());
        
        }
        private async void Codologia(object sender, EventArgs e)
        {


            await Navigation.PushAsync(new CodologiaPage());

        }


    }
}