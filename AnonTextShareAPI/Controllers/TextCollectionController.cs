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
        public TextCollection Get(string id)
        {
            return new(id);
        }

        // POST api/<TextCollectionController>?title=judul&pass=password
        [HttpPost]
        public string Post(string title, string? pass, [FromBody] List<string> idList)
        {
            if (pass == null)
            {
                return Config.db.CreateCollection(title, idList);
            }
            else
            {
                return Config.db.CreateCollection(title, idList, pass);
            }
        }

        // PATCH api/<TextCollectionController>/{id}/title?pass=password
        [HttpPatch("{id}/title")]
        public void PatchTitle(string id, string pass, [FromBody] string value)
        {
            Config.db.UpdateCollectionTitle(id, value, pass);
        }

        // PATCH api/<TextCollectionController>/{id}/content?pass=password
        [HttpPatch("{id}/contents")]
        public void AddContent(string id, string pass, [FromBody] string value)
        {
            Config.db.AddCollectionDocument(id, value, pass);
        }

        // PATCH api/<TextCollectionController>/{id}/content/{idDoc}?pass=password
        [HttpDelete("{id}/contents/{idDoc}")]
        public void RemoveContent(string id, string pass, string idDoc)
        {
            Config.db.RemoveCollectionDocument(id, idDoc, pass);
        }

        // DELETE api/<TextCollectionController>/{id}?pass=password
        [HttpDelete("{id}")]
        public void Delete(string id, string pass)
        {
            Config.db.DeleteCollection(id, pass);
        }
    }
}
