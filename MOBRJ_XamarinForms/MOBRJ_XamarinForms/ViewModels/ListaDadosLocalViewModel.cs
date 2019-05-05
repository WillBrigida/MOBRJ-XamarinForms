using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOBRJ_XamarinForms.ViewModels
{
    class ListaDadosLocalViewModel : BaseViewModel
    {
        #region Propriedades

        #endregion

        #region Construtor
        public ListaDadosLocalViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            this.Title = "Lista Local";
        }
        #endregion

        #region Commands

        #endregion

        #region Métodos

        #endregion
    }
}
