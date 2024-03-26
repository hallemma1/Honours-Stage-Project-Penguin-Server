using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenguinServer.DB_Class;
using PenguinServer.Services;

namespace PenguinServer.Controllers
{
    [Route("api/v1/carbonemissionschange")]
    [ApiController]
    public class CarbonEmissionsChangeController : ControllerBase
    {
        [HttpPost]
        public IActionResult CarbonEmissionsAlteredState()
        {
            CarbonEmissionsChangeControllerService service = new CarbonEmissionsChangeControllerService();

            List<PenguinData> carbonEmissionsAlteredData = service.GetCarbonEmissionsAlteredData();

            PenguinDataObject penguinDataObject = new PenguinDataObject();

            penguinDataObject.DataObject = carbonEmissionsAlteredData.ToArray();

            return Ok(penguinDataObject);

        }
    }
}
