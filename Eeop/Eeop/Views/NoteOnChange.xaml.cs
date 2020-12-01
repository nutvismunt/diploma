using Eeop.Interfaces;
using Eeop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eeop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteOnChange : ContentPage
    {
        string dbPath;

        public NoteOnChange()
        {

            InitializeComponent();

            var editor = new Editor { AutoSize = EditorAutoSizeOption.TextChanges };
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.dbfilename);
            NavigationPage.SetTitleIconImageSource(this, "logo1");
            // NavigationPage.SetHasBackButton(this, false);
        }
        async void ComeBack(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
        private async void SaveNote(object sender, EventArgs e)
        {
            var note = (NoteElement)BindingContext;
            if (!String.IsNullOrEmpty(note.Headline))
            {
                using (ApplicationContext db = new ApplicationContext(dbPath))
                {

                    db.NoteElements.Update(note);
                    db.SaveChanges();
                }
            }
            await Navigation.PopAsync();
        }
    }
}