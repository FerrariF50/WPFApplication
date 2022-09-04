using BlankApp1.Constants;
using BlankApp1.Dto;
using BlankApp1.Interfaces;
using BlankApp1.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace BlankApp1.ViewModels
{
    public class RetrieveCustomersViewModel : BindableBase
    {
        private readonly IBaseRequestsHandler _reqHandler;
        private string _selectedItem;
        private static object _block = new object();

        public DelegateCommand<SelectionChangedEventArgs> SelectedCommand { get; private set; }
        public DelegateCommand<TextBox> SubmitCommand { get; private set; }
        public string SelectedItem { get => _selectedItem; set => SetProperty(ref _selectedItem, value); }
        public DelegateCommand LoadCommand { get; private set; }
        public ObservableCollection<Customer> Customers { get; set; }

        public RetrieveCustomersViewModel(IBaseRequestsHandler reqHandler)
        {
            this.SubmitCommand = new DelegateCommand<TextBox>(async x => await ExecuteSearch(x));
            this.SelectedCommand = new DelegateCommand<SelectionChangedEventArgs>(OnItemSelected);
            this.LoadCommand = new DelegateCommand(async () => await LoadDataCommand());
            this.Customers = new ObservableCollection<Customer>();
            this._reqHandler = reqHandler;
        }

        private async Task LoadDataCommand()
        {
            try
            {
                var url = $"{ProjectConstants.ServiceUrl}/GetAll";
                var response = await _reqHandler.GetAsync(url);
                var result = JsonConvert.DeserializeObject<Response>(response);
                Customers.Clear();
                result.Body.ForEach(customer =>
                {
                    Customers.Add(customer);
                });
            }
            catch (Exception ex)
            {

            }
        }

        private void OnItemSelected(SelectionChangedEventArgs obj)
        {
            if (obj != null && obj.AddedItems.Count > 0)
            {
                var x = obj.AddedItems[0].ToString().Split(':');
                SelectedItem = x[1].Trim();
            }
        }

        private async Task ExecuteSearch(TextBox textBox)
        {
            switch (SelectedItem)
            {
                case "Name":
                    await FilterByName(textBox.Text);
                    break;
                case "Company":
                    await FilterByCompany(textBox.Text);
                    break;
                case "Phone":
                    await FilterByPhone(textBox.Text);
                    break;
                case "Email":
                    await FilterByEmail(textBox.Text);
                    break;
            }
        }

        private async Task FilterByName(string content)
        {
            var newList = Customers.OrderBy(x => x.Name).Where(x => x.Name == content).Select(x => x).ToList();
            await FilledListAsync(newList);
        }

        private async Task FilterByCompany(string content)
        {
            var newList = Customers.OrderBy(x => x.CompanyName).Where(x => x.CompanyName == content).Select(x => x).ToList();
            await FilledListAsync(newList);
        }

        private async Task FilterByEmail(string content)
        {
            var newList = Customers.OrderBy(x => x.Name).Where(x => x.Email == content).Select(x => x).ToList();
            await FilledListAsync(newList);
        }

        private async Task FilterByPhone(string content)
        {
            var newList = Customers.OrderBy(x => x.Name).Where(x => x.CompanyName == content).Select(x => x).ToList();
            await FilledListAsync(newList);
        }

        private async Task<ObservableCollection<Customer>> FilledListAsync(List<Customer> newList)
        {
            BindingOperations.EnableCollectionSynchronization(Customers, _block);
            Customers.Clear();
            return await Task.Run(() =>
            {
                newList.ForEach(x =>
                {
                    Customers.Add(x);
                });
                return Customers;
            });
        }
    }
}
