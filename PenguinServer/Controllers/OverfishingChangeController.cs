using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenguinServer.DB_Class;
using PenguinServer.Services;

namespace PenguinServer.Controllers
{
    [Route("api/v1/overfishingchange")]
    [ApiController]
    public class OverfishingChangeController : ControllerBase
    {
        [HttpPost]
        public IActionResult OverfishingAlteredState()
        {
            OverfishingChangeControllerService service = new OverfishingChangeControllerService();

            List<PenguinData>overfishingAlteredData = service.GetOverfishingAlteredData();

            PenguinDataObject penguinDataObject = new PenguinDataObject();

            penguinDataObject.DataObject = overfishingAlteredData.ToArray();

            return Ok(penguinDataObject);

        }
    }
}
