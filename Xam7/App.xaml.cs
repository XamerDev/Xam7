using System;
using System.Threading.Tasks;
using Xam7.Services.Navigation;
using Xam7.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitApp();
            InitNavigation();
            

        }
        private void InitApp()
        {
            
            ViewModelLocator.RegisterDependencies(false);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
