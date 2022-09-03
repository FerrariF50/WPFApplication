using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace BlankApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> UpdateCommand { get; private set;}
        public DelegateCommand<string> DeleteCommand { get; private set; }
        public DelegateCommand<string> AddCommand { get; private set; }
        public DelegateCommand<string> GetAllCustomerCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            UpdateCommand = new DelegateCommand<string>(NavigateUpdate);
            DeleteCommand = new DelegateCommand<string>(NavigateDelete);
            AddCommand = new DelegateCommand<string>(NavigateAddCustumer);
            this._regionManager = regionManager;
        }

        private void NavigateUpdate(string path)
        {
            _regionManager.RequestNavigate("ContentRegion",path);
        }
        private void NavigateDelete(string path)
        {
            _regionManager.RequestNavigate("ContentRegion", path);
        }

        private void NavigateAddCustumer(string path)
        {
            _regionManager.RequestNavigate("ContentRegion", path);
        }
    }
}
