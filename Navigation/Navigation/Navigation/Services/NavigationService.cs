using Navigation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navigation.Services
{
    public class NavigationService
    {
        private Dictionary<Type, Type> _registration = new Dictionary<Type, Type>();
        private readonly DependencyService _dependencyService;
        private readonly MainPage _contentView;
        private Stack<BaseView> _navigationStack = new Stack<BaseView>();

        public NavigationService(DependencyService dependencyService, MainPage contentView)
        {
            _dependencyService = dependencyService;
            _contentView = contentView;
        }

        public void RegisterView<TView, TViewModel>() where TView : BaseView where TViewModel : class
        {
            _registration.Add(typeof(TViewModel), typeof(TView));
        }

        public void RegisterPage<TView, TViewModel>() where TView : BasePage where TViewModel : class
        {
            _registration.Add(typeof(TViewModel), typeof(TView));
        }

        public void Navigate<TViewModel>(Action<TViewModel> init = null) where TViewModel : class
        {
            var viewType = _registration[typeof(TViewModel)];
            var view = _dependencyService.Resolve<BaseView>(viewType);
            var viewModel = _dependencyService.Resolve<TViewModel>();
            init?.Invoke(viewModel);
            view.BindingContext = viewModel;
            view.InitializeAsync();

            _navigationStack.Push(view);
            _contentView.MainContent.Content = view;
        }

        public void Pop()
        {
            if(_navigationStack.Count > 1)
            {
                var view = _navigationStack.Pop();
                view.Dispose();

                _contentView.MainContent.Content = _navigationStack.Peek();
            }
        }

        public Task PresentAsync<TViewModel>(Action<TViewModel> init = null) where TViewModel : class
        {
            var viewType = _registration[typeof(TViewModel)];
            var view = _dependencyService.Resolve<BasePage>(viewType);
            var viewModel = _dependencyService.Resolve<TViewModel>();
            init?.Invoke(viewModel);
            view.BindingContext = viewModel;
            view.InitializeAsync();

            return _contentView.Navigation.PushModalAsync(view, false);
        }

        public Task PopModalAsync()
        {
            var page = (BasePage)_contentView.Navigation.ModalStack.Last();
            page.Dispose();

            return _contentView.Navigation.PopModalAsync(false);
        }
    }
}
