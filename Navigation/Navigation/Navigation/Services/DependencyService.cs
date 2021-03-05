using Navigation.ViewModels;
using Navigation.Views;
using SimpleInjector;
using System;

namespace Navigation.Services
{
    public class DependencyService
    {
        private Container _container = new Container();

        public T Resolve<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public void Register<T>(Lifestyle style) where T : class
        {
            _container.Register<T>(style);
        }
        
        public void Register<T>(Func<T> instanceCreator, Lifestyle lifestyle) where T : class
        {
            _container.Register<T>(instanceCreator, lifestyle);
        }

        public T Resolve<T>(Type type) where T : class
        {
            return (T)_container.GetInstance(type);
        }
    }
}
