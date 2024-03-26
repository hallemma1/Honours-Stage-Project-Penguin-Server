using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenguinServer.DB_Class;
using PenguinServer.Services;

namespace PenguinServer.Controllers
{
    [Route("api/v1/collectedpenguins")]
    [ApiController]
    public class CollectedPenguinsController : ControllerBase
    {
        private readonly CollectedPenguinsControllerService _service;
        public CollectedPenguinsController(CollectedPenguinsControllerService service) 
        {
            _service = service;
        }


        [HttpGet("collectedpenguindata")]
        public IActionResult GetCollectedPenguinData()
        {
            try
            {
                //  Create instance of CollectedPenguinsDataObject and Populate Array To return
                CollectedPenguinDataObject collectedPenguinsDataObject = _service.GetCollectedPenguinsData();

                // Return Data
                return Ok(collectedPenguinsDataObject.DataObject);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Unknown Error Occured" });
            }         
        }




        [HttpPost("collectedpenguindata")]
        public IActionResult PostPenguinData(string? penguinName, int score)
        {
            try
            {
                //  Create instance of CollectedPenguinsDataObject and Populate Array To return
                
                string response = _service.UpdateCollectedPenguinData(penguinName, score);

                // Return Data
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Unknown Error Occured" });
            }
            // Take in penguin data and update CollectedPenguins.csv
            
        }
    }
}
