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
    public class ListaDBViewModel : BaseViewModel
    {
        #region Propriedades
        DataBaseHelper _dataBaseHelper;
        public ObservableCollection<Fields> Lista { get; set; }
        public ObservableCollection<Record> ListaRecord { get; set; }
        #endregion

        #region Construtor
        public ListaDBViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Lista = new ObservableCollection<Fields>();
            ListaRecord = new ObservableCollection<Record>();
            this.Title = "Lista Local";

            _dataBaseHelper = new DataBaseHelper();
            GetListaApi();
        }
        #endregion

        #region Commands
        private DelegateCommand _carregarDoBancoLocalCommand;

        public DelegateCommand CarregarDoBancoLocalCommand => _carregarDoBancoLocalCommand ?? (_carregarDoBancoLocalCommand = new DelegateCommand(async () => await OnBancoLocal(), () => !IsBusy));


        #endregion

        #region Métodos
        private async Task GetListaApi()
        {
            //var estado = await _dataBaseHelper.GetApi(); // Chamada à API

            var listaLocal = GetListaLocal();
            foreach (var item in listaLocal)
            {
                foreach (var attachment in item.Fields.Attachments)
                {
                    Lista.Add(new Fields
                    {
                        Capital = item.Fields.Capital,
                        Estado = item.Fields.Estado,
                        Regiao = item.Fields.Regiao,
                        Sigla = item.Fields.Sigla,
                        Icon = attachment.Thumbnails.Large.Url
                    });

                }
            }


            //foreach (var item in estado)
            //{
            //    foreach (var attachment in item.Fields.Attachments)
            //    {

            //        Lista.Add(new Fields
            //        {
            //            Capital = item.Fields.Capital,
            //            Estado = item.Fields.Estado,
            //            Regiao = item.Fields.Regiao,
            //            Sigla = item.Fields.Sigla,
            //            Icon = attachment.Thumbnails.Large.Url
            //        });


            //    }

            //}
        }



        private void SalvarNoBancoLocal()
        {
            _dataBaseHelper.SalvarNoBancoLocalHelper();
        }

        private List<Record> GetListaLocal()
        {
            return _dataBaseHelper.GetListaLocalHelper();
        }

        private void DeletarListaLocal()
        {
            _dataBaseHelper.DeletarListaLocalHelper();
        }

        private async Task OnBancoLocal()
        {
            //DeletarListaLocal();
            //SalvarNoBancoLocal();
            var resp = GetListaLocal();
            var cont = resp.Count;
        }

        #endregion
    }
}
