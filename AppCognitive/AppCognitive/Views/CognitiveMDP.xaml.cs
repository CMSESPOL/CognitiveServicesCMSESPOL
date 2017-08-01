using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCognitive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CognitiveMDP : MasterDetailPage
    {
        public CognitiveMDP()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Master = this;
            App.Navigator = this.Navigator;
        }
    }
}