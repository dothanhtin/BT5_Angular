using DMS.Core.Models;
using DMS.Core.Repositories;
using DMS.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.Extensions;

namespace Test_DMS_Repositories
{
    [TestClass]
    public class TestAccountRepository
    {
        private readonly IAccountRepository accountRepository;
        private readonly CancellationToken cancellationToken;
        public TestAccountRepository()
        {
            Startup.Start();
            accountRepository = new AccountRepository();
            cancellationToken = CancellationToken.None;
        }

        [TestMethod]
        public async Task Test_Exist_GetAccountByUsernameAsync()
        {
            var username = "tan.nguyen.xuan";

            var account = await accountRepository.GetAccountByUsernameAsync(username, cancellationToken);
            Assert.IsTrue(account.Username.EqualsWithIgnoreCase(username));
        }

        [TestMethod]
        public async Task Test_NotExist_GetAccountByUsernameAsync()
        {
            var username = "tan.nguyen.xuan2";
            var account = await accountRepository.GetAccountByUsernameAsync(username, cancellationToken);
            Assert.IsTrue(account==null);
        }

        [TestMethod]
        public async Task Test_NotExist_GetAccountIdByTokenAsync()
        {
            var token = "tan.nguyen.xuan2";
            var accountId = await accountRepository.GetAccountIdByTokenAsync(token, cancellationToken);
            Assert.IsTrue(accountId == Guid.Empty);
        }

        [TestMethod]
        public async Task Test_Exist_GetAccountIdByTokenAsync()
        {
            var token = "7939388e-1d7e-4b68-9fc3-004816bae3b9";
            var accountId = await accountRepository.GetAccountIdByTokenAsync(token, cancellationToken);
            Assert.IsTrue(accountId == Guid.Parse("c6f1b9e4-5e1f-49fa-ab93-73f0ef157232"));
        }

        [TestMethod]
        public async Task Test_Exist_GetAccountByIdAsync()
        {
            var accountId =Guid.Parse("c6f1b9e4-5e1f-49fa-ab93-73f0ef157232");
            var account = await accountRepository.GetAccountByIdAsync(accountId, cancellationToken);
            Assert.IsTrue(account!=null);
            Assert.IsTrue(account.Id == Guid.Parse("c6f1b9e4-5e1f-49fa-ab93-73f0ef157232"));
        }

        [TestMethod]
        public async Task Test_NotExist_GetAccountByIdAsync()
        {
            var accountId = Guid.Parse("00000000-0000-0000-0000-000000001000");
            var account = await accountRepository.GetAccountByIdAsync(accountId, cancellationToken);
            Assert.IsNull(account);
        }

        [TestMethod]
        public async Task Test_Success_InsertAccountAsync()
        {
            var newAccount = new Account
            {
                Id = Guid.NewGuid(),
                Username = $"test_{DateTime.Now.Ticks}",
                Fullname = $"Test Unit {DateTime.Now.Ticks}",
                Password = "123456"
            };
            var result = await accountRepository.InsertAccountAsync(newAccount, cancellationToken);
            Assert.IsTrue(result !=null);
            var account = await accountRepository.GetAccountByUsernameAsync(newAccount.Username, cancellationToken);
            Assert.IsNotNull(account);
            Assert.IsTrue(account.Username == newAccount.Username);
        }

    }
}
