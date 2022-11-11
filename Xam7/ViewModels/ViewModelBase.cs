using Xam7.Services.Navigation;
using Xam7.ViewModels;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xam7.ViewModels
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        
        protected readonly INavigationService NavigationService;
        

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public ViewModelBase()
        {
            
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
