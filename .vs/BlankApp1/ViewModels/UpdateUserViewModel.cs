using BlankApp1.Constants;
using BlankApp1.Dto;
using BlankApp1.Interfaces;
using BlankApp1.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlankApp1.ViewModels
{
    public class UpdateUserViewModel : BindableBase
    {
        private readonly IBaseRequestsHandler _requestHandler;
        public Customer Customer {get;set;}
        private readonly IModelMapper<Customer, CustomerRequestDto> _mapper;
        public DelegateCommand SubmitCommand { get; private set; }

        public UpdateUserViewModel(IBaseRequestsHandler requestHandler, IModelMapper<Customer, CustomerRequestDto> mapper)
        {
            this.Customer = new Customer();
            this._requestHandler = requestHandler;
            this.SubmitCommand = new DelegateCommand(async () => await UpdateCustomer());
            this._mapper = mapper;
        }

        private async Task UpdateCustomer()
        {
            var url = $"{ProjectConstants.ServiceUrl}/Update";
            await _requestHandler.UpdateAsync(url, _mapper.Map(Customer));
        }
    }
}
