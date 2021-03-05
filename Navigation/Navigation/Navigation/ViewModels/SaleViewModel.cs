using Navigation.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Navigation.ViewModels
{
    public class SaleViewModel
    {
        private readonly NavigationService _navigationService;

        public SaleViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand BackCommand => new Command(() => _navigationService.Pop());
        public ICommand PresentCommand => new Command(async () => await _navigationService.PresentAsync<AboutViewModel>());
    }
}
