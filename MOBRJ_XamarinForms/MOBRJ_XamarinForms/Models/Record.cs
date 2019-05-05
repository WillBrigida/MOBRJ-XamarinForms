using System;
using System.Collections.Generic;
using System.Text;

namespace MOBRJ_XamarinForms.Models
{
    public class Record
    {
        public string Id { get; set; }
        public Fields Fields { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
