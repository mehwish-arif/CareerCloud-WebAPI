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
    public class SecurityLoginController : ControllerBase
    {
        private SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            EFGenericRepository<SecurityLoginPoco> repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(repo);
        }
        [HttpGet]
        [Route("security/{id}")]
        [ProducesResponseType(typeof(SecurityLoginPoco), 200)]
        public ActionResult GetSecurityLogin(Guid id)
        {
            SecurityLoginPoco poco = _logic.Get(id);

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
        [Route("security")]
        public ActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("security")]
        public ActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("security")]
        public ActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("security")]
        [ProducesResponseType(typeof(List<SecurityLoginPoco>), 200)]
        public ActionResult GetAllSecurityLogin()
        {
            return Ok(_logic.GetAll());
        }

    }
}
