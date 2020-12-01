using System;
using System.Collections.Generic;
using System.Text;

namespace Eeop.Services
{
    public interface IAlarmSetter
    {
        void SetAlarm(DateTime time, string notifiText);
    }
}
