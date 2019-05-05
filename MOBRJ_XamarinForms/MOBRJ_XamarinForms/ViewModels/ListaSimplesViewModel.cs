using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MOBRJ_XamarinForms.ViewModels
{
    class ListaSimplesViewModel : BaseViewModel
    {
        #region Propriedades

        #endregion

        #region Construtor
        public ListaSimplesViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            this.Title = "Lista Simples";
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
        #endregion
    }
}
