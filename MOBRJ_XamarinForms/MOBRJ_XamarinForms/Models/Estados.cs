using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOBRJ_XamarinForms.Models
{
    public class Estados : RealmObject
    {
        public IList<Record> Records { get; }
    }
}
