using Eeop.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AlarmSetterClass))]

namespace Eeop.Services
{
    class AlarmSetterClass : IAlarmSetter
    {
        public void SetAlarm(DateTime time, string notifiText)
        {
           /* Notification noti = new Notification();
            noti.Title = "Alarm";
            noti.Content = notifiText;
            noti.IsDisplay = true;
            noti.AddStyle(new Notification.ActiveStyle());
            AlarmManager.CreateAlarm(time, noti);*/
        }
    }
}
