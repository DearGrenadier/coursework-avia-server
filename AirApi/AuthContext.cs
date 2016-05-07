using Microsoft.AspNet.Identity.EntityFramework;

namespace AirApi
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("name=AirAuth")
        {
     
        }
    }

}