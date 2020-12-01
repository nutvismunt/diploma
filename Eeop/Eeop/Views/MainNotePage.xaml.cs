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
    public partial class MainNotePage : ContentPage
    {
        public MainNotePage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetTitleIconImageSource(this, "logo1");

        }
        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.dbfilename);
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                notesList.ItemsSource = db.NoteElements.ToList();
            }


            base.OnAppearing();

        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NoteElement selectedNote = (NoteElement)e.SelectedItem;
            NotePage notePage = new NotePage();
            notePage.BindingContext = selectedNote;
            await Navigation.PushAsync(notePage);

        }

        private async void CreateNote(object sender, EventArgs e)
        {
            NoteElement note = new NoteElement();
            NoteOnCreate notePage = new NoteOnCreate();
            notePage.BindingContext = note;
            await Navigation.PushAsync(notePage);

        }
        private async void ToClients(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());
        }
    }
}