using Interfaces.API;
using Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Spreadsheet;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpreadsheetController : ControllerBase
    {
        private readonly IDataCreator _dataCreator;
        public SpreadsheetController(IDataCreator dataCreator) 
        {
            _dataCreator = dataCreator;
        }

        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromForm] SaveSettings saveSettings)
        {
            var JSONData = saveSettings.JSONData;

            var data = _dataCreator.Save(JSONData);
            
            var response = ApiResponse<List<string>>.CreateSuccessResponse(data);

            return Workbook.Save(saveSettings);
        }
    }
}
