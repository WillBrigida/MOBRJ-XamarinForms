using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOBRJ_XamarinForms.Models
{
    public partial class Fields : RealmObject
    {
        public string Sigla { get; set; }
        public IList<Attachment> Attachments { get; }
        public string Estado { get; set; }
        public string Capital { get; set; }
        public string Regiao { get; set; }
        public string Icon { get; set; }
    }
}
