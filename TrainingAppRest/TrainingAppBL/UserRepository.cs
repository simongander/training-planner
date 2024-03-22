using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;
using TrainingAppDAL.Model;

namespace TrainingAppBL
{
    public class UserRepository : IUserRepository
    {
        private readonly ITrainingDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string _salt;
        private readonly TimeSpan _expireTime = new TimeSpan(7, 0, 0, 0);

        public UserRepository(ITrainingDbContext context, IMemoryCache memoryCache, string salt = null)
        {
            this._context = context;
            this._cache = memoryCache;
            this._salt = salt;
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
            if (user != null && user.PasswordHash == CreatePwHash(credentials[1]))
            {
                var bearer = CreateBearer(credentials[0]);
                _cache.Set(bearer, user, _expireTime);
                return bearer;
            }

            throw new UnauthorizedAccessException("Unauthorized");
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
            var shaManager = SHA512.Create();
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

        private string CreateBearer(string username)
        {
            var shaManager = SHA512.Create();
            var encoding = new UTF8Encoding();
            var strBuild = new StringBuilder();

            var randomBytes = RandomNumberGenerator.GetBytes(32);
            var usernameBytes = encoding.GetBytes(username);
            List<byte> bytes;
            if (_salt != null)
            {
                bytes = usernameBytes.Concat(encoding.GetBytes(_salt)).ToList();
            }
            else
            {
                bytes = usernameBytes.Concat(randomBytes).ToList();
            }

            var bearer = shaManager.ComputeHash(bytes.ToArray());

            foreach (var b in bearer)
            {
                strBuild.Append(b.ToString("x2"));
            }
            return strBuild.ToString();
        }
    }
}
