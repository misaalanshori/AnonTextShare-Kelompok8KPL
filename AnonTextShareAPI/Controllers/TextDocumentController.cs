using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnonTextShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextDocumentController : ControllerBase
    {

        // GET api/<TextDocumentController>/{id}
        [HttpGet("{id}")]
        public TextDocument Get(string id)
        {
            return new(id);
        }

        // POST api/<TextDocumentController>?pass=password
        [HttpPost]
        public string Post(string? pass, [FromBody] TextDocument value)
        {
            if (pass == null)
            {
                return Config.db.CreateDocument(value.title, value.contents);
            } else
            {
                return Config.db.CreateDocument(value.title, value.contents, pass);
            }
        }

        // POST api/<TextDocumentController>/comment
        [HttpPost("{id}/comment")]
        public void PostComment(string id, [FromBody] string comment)
        {
            Config.db.AddDocumentComment(id, comment);
        }

        // PATCH api/<TextDocumentController>/{id}/title?pass=password
        [HttpPatch("{id}/title")]
        public void PatchTitle(string id, string pass, [FromBody] string value)
        {
            Config.db.UpdateDocumentTitle(id, pass, value);
        }

        // PATCH api/<TextDocumentController>/{id}/contents?pass=password
        [HttpPatch("{id}/contents")]
        public void PatchContents(string id, string pass, [FromBody] string value)
        {
            Config.db.UpdateDocumentText(id, pass, value);
        }

        // DELETE api/<TextDocumentController>/{id}?pass=password
        [HttpDelete("{id}")]
        public void Delete(string id, string pass)
        {
            Config.db.DeleteDocument(id, pass);
        }
    }
}
