using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using APIIClient;
using MAUIAPIConsumer.DTOs;
using MAUIAPIConsumer.Utilities;
using APIIClient.Models.Models;
using System.Collections.ObjectModel;
using MAUIAPIConsumer.Views;


namespace MAUIAPIConsumer.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private APIClientService _Service;

        [ObservableProperty]
        private ObservableCollection<UserDTO> userList = new ObservableCollection<UserDTO>();

        public MainViewModel(APIClientService service)
        {
            _Service = service;

            MainThread.BeginInvokeOnMainThread(new Action(async () => await Load()));

            WeakReferenceMessenger.Default.Register<UserMenssenger>(this, (r, m) =>
            {
                EmpleadoMensajeRecibido(m.Value);
            });
        }

        public async Task Load()
        {
            var List = await _Service.GetUsers();
            if (List.Any())
            {
                foreach (var item in List)
                {
                    UserList.Add(new UserDTO
                    {
                        UserId = item.UserId,
                        Name = item.Name,
                        LastName = item.LastName,
                        Email = item.Email,
                    });
                }

            }
        }

        private void EmpleadoMensajeRecibido(UserMensaje message)
        {
            var UserDTO = message.User;

            if (message.EsCrear)
            {
                UserList.Add(UserDTO);
            }
            else
            {
                var finded = UserList
                    .First(e => e.UserId == UserDTO.UserId);


                finded.Name  = UserDTO.name;
                finded.email = UserDTO.email;
                finded.lastName = UserDTO.lastName;
                

            }

        }

        [RelayCommand]
        private async Task Crear()
        {
            var uri = $"{nameof(UserPage)}?id=0";
            await Shell.Current.GoToAsync(uri);
        }

        [RelayCommand]
        private async Task Editar(UserDTO userDTO)
        {
            var uri = $"{nameof(UserPage)}?id={userDTO.UserId}";
            await Shell.Current.GoToAsync(uri);
        }

        [RelayCommand]
        private async Task Eliminar(UserDTO userDTO)
        {
            bool answer = await Shell.Current.DisplayAlert("Mensaje", "Desea eliminar el usuario?", "Si", "No");

            if (answer)
            {
                await _Service.DeleteUser(userDTO.UserId);


                UserList.Remove(userDTO);

            }

        }
    }
}
