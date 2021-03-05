using Navigation.Services;
using Navigation.ViewModels;
using Navigation.Views;
using SimpleInjector;
using Xamarin.Forms;

namespace Navigation
{
    public partial class App : Application
    {
        private NavigationService _navigationService;

        public App()
        {
            InitializeComponent();
            Services.DependencyService dependencyService = new Services.DependencyService();
           
            var mainPage = new MainPage();
            _navigationService = new NavigationService(dependencyService, mainPage);

            _navigationService.RegisterView<HomeView, HomeViewModel>();
            _navigationService.RegisterView<SaleView, SaleViewModel>();
            _navigationService.RegisterPage<AboutPage, AboutViewModel>();

            dependencyService.Register(() => _navigationService, Lifestyle.Singleton);

            dependencyService.Register<AboutViewModel>(Lifestyle.Singleton);
            dependencyService.Register<HomeViewModel>(Lifestyle.Singleton);
            dependencyService.Register<SaleViewModel>(Lifestyle.Singleton);

            dependencyService.Register<HomeView>(Lifestyle.Singleton);
            dependencyService.Register<SaleView>(Lifestyle.Singleton);
            dependencyService.Register<AboutPage>(Lifestyle.Singleton);

            MainPage = new NavigationPage(mainPage);
        }

        protected override void OnStart()
        {
            _navigationService.Navigate<HomeViewModel>();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
