using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using APIIClient;
using MAUIAPIConsumer.DTOs;
using MAUIAPIConsumer.Utilities;
using APIIClient.Models.Models;



namespace MAUIAPIConsumer.ViewModels
{
    public partial class UserViewModel : ObservableObject, IQueryAttributable
    {
        private APIClientService _Service;

        [ObservableProperty]
        private UserDTO userDTO = new UserDTO();

        [ObservableProperty]
        private string tituloPagina;

        private Int64 idUser;

        [ObservableProperty]
        private bool loadingIsVisible = false;

        public UserViewModel(APIClientService service)
        {
            _Service = service;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = Int64.Parse(query["id"].ToString());
            idUser = id;

            if (idUser == 0)
            {
                TituloPagina = "Nuevo Usuario";
            }
            else
            {
                TituloPagina = "Editar Usuario";
                LoadingIsVisible = true;
                await Task.Run(async () =>
                {
                    var finded = await _Service.GetUserById(idUser);
                    UserDTO.UserId = idUser;
                    UserDTO.Name = finded.Name;
                    userDTO.LastName = finded.LastName;
                    userDTO.Email = finded.Email;

                    MainThread.BeginInvokeOnMainThread(() => { LoadingIsVisible = false; });

                });


            }
        }

        [RelayCommand]
        private async Task Save()
        {
            LoadingIsVisible = true;
            UserMensaje message = new UserMensaje();

            await Task.Run(async () =>
            {
                if (idUser == 0)
                {
                    await _Service.SaveUser
                    (   
                      new User
                      {
                            Name = UserDTO.Name,
                            LastName = userDTO.LastName,
                            Email = userDTO.Email,
                      }
                    );

                    message = new UserMensaje()
                    {
                        EsCrear = true,
                        User = UserDTO
                    };
                }
                else
                {
                    await _Service.UpdateUser(
                    new User
                    {
                        UserId = idUser,
                        Name = UserDTO.Name,
                        LastName = userDTO.LastName,
                        Email = userDTO.Email,
                    });

                    message = new UserMensaje()
                    {
                        EsCrear = false,
                        User = UserDTO,
                    };
                
                }

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    LoadingIsVisible = false;
                    WeakReferenceMessenger.Default.Send(new UserMenssenger(message));
                    await Shell.Current.Navigation.PopAsync();
                });
            });
        
        }
    }
 }
