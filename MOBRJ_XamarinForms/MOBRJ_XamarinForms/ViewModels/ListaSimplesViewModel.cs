using MOBRJ_XamarinForms.Helpers;
using MOBRJ_XamarinForms.Models;
using MOBRJ_XamarinForms.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Linq;
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

        DataBaseHelper _dataBaseHelper;
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

            _dataBaseHelper = new DataBaseHelper();
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
            var estados = await _dataBaseHelper.GetApi(); // chamada à API


            foreach (var item in estados)
            {
                foreach (var attachment in item.Fields.Attachments)
                {
                    ListaEstados.Add(new Fields
                    {
                        Capital = item.Fields.Capital,
                        Estado = item.Fields.Estado,
                        Regiao = item.Fields.Regiao,
                        Sigla = item.Fields.Sigla,
                        Icon = attachment.Thumbnails.Large.Url
                    });

                    _listaFiltrada = ListaEstados;
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
