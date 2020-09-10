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
    public class SecurityRoleController : ControllerBase
    {
        private SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            EFGenericRepository<SecurityRolePoco> repo = new EFGenericRepository<SecurityRolePoco>();
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("SecurityRole/{id}")]
        [ProducesResponseType(typeof(SecurityRolePoco), 200)]
        public ActionResult GetSecurityRole(Guid id)
        {
            SecurityRolePoco poco = _logic.Get(id);

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
        [Route("SecurityRole")]
        public ActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("SecurityRole")]
        public ActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("SecurityRole")]
        public ActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("SecurityRole")]
        [ProducesResponseType(typeof(List<SecurityRolePoco>), 200)]
        public ActionResult GetAllSecurityRole()
        {
            return Ok(_logic.GetAll());
        }
    }
}
