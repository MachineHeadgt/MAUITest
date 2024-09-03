
using MAUIAPIConsumer.ViewModels;

namespace MAUIAPIConsumer
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage(MainViewModel ViewModel)
        {

            InitializeComponent();
            BindingContext = ViewModel;
        }

    }

}
