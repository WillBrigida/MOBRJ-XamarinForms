using MOBRJ_XamarinForms.Helpers;
using MOBRJ_XamarinForms.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MOBRJ_XamarinForms.ViewModels
{
    class ListaDadosLocalViewModel : BaseViewModel
    {
        #region Propriedades
        DataBaseHelper _dataBaseHelper;
        public ObservableCollection<Fields> ListaLocal { get;}
        #endregion

        #region Construtor
        public ListaDadosLocalViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            ListaLocal = new ObservableCollection<Fields>();
            this.Title = "Lista Local";

            _dataBaseHelper = new DataBaseHelper();
            GetListaApi();
        }
        #endregion

        #region Commands
        private DelegateCommand _carregaarDoBancoLocalCommand;

        public DelegateCommand CarregaarDoBancoLocalCommand => _carregaarDoBancoLocalCommand ?? (_carregaarDoBancoLocalCommand = new DelegateCommand(async () => await OnBancoLocal(), () => !IsBusy));

       
        #endregion

        #region Métodos
        private async Task GetListaApi()
        {
            var estado = await _dataBaseHelper.GetApi(); // Chamada à API

            foreach (var item in estado)
            {
                foreach (var attachment in item.Fields.Attachments)
                {
                    ListaLocal.Add(new Fields
                    {
                        Capital = item.Fields.Capital,
                        Estado = item.Fields.Estado,
                        Regiao = item.Fields.Regiao,
                        Sigla = item.Fields.Sigla,
                        Icon = attachment.Thumbnails.Large.Url
                    });

                }

            }
        }



        private void SalvarNoBancoLocal()
        {
            _dataBaseHelper.SalvarNoBancoLocalHelper();
        }

        //private List<Record> GetListaLocal()
        //{
        //    return _dataBaseHelper.GetListaLocalHelper();
        //}

        private void DeletarListaLocal()
        {
            _dataBaseHelper.DeletarListaLocalHelper();
        }

        private async Task OnBancoLocal()
        {
            DeletarListaLocal();
            SalvarNoBancoLocal();
            //GetListaLocal();
        }

        #endregion
    }
}
