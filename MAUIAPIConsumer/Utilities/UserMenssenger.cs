using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MAUIAPIConsumer.Utilities
{
    public class UserMenssenger: ValueChangedMessage <UserMensaje>
    {
        public UserMenssenger(UserMensaje value ):base(value)
        {
            
        }

    }
}
