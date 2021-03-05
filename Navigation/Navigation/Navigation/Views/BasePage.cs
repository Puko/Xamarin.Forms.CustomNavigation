using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation.Views
{
    public class BasePage : ContentPage, IDisposable
    {
        public virtual void Dispose()
        {

        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
