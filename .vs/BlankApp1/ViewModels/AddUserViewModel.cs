using BlankApp1.Constants;
using BlankApp1.Dto;
using BlankApp1.Interfaces;
using BlankApp1.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Threading.Tasks;

namespace BlankApp1.ViewModels
{
    public class AddUserViewModel : BindableBase
    {
        private readonly IBaseRequestsHandler _requestHandler;
        private readonly IModelMapper<Customer, CustomerRequestDto> _mapper;

        public Customer Customer { get; set; }
        public DelegateCommand SubmitCommand { get; private set; }

        public AddUserViewModel(IBaseRequestsHandler requestHandler, IModelMapper<Customer, CustomerRequestDto> mapper)
        {
            Customer = new Customer();
            this._requestHandler = requestHandler;
            this.SubmitCommand = new DelegateCommand(async () => await AddCustomer());
            this._mapper = mapper;
        }

        private async Task AddCustomer()
        {
            var url = $"{ProjectConstants.ServiceUrl}/Add";
            await _requestHandler.AddAsync(url, _mapper.Map(Customer));
        }
    }
}
