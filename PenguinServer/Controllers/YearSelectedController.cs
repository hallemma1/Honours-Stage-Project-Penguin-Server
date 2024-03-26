using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenguinServer.DB_Class;
using PenguinServer.Services;

namespace PenguinServer.Controllers
{
    [Route("api/v1/yearselected/year={year}")]
    [ApiController]
    public class YearSelectedController : ControllerBase
    {

        [HttpPost]
        public IActionResult YearSelectedState(int year)
        {
            YearSelectedControllerService yearSelectedControllerService = new YearSelectedControllerService(year);

            List<PenguinData> yearSelectedData = yearSelectedControllerService.GetYearSelectedData();

            PenguinDataObject penguinDataObject = new PenguinDataObject();

            penguinDataObject.DataObject = yearSelectedData.ToArray();


            return Ok(penguinDataObject);
            
        }
    }
}
