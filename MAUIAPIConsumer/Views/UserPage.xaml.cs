using MAUIAPIConsumer.ViewModels;

namespace MAUIAPIConsumer.Views;

public partial class UserPage : ContentPage
{
	public UserPage(UserViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel;

	}
}

