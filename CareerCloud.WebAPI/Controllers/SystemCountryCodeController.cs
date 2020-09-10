using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemCountryCodeController : ControllerBase
    {
        private SystemCountryCodeLogic _logic;

        public SystemCountryCodeController()
        {
            EFGenericRepository<SystemCountryCodePoco> repo = new EFGenericRepository<SystemCountryCodePoco>();
            _logic = new SystemCountryCodeLogic(repo);
        }
        [HttpGet]
        [Route("SystemCountryCode/{id}")]
        [ProducesResponseType(typeof(SystemCountryCodePoco), 200)]
        public ActionResult GetSystemCountryCode(string id)
        {
            SystemCountryCodePoco poco = _logic.Get(id);

            if (poco != null)
            {
                return Ok(poco);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("SystemCountryCode")]
        public ActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("SystemCountryCode")]
        public ActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("SystemCountryCode")]
        public ActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("SystemCountryCode")]
        [ProducesResponseType(typeof(List<SystemCountryCodePoco>), 200)]
        public ActionResult GetAllSystemCountryCode()
        {
            return Ok(_logic.GetAll());
        }

    }
}
