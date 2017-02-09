using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Phoneword2.UWP;
using Windows.ApplicationModel.Calls;
using Windows.UI.Popups;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword2.UWP
{
    public class PhoneDialer : IDialer
    {
        bool dialled = false;
        public bool Dial(string number)
        {
            DialNumber(number);
            return dialled;
        }
            async void DialNumber(string number)
        {
            var PhoneLine = await GetDefaultPhoneLineAsync();
            if (PhoneLine != null)
            {
                PhoneLine.Dial(number, number);
                dialled = true;
            }
            else
            {
                var dialog = new MessageDialog("No line found to place call");
                await dialog.ShowAsync();
                dialled = false;
            }
        }
        async Task<PhoneLine> GetDefaultPhoneLineAsync()
        {
            var phoneCallStore = await PhoneCallManager.RequestStoreAsync();
            var lineId = await phoneCallStore.GetDefaultLineAsync();
            return await PhoneLine.FromIdAsync(lineId);
        }

    }
}
