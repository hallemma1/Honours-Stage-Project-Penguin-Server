using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenguinServer.DB_Class;
using PenguinServer.Services;

namespace PenguinServer.Controllers
{
    [Route("api/v1/pollutionchange")]
    [ApiController]
    public class PollutionChangeController : ControllerBase
    {
        [HttpPost]
        public IActionResult PollutionAlteredState()
        {
            PollutionChangeControllerService service = new PollutionChangeControllerService();

            List<PenguinData> pollutionAlteredData = service.GetPollutionAlteredData();

            PenguinDataObject penguinDataObject = new PenguinDataObject();

            penguinDataObject.DataObject = pollutionAlteredData.ToArray();

            return Ok(penguinDataObject);

        }
    }
}
