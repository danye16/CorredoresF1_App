using CorredoresF1_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CorredoresF1_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vcorredor : ContentPage
    {
        public Vcorredor()
        {
            InitializeComponent();
            BindingContext =  new VMapi(Navigation);
        }
    }
}