using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace BlankApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private string _companyName;

        public string CompanyName { get => _companyName; set => SetProperty(ref _companyName, value); }
        public DelegateCommand<string> UpdateCommand { get; private set;}
        public DelegateCommand<string> DeleteCommand { get; private set; }
        public DelegateCommand<string> AddCommand { get; private set; }
        public DelegateCommand<string> GetAllCustomerCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            CompanyName = "DevPace";
            UpdateCommand = new DelegateCommand<string>(NavigateUpdate);
            DeleteCommand = new DelegateCommand<string>(NavigateDelete);
            AddCommand = new DelegateCommand<string>(NavigateAddCustumer);
            GetAllCustomerCommand = new DelegateCommand<string>(NavigateToLoadData);
            this._regionManager = regionManager;
        }

        private void NavigateToLoadData(string path)
        {
            _regionManager.RequestNavigate("ContentRegion", path);
            CompanyName = "";
        }

        private void NavigateUpdate(string path)
        {
            _regionManager.RequestNavigate("ContentRegion",path);
            CompanyName = "";
        }
        private void NavigateDelete(string path)
        {
            _regionManager.RequestNavigate("ContentRegion", path);
            CompanyName = "";
        }

        private void NavigateAddCustumer(string path)
        {
            _regionManager.RequestNavigate("ContentRegion", path);
            CompanyName = "";
        }
    }
}
