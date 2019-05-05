using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOBRJ_XamarinForms.Models
{
    public class Thumbnails : RealmObject
    {
        public Small Small { get; set; }
        public Large Large { get; set; }
        public Full Full { get; set; }
    }
}
