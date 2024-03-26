using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenguinServer.DB_Class;
using PenguinServer.Services;

namespace PenguinServer.Controllers
{
    [Route("api/v1/getinitalstate")]
    [ApiController]
    public class InitialMapStateController : ControllerBase 
    {
        [HttpPost]
        public IActionResult InitialMapState()
        {
            InitialMapStateControllerService initialMapStateControllerService = new InitialMapStateControllerService();

            List<PenguinData> initialMapData = initialMapStateControllerService.GetInitialMapData();

            PenguinDataObject penguinDataObject = new PenguinDataObject();

            penguinDataObject.DataObject = initialMapData.ToArray();


            return Ok(penguinDataObject);
;       }
    }
}
