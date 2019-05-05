using MOBRJ_XamarinForms.ViewModels;
using MOBRJ_XamarinForms.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MOBRJ_XamarinForms
{
    public partial class App : PrismApplication
    {
        public App()
            : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }


        protected override async void OnInitialized()
        {
            InitializeComponent();
            Realms.RealmConfiguration.DefaultConfiguration.SchemaVersion = 4;
            await NavigationService.NavigateAsync("/NavigationPage/ListaSimplesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<ListaSimplesPage, ListaSimplesViewModel>();
            containerRegistry.RegisterForNavigation<ListaAgrupadaPage, ListaAgrupadaViewModel>();
            containerRegistry.RegisterForNavigation<ListaDBPage, ListaDBViewModel>();
        }
    }
}