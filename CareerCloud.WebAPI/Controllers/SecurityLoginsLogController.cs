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
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginsLogController : ControllerBase
    {
        private SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogController()
        {
            EFGenericRepository<SecurityLoginsLogPoco> repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _logic = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("SecurityLoginsLog/{id}")]
        [ProducesResponseType(typeof(SecurityLoginsLogPoco), 200)]
        public ActionResult GetSecurityLoginLog(Guid id)
        {
            SecurityLoginsLogPoco poco = _logic.Get(id);

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
        [Route("SecurityLoginsLog")]
        public ActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("SecurityLoginsLog")]
        public ActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("SecurityLoginsLog")]
        public ActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("SecurityLoginsLog")]
        [ProducesResponseType(typeof(List<SecurityLoginsLogPoco>), 200)]
        public ActionResult GetAllSecurityLoginsLog()
        {
            return Ok(_logic.GetAll());
        }

    }
}
