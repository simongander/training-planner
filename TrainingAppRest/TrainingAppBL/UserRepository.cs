using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using TrainingAppDAL;
using TrainingAppDAL.Model;
using TrainingAppBL.Interfaces;
using TrainingAppDAL.Interfaces;

namespace TrainingAppBL
{
    public class UserRepository : IUserRepository
    {
        private readonly TrainingDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _expireTime = new TimeSpan(7, 0, 0, 0);

        public UserRepository(ITrainingDbContext context, IMemoryCache memoryCache)
        {
            this._context = context as TrainingDbContext;
            this._cache = memoryCache;
        }

        public User GetUserByUsername(string username)
        {
            return this._context.User.FirstOrDefault(x => x.Username == username);
        }

        public string Authenticate(string credString)
        {
            var decodedBytes = Convert.FromBase64String(credString);
            var decodedCredString = Encoding.UTF8.GetString(decodedBytes);
            var credentials = decodedCredString.Split(separator: ':', count: 2);
            var user = this.GetUserByUsername(credentials[0]);
            if (user != null)
            {
                if (user.PasswordHash == CreatePwHash(credentials[1]))
                {
                    var bearer = CreateBearer(credentials[0]);
                    _cache.Set(bearer, user, _expireTime);
                    return bearer;
                }
            }

            throw new Exception("Unauthorized");
        }

        public void CreateUser(string credString)
        {
            var decodedBytes = Convert.FromBase64String(credString);
            var decodedCredString = Encoding.UTF8.GetString(decodedBytes);
            var credentials = decodedCredString.Split(separator: ':', count: 2);
            var user = new User();
            user.Username = credentials[0];
            user.PasswordHash = CreatePwHash(credentials[1]);
            _context.Add(user);
            _context.SaveChanges();
        }

        private static string CreatePwHash(string pw)
        {
            var shaManager = new SHA512Managed();
            var encoding = new UTF8Encoding();
            var strBuild = new StringBuilder();

            var pwBytes = encoding.GetBytes(pw);
            var hashBytes = shaManager.ComputeHash(pwBytes).ToArray();

            foreach (var b in hashBytes)
            {
                strBuild.Append(b.ToString("x2"));
            }

            return strBuild.ToString();
        }

        private static string CreateBearer(string username)
        {
            var shaManager = new SHA512Managed();
            var encoding = new UTF8Encoding();
            var randomGenerator = new RNGCryptoServiceProvider();
            var randomBytes = new byte[32];
            var strBuild = new StringBuilder();

            randomGenerator.GetBytes(randomBytes);
            var usernameBytes = encoding.GetBytes(username);
            var bytes = usernameBytes.Concat(randomBytes);
            var bearer = shaManager.ComputeHash(bytes.ToArray());

            foreach (var b in bearer)
            {
                strBuild.Append(b.ToString("x2"));
            }
            return strBuild.ToString();
        }
    }
}
