using Eeop.Interfaces;
using Eeop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eeop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientOnCreate : ContentPage
    {

        string dbPath;



        
        public ClientOnCreate()
        {
            InitializeComponent();
            var editor = new Editor { AutoSize = EditorAutoSizeOption.TextChanges };
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.dbfilename);
            NavigationPage.SetTitleIconImageSource(this, "logo1");
            // NavigationPage.SetHasBackButton(this, false);


            //SaveCl.Clicked += OnButtonClicked;
            //alarmTimePicker.Time = DateTime.Now.TimeOfDay;
        }
        async void ComeBack(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
        private void SaveClientPr(object sender, EventArgs e)
        {

            var client = (ClientProfile)BindingContext;
            if (!String.IsNullOrEmpty(client.ClName))
            {
                using (ApplicationContext db = new ApplicationContext(dbPath))
                {
                   // if (client.Id == 0)
                   // {
                       
                        
                      client.DateComeStr = _Dpicker.Date.ToString("dd.MM.yyyy");
                      client.TimeComeStr = _Tpicker.Time.ToString("hh\\:mm");
                    client.DateCome = _Dpicker.Date;
                    client.TimeCome = _Tpicker.Time;

                        db.ClientProfiles.Add(client);
                          db.SaveChanges();

                   // }
                    //else
                   // {
                       // client.DateComeStr = _Dpicker.Date.ToString("dd.MM.yyyy");
                       // client.TimeComeStr = _Tpicker.Time.ToString("hh\\:mm") ;
                       // db.ClientProfiles.Update(client);
                        
                  //  }
                  
                }
            }




            this.Navigation.PopAsync();
        }

       // private void DeleteClientPr(object sender, EventArgs e)
      //  {
         //   var client = (ClientProfile)BindingContext;
          //  using (ApplicationContext db = new ApplicationContext(dbPath))
          //  {
            //    db.ClientProfiles.Remove(client);
            //    db.SaveChanges();
          //  }
          //  this.Navigation.PopAsync();
      //  }
    }
    }