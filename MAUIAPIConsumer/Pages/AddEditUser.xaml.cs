using APIIClient;
using APIIClient.Models.Models;

namespace MAUIAPIConsumer.Pages;

public partial class AddEditUser : ContentPage
{
	private readonly APIClientService _APIClientService;
	private User _User;

	public AddEditUser(APIClientService apiclient,User user)
	{
		InitializeComponent();
		_APIClientService = apiclient;
		_User = user;
		Loaduser();

    }

	private void Loaduser()
	{
		if (_User is not null)
		{ 
			txtName.Text = _User.Name;
			txtLastName.Text = _User.LastName;
			txtEmail.Text = _User.Email;

		}
	}


	private async void btnAdd_click(object sender, EventArgs e)
	{
		if (_User is  null)
		{
			await _APIClientService.SaveUser
			(new User
				{
					Name = txtName.Text,
					LastName = txtLastName.Text,
					Email = txtEmail.Text
				}
			);
		}
		else
		{
			await _APIClientService.UpdateUser(
					new User
					{
						UserId = _User.UserId,
						Name = txtName.Text,
						LastName	= txtLastName.Text,
						Email = txtEmail.Text
					}
				);
		}

		await Navigation.PopModalAsync();
	}

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}