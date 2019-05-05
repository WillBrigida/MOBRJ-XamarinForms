using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOBRJ_XamarinForms.Models
{
    public class Full : RealmObject
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
