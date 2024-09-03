

namespace APIIClient.Models.Models
{
    public class User
    {
        public Int64 UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
