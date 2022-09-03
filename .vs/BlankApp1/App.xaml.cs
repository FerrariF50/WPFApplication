using BlankApp1.BaseHttpHandler;
using BlankApp1.Dto;
using BlankApp1.Interfaces;
using BlankApp1.Mappers;
using BlankApp1.Models;
using BlankApp1.ViewModels;
using BlankApp1.Views;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace BlankApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<MainWindowViewModel>();
            containerRegistry.Register<IModelMapper<Customer, CustomerDto>, CustomerMapper>();
            containerRegistry.Register<IBaseRequestsHandler, BaseRequestsHandler>();
            containerRegistry.RegisterForNavigation<AddUser, AddUserViewModel>();
            containerRegistry.RegisterForNavigation<DeleteUser, DeleteUserViewModel>();
            containerRegistry.RegisterForNavigation<UpdateUser, UpdateUserViewModel>();
            containerRegistry.RegisterForNavigation<RetrieveCustomers,RetrieveCustomersViewModel>();
        }
    }
}
