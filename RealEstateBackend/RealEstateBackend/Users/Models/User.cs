using System.ComponentModel.DataAnnotations;

namespace RealEstateBackend.Users.Models
{
    public class User
    {
        public User()
        {
        }

        public User(
            int id, 
            string email)
        {
            this.id = id;
            this.email = email ?? throw new ArgumentNullException(nameof(email));
        }

        [Key]
        public int id { get; private set; }
        public string email { get; private set; }
    }
}
