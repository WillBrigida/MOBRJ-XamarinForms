using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOBRJ_XamarinForms.Models
{
    public class Record : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public Fields Fields { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
