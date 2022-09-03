using BlankApp1.Dto;
using BlankApp1.Interfaces;
using BlankApp1.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BlankApp1.ViewModels
{
    public class RetrieveCustomersViewModel : BindableBase
    {
        private readonly IBaseRequestsHandler _reqHandler;

        public  DelegateCommand LoadCommand { get; private set; }

        public ObservableCollection<Customer> Customers { get; set; }

        public RetrieveCustomersViewModel(IBaseRequestsHandler reqHandler)
        {
            LoadCommand = new DelegateCommand(async ()=> await LoadDataCommand());
            this.Customers = new ObservableCollection<Customer>();
            this._reqHandler = reqHandler;
        }

        private async Task LoadDataCommand()
        {
            try
            {
                var url = "https://localhost:44341/customer/GetAll";
                var response = await _reqHandler.GetAsync(url);
                var result = JsonConvert.DeserializeObject<Response>(response);

                result.Body.ForEach(customer =>
                {
                    Customers.Add(customer);
                });
            }
            catch (Exception ex)
            {

            }
        }
    }
}
