using MOBRJ_XamarinForms.Models;
using MOBRJ_XamarinForms.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBRJ_XamarinForms.ViewModels
{
    class ListaAgrupadaViewModel : BaseViewModel
    {
        #region Propriedades
        public ObservableCollection<Regiao> ListaAgrupada { get; set; }
        ApiService _apiService;
        public enum EnumRegiao { CentroOeste, Nordeste, Norte, Sudeste, Sul };

        #endregion

        #region Construtor
        public ListaAgrupadaViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            this.Title = "Lista Agrupada";
            ListaAgrupada = new ObservableCollection<Regiao>();
            _apiService = new ApiService();
            InitApi();
        }
        #endregion

        #region Commands
        private DelegateCommand _listaDadosLocalCommand;
        public DelegateCommand ListaDadosLocalCommand => _listaDadosLocalCommand ?? (_listaDadosLocalCommand = new DelegateCommand(async () => await OnListaDadosLocal(), () => !IsBusy));

        #endregion

        #region Métodos
        private async Task OnListaDadosLocal()
        {
            await NavigationService.NavigateAsync("ListaDadosLocalPage");
        }

        private async Task InitApi()
        {
            var estados = await _apiService.Get<Estados>("https://api.airtable.com",
                "/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
            //foreach (var item in estados.Records)
            //{
            //    foreach (var attachment in item.Fields.Attachments)
            //    {

            //        ListaAgrupada.Add(new Fields
            //        {
            //            Capital = item.Fields.Capital,
            //            Attachments = item.Fields.Attachments,
            //            Estado = item.Fields.Estado,
            //            Regiao = item.Fields.Regiao,
            //            Sigla = item.Fields.Sigla,
            //            Icon = attachment.Thumbnails.Large.Url
            //        });

            //    }

            //}

            var nordeste = new Regiao() { LongName = "Nordeste", ShortName = "N" };

            foreach (var estado in estados.Records.Where(l => l.Fields.Regiao.Contains("Nordeste")).ToList())
            {
                nordeste.Add(estado.Fields);
            }
            ListaAgrupada.Add(nordeste);


            var sudeste = new Regiao() { LongName = "Sudeste", ShortName = "S"};

            foreach (var estado in estados.Records.Where(l => l.Fields.Regiao.Contains("Sudeste")).ToList())
            {
                sudeste.Add(estado.Fields);
            }
            ListaAgrupada.Add(sudeste);


            var sul = new Regiao() { LongName = "Sul", ShortName = "S" };

            foreach (var estado in estados.Records.Where(l => l.Fields.Regiao.Contains(EnumRegiao.Sul.ToString())).ToList())
            {
                sul.Add(estado.Fields);
            }
            ListaAgrupada.Add(sul);



            var centroOeste = new Regiao() { LongName = "Centro-Oeste", ShortName = "C" };

            foreach (var estado in estados.Records.Where(l => l.Fields.Regiao.Contains("Centro-Oeste")).ToList())
            {
                centroOeste.Add(estado.Fields);
            }
            ListaAgrupada.Add(centroOeste);
        }

        #endregion
    }
}
