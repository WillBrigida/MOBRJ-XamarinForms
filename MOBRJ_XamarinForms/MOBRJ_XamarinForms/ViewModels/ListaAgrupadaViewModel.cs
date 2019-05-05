using MOBRJ_XamarinForms.Helpers;
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
        DataBaseHelper _dataBaseHelper;
        public enum EnumRegiao { CentroOeste, Nordeste, Norte, Sudeste, Sul };

        #endregion

        #region Construtor
        public ListaAgrupadaViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            this.Title = "Lista Agrupada";
            ListaAgrupada = new ObservableCollection<Regiao>();
            _apiService = new ApiService();
            _dataBaseHelper = new DataBaseHelper();
            InitApi();
        }
        #endregion

        #region Commands
        private DelegateCommand _listaDadosLocalCommand;
        public DelegateCommand ListaDBCommand => _listaDadosLocalCommand ?? (_listaDadosLocalCommand = new DelegateCommand(async () => await OnListaDadosLocal(), () => !IsBusy));

        #endregion

        #region Métodos
        private async Task OnListaDadosLocal()
        {
            await NavigationService.NavigateAsync("ListaDBPage");
        }

        private async Task InitApi()
        {
           
            var estados =  await _dataBaseHelper.GetApi(); // Chamada da API


            var nordeste = new Regiao() { LongName = "Nordeste", ShortName = "N" };

            foreach (var estado in estados.Where(l => l.Fields.Regiao.Contains("Nordeste")).ToList())
            {
                nordeste.Add(estado.Fields);
            }
            ListaAgrupada.Add(nordeste);


            var sudeste = new Regiao() { LongName = "Sudeste", ShortName = "S"};

            foreach (var estado in estados.Where(l => l.Fields.Regiao.Contains("Sudeste")).ToList())
            {
                sudeste.Add(estado.Fields);
            }
            ListaAgrupada.Add(sudeste);


            var sul = new Regiao() { LongName = "Sul", ShortName = "S" };

            foreach (var estado in estados.Where(l => l.Fields.Regiao.Contains(EnumRegiao.Sul.ToString())).ToList())
            {
                sul.Add(estado.Fields);
            }
            ListaAgrupada.Add(sul);



            var centroOeste = new Regiao() { LongName = "Centro-Oeste", ShortName = "C" };

            foreach (var estado in estados.Where(l => l.Fields.Regiao.Contains("Centro-Oeste")).ToList())
            {
                centroOeste.Add(estado.Fields);
            }
            ListaAgrupada.Add(centroOeste);
        }

        #endregion
    }
}
