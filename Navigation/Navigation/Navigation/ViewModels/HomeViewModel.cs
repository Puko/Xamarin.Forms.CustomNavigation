using Navigation.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Navigation.ViewModels
{
    public class HomeViewModel
    {
        private readonly NavigationService _navigationService;

        public HomeViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand NavigateToSaleCommand => new Command(() => _navigationService.Navigate<SaleViewModel>());
    }
}
