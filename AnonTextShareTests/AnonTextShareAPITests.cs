using AnonTextShareAPI;
using AnonTextShareAPI.Controllers;

namespace AnonTextShareTests
{
    

    [TestClass]
    public class AnonTextShareAPITests
    {
        private TextDocumentController? _controller;
        private string _doc;
        [TestInitialize]
        public void InitTest()
        {
            _controller = new TextDocumentController();
            _doc = _controller.Post("password", new TextDocument("A Title", "The Content")).Value;
        }

        [TestMethod]
        public void TestPatchTitle_InvalidID()
        {
            var result = _controller.PatchTitle("123456", "password", "newTitle");
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.NotFoundObjectResult));
        }
        [TestMethod]
        public void TestPatchTitle_InvalidPassword()
        {
            var result = _controller.PatchTitle(_doc, "pass", "newTitle");
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.BadRequestObjectResult));
        }
        [TestMethod]
        public void TestPatchTitle_WrongPassword()
        {
            var result = _controller.PatchTitle(_doc, "password123", "newTitle");
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.UnauthorizedObjectResult));
        }
        [TestMethod]
        public void TestPatchTitle_Success()
        {
            var result = _controller.PatchTitle(_doc, "password", "newTitle");
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkResult));
        }


    }
}