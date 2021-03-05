using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation.Views
{
    public class BaseView : ContentView, IDisposable
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
