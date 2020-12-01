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
    public partial class NotePage : ContentPage
    {

        string dbPath;


        public NotePage()
        {
            InitializeComponent();

            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.dbfilename);
            var note = (NoteElement)BindingContext;
            NavigationPage.SetTitleIconImageSource(this, "logo1");
            // NavigationPage.SetHasBackButton(this, false);


        }
        async void ComeBack(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }

        private async void OnChange(object sender, EventArgs e)
        {
            NoteElement selectedNote = (NoteElement)BindingContext;
            NoteOnChange noteOnChange = new NoteOnChange();


            noteOnChange.BindingContext = selectedNote;
            await Navigation.PushAsync(noteOnChange);

        }

        async void DeleteNote(object sender, EventArgs e)
        {
            var note = (NoteElement)BindingContext;
            if (!String.IsNullOrEmpty(note.Note))
            {
 

                var answer = await DisplayAlert("Удаление записки", "Вы уверены что хотите удалить?", "Да", "Нет");

                if (answer)
                {
                    using (ApplicationContext db = new ApplicationContext(dbPath))
                    {

                        db.NoteElements.Remove(note);
                        db.SaveChanges();
                    }
                    await this.Navigation.PopAsync();
                }




            }


        }


    }
}
