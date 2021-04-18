using DMS.Core.Models;
using DMS.Core.Services;
using DMS.Workflows.AccountWorkflows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test_DMS_Workflow
{
    [TestClass]
    public class TestAccountCreateNewWorkflow
    {
        private readonly IAccountService accountService;
        private readonly CancellationToken cancellationToken;
        public TestAccountCreateNewWorkflow()
        {
            Startup.Start();
            var resolver = DependencyResolution.Instance;
            cancellationToken = CancellationToken.None;
            
        }

        //[TestMethod]
        //public async Task Test_Fail_Empty_CreateNewAccountAsync()
        //{
        //    var account = new Account();
        //    var workflow = new AccountCreateNewWorkflow(account);
        //    var (lastResult, details) = await workflow.ExecuteAsync(cancellationToken);
        //    Assert.IsTrue(lastResult.Failed);
        //}

        //[TestMethod]
        //public async Task Test_Fail_MissingUsername_CreateNewAccountAsync()
        //{
        //    var account = new Account
        //    {
        //        Fullname = $"Test Unit {DateTime.Now.Ticks}",
        //        Password = "123456",
        //        Id = Guid.NewGuid()
        //    };
        //    var workflow = new AccountCreateNewWorkflow(account);
        //    var (lastResult, details) = await workflow.ExecuteAsync(cancellationToken);
        //    Assert.IsTrue(lastResult.Failed);
        //}

        //[TestMethod]
        //public async Task Test_Fail_MissingOrg_CreateNewAccountAsync()
        //{
        //    var account = new Account
        //    {
        //        Id = Guid.NewGuid(),
        //        Username = $"Test_{DateTime.Now.Ticks}",
        //        Fullname = $"Test Unit {DateTime.Now.Ticks}",
        //        Password = "123456"
        //    };
        //    var workflow = new AccountCreateNewWorkflow(account);
        //    var (lastResult, details) = await workflow.ExecuteAsync(cancellationToken);
        //    Assert.IsTrue(lastResult.Failed);
        //}
    }
}
