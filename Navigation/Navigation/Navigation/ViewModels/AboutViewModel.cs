using System.Windows.Input;
using Navigation.Services;
using Xamarin.Forms;

namespace Navigation.ViewModels
{
    public class AboutViewModel
    {
      private readonly NavigationService _navigationService;

      public AboutViewModel(NavigationService navigationService)
      {
         _navigationService = navigationService;
      }

      public ICommand PopCommand => new Command(async () =>  await _navigationService.PopModalAsync());

   }
}
