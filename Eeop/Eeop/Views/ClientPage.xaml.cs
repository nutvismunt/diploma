using Eeop.Interfaces;
using Eeop.Models;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Eeop.Models;
using System.Windows.Input;
using System.ComponentModel;
using Plugin.Messaging;

namespace Eeop.Views
{
  
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        string dbPath;


        public ClientPage()
        {
            InitializeComponent();
        
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.dbfilename);
            var client = (ClientProfile)BindingContext;




            //  NavigationPage.SetHasBackButton(this, false);


        }
 
        private async void Calling (object sender,EventArgs e)
        {
            var client = (ClientProfile)BindingContext;
            var PhoneCallTask = CrossMessaging.Current.PhoneDialer;
            if (PhoneCallTask.CanMakePhoneCall)
                PhoneCallTask.MakePhoneCall(client.PhoneNum);
        }
        private async void OnChange (object sender, EventArgs e)
        {
            ClientProfile selectedClient = (ClientProfile)BindingContext;
            ClientOnChange clientOnChange = new ClientOnChange();

            
            clientOnChange.BindingContext = selectedClient;
            await Navigation.PushAsync(clientOnChange);
            //this.OnPropertyChanged("ClientPage");
        }
        async void ComeBack (object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }

        async void DeleteClient(object sender, EventArgs e)
        {
            var client = (ClientProfile)BindingContext;
            if (!String.IsNullOrEmpty(client.ClName))
            {
                //  DisplayAlert("Удаление клиента", "Вы уверены что хотите удалить?", "Да", "Нет");
                
                var answer= await DisplayAlert("Удаление клиента", "Вы уверены что хотите удалить?", "Да", "Нет");
                
                if (answer)
                {
                    using (ApplicationContext db = new ApplicationContext(dbPath))
                    { 

                    db.ClientProfiles.Remove(client);
                    db.SaveChanges();
                    }
                    await this.Navigation.PopAsync();
                }


            }

        }
            
        }

    }
