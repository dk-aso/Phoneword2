using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Telephony;
using Phoneword2.Droid;
using Xamarin.Forms;
using Uri = Android.Net.Uri;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword2.Droid
{
    public class PhoneDialer : IDialer
    {
        public bool Dial (string number)
        {
            var context = Forms.Context;
            if (context == null)
                return false;
            var intent = new Intent(Intent.ActionCall);

        }
    }
}