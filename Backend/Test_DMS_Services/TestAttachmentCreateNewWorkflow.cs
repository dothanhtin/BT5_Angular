using DMS.Core.Models;
using DMS.Workflows.AttachmentWorkflows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_DMS_Workflow
{
    [TestClass]
    public class TestAttachmentCreateNewWorkflow
    {
        private readonly CancellationToken cancellationToken;
        public TestAttachmentCreateNewWorkflow()
        {
            Startup.Start();
            var resolver = DependencyResolution.Instance;
            cancellationToken = CancellationToken.None;

        }

        //[TestMethod]
        //public async Task Test_Fail_Token_Missing_CreateNewAttachment()
        //{
        //    var attachment = new Attachment();
        //    var token = string.Empty;
        //    var workflow = new AttachmentCreateNewWorkflow(attachment, token);
        //    var (lastestResult, detailsResult) = await workflow.ExecuteAsync(cancellationToken);
        //    Assert.IsTrue(lastestResult.Failed);

        //}

        //[TestMethod]
        //public async Task Test_Fail_Token_Invalid_CreateNewAttachment()
        //{
        //    var attachment = new Attachment();
        //    var token = "3423428375234572843";
        //    var workflow = new AttachmentCreateNewWorkflow(attachment, token);
        //    var (lastestResult, detailsResult) = await workflow.ExecuteAsync(cancellationToken);
        //    Assert.IsTrue(lastestResult.Failed);

        //}

        //[TestMethod]
        //public async Task Test_Success_CreateNewAttachment()
        //{
        //    var attachment = new Attachment
        //    {
        //        Address="ftp://10.10.10.10/test",
        //        Attributes = new List<DMS.Core.Models.Attribute>(),
        //        Document= new Document
        //        {
        //            Id= Guid.NewGuid()
        //        },
        //    };
        //    var token = "7939388e-1d7e-4b68-9fc3-004816bae3b9";
        //    var workflow = new AttachmentCreateNewWorkflow(attachment, token);
        //    try
        //    {
        //        var (lastestResult, detailsResult) = await workflow.ExecuteAsync(cancellationToken);
        //        Assert.IsTrue(lastestResult.Succeed);
        //    }
        //    catch(Exception ex)
        //    {
        //        Assert.Fail(ex.Message);
        //    }
            

        //}
    }
}
