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
    class ListaSimplesViewModel : BaseViewModel
    {
        #region Propriedades
        private ObservableCollection<Fields> _listaFiltrada = new ObservableCollection<Fields>();

        private ObservableCollection<Fields> _listaEstados;

        public ObservableCollection<Fields> ListaEstados
        {
            get { return _listaEstados; }
            set { this.SetProperty(ref _listaEstados, value); }
        }

        private string filtro;

        public string Filtro
        {
            get { return filtro; }
            set
            {
                this.SetProperty(ref filtro, value);
                Busca();
            }

        }
        ApiService _apiService;
        private Estados _estados;

        public Estados Estados
        {
            get { return _estados; }
            set { SetProperty(ref _estados, value); }
        }

        private Attachment _attachment;

        public Attachment Attachment
        {
            get { return _attachment; }
            set { SetProperty(ref _attachment, value); }
        }


        #endregion

        #region Construtor
        public ListaSimplesViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            ListaEstados = new ObservableCollection<Fields>();
            this.Title = "Lista Simples";

            _apiService = new ApiService();

            InitApi();

        }
        #endregion

        #region Commands
        private DelegateCommand _listaAgrupadaCommand;

        public DelegateCommand ListaAgrupadaCommand => _listaAgrupadaCommand ?? (_listaAgrupadaCommand = new DelegateCommand(async () => await OnListaAgrupada(), () => !IsBusy));
        #endregion

        #region Métodos
        private async Task OnListaAgrupada()
        {
            await NavigationService.NavigateAsync("ListaAgrupadaPage");
        }

        private async Task InitApi()
        {
            Estados = await _apiService.Get<Estados>("https://api.airtable.com",
                "/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
            foreach (var item in Estados.Records)
            {
                foreach (var attachment in item.Fields.Attachments)
                {

                    ListaEstados.Add(new Fields
                    {
                        Capital = item.Fields.Capital,
                        Attachments = item.Fields.Attachments,
                        Estado = item.Fields.Estado,
                        Regiao = item.Fields.Regiao,
                        Sigla = item.Fields.Sigla,
                        Icon = attachment.Thumbnails.Large.Url
                    });

                    _listaFiltrada.Add((new Fields
                    {
                        Capital = item.Fields.Capital,
                        Attachments = item.Fields.Attachments,
                        Estado = item.Fields.Estado,
                        Regiao = item.Fields.Regiao,
                        Sigla = item.Fields.Sigla,
                        Icon = attachment.Thumbnails.Large.Url
                    }));
                }

            }
        }

        private void Busca()
        {
            if (string.IsNullOrEmpty(Filtro))
            {
                ListaEstados = new ObservableCollection<Fields>(_listaFiltrada);
            }
            else
            {
                ListaEstados = new ObservableCollection<Fields>
                     (_listaFiltrada.Where(l => l.Estado.ToLower().Contains(Filtro.ToLower()) ||
                      l.Capital.ToString().ToLower().Contains(Filtro.ToLower())));
            }
        }

        #endregion
    }
}
