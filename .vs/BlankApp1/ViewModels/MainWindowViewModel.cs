using BlankApp1.Interfaces;
using BlankApp1.Models;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BlankApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public Customer Customer { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        private IBaseRequestsHandler _reqHandler;
        public MainWindowViewModel(IBaseRequestsHandler reqHandler)
        {
            Customer = new Customer();
            this.Customers = new ObservableCollection<Customer>();
            this._reqHandler = reqHandler;
            Task.Factory.StartNew(async () => await LoadData());
           
        }

        private async Task LoadData()
        {
           
        }
    }
}
