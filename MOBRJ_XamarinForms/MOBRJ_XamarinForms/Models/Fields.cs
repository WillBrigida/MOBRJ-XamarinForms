using System;
using System.Collections.Generic;
using System.Text;

namespace MOBRJ_XamarinForms.Models
{
    public partial class Fields
    {
        public string Sigla { get; set; }
        public List<Attachment> Attachments { get; set; }
        public string Estado { get; set; }
        public string Capital { get; set; }
        public string Regiao { get; set; }
        public string Icon { get; set; }
    }
}
