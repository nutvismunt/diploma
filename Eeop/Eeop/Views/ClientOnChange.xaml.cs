using Eeop.Interfaces;
using Eeop.Models;
using Eeop.Services;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eeop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ClientOnChange : ContentPage
    {
        string dbPath;

        public ClientOnChange()
        {
            
            InitializeComponent();
          
            var editor = new Editor {AutoSize=EditorAutoSizeOption.TextChanges };
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.dbfilename);
         
          
           // NavigationPage.SetHasBackButton(this, false);







            //  var client = (ClientProfile)BindingContext;
            //_DpickerCh.Date = client.DateCome;
            //_TpickerCh.Time = client.TimeCome;



        }
        async void ComeBack(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
        private async void SaveClientPr(object sender, EventArgs e)
        {
            

            var client = (ClientProfile)BindingContext;
            if (!String.IsNullOrEmpty(client.ClName))
            {
               


                using (ApplicationContext db = new ApplicationContext(dbPath))
                {
                   // _time =Convert.ToDateTime(_TpickerCh);
                    client.DateComeStr = _DpickerCh.Date.ToString("dd.MM.yyyy");
                   client.TimeComeStr = _TpickerCh.Time.ToString("hh\\:mm");
                   

                    db.ClientProfiles.Update(client);
                  
                    db.SaveChanges();
                    

                }

            }

                    await Navigation.PopAsync();

        }

 

        // private void DeleteClientPr(object sender, EventArgs e)
        //{
        //   var client = (ClientProfile)BindingContext;

        //  using (ApplicationContext db = new ApplicationContext(dbPath))
        //{
        //  db.ClientProfiles.Remove(client);
        //db.SaveChanges();
        //}
        //this.Navigation.PopAsync();
        //}
        //<Entry MaxLength = "100" Keyboard="Text" VerticalOptions="StartAndExpand" Text="{Binding Description}"/>
    }
}