using Microsoft.AspNetCore.Mvc;
using ReservationSystemASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Controllers
{
    [Route("api/seanses")]
    [ApiController]
    public class ApiSeanseController : ControllerBase
    {
        private ICRUDSeanseRepository seanses;

        public ApiSeanseController(ICRUDSeanseRepository seanses)
        {
            this.seanses = seanses;
        }

        [HttpGet]
        public IList<SeanseModel> GetSeanses()
        {
            return seanses.FindAll();
        }

        [HttpPost]
        public ActionResult<SeanseModel> AddSeanse([FromBody] SeanseModel seanseModel)
        {
            SeanseModel seanseModel1 = seanses.Add(seanseModel);
            return new CreatedResult($"/api/seanses/{seanseModel1.Id}", seanseModel1);
        }

        [HttpGet("{id}")]
        public ActionResult<SeanseModel> GetSeanse(int id)
        {
            SeanseModel seanseModel = seanses.FindById(id);
            if (seanseModel != null)
            {
                return new OkObjectResult(seanseModel);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<SeanseModel> EditSeanse(int id, [FromBody] SeanseModel seanseModel)
        {
            if(id > 0)
            {
                seanseModel.Id = id;
                return new OkObjectResult(seanseModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeanse(int id)
        {
            if(id > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
