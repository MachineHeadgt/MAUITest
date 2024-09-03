using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUIAPIConsumer.DTOs
{
    public partial class UserDTO: ObservableObject
    {
        [ObservableProperty]
        public Int64 userId;

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string lastName;
     }
}
