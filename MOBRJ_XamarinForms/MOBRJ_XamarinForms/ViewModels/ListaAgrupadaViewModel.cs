using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MOBRJ_XamarinForms.ViewModels
{
    class ListaAgrupadaViewModel : BaseViewModel
    {
        #region Propriedades

        #endregion

        #region Construtor
        public ListaAgrupadaViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            this.Title = "Lista Agrupada";
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

        #endregion
    }
}
