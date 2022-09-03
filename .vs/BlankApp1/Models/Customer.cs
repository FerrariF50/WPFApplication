using Prism.Mvvm;

namespace BlankApp1.Models
{
    public class Customer : BindableBase
    {
        private int _customerId;
        private string _name;
        private string _comapnyName;
        private string _phone;
        private string _email;

        public int Customerid { get => _customerId; set => SetProperty(ref _customerId, value); }
        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public string Companyname { get => _comapnyName; set => SetProperty(ref _comapnyName, value); }
        public string Phone { get => _phone; set => SetProperty(ref _phone, value); }
        public string Email { get => _email; set => SetProperty(ref _email, value); }
    }
}
