using System;
using Eeop.Droid;

using Xamarin.Forms;
using System.IO;
using Eeop.Interfaces;

[assembly: Dependency (typeof(AndroidDbPath))]

namespace Eeop.Droid
{
    public class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine
                (Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), filename);
        }
    }
}