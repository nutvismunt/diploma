using System;
using System.Collections.Generic;
using System.Text;

namespace Eeop.Models
{
    public class ClientProfile
    {
        public int Id { get; set; }
        public string ClName { get; set; }
        public string Description { get; set; }
        public string PhoneNum { get; set; }
        public DateTime DateCome { get; set; }
        public string DateComeStr { get; set; }
        public TimeSpan TimeCome { get; set; }
        public string TimeComeStr { get; set; }
    }
}
