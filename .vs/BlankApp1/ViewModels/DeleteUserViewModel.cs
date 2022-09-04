using BlankApp1.Constants;
using BlankApp1.Interfaces;
using BlankApp1.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Threading.Tasks;

namespace BlankApp1.ViewModels
{
    public class DeleteUserViewModel : BindableBase
    {
        private readonly IBaseRequestsHandler _requestHandler;

        public Customer Customer { get; set; }
        public DelegateCommand SubmitCommand { get; private set; }

        public DeleteUserViewModel(IBaseRequestsHandler requestHandler)
        {
            this.Customer = new Customer();
            this._requestHandler = requestHandler;
            this.SubmitCommand = new DelegateCommand(async () => await DeleteCustomer());
        }
       
        private async Task DeleteCustomer()
        {
            var url = $"{ProjectConstants.ServiceUrl}/Delete/{Customer.CustomerId}";
            await _requestHandler.DeleteAsync(url);
        }
    }
}
