using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnonTextShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextCollectionController : ControllerBase
    {

        // GET api/<TextCollectionController>/{id}
        [HttpGet("{id}")]
        public ActionResult<TextCollection> Get(string id)
        {
            if (Config.db.CheckCollection(id))
            {
                return new TextCollection(id);
            } else
            {
                return NotFound("Collection does not exist");
            }
            
        }

        // POST api/<TextCollectionController>?title=judul&pass=password
        [HttpPost]
        public ActionResult<string> Post(string title, string? pass, [FromBody] List<string> idList)
        {
            foreach (string id in idList)
            {
                if (!Config.db.CheckDocument(id))
                {
                    return BadRequest($"Document {id} does not exist");
                }
            }

            if (pass == null)
            {
                return Config.db.CreateCollection(title, idList);
            }
            else
            {
                if (pass.Length <= 4)
                {
                    return BadRequest("Password must be at least 5 characters long");
                }

                return Config.db.CreateCollection(title, idList, pass);
            }
        }

        // PATCH api/<TextCollectionController>/{id}/title?pass=password
        [HttpPatch("{id}/title")]
        public IActionResult PatchTitle(string id, string pass, [FromBody] string value)
        {
            if (!Config.db.CheckCollection(id))
            {
                return NotFound("Collection does not exist");
            }

            if (pass.Length <= 4)
            {
                return BadRequest("Password must be at least 5 characters long");
            }

            if (Config.db.UpdateCollectionTitle(id, value, pass))
            {
                return Ok();
            } else
            {
                return Unauthorized("Incorrect Password");
            }
        }

        // PATCH api/<TextCollectionController>/{id}/content?pass=password
        [HttpPatch("{id}/contents")]
        public IActionResult AddContent(string id, string pass, [FromBody] string idDoc)
        {
            if (!Config.db.CheckCollection(id))
            {
                return NotFound("Collection does not exist");
            }

            if (pass.Length <= 4)
            {
                return BadRequest("Password must be at least 5 characters long");
            }

            if (!Config.db.CheckDocument(idDoc))
            {
                return BadRequest($"Document {idDoc} does not exist");
            }

            if (Config.db.AddCollectionDocument(id, idDoc, pass))
            {
                return Ok();
            }
            else
            {
                return Unauthorized("Incorrect Password");
            }
        }

        // PATCH api/<TextCollectionController>/{id}/content/{idDoc}?pass=password
        [HttpDelete("{id}/contents/{idDoc}")]
        public IActionResult RemoveContent(string id, string pass, string idDoc)
        {
            if (!Config.db.CheckCollection(id))
            {
                return NotFound("Collection does not exist");
            }

            if (pass.Length <= 4)
            {
                return BadRequest("Password must be at least 5 characters long");
            }

            if (!Config.db.GetCollectionContents(id).Contains(idDoc))
            {
                return BadRequest("Document is not in the collection");
            }

            if (Config.db.RemoveCollectionDocument(id, idDoc, pass))
            {
                return Ok();
            }
            else
            {
                return Unauthorized("Incorrect Password");
            }
        }

        // POST api/<TextCollectionController>/{id}/report
        [HttpGet("{id}/report")]
        public ActionResult<TextCollection> PostReport(string id)
        {
            if (Config.db.CheckCollection(id))
            {
                Config.db.ReportDocument(id);
                return Ok();
            }
            else
            {
                return NotFound("Collection does not exist");
            }
        }

        // POST api/<TextCollectionController>/{id}/report/unlock
        [HttpGet("{id}/report/unlock")]
        public ActionResult<TextCollection> PostReportUnlock(string id, [FromBody] string pass)
        {
            if (Config.db.UnlockDocument(id, pass))
            {
                return Ok();
            }
            else
            {
                return NotFound("Collection does not exist");
            }
        }

        // POST api/<TextCollectionController>/{id}/lock
        [HttpGet("{id}/lock")]
        public ActionResult<TextCollection> PostLock(string id, [FromBody] string pass)
        {
            if (Config.db.TriggerDocumentLock(id, AnonTextShareStorage.EditingAutomata.Trigger.Editing, pass))
            {
                return Ok();
            }
            else
            {
                return NotFound("Collection does not exist");
            }
        }

        // POST api/<TextCollectionController>/{id}/unlock
        [HttpGet("{id}/unlock")]
        public ActionResult<TextCollection> PostUnlock(string id, [FromBody] string pass)
        {
            if (Config.db.TriggerDocumentLock(id, AnonTextShareStorage.EditingAutomata.Trigger.Editing, pass))
            {
                return Ok();
            }
            else
            {
                return NotFound("Collection does not exist");
            }
        }

        // DELETE api/<TextCollectionController>/{id}?pass=password
        [HttpDelete("{id}")]
        public IActionResult Delete(string id, string pass)
        {
            if (!Config.db.CheckCollection(id))
            {
                return NotFound("Collection does not exist");
            }

            if (pass.Length <= 4)
            {
                return BadRequest("Password must be at least 5 characters long");
            }

            if (Config.db.DeleteCollection(id, pass))
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
