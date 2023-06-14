using Microsoft.AspNetCore.Mvc;
using AnonTextShareStorage;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnonTextShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextDocumentController : ControllerBase
    {

        // GET api/<TextDocumentController>/{id}
        [HttpGet("{id}")]
        public ActionResult<TextDocument> Get(string id)
        {
            if (Config.db.CheckDocument(id))
            {
                return new TextDocument(id);
            }
            else
            {
                return NotFound("Document does not exist");
            }
            
        }

        // POST api/<TextDocumentController>?pass=password
        [HttpPost]
        public ActionResult<string> Post(string? pass, [FromBody] TextDocument value)
        {
            if (value.Title.Length > Config.conf.config.MaxTitleChars)
            {
                return BadRequest("Title Too Long");
            }
            if (value.Contents.Length > Config.conf.config.MaxTextChars)
            {
                return BadRequest("Contents Too Long");
            }
            if (pass == null)
            {
                return Config.db.CreateDocument(value.Title, value.Contents, KategoriDokumen.kategoriFromString(value.Kategori));
            } else
            {
                if (pass.Length <= 4)
                {
                    return BadRequest("Password must be at least 5 characters long");
                }
                return Config.db.CreateDocument(value.Title, value.Contents, KategoriDokumen.kategoriFromString(value.Kategori), pass);
            }
        }

        // POST api/<TextDocumentController>/comment
        [HttpPost("{id}/comment")]
        public IActionResult PostComment(string id, [FromBody] string comment)
        {

            if (Config.db.AddDocumentComment(id, comment))
            {
                return Ok();
            } else
            {
                return NotFound("Document does not exist");
            }
            
        }

        // PATCH api/<TextDocumentController>/{id}/title?pass=password
        [HttpPatch("{id}/title")]
        public IActionResult PatchTitle(string id, string pass, [FromBody] string value)
        {
            if (value.Length > Config.conf.config.MaxTitleChars)
            {
                return BadRequest("Title Too Long");
            }
            if (!Config.db.CheckDocument(id))
            {
                return NotFound("Document does not exist");
            }
            if (pass.Length <= 4)
            {
                return BadRequest("Password must be at least 5 characters long");
            }
            if (Config.db.UpdateDocumentTitle(id, pass, value))
            {
                return Ok();
            } else
            {
                return Unauthorized("Incorrect Password");
            }
        }

        // PATCH api/<TextDocumentController>/{id}/contents?pass=password
        [HttpPatch("{id}/contents")]
        public IActionResult PatchContents(string id, string pass, [FromBody] string value)
        {
            if (value.Length > Config.conf.config.MaxTextChars)
            {
                return BadRequest("Contents Too Long");
            }
            if (!Config.db.CheckDocument(id))
            {
                return NotFound("Document does not exist");
            }
            if (pass.Length <= 4)
            {
                return BadRequest("Password must be at least 5 characters long");
            }
            if (Config.db.UpdateDocumentText(id, pass, value))
            {
                return Ok();
            }
            else
            {
                return Unauthorized("Incorrect Password");
            }
        }

        // PATCH api/<TextDocumentController>/{id}/contents?pass=password
        [HttpPatch("{id}/kategori")]
        public IActionResult PatchKategori(string id, string pass, [FromBody] string value)
        {
            if (!Config.db.CheckDocument(id))
            {
                return NotFound("Document does not exist");
            }
            if (pass.Length <= 4)
            {
                return BadRequest("Password must be at least 5 characters long");
            }
            if (Config.db.UpdateDocumentCategory(id, KategoriDokumen.kategoriFromString(value), pass))
            {
                return Ok();
            }
            else
            {
                return Unauthorized("Incorrect Password");
            }
        }

        // DELETE api/<TextDocumentController>/{id}?pass=password
        [HttpDelete("{id}")]
        public IActionResult Delete(string id, string pass)
        {
            if (!Config.db.CheckDocument(id))
            {
                return NotFound("Document does not exist");
            }
            if (pass.Length <= 4)
            {
                return BadRequest("Password must be at least 5 characters long");
            }
            if (Config.db.DeleteDocument(id, pass))
            {
                return Ok();
            }
            else
            {
                return Unauthorized("Incorrect Password");
            }
            
        }
    }
}
