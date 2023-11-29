using Android.Widget;
using HomeFinancialControl.Droid;
using HomeFinancialControl.Presentation.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastService))]
namespace HomeFinancialControl.Droid
{
    public class ToastService : IToastService
    {
        public void ShowToast(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }

}