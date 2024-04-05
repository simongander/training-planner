using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppBL;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;
using TrainingAppModel;

namespace TrainingAppRest.BL.Test
{
    internal class UserRepositoryTest
    {
        private readonly string _validUser = "VmFsaWRVc2VyOjEyMzQ=";
        private readonly string _invalidUser = "SW52YWxpZFVzZXI6MTIzNA==";
        private readonly string _bearer = "157591088ba9c931ba24a67d480ff1424e8b76c89ffb2e20e2ddf2bd052e1d8961aaea7a9be94089ce3c4e297fead5a55616468b68f80b9bcc7c9325dea3bde4";
        private readonly User user = new User 
        { 
            UserId = 1,
            Username = "TestUser",
            PasswordHash = "d404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db"
        };
        private UserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            ITrainingDbContext dbContext = new TrainingDbContextInMemory();
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            _userRepository = new UserRepository(dbContext, memoryCache, "1234");
        }

        [Test]
        public void Authenticate_Success()
        {
            _userRepository.CreateUser(_validUser);

            var bearer = _userRepository.Authenticate(_validUser);

            Assert.That(bearer == _bearer);
        }

        [Test]
        public void Authenticate_Failure()
        {
            Assert.Throws(typeof(UnauthorizedAccessException), () => _userRepository.Authenticate(_invalidUser));
        }
    }
}
