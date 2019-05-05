using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MOBRJ_XamarinForms.Models
{
    public class Regiao : ObservableCollection<Fields>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public Regiao()
        {
        }

    }
}
