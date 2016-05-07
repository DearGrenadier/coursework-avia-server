using System;
using System.Threading.Tasks;
using AirApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AirApi
{

    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            this._ctx = new AuthContext();
            this._userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(this._ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await this._userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await this._userManager.FindAsync(userName, password);

            return user;
        }

       

        public async Task<IdentityUser> FindAsync(UserLoginInfo loginInfo)
        {
            IdentityUser user = await this._userManager.FindAsync(loginInfo);

            return user;
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user)
        {
            var result = await this._userManager.CreateAsync(user);

            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await this._userManager.AddLoginAsync(userId, login);

            return result;
        }

        public void Dispose()
        {
            this._ctx.Dispose();
            this._userManager.Dispose();

        }
    }
}