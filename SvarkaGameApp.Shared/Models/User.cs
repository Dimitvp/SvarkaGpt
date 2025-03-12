using Microsoft.AspNetCore.Identity;

namespace SvarkaGameApp.Shared.Models
{

    public class User : IdentityUser
    {
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }

        public string DisplayName { get; set; }
    }

}
