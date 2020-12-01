using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eeop.Interfaces;
using Eeop.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eeop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteOnCreate : ContentPage
    {

        string dbPath;




        public NoteOnCreate()
        {
            InitializeComponent();
            var editor = new Editor { AutoSize = EditorAutoSizeOption.TextChanges };
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.dbfilename);
            NavigationPage.SetTitleIconImageSource(this, "logo1");
            //NavigationPage.SetHasBackButton(this, false);
        }
        async void ComeBack(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
        private void SaveNote(object sender, EventArgs e)
        {

            var note = (NoteElement)BindingContext;
            if (!String.IsNullOrEmpty(note.Headline))
            {
                using (ApplicationContext db = new ApplicationContext(dbPath))
                {
                    db.NoteElements.Add(note);
                    db.SaveChanges();

                }
            }

            this.Navigation.PopAsync();
        }
    } 
}